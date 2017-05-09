using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAnalyser
{
	public class StreamExtractor
	{
		private string fileFormat = null;

		private string fileName = null;

		private int headerStart = 0;

		private int headerLength = 0;

		private byte[] headerByteArray = null;

		private string headerContents = null;

		private byte[] bodyByteArray = null;

		private string bodyContents = null;

		private byte[] recordedGameByteArray = null;

		public StreamExtractor()
		{
		}

		public StreamExtractor(string fileName)
		{
			recordedGameByteArray = File.ReadAllBytes(fileName);

			fileFormat = Path.GetExtension(fileName);

			fileName = Path.GetFileName(fileName);
		}

		public StreamExtractor(byte[] recordedGameByteArray)
		{
			this.recordedGameByteArray = recordedGameByteArray;

			setHeaderLength();

			readHeaderArray();
		}

		private void setHeaderLength()
		{
			try
			{
				byte[] raw = recordedGameByteArray.Take(4).ToArray();

				if (!BitConverter.IsLittleEndian)
					Array.Reverse(raw);

				int rawUnpack = (int)BitConverter.ToUInt32(raw, 0);
				raw = new byte[3]{
					recordedGameByteArray[4],
					recordedGameByteArray[5],
					recordedGameByteArray[6],
				};

				headerStart = raw != new byte[] { 0xEC, 0x7D, 0x09 } ? 8 : 4;
				headerLength = rawUnpack - headerStart;
			}
			catch
			{
				throw new Exception("Unable to read the header length");
			}
		}

		private void readHeaderArray()
		{
			headerByteArray = new byte[headerLength];

			int counter = 0;
			while (counter < headerLength)
			{
				headerByteArray[counter] = recordedGameByteArray[headerStart + counter];
				counter++;
			}

			using (MemoryStream inputStream = new MemoryStream(headerByteArray))
			{
				using (DeflateStream gzip =
				  new DeflateStream(inputStream, CompressionMode.Decompress))
				{
					byte[] tempArray = new byte[256];
					List<byte[]> tempList = new List<byte[]>();
					int length = 0;
					while ((counter = gzip.Read(tempArray, 0, 256)) > 0)
					{
						if (counter == 256)
						{
							tempList.Add(tempArray);
							tempArray = new byte[256];
						}
						else
						{
							byte[] temp = new byte[counter];
							Array.Copy(tempArray, 0, temp, 0, counter);
							tempList.Add(temp);
						}
						length += counter;
					}

					headerByteArray = new byte[length];

					counter = 0;
					foreach (byte[] temp in tempList)
					{
						Array.Copy(temp, 0, headerByteArray, counter, temp.Length);
						counter += temp.Length;
					}
				}
			}
		}

		private void readBodyArray()
		{
			bodyByteArray = new byte[recordedGameByteArray.Length - headerStart - headerLength];

			int counter = 0;
			while (counter < bodyByteArray.Length)
			{
				bodyByteArray[counter] = recordedGameByteArray[headerStart + headerLength + counter];
				counter++;
			}
		}

		public string getHeaderContent()
		{
			if (headerContents != null)
				return headerContents;

			if (headerLength == 0)
			{
				setHeaderLength();
			}

			readHeaderArray();

			//headerByteArray = Encoding.ASCII.GetBytes(headerContents);
			headerContents = Encoding.ASCII.GetString(headerByteArray);

			return headerContents;
		}

		public string getBodyContent()
		{
			if (bodyContents != null)
			{
				return bodyContents;
			}

			if (headerLength == 0)
			{
				setHeaderLength();
			}

			readBodyArray();

			bodyContents = Encoding.ASCII.GetString(bodyByteArray);

			return bodyContents;
		}

		public byte[] getHeaderByteArray()
		{
			if (headerByteArray != null)
				return headerByteArray;

			if (headerLength == 0)
			{
				setHeaderLength();
			}

			readHeaderArray();

			return headerByteArray;
		}

		public static void CopyStream(System.IO.Stream input, System.IO.Stream output)
		{
			byte[] buffer = new byte[8192];
			int len;
			while ((len = input.Read(buffer, 0, 8192)) > 0)
			{
				output.Write(buffer, 0, len);
			}
			output.Flush();
		}

		public byte[] getBodyByteArray()
		{
			if (bodyContents != null)
			{
				return bodyByteArray;
			}

			if (headerLength == 0)
			{
				setHeaderLength();
			}

			readBodyArray();

			return bodyByteArray;
		}

		public List<byte> getHeaderByteList()
		{
			if (headerByteArray != null)
				return headerByteArray.ToList();

			if (headerLength == 0)
			{
				setHeaderLength();
			}

			readHeaderArray();

			return headerByteArray.ToList();
		}

		public List<byte> getBodyByteList()
		{
			if (bodyByteArray != null)
				return bodyByteArray.ToList();

			if (headerLength == 0)
			{
				setHeaderLength();
			}

			readBodyArray();

			return bodyByteArray.ToList();
		}

		public byte[] getByteSubArray(byte[] source, int startPos, int length)
		{
			int counter = 0;
			List<byte> result = new List<byte>();

			while (counter < length)
			{
				result.Add(source[startPos + counter]);
				counter++;
			}

			return result.ToArray();
		}

		public string getFileFormat()
		{
			return fileFormat;
		}

		public string getFileName()
		{
			return fileName;
		}

		static int searchFirst(byte[] haystack, byte[] needle, int startPosition = 0, int endPosition = 0)
		{
			int end = endPosition == 0 ? haystack.Length : endPosition;
			for (int i = startPosition; i <= end - needle.Length; i++)
			{
				if (match(haystack, needle, i))
				{
					return i;
				}
			}
			return -1;
		}

		static bool match(byte[] haystack, byte[] needle, int start)
		{
			if (needle.Length + start > haystack.Length)
			{
				return false;
			}
			else
			{
				for (int i = 0; i < needle.Length; i++)
				{
					if (needle[i] != haystack[i + start])
					{
						return false;
					}
				}
				return true;
			}
		}
	}
}

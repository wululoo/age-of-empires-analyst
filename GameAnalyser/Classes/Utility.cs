using System;
using System.Collections.Generic;

namespace GameAnalyser
{
	public static class Utility
	{
		public static int LastIndexOf(List<byte> raw, byte[] target)
		{
			for (int i = raw.Count - target.Length; i >= 0; i--)
			{
				if (Equals(raw.GetRange(i, target.Length).ToArray(), target))
					return i;
			}

			return -1;
		}

		public static int IndexOf(List<byte> raw, byte[] target)
		{
			for (int i = 0; i <= raw.Count - target.Length; i++)
			{
				if (Equals(raw.GetRange(i, target.Length).ToArray(), target))
					return i;
			}

			return -1;
		}

		public static int IndexOf(List<byte> raw, byte[] target, int startPos)
		{
			for (int i = startPos; i <= raw.Count - target.Length; i++)
			{
				if (Equals(raw.GetRange(i, target.Length).ToArray(), target))
					return i;
			}

			return -1;
		}

		public static bool Equals(byte[] a, byte[] b)
		{
			if (a.Length > 0 && b.Length > 0 && a.Length != b.Length)
				return false;

			for (int i = 0; i < a.Length; i++)
				if (a[i] != b[i])
					return false;

			return true;
		}
	}


}

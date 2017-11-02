using System;
namespace AgeOfEmpiresLibrary
{
	/// <summary>
	/// Utility.
	/// Implement functions to read rec games
	/// </summary>
	public static class Utility
	{
		// TODO: 
		//    implement read file function
		//    implement version distinguish mechanism

    //    public static int IndexOf(byte[] byteArray, byte[] targetArray, int startIndex = 0)
    //    {
    //        int j = 0;

    //        while (startIndex < byteArray.Length)
    //        {
    //            j = 0;

    //            while (j < targetArray.Length)
    //            {
				//	if (byteArray[startIndex + j] == targetArray[j])
				//		j++;
				//	else
    //                {
    //                    j = 0;
    //                    break;
    //                }
				//}

        //        if (j == targetArray.Length)
        //            return startIndex;

        //        startIndex++;
        //    }

        //    return -1;
        //}

        public static int IndexOf(byte[] byteArray, byte[] targetArray, int startIndex = 0, int endIndex = -1)
        {
            int j = 0;

            endIndex = endIndex > 0 ? endIndex : byteArray.Length;

            while (startIndex < endIndex)
            {
                j = 0;

                while (j < targetArray.Length)
                {
                    if (byteArray[startIndex + j] == targetArray[j])
                        j++;
                    else
                    {
                        j = 0;
                        break;
                    }
                }

                if (j == targetArray.Length)
                    return startIndex;

                startIndex++;
            }

            return -1;
        }

		public static int LastIndexOf(byte[] byteArray, byte[] targetArray)
		{
            int j = 0;

			for (int i = byteArray.Length - targetArray.Length; i >= 0; i--)
			{
                j = 0;

                while (j < targetArray.Length)
                {
                    if (byteArray[i] == targetArray[targetArray.Length - j - 1])
                        j++;
                    else
                    {
                        j = 0;
                        break;
                    }
                }

				if (j == targetArray.Length)
					return i;
			}

			return -1;
		}

		public static T[] SubArray<T>(this T[] data, int index, int length)
		{
			T[] result = new T[length];
			Array.Copy(data, index, result, 0, length);
			return result;
		}
	}
}

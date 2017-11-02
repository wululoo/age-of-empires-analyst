using System;
using System.Linq;

namespace AgeOfEmpiresLibrary
{
    public static class Age
    {
        public const int DARK_AGE = 1;
        public const int FEUDAL_AGE = 2;
        public const int CASTLE_AGE = 3;
        public const int IMPERIAL_AGE = 4;

        public static string getAgeName(int age)
        {
            switch (age)
            {
                case 1:
                    return "Dark Age";
                
                case 2:
                    return "Feudal Age";

                case 3:
                    return "Castle Age";

                case 4:
                    return "Imperial Age";

                default:
                    return "";
            }
        }

        public static bool isValidAge(int age)
        {
            return new[] { DARK_AGE, FEUDAL_AGE, CASTLE_AGE, IMPERIAL_AGE }.Contains(age);
        }
    }
}

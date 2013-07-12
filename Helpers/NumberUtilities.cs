using System;

namespace MAXX.Utils.Helpers
{
    public class NumberUtilities
    {
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}

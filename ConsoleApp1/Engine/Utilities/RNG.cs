using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Utilities
{
    public static class RNG
    {
        public static readonly RNGCryptoServiceProvider Generator = new RNGCryptoServiceProvider();

        public static int NumberBetween(int min, int max)
        {
            byte[] randomNumber = new byte[1];
            Generator.GetBytes(randomNumber);

            double asciiValueOfRandomChar = Convert.ToDouble(randomNumber[0]);

            double multiplier = Math.Max(0, asciiValueOfRandomChar / 255d);

            int range = max - min + 1;
            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(min + randomValueInRange);
        }
    }
}

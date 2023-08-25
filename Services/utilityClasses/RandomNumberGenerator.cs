using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Services.utilityClasses
{
    public class RandomNumberGenerator
    {
        private Random random = new Random();

        public int[] GenerateRandomNumbers(int count)
        {
            int[] randomNumbers = new int[count];

            for (int i = 0; i < count; i++)
            {
                randomNumbers[i] = random.Next();
            }

            return randomNumbers;
        }
    }
}

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

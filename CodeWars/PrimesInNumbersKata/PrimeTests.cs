using NUnit.Framework;

namespace PrimesInNumbersKata
{
	public class PrimeTests
	{
		[Test]
		public void CheckPrimes()
		{
			CompareStrings(GetPrimeNumbers(1), "");
			CompareStrings(GetPrimeNumbers(2), "(2)");
			CompareStrings(GetPrimeNumbers(4), "(2**2)");
			CompareStrings(GetPrimeNumbers(86240), "(2**5)(5)(7**2)(11)");
			CompareStrings(GetPrimeNumbers(5649240), "(2**3)(3)(5)(179)(263)");
			CompareStrings(GetPrimeNumbers(7775460), "(2**2)(3**3)(5)(7)(11**2)(17)");
		}

		public void CompareStrings(string result, string expected) => Assert.That(result, Is.EqualTo(expected));
		
		public string GetPrimeNumbers(int number)
		{
			var output = "";
			for (var factor = 2; factor < int.MaxValue; factor++)
			{
				var counter = 0;
				while (number % factor == 0 && number > 1)
				{
					number /= factor;
					counter++;
				}

				output += counter > 1 ? "(" + factor + "**" + counter + ")"
					: counter == 1 ? "(" + factor + ")" : "";

				if (number <= 1)
					return output;
			}
			return output;
		}
	}
}
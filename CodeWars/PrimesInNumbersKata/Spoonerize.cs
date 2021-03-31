using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PrimesInNumbersKata
{
	public class Spoonerize
	{
		[Test]
		public void CheckPrimes()
		{
			Assert.That(SpooneIt("Hallo Du"), Is.EqualTo("Dallo Hu"));
		}

		private string SpooneIt(string str)
		{
			var chars = str.ToCharArray();
			var secondWordIndex = str.IndexOf(" ", StringComparison.Ordinal) + 1;
			var secondWordFirstLetter = chars[secondWordIndex];
			chars[secondWordIndex] = chars[0];
			chars[0] = secondWordFirstLetter;
			return new string(chars);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DecodetheMorsecode
{
	public class Tests
	{
			[Test]
		public void MorseCodeDecoderBasicTest_1()
		{
			try
			{
				string input = ".... . -.--   .--- ..- -.. .";
				string expected = "HEY JUDE";

				string actual = Decode(input);

				Assert.AreEqual(expected, actual);
			}
			catch (Exception ex)
			{
				Assert.Fail("There seems to be an error somewhere in your code. Exception message reads as follows: " +
				            ex.Message);
			}
		}
		public static string Decode(string input) => Decoder.Decode(input);

	}
}
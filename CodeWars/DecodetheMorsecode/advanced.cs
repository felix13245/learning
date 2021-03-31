using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DecodetheMorsecode
{
	public class advanced
	{
		[Test]
		public void TestExampleFromDescription()
		{
			Assert.AreEqual("HEY JUDE", DecodeMorse(DecodeBits("1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011")));
		}

		[Test]
		public void TestExampleFromDehhscription()
		{
			Assert.AreEqual("E",
				DecodeMorse(DecodeBits(
					"0111")));
		}
		[Test]
		public void TestExampleFromDehhddscription()
		{
			Assert.AreEqual("M",
				DecodeMorse(DecodeBits(
					"01110111")));
		}
		[Test]
		public void TestExampleFromDehdhddscription()
		{
			Assert.AreEqual("TEE",
				DecodeMorse(DecodeBits(
					"11100010001")));
		}

		[Test]
		public void TestExadmpleFromDehdhddscription()
		{
			Assert.AreEqual("E",
				DecodeMorse(DecodeBits(
					"01100000")));
		}

		[Test]
		public void TestExampleFrofggmDehhscription()
		{
			Assert.AreEqual("EE",
				DecodeMorse(DecodeBits(
					"111000000000111")));
		}

		[Test]
		public void TestgExampleFromDehhscription()
		{
			Assert.AreEqual("I",
				DecodeMorse(DecodeBits(
					"111000111")));
		}

		public static string DecodeBits(string morseBits)
		{
			morseBits = morseBits.Trim('0');
			var timeUnitLength = GetTimeUnitLength(morseBits);
			var words = morseBits.Split(string.Concat(Enumerable.Repeat("0000000", timeUnitLength)), StringSplitOptions.RemoveEmptyEntries);
			var decodedMessage = "";
			foreach (var word in words)
			{
				var letters = word.Trim('0').Split(string.Concat(Enumerable.Repeat("000", timeUnitLength)), StringSplitOptions.RemoveEmptyEntries);
				foreach (var letter in letters)
				{
					var letterParts = letter.Trim('0').Split("0", StringSplitOptions.RemoveEmptyEntries);
					decodedMessage = letterParts.Aggregate(decodedMessage, (current, part) => current + (part.Length / timeUnitLength != 3 ? "." : "-"));
					decodedMessage += " ";
				}
				decodedMessage += " ";
			}
			return decodedMessage;
		}



		private static int GetTimeUnitLength(string message)
		{
			var pauseBits = message.Split("1", StringSplitOptions.RemoveEmptyEntries);
			if (pauseBits.Length == 0)
				return message.Length;
			var letterBits = message.Split("0", StringSplitOptions.RemoveEmptyEntries);
			var smallestPause = pauseBits.Select(pause => pause.Length).Prepend(message.Length).Min();
			var smallestLetter = letterBits.Select(letter => letter.Length).Prepend(message.Length).Min();
			return smallestLetter < smallestPause ? smallestLetter : smallestPause;
		}

		public static string DecodeMorse(string morseCode)
	{
		var words = morseCode.Split("  ", StringSplitOptions.RemoveEmptyEntries);
		var text = "";
		foreach (var word in words)
		{
			var letters = word.Split(" ", StringSplitOptions.RemoveEmptyEntries);
			text = letters.Aggregate(text, (current, letter) => current + MorseCode.Get(letter));
			text += " ";
		}
		text = text.Trim();
		return text;
	}

	public static string Decode(string morseCode)
	{
		var words = morseCode.Split("  ", StringSplitOptions.RemoveEmptyEntries);
		var text = "";
		foreach (var word in words)
		{
			var letters = word.Split(" ", StringSplitOptions.RemoveEmptyEntries);
			text = letters.Aggregate(text, (current, letter) => current + MorseCode.Get(letter));
			text += " ";
		}
		text = text.Trim();
		return text;
	}
}
}
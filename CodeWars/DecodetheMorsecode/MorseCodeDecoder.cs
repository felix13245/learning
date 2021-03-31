using System;
using System.Linq;
using DecodetheMorsecode;

public class MorseCodeDecoder
{
    public static string DecodeBits(string morseBits)
		{
			morseBits = morseBits.Trim('0');
			var timeUnitLength = GetTimeUnitLength(morseBits);
			var words = morseBits.Split(String.Concat(Enumerable.Repeat("0000000", timeUnitLength)), StringSplitOptions.RemoveEmptyEntries);
			var decodedMessage = "";
			foreach (var word in words)
			{
				var letters = word.Trim('0').Split(String.Concat(Enumerable.Repeat("000", timeUnitLength)), StringSplitOptions.RemoveEmptyEntries);
				foreach (var letter in letters)
				{
					var letterParts = letter.Trim('0').Split("0", StringSplitOptions.RemoveEmptyEntries);
					if (letterParts.Length == 1)
						decodedMessage += ".";
					else
						decodedMessage = letterParts.Aggregate(decodedMessage, (current, part) => current + (part.Length / timeUnitLength != 3 ? "." : "-"));
					decodedMessage += " ";
				}
				decodedMessage += " ";
			}
			return decodedMessage;
		}

		private static int GetTimeUnitLength(string message)
		{
			if (TimeUnitLength != 0)
				return TimeUnitLength;
			var bits = message.ToCharArray();
			for (var unitLength = 0; unitLength < bits.Length; unitLength++)
			{
				TimeUnitLength = unitLength ;
				if (bits[unitLength] != '0') continue;
				if(TimeUnitLength % 3 !=0)
					return TimeUnitLength;
				for (var zeroCount = unitLength; zeroCount < bits.Length; zeroCount++)
					if (bits[zeroCount] == '1')
						if ((zeroCount) % 3 != 0)
							return TimeUnitLength/3;
						else
							return TimeUnitLength;
			}
			return TimeUnitLength != 0 ? TimeUnitLength : 1  ;
		}

		private static int TimeUnitLength = 0;

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
}
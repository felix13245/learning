using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodetheMorsecode
{
	public class Decoder
	{
		public static string Decode(string morseCode)
		{
			var words = morseCode.Split("  ", StringSplitOptions.RemoveEmptyEntries);
			var text = ""; 
			foreach (var word in words)
			{
				var letters = word.Split(" ",StringSplitOptions.RemoveEmptyEntries);
				text = letters.Aggregate(text, (current, letter) => current + MorseCode.Get(letter));
				text += " ";
			}
			text = text.Trim();
			return text;
		}
	}

	public static class MorseCode
	{
		public static string Get(string morseCode)
		{
			morseCodeDict.TryGetValue(morseCode, out var letter);
			return letter;
		}
			

		public static char dot = '.';
		public static char dash = '-';
		private static Dictionary<string, string> morseCodeDict = new Dictionary<string, string>()
            {
                {string.Concat(dot, dash), "A"},
                {string.Concat(dash, dot, dot, dot), "B"},
                {string.Concat(dash, dot, dash, dot), "C"},
                {string.Concat(dash, dot, dot), "D"},
                {dot.ToString(), "E"},
                {string.Concat(dot, dot, dash, dot), "F"},
                {string.Concat(dash, dash, dot), "G"},
                {string.Concat(dot, dot, dot, dot), "H"},
                {string.Concat(dot, dot), "I"},
                {string.Concat(dot, dash, dash, dash), "J"},
                {string.Concat(dash, dot, dash), "K"},
                {string.Concat(dot, dash, dot, dot), "L"},
                {string.Concat(dash, dash), "M"},
                {string.Concat(dash, dot), "N"},
                {string.Concat(dash, dash, dash),"O"},
                {string.Concat(dot, dash, dash, dot), "P"},
                {string.Concat(dash, dash, dot, dash), "Q"},
                {string.Concat(dot, dash, dot), "R"},
                {string.Concat(dot, dot, dot), "S"},
                {string.Concat(dash),"T"},
                {string.Concat(dot, dot, dash), "U"},
                {string.Concat(dot, dot, dot, dash), "V"},
                {string.Concat(dot, dash, dash), "W"},
                {string.Concat(dash, dot, dot, dash), "X"},
                {string.Concat(dash, dot, dash, dash), "Y"},
                {string.Concat(dash, dash, dot, dot), "Z"},
                {string.Concat(dash, dash, dash, dash, dash), "0"},
                {string.Concat(dot, dash, dash, dash, dash), "1"},  
                {string.Concat(dot, dot, dash, dash, dash), "2"},
                {string.Concat(dot, dot, dot, dash, dash), "3"},
                {string.Concat(dot, dot, dot, dot, dash), "4"},
                {string.Concat(dot, dot, dot, dot, dot), "5"},
                {string.Concat(dash, dot, dot, dot, dot),"6"},
                {string.Concat(dash, dash, dot, dot, dot), "7"},
                {string.Concat(dash, dash, dash, dot, dot),"8"},
                {string.Concat(dash, dash, dash, dash, dot), "9"}
            };
	}
}

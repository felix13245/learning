using System.Runtime.InteropServices.ComTypes;
using System.Text;
using NUnit.Framework;
using System.Security.Cryptography;
namespace CrackThePin
{
	public class CodeWars
	{
		[Test]
		public void SimpleTest()
		{
			Assert.AreEqual("12345", CodeWars.crack("827ccb0eea8a706c4c34a16891f84e7b"));
		}
		[Test]
		public void HarderTest()
		{
			Assert.AreEqual("00078", CodeWars.crack("86aa400b65433b608a9db30070ec60cd"));
		}

		public static string crack(string hash)
		{
			for(var first = 0; first <=9;first++)
			for(var second = 0; second <=9;second++)
			for(var third = 0; third <=9;third++)
			for(var fourth = 0; fourth <=9;fourth++)
			for (var fifth = 0; fifth <= 9; fifth++)
			{
				var pin = "" + first + second + third + fourth + fifth;
				if (CreateMD5(pin) == hash)
					return pin;
			}
			return "";
		}

		private static StringBuilder stringBuilder = new StringBuilder();

		public static string CreateMD5(string input)
		{
			var md5 = MD5.Create();
			var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
			var hashBytes = md5.ComputeHash(inputBytes);
			stringBuilder.Clear();
			foreach (var bytes in hashBytes)
				stringBuilder.Append(bytes.ToString("X2"));
			return stringBuilder.ToString().ToLower();
		}
	}
}
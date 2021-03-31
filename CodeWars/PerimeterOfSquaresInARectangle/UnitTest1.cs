using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;

namespace PerimeterOfSquaresInARectangle
{
	public class Tests
	{
		[Test]
		public void Test1()
		{
			Assert.AreEqual(new BigInteger(80), perimeter(new BigInteger(5)));
		}

		[Test]
		public void Test2()
		{
			Assert.AreEqual(new BigInteger(216), perimeter(new BigInteger(7)));
		}
		[Test]
		public void testFib3()
		{
			testFib(2, 3);
		}

		[Test]
		public void testFib4()
		{
			testFib(3, 4);
		}

		[Test]
		public void testFib5()
		{
			testFib(5, 5);
		}
		[Test]
		public void testFib1()
		{
			testFib(-8, -6);
		}
		private static void testFib(long expected, int input)
		{
			BigInteger found = fib(input);
			Assert.AreEqual(new BigInteger(expected), found);
		}
		public static BigInteger perimeter(BigInteger n) => GetFibonacciSequence(n)
			.Aggregate<BigInteger, BigInteger>(0, (current, number) => current + number) * 4;

		public static List<BigInteger> GetFibonacciSequence(BigInteger n)
		{
			var sequence = new List<BigInteger>();
			BigInteger a = 0;
			BigInteger b = 1;
			for (var i = 0; i <= n; i++)
			{
				sequence.Add(b);
				BigInteger temp = a;
				a = b;
				b = temp + b;
			}

			return sequence;
		}

		

		public static BigInteger fib(BigInteger number)
		{
			while (number != 0)
			{
				if (number % 2 == 0)
				{
					BigInteger temp = p;
					p = p * p + q * q;
					q = q * q + 2 * temp * q;
					number /= 2;
				}
				else
				{
					BigInteger temp = a;
					a = (p + q) * a + q * b;
					b = temp * q + b * p;
					number -= 1;
				}
			}
			return b;
		}

		static BigInteger a = 1;
		static BigInteger b = 0;
		static BigInteger p = 0;
		static BigInteger q = 1;

	}
}
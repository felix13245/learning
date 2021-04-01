using NUnit.Framework;

namespace MakeaSpiral
{
	public class Spiralizor
	{
		[Test]
		public void Test05()
		{
			int input = 5;
			int[,] expected = new int[,]{
				{1, 1, 1, 1, 1},
				{0, 0, 0, 0, 1},
				{1, 1, 1, 0, 1},
				{1, 0, 0, 0, 1},
				{1, 1, 1, 1, 1}
			};

			int[,] actual = Spiralizor.Spiralize(input);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Test08()
		{
			int input = 8;
			int[,] expected = new int[,]{
				{1, 1, 1, 1, 1, 1, 1, 1},
				{0, 0, 0, 0, 0, 0, 0, 1},
				{1, 1, 1, 1, 1, 1, 0, 1},
				{1, 0, 0, 0, 0, 1, 0, 1},
				{1, 0, 1, 0, 0, 1, 0, 1},
				{1, 0, 1, 1, 1, 1, 0, 1},
				{1, 0, 0, 0, 0, 0, 0, 1},
				{1, 1, 1, 1, 1, 1, 1, 1},
			};

			int[,] actual = Spiralizor.Spiralize(input);
			Assert.AreEqual(expected, actual);
		}

		public static int[,] Spiralize(int size)
		{
			var spiral = new int[size, size];
			for (var height = 0; height < size; height++)
				for (var width = 0; width < size; width++)
					spiral[height, width] = 0;
			return GenerateSpiral(spiral, size);
		}

		public static int [,] GenerateSpiral(int [,] spiral, int size)
		{
			var rotations = 0;
			var width = 0;
			var height = 0;
			var direction = 1;
			var isHorizontal = true;
			var minWidth = 0;
			var minHeight = 0;
			while (rotations < size)
			{
				spiral[height, width] = 1;
				if (height == 0 + minHeight && !isHorizontal && direction < 0)
				{
					isHorizontal = true;
					direction *= -1;
					rotations++;
				}
				if (height == size - minHeight - 1 && !isHorizontal && direction > 0)
				{
					isHorizontal = true;
					minHeight += 2;
					direction *= -1;
					rotations++;
				}
				if (width == size - minWidth - 1 && isHorizontal && direction > 0)
				{
					isHorizontal = false;
					rotations++;
				}
				if (height != 0 && width == 0 + minWidth && isHorizontal && direction < 0)
				{
					isHorizontal = false;
					minWidth += 2;
					rotations++;
				}
				if (isHorizontal)
					width += direction;
				else 
					height += direction;
			}
			return spiral;
		}
	}
}
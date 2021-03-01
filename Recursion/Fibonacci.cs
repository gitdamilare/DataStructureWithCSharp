using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
	public class Fibonacci
	{
		static int[] resultStorage = new int[50];

		public Fibonacci()
		{
			for(int i= 0; i<50; i++)
			{
				resultStorage[i] = -1;
			}
		}
		public static int FibIterative(int n)
		{
			int initialFirst = 0;
			int initialSecond = 1;
			int result = 0;

			if(n <= 1)
			{
				result = 1;
				return result;
			}

			for(int i=2; i<=n; ++i)
			{
				result = initialFirst + initialSecond;
				initialFirst = initialSecond;
				initialSecond = result;
				//Console.WriteLine(result);
			}

			return result;

		}

		public static int FibRecursion(int n)
		{
			if(n <= 1)
			{
				return n;
			}

			return FibRecursion(n - 1) + FibRecursion(n - 2);
		}

		public static int FibRecursionMemoization(int n)
		{
			if (n <= 1) return n;

			if(resultStorage[n] != -1)
			{
				return resultStorage[n];
			}

			resultStorage[n] = FibRecursionMemoization(n - 1) + FibRecursionMemoization(n - 2);
			return resultStorage[n];
		}

	}
}

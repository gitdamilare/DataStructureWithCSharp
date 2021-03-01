using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
	public class Factorial
	{
		public static int CalFactorial(int n)
		{
			Console.WriteLine("I am Calculating F({0})", n);
			int result;
			if (n == 0)
			{
				result = 1;
				return result;
			}
			result = n * CalFactorial(n-1);
			Console.WriteLine("Done Calculating F({0}) which is {1}", n, result);
			return result;
		}
	}
}

using System;

namespace Recursion
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine(Factorial.CalFactorial(5));
			//Console.WriteLine(Fibonacci.FibIterative(40));
			//Console.WriteLine(Fibonacci.FibRecursion(40));
			//Fibonacci fibonacci = new Fibonacci();
			//Console.WriteLine(Fibonacci.FibRecursionMemoization(40));
			Console.WriteLine(Power.CalPowerR(4,3));
			//Console.WriteLine(Power.CalPowerIternative(4, 3));
			Console.WriteLine(Power.ModExp(5,3,7));

			int currestState = 0; //Awake 

			Alive alive = new Alive(currestState);
			alive.Sleep();
			alive.WakeUp();

		}
	}
}

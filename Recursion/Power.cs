using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
	public class Power
	{

		//This Function is used to calculate 
		//x raised to the power of n
		public static int CalPower(int x, int n)
		{
			int result = 1;
			if(n == 0)
			{
				result = 1;
				return result;
			}
			if( n == 1)
			{
				return x;
			}

			if(n > 0)
			{
				result = x * x;
			}

			result = x * CalPower(x, n-1);
			
			return result;
		}

		public static int CalPowerR(int x, int n)
		{
			if (n == 0)
			{
				return 1;
			}
			else if (n % 2 == 0)
			{
				int temp = CalPower(x, n / 2);
				return temp * temp;
			}
			else
			{
				return x * CalPower(x, n- 1);
			}
			
		}

		public static int CalPowerIternative(int x, int n)
		{
			int result = 1;
			if (n == 0)
				return 1;
			for(int i = 0; i < n; ++i)
			{
				result = result * x;
			}

			return result;
		}
	
		public static int ModExp(int x, int n, int m)
		{
			if(n == 0)
			{
				return 1;
			}else if(n % 2 == 0)
			{
				int temp = ModExp(x, n / 2, m);
				return (temp * temp) % m; 
			}
			else
			{
				return ((x % m) * ModExp(x, n - 1, m)) % m;
			}
		}
	}
}

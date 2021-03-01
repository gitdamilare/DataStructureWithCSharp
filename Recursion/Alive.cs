using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Recursion
{
	public class Alive
	{
		public int CurrentState { get; set; } //Awake = 0 Sleeping = 1
		public Alive(int currentState)
		{
			CurrentState = currentState;
		}

		public void WakeUp()
		{
			if (CurrentState == 1)
			{
				Console.WriteLine("Waking up now");
				CurrentState = 0;
			}
			else
			{
				Console.WriteLine("I am already Awake");
			}
		}

		public void Sleep()
		{
			if(CurrentState == 0)
			{
				Console.WriteLine("Going to Bed");
				CurrentState = 1;
			}
			else
			{
				Console.WriteLine("I am already asleep");
			}
		}
	}

}

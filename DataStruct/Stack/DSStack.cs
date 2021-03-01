using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataStruct
{
	public class DSStack
	{
		private static int arraySize = 3;
		private int top;
		private int[] arrStack = new int[arraySize];
		public DSStack()
		{
			top = -1;
			Push(2); //0
			Push(3); //1
			Push(5); //2
			Push(6);
			Print();
			Console.WriteLine('\n');
			Push(8);
			Print();

			Console.WriteLine('\n');
			//Console.WriteLine(GetTop());
			Console.WriteLine(IsEmpty());

		}

		public void Push(int x)
		{
			if(top == arraySize - 1)
			{
				//int[] newArr = new int[arraySize * 2];
				//Array.Copy(arrStack, newArr, arrStack.Length);
				arrStack = MakeCopy(arrStack);
			}
			top++;
			arrStack[top] = x;	
		}

		public void Pop()
		{
			if(top == -1)
			{
				throw new Exception("No Element to POP");
			}
			top--;
			return;
		}

		public int GetTop()
		{
			if(top == -1)
			{
				throw new Exception("No top for an Element Stack");
			}
			return arrStack[top];
		}

		public bool IsEmpty()
		{
			if(top == -1)
			{
				return true;
			}
			return false;
		}

		public void Print()
		{
			for(int i = 0; i <= top; ++i)
			{
				Console.Write(arrStack[i] + " ");
			}
		}
	
		public int[] MakeCopy(int[] arr)
		{
			int[] newArr = new int[arraySize * 2];
			for(int i=0; i < arr.Length; ++i)
			{
				newArr[i] = arr[i];
			}
			return newArr;
		}
	}
}

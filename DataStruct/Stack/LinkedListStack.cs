using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct
{
	public class LinkedListStack
	{
		private SNode top = null;

		public LinkedListStack()
		{
			Push(30);
			Push(50);
			Push(10);
			Print(top);

			Console.WriteLine('\n');
			Pop();
			Print(top);
			Console.WriteLine('\n');

			Console.WriteLine(IsEmpty());

		}

		void Push(int x)
		{
			SNode newNode = new SNode(x);
			if(top == null)
			{
				top = newNode;
				return;
			}
			newNode.NextSNode = top;
			top = newNode;
			return;
		}
		
		void Pop()
		{
			if (top == null) throw new Exception("No Element to POP");
			SNode tempNode = top;
			top = tempNode.NextSNode;
			tempNode = null;
		}
		
		void Print(SNode top)
		{
			if(top == null)
			{
				return;
			}
			Console.Write(top.Data + " ");
			Print(top.NextSNode);
		}

		int GetTop()
		{
			return top.Data;
		}

		bool IsEmpty()
		{
			if (top == null) return true;
			return false;
		}
	}


	public class SNode
	{
		public int Data { get; set; }
		public  SNode NextSNode { get; set; } = null;

		public SNode(int data)
		{
			Data = data;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DataStruct
{
	public class DoublyLinkedList
	{
		public DNode headNode = null;
		public DoublyLinkedList()
		{
			InsertFront(1);
			InsertBack(20);
			InsertBack(30);
			InsertBack(10);
			InsertFront(5);
			Print(headNode);

			Console.WriteLine('\n');
			PrintReverse();
		}

		#region Double Linked List Operation

		#region Insert Operation
		public void InsertFront(int data)
		{
			DNode newNode = new DNode(data);
			if (headNode == null)
			{
				headNode = newNode;
				return;
			}
			newNode.NextNode = headNode;
			headNode.PrevNode = newNode;
			headNode = newNode;
			return;

		}
		public void InsertBack(int data)
		{
			DNode newNode = new DNode(data);
			if (headNode == null)
			{
				headNode = newNode;
				return;
			}
			DNode lastNode = GetLastDNode();
			newNode.PrevNode = lastNode;
			lastNode.NextNode = newNode;

		}
		#endregion

		#region Get Operation
		public DNode GetLastDNode()
		{
			DNode currentNode = headNode;
			while (currentNode.NextNode != null)
			{
				currentNode = currentNode.NextNode;
			}
			return currentNode;
		}

		public DNode GetDNode(int position)
		{
			if(headNode == null) throw new IndexOutOfRangeException("Cannot Access Element For Empty List");
			if(headNode.GetLength() <= position) throw new IndexOutOfRangeException("Index out of Range");

			DNode currentNode = headNode;
			for(int i=0; i<position; ++i)
			{
				currentNode = currentNode.NextNode;
			}
			return currentNode;
		}
		#endregion

		#region Delete Operation
		public void Delete(int position)
		{
			if(position == 0)
			{
				DNode currentNode = headNode;
				currentNode = null;
				headNode.NextNode.PrevNode = currentNode;
				headNode = headNode.NextNode;
				return;
			}
			DNode nodeToDelete = GetDNode(position);
			nodeToDelete.PrevNode.NextNode = nodeToDelete.NextNode;
			nodeToDelete = null;
			return;
		}
		#endregion

		#region Print Operation
		public void Print(DNode headNode)
		{
			if (headNode == null)
			{
				return;
			}
			Console.Write(headNode.Data + " ");
			Print(headNode.NextNode);
		}
		
		public void PrintReverse()
		{
			if(headNode == null)
			{
				return;
			}

			DNode lastNode = GetLastDNode();

			DNode currentNode = lastNode;
			while(currentNode != null)
			{
				Console.Write(currentNode.Data + " ");
				currentNode = currentNode.PrevNode;
			}
			return;
		}

		public void PrintReverse(DNode headNode)
		{
			if(headNode == null)
			{
				return;
			}
			PrintReverse(headNode.NextNode);
			Console.Write(headNode.Data + " ");
		}
		#endregion

		#region Reverse Operation

		#endregion
		#endregion
	}

	public class DNode
	{
		public int Data { get; set; }
		public DNode NextNode { get; set; } = null;
		public DNode PrevNode { get; set; } = null;

		public DNode(int data)
		{
			Data = data;
		}

	}

	public static class DNodeExtention
	{
		public static int GetLength(this DNode dNode)
		{
			int count = 0;
			if (dNode == null)
			{
				return count;
			}

			count = 1 + GetLength(dNode.NextNode);
			return count;
		}
	}
}


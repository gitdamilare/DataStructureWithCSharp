using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataStruct
{
    public class SinglyLinkedList
    {

        private Node headNode = null;
        public SinglyLinkedList()
        {
            InsertBack(1); //0
            InsertBack(5); //1
            InsertBack(10); //2
            InsertBack(8);   //3
            PrintNode();

            Insert(new Node(30), 1);
            Console.WriteLine('\n');
            ReversePrint();

            Console.WriteLine('\n');
            headNode = ReverseWithStack(headNode);
            RecursionPrint(headNode);

        }

        #region Operation Of Linked List

        #region Insert Operation
        public void InsertFront(int x)
        {
            Node newNode = new Node(x);
            if (headNode == null)
            {
                headNode = newNode;
                return;
            }
            //Save the Current Head into a Temp Value
            //then set the Node to be placed in front Next to be the currenthead 
            //then allocate the newNode to be the head. Done
            Node currentHead = headNode;
            newNode.NextNode = currentHead;
            headNode = newNode;
        }

        public void InsertBack(int x)
        {
            Node newNode = new Node(x);
            if (headNode == null)
            {
                headNode = newNode;
                return;
            }
            Node lastNode = GetLastNode();
            lastNode.NextNode = newNode;
        }

        public void Insert(Node node, int position)
        {
            if (position == 0)
            {
                Node currentHead = headNode;
                node.NextNode = currentHead;
                headNode = node;
                return;
            }

            //Get the Node Before the desired Position
            Node tempNode = GetNode(position - 1);

            node.NextNode = tempNode.NextNode;
            tempNode.NextNode = node;
        }

        #endregion

        #region Get Operation
        public Node GetLastNode()
        {
            Node currentNode = headNode;
            while (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
            }
            return currentNode;
        }
        public Node GetNode(int n)
        {
            int nodeLength = NodeSize();
            if (headNode == null)
            {
                throw new IndexOutOfRangeException("Cannot Access Element For Empty List");
            }
            if (n >= nodeLength)
            {
                throw new IndexOutOfRangeException("Index out of Range");
            }
            if (n <= 0)
            {
                return headNode;
            }

            Node currentNode = headNode;
            for (int i = 0; i < n; ++i)
            {
                currentNode = currentNode.NextNode;
            }
            return currentNode;
        }
        #endregion

        #region Delete Operation
        public void DeleteNode(int position)
        {
            if (headNode == null) throw new InvalidOperationException("Cannot Perform Operation on Empty List");
            if (position == 0)
            {
                Node currentHead = headNode;
                headNode = currentHead.NextNode;
                currentHead = null;
                return;
            }
            Node nodeToDelete = GetNode(position);
            Node prevNode = GetNode(position - 1);

            prevNode.NextNode = nodeToDelete.NextNode;
            nodeToDelete = null;

        }
        #endregion

        #region Print
        public void PrintNode()
        {
            if (headNode != null)
            {
                Node currentNode = headNode;
                while (currentNode != null)
                {
                    Console.Write(currentNode.Data + " ");
                    currentNode = currentNode.NextNode;
                }
            }
            else
            {
                Console.WriteLine("No Element to Print");
            }
        }

        public void RecursionPrint(Node head)
        {
            if (head != null)
            {
                Console.Write(head.Data + " ");
                RecursionPrint(head.NextNode);
            }
            return;
        }

        public void ReverseRecursionPrint(Node head)
        {
            if (head == null) return;
            ReverseRecursionPrint(head.NextNode);
            Console.Write(head.Data + " ");
        }

        public void ReversePrint()
        {
            Node currentNode = headNode;
            Stack<Node> nodes = new Stack<Node>();
            while (currentNode != null)
            {
                nodes.Push(currentNode);
                currentNode = currentNode.NextNode;
            }

            foreach (Node node in nodes)
            {
                Console.Write(node.Data + " ");
            }
        }
        #endregion

        #region Reverse
        public void ReverseNode()
        {
            Node currentNode = headNode;
            Node prevNode = null, nextNode = null;

            while (currentNode != null)
            {
                nextNode = currentNode.NextNode; //Store the Value Next Node setting it to it prevNode;
                currentNode.NextNode = prevNode; // Point the CurrentNode to it PrevNode;

                //Setting things up for the next iteration
                prevNode = currentNode;
                currentNode = nextNode;
            }

            headNode = prevNode;

        }

        public void ReverseNode(Node node)
        {
            //Go to the Last Node
            if (node.NextNode == null)
            {
                headNode = node;
                return;
            }
            ReverseNode(node.NextNode);

            Node temp = node.NextNode;

            temp.NextNode = node;

            node.NextNode = null;
        }

        public Node ReverseNodee(Node node)
        {
            //Go to the Last Node
            if (node == null)
            {
                return node;
            }
            if (node.NextNode == null)
            {
                //headNode = node;
                return node;
            }
            //AT WHAT Point does result gets affected
            Node result = ReverseNodee(node.NextNode);
            Node temp = node.NextNode;
            temp.NextNode = node;
            node.NextNode = null;
            return result;

        }

        public void ReverseWithStack()
        {
            if (headNode == null)
            {
                return;
            }

            Node currentNode = headNode;
            Stack<Node> stackNodes = new Stack<Node>();
            while (currentNode != null)
            {
                stackNodes.Push(currentNode);
                currentNode = currentNode.NextNode;
            }

            //Since this is an Object it a Reference Type 
            //meaning any assignment is pointing to the address in memory
            Node temp = stackNodes.Peek();
            headNode = temp;
            stackNodes.Pop();

            while (stackNodes.Count > 0)
            {
                temp.NextNode = stackNodes.Peek();
                stackNodes.Pop();
                temp = temp.NextNode;
                //Console.WriteLine(headNode.Data + " " + temp.Data);
            }
            temp.NextNode = null;
        }

        public Node ReverseWithStack(Node head)
        {
            Node currentNode = head;
            Stack<Node> nodes = new Stack<Node>();
            while (currentNode != null)
            {
                nodes.Push(currentNode);
                currentNode = currentNode.NextNode;
            }

            Node temp = nodes.Peek();
            currentNode = temp;
            nodes.Pop();
            while (nodes.Count > 0)
            {
                temp.NextNode = nodes.Peek();
                nodes.Pop();
                temp = temp.NextNode;
            }
            temp.NextNode = null;
            return currentNode;
        }
        #endregion


        public int NodeSize()
        {
            int result = 0;
            if (headNode == null)
            {
                return result;
            }
            Node currentNode = headNode;
            while (currentNode != null)
            {
                result += 1;
                currentNode = currentNode.NextNode;
            }
            return result;
        }

        public int NodeSize(Node head)
        {
            int result = 0;
            if (head == null)
            {
                return result;
            }

            result = 1 + NodeSize(head.NextNode);
            return result;
        }

        #endregion
    }

    public class Node
    {
        public int Data { get; set; }
        public Node NextNode { get; set; } = null;

        public Node(int data)
        {
            this.Data = data;
        }
    }
}

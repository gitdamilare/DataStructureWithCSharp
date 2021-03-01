using System;


//Queue Implementation 
//Insertion is Done From the REAR/TAIL
//Removal is done from the FRONT/HEAD
namespace DataStruct
{
    public class DSQueue
    {
        private static int queueLength = 5;
        private int[] A = new int[queueLength];
        private int front = -1;
        private int tail = -1;
        public DSQueue()
        {
            Enqueue(2);
            Enqueue(3);
            Dequeue();
            Enqueue(4);
            Enqueue(5);
            Enqueue(6);
            Dequeue();
            Print();
        }

        private void Print()
        {
           for(int i = front; i <= tail ; i++){
               Console.Write(A[i] + " ");
           }
        }

        private void Enqueue(int x)
        {
            if (IsFull())
            {
                throw new Exception("List is Full");
            }
            else if (IsEmpty())
            {
                front++;
                tail++;
            }
            else
            {
                tail = (tail + 1) % queueLength;
            }
            A[tail] = x;
        }
        private void Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("List is Full");
            }
            else if (front == tail) //Meaning the Queue will be empty after this
            {
                front = tail = -1; //So set it to empty
            }
            else
            {
                front = (front + 1) % queueLength;
            }
        }
        private int GetFront()
        {
            if (IsEmpty())
            {
                throw new Exception("List is Full");
            }
            else
            {
                return A[front];
            }
        }
        private bool IsEmpty()
        {
            if (front == -1) return true;
            return false;
        }
        private bool IsFull()
        {
            if (((tail + 1) % queueLength) == front)
            {
                return true;
            }
            return false;

        }
    }
}

using System;

namespace DataStruct{
    public class LinkedListQueue{

        private QNode front = null;
        private QNode rear = null;
        public LinkedListQueue(){
            Enqueue(2);
            Enqueue(3);
            Enqueue(4);
            Print(front);
            Console.WriteLine('\n');
            Dequeue();
            Dequeue();
            Dequeue();
            Print(front);
        }

        private void Enqueue(int data ){
            QNode newNode = new QNode(data);
            if(front == null && rear == null){
                front = rear = newNode;
                return;
            }
            rear.NextNode = newNode;
            rear = newNode;
        }

        private void Dequeue(){
            QNode temp = front;
            if(front == null){
                throw new Exception("Cannot get perform operation Deqeue on Empty List");
            }else if(front.Equals(rear)){
                front = rear = null;
            }else{           
            front = front.NextNode;
            }
            temp = null;
        }

        private void Print(QNode front){
            if(front == null){
                return;
            }
            Console.Write(front.Data + " ");
            Print(front.NextNode);
        }
    }

    public class QNode{
        public int Data {get; set;}
        public QNode NextNode {get; set;}

        public QNode(int data){
            Data = data;
        }
    }
}
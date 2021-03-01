 using System;
 
 namespace DataStruct{

     public class BinaryTree{
          private BSTNode root;
        public BinaryTree(){
            root = null;
            root = InsertNode(root, 15);
            root = InsertNode(root,10);
            root = InsertNode(root,8);
            root = InsertNode(root,12);
            root = InsertNode(root,20);
            root = InsertNode(root,25);
            root = InsertNode(root,17);
            root = InsertNode(root,30);
            root = InsertNode(root,35);
            bool result = Search(root,15);
            Println(root);

            

             Console.WriteLine(result);
             Console.WriteLine("The Smallest Value in the Tree is " + root.GetMinimum());
             Console.WriteLine("The Maximum Value of the Tree is " + root.GetMax());
              Console.WriteLine("The Heigth of the Tree is " + root.GetHeight());
              Console.WriteLine("The Level Order Traversal " + root.LevelOrder());
        }

        private bool Search(BSTNode root,int v)
        {
            bool result;
            if(root == null ){
                result = false;
            }else if(v == root.Data){
                result = true;             
            }
            else if(v <= root.Data){
                return Search(root.LeftTree, v);
            }else{
              return Search(root.RightTree, v);
            }
            return result;
        }

        private BSTNode InsertNode(BSTNode root, int v)
        {
            BSTNode newNode = new BSTNode(v);
            if(root == null){
                root = newNode;
            }else if(v <= root.Data){
                root.LeftTree = InsertNode(root.LeftTree,v);
            }else{
                root.RightTree = InsertNode(root.RightTree,v);
            }
            return root;
        }

        private BSTNode NodeInsert(BSTNode root, int v){
            BSTNode newNode = new BSTNode(v);
            BSTNode tempRoot = null;
            while(root != null){
                tempRoot = root;
                if(v <= root.Data){
                    root = root.LeftTree;
                }else{
                    root = root.RightTree;
                }
            }

            if(tempRoot == null){
               tempRoot = newNode;
               return tempRoot;
            }else if(v <= tempRoot.Data){
                tempRoot.LeftTree = newNode;
            }else{
                tempRoot.RightTree = newNode;
            }  
            return tempRoot;
        }

        void Print(BSTNode root){
            if(root == null){
                return;
            }
            Console.WriteLine(root.Data);
            BSTNode tempLeft = root.LeftTree;
            BSTNode tempRight = root.RightTree;
            while(tempLeft != null){
                Console.WriteLine(tempLeft.Data);
                tempLeft = tempLeft.LeftTree;
            } 
            while(tempRight != null){
                Console.WriteLine(tempRight.Data);
                tempRight = tempRight.RightTree;
            } 

        }

        void Println(BSTNode root){
            if(root == null){
                return;
            }
            Console.WriteLine(root.Data);
            if(root.LeftTree != null){
                Println(root.LeftTree);
            }
            if(root.RightTree != null){
                Println(root.RightTree);
            }

        }
         
     }


     public class BSTNode{
         public int Data {get; set;}
         public BSTNode LeftTree{get; set;} = null;
         public BSTNode RightTree{get; set;} = null;

         public BSTNode(int data){
             Data = data;
         }
     }
 }
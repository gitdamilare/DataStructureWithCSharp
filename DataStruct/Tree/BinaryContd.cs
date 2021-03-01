using System;
using System.Collections.Generic;

namespace DataStruct{
    public static class BinaryContd{

        #region Operations

        public static int GetMinimum(this BSTNode input){
            int result;
            if(input == null){
                throw new Exception("Can't Get Minimum For Empty Tree");
            }
            if(input.LeftTree == null){
                result = input.Data;
                return result;
            }else{
                result = GetMinimum(input.LeftTree);
                return result;
            }
        }

        public static int GetMax(this BSTNode input){
            if(input == null){
               throw new Exception("Can't Get Minimum For Empty Tree");
            }else if(input.RightTree == null){
                return input.Data;
            }else {
                return GetMax(input.RightTree);
            }
        }

        public static int GetHeight(this BSTNode input){
            int result = 0;
            if(input == null){
                result = 0;
                return result;
            }
            if(input.LeftTree != null || input.RightTree != null){
                int leftHeight = GetHeight(input.LeftTree);
                int rightTree = GetHeight(input.RightTree);
                result = 1 + Math.Max(leftHeight,rightTree);            
           }

            return result;
            
        }
        
        public static string LevelOrder(this BSTNode root){
            string result = string.Empty;
            Queue<BSTNode> queue = new Queue<BSTNode>();
            if(root == null){
                throw new Exception("Empty Tree");
            }
            queue.Enqueue(root);

            while(queue.Count > 0){
            BSTNode temp = queue.Peek();
            result += temp.Data.ToString() + " ";
            if(temp.LeftTree != null)queue.Enqueue(temp.LeftTree);
            if(temp.RightTree != null)queue.Enqueue(temp.RightTree);
            queue.Dequeue();            
            }
            return result;

        }
        #endregion
        
    }
}
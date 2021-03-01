using System;
using System.Collections.Generic;
using System.Text;

namespace DataStruct
{
    public class StackContd
    {
        public static string ReverseString(string input)
        {
            //string result;
            Stack<char> s = new Stack<char>();
            char[] charArr = new char[input.Length];
            foreach (char x in input)
            {
                s.Push(x);
            }

            for (int i = 0; i < input.Length; ++i)
            {
                charArr[i] = s.Peek();
                s.Pop();
            }
            string result = new string(charArr);
            return result;
        }
        public static string ReverseeString(string input)
        {
            var result = input.ToCharArray();
            for (int i = 0, j = result.Length - 1; i < result.Length; ++i, --j)
            {
                char temp = result[i];
                char temp2 = result[j];
                if (i < j)
                {
                    result[i] = temp2;
                    result[j] = temp;
                }
            }

            return new string(result);
        }

        public static bool CheckBalanceParentheses(string exp)
        {
            Stack<Char> stackChars = new Stack<char>();
            foreach (char x in exp)
            {
                if (x == '(' || x == '{' || x == '[')
                {
                    stackChars.Push(x);
                }
                if (x == ')' || x == '}' || x == ']')
                {
                    if (stackChars.Count > 0 && ArePair(stackChars.Peek(), x))
                    {
                        stackChars.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return stackChars.Count > 0 ? false : true;
        }

        public static bool ArePair(char x, char y)
        {
            if (x == '(' && y == ')') return true;
            if (x == '{' && y == '}') return true;
            if (x == '[' && y == ']') return true;
            return false;
        }

        public static int EvaluatePostFix(string exp)
        {
            int result = -1;
            Stack<int> sChars = new Stack<int>();
            foreach (char e in exp)
            {
                if (e == ' ' || e == ' ') continue;
                if (!IsOperator(e))
                {
                    sChars.Push((int)Char.GetNumericValue(e));
                }
                else
                {
                    int operand2 = sChars.Peek(); sChars.Pop();
                    int operand1 = sChars.Peek(); sChars.Pop();
                    result = PerformOperation(operand1, operand2, e);
                    sChars.Push(result);
                }
            }
            sChars.Pop();
            return result;
        }
        public static bool IsOperator(char input)
        {
            if (input.Equals('*') || input.Equals('+') || input.Equals('-')
                || input.Equals('/') || input.Equals('(') || input.Equals(')'))
                return true;
            return false;
        }
        public static int PerformOperation(int operand1, int operand2, char operatr)
        {
            int result = -1;
            if (operatr == '+') result = operand1 + operand2;
            if (operatr == '*') result = operand1 * operand2;
            if (operatr == '/') result = operand1 / operand2;
            if (operatr == '-') result = operand1 - operand2;

            return result;
        }

        public static int EvaluatePreFix(string exp)
        {
            Stack<int> sInts = new Stack<int>();
            int result = -1;
            for (int i = exp.Length - 1; i >= 0; --i)
            {
                char e = exp[i];
                if (e == ' ' || e == ',') continue;
                if (!IsOperator(e))
                {
                    sInts.Push((int)Char.GetNumericValue(e));
                }
                else
                {
                    int operand1 = sInts.Peek(); sInts.Pop();
                    int operand2 = sInts.Peek(); sInts.Pop();
                    result = PerformOperation(operand1, operand2, e);
                    sInts.Push(result);
                }
            }
            sInts.Pop();
            return result;
        }

        public static string InfixToPostFix(string exp)
        {
            Stack<char> sChars = new Stack<char>();
            string result = string.Empty;
            foreach (char x in exp)
            {
                if (x == ' ' || x == ',')
                    continue;
                else if (!IsOperator(x))
                {
                    result += x;
                    continue;
                }
                else if (x == '(')
                {
                    sChars.Push(x);
                    continue;
                }
                else if (x == ')' && sChars.Contains('('))
                {
                    while (sChars.Count > 0 && sChars.Peek() != '(')
                    {
                        result += sChars.Peek();
                        sChars.Pop();
                    };
                    sChars.Pop();
                    continue;
                }
                else if (IsOperator(x))
                {
                    while(sChars.Count > 0 && sChars.Peek() != '(' && HasHigherPrecendence(sChars.Peek(), x))
                    {
                        result += sChars.Peek();
                        sChars.Pop();
                        //sChars.Push(x);
                    }
                    sChars.Push(x);
                    continue;
                }
            }
            while (sChars.Count > 0)
            {
                result += sChars.Peek();
				sChars.Pop();
            }
            return result;
        }



        public static bool HasHigherPrecendence(char operator1, char operator2)
        {
            bool result = false;
            if (operator1.Equals(operator2))
                result = false;
			
			if (operator1 == '+' && operator2 == '-' )
                result = true;

			if (operator1 == '-' && operator2 == '+' )
                result = true;

            if ((operator1 == '*' || operator1 == '/') && (operator2 == '+' || operator2 == '-'))
                result = true;

            if ((operator1 == '+' || operator1 == '-') && (operator2 == '*' || operator2 == '/'))
                result = false;

            return result;
        }
    }
}

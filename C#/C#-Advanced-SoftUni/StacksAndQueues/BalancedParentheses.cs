using System;
using System.Collections.Generic;

namespace BalancedParentheses
{

    //има грешка
    class BalancedParentheses
    {
        static void Main(string[] args)
        {
            Stack<char> leftSide = new Stack<char>(Console.ReadLine());
            int originaLength = leftSide.Count;
            Stack<char> rightSide = new Stack<char>();


            if (originaLength % 2 == 0)
            {
                for (int i = 0; i < originaLength / 2; i++)
                {
                    char parentheses = leftSide.Pop();
                    rightSide.Push(parentheses);
                }

                bool isBalanced = true;

                int length = leftSide.Count; //Math.Min(leftSide.Count, rightSide.Count);

                for (int i = 0; i < length; i++)
                {
                    char left = leftSide.Pop();
                    char right = rightSide.Pop();

                    if (left == '[' && right == ']')
                    {

                    }
                    else if (left == '{' && right == '}')
                    {

                    }
                    else if (left == '(' && right == ')')
                    {

                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }

                if (isBalanced && leftSide.Count == rightSide.Count)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
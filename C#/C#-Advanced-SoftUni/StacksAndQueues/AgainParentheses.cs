using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class BalancedParentheses
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>();
            char[] bracketArr = new char[] { '(', '{', '[' };
            bool isBalanced = true;

            foreach (var item in input)
            {
                if (bracketArr.Contains(item))
                {
                    stack.Push(item);
                    continue;
                }

                if (stack.Count == 0)
                {
                    isBalanced = false;
                    break;
                }

                if (stack.Peek() == '(' && item == ')')
                {
                    stack.Pop();
                }
                else if (stack.Peek() == '[' && item == ']')
                {
                    stack.Pop();
                }
                else if (stack.Peek() == '{' && item == '}')
                {
                    stack.Pop();
                }
                else
                {
                    isBalanced = false;
                    break;
                }

            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }


        }
    }
}
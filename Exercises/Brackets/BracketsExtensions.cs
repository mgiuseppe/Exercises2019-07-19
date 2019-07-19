using System.Collections.Generic;

namespace Exercises
{
    public static class BracketsExtensions
    {
        /// <summary>
        /// Returns true if the usage of round and square brackets is consistent
        /// 
        /// Empty or Null exp is consistent
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool AreBracketsBalanced(this string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                return true;

            var bracketsStack = new Stack<char>();
            var isExpressionWellFormed = true;
            var currChar = 0;
            while (currChar < expression.Length && isExpressionWellFormed)
            {
                var c = expression[currChar];

                if (c == '(' || c == '[')
                    bracketsStack.Push(c);
                else if (c == ')')
                    isExpressionWellFormed = bracketsStack.Count > 0 && bracketsStack.Pop() == '(';
                else if (c == ']')
                    isExpressionWellFormed = bracketsStack.Count > 0 && bracketsStack.Pop() == '[';
                //else ignore

                currChar++;
            }

            //check if there are brackets not closed
            isExpressionWellFormed &= bracketsStack.Count == 0;

            return isExpressionWellFormed;
        }
    }
}

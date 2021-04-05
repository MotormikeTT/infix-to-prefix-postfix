using System.Collections.Generic;
using System.Linq;

namespace Project2_Group_16
{
    /// <summary>
    /// Polish notation (PN), also known as normal Polish notation (NPN)
    /// prefix notation, is a mathematical notation in which operators precede their operands
    /// </summary>
    public class PreFix
    {
        string value;

        // ctor that will convert from infix notation to prefix
        public PreFix(string inFix)
        {
            inFix = "(" + inFix + ")";
            var reversedInFix = inFix.Reverse();
            Stack<char> charStack = new Stack<char>();
            string output = string.Empty;
            foreach (var val in reversedInFix)
            {
                // If the scanned character is an operand, add it to output.
                if (char.IsLetterOrDigit(val))
                    output += val;

                // If the character is a closing parenthesis, then push it to the stack.
                else if (val == ')')
                    charStack.Push(')');

                // If the character is an opening parenthesis,
                // pop the elements in the stack until we find the corresponding closing parenthesis.
                else if (val == '(')
                {
                    while (charStack.Peek() != ')')
                    {
                        output += charStack.Pop();
                    }

                    // Remove the closing parenthesis from the stack
                    charStack.Pop();
                }

                // If the character scanned is an operator
                else if (!char.IsDigit(val) && !char.IsLetter(val))
                {
                    while (getPriority(val) < getPriority(charStack.Peek()))
                    {
                        output += charStack.Pop();
                    }

                    // Push current Operator on stack
                    charStack.Push(val);
                }
            }

            value = new string(output.Reverse().ToArray());
        }

        // helper method
        // get priority of operator by precedence
        private int getPriority(char C)
        {
            if (C == '-' || C == '+')
                return 1;
            else if (C == '*' || C == '/')
                return 2;
            else if (C == '^')
                return 3;
            return 0;
        }

        public override string ToString()
        {
            return value;
        }
    }
}

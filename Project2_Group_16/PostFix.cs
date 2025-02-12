﻿using System.Collections.Generic;
using System.Linq;

namespace Project2_Group_16
{
    /// <summary>
    /// Reverse Polish notation(RPN), also known as Polish postfix notation or simply postfix notation,
    /// is a mathematical notation in which operators follow their operands, in contrast to Polish notation(PN),
    /// in which operators precede their operands.
    /// </summary>
    public class PostFix
    {
        string value = string.Empty;

        public string Result { get; private set; }

        // ctor that will convert from infix notation to postfix
        public PostFix(string inFix)
        {
            inFix = "(" + inFix + ")";
            Stack<char> charStack = new Stack<char>();
            string output = string.Empty;

            foreach (var val in inFix)
            {
                // If the scanned character is an operand, add it to output.
                if (char.IsLetterOrDigit(val))
                    output += val;

                // If the character is a opening parenthesis, then push it to the stack.
                else if (val == '(')
                    charStack.Push('(');

                // If the character is an closing parenthesis,
                // pop the elements in the stack until we find the corresponding opening parenthesis.
                else if (val == ')')
                {
                    while (charStack.Peek() != '(')
                    {
                        output += charStack.Pop();
                    }

                    // Remove the closing parenthesis from the stack
                    charStack.Pop();
                }

                // If the character scanned is an operator
                else if (!char.IsDigit(val) && !char.IsLetter(val))
                {
                    while (getPriority(val) <= getPriority(charStack.Peek()))
                    {
                        output += charStack.Pop();
                    }

                    // Push current Operator on stack
                    charStack.Push(val);
                }
            }

            value = output;

            Result = ExpressionEvaluation.Evaluate(this);
            System.Console.Write($"Postfix: {value} Postfix Evaluation: {Result}\n\n");
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

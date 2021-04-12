using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_16
{
    class ExpressionEvaluation
    {
        static Expression<Func<double, double, double>> add = (a, b) => a + b;
        static Expression<Func<double, double, double>> subtract = (a, b) => a - b;
        static Expression<Func<double, double, double>> multiply = (a, b) => a * b;
        static Expression<Func<double, double, double>> divide = (a, b) => a / b;

        static Stack<double> stack = new Stack<double>();

        static bool isOperand(char c)
        {
            // If the character is a digit
            // then it must be an operand
            if (c >= 48 && c <= 57)
                return true;
            else
                return false;
        }

        public static string evaluatePrefix(PreFix exprsn)
        {
            for (int j = exprsn.ToString().Length - 1; j >= 0; j--)
            {
                // Push operand to Stack
                // To convert exprsn[j] to digit subtract
                // '0' from exprsn[j].
                if (isOperand(exprsn.ToString()[j]))
                    stack.Push((double)(exprsn.ToString()[j] - 48));

                else
                {

                    // Operator encountered
                    // Pop two elements from Stack
                    double o1 = stack.Peek();
                    stack.Pop();
                    double o2 = stack.Peek();
                    stack.Pop();

                    // Use switch case to operate on o1
                    // and o2 and perform o1 O o2.
                    switch (exprsn.ToString()[j])
                    {
                        case '+':
                            var addCompiled = add.Compile();
                            stack.Push(addCompiled(o1, o2));
                            break;
                        case '-':
                            var subtractCompiled = subtract.Compile();
                            stack.Push(subtractCompiled(o1, o2));
                            break;
                        case '*':
                            var multiplyCompiled = multiply.Compile();
                            stack.Push(multiplyCompiled(o1, o2));
                            break;
                        case '/':
                            var divideCompiled = divide.Compile();
                            stack.Push(divideCompiled(o1, o2));
                            break;
                    }
                }
            }

            return stack.Peek().ToString();
        }

        public static string evaluatePostfix(PostFix exprsn)
        //evaluation method
        {
            for (int j = 0; j < exprsn.ToString().Length; j++)
            {
                // Push operand to Stack
                // To convert exprsn[j] to digit subtract
                // '0' from exprsn[j].
                if (isOperand(exprsn.ToString()[j]))
                    stack.Push((double)(exprsn.ToString()[j] - 48));

                else
                {
                    // Operator encountered
                    // Pop two elements from Stack
                    double o1 = stack.Peek();
                    stack.Pop();
                    double o2 = stack.Peek();
                    stack.Pop();

                    // Use switch case to operate on o1
                    // and o2 and perform o1 O o2.
                    switch (exprsn.ToString()[j])
                    {
                        case '+':
                            var addCompiled = add.Compile();
                            stack.Push(addCompiled(o2, o1));
                            break;
                        case '-':
                            var subtractCompiled = subtract.Compile();
                            stack.Push(subtractCompiled(o2, o1));
                            break;
                        case '*':
                            var multiplyCompiled = multiply.Compile();
                            stack.Push(multiplyCompiled(o2, o1));
                            break;
                        case '/':
                            var divideCompiled = divide.Compile();
                            stack.Push(divideCompiled(o2, o1));
                            break;
                    }
                }
            }

            return stack.Peek().ToString();
        }
    }
}

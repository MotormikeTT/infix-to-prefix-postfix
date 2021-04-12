using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project2_Group_16
{
    /// <summary>
    /// Evaluates the different types of expressions, either Prefix or Postfix and returns the result
    /// </summary>
    class ExpressionEvaluation
    {
        // Private Properties
        private static Stack<Expression> stack = new Stack<Expression>();

        // Helper method to tell if a character is an operand or not
        private static bool isOperand(char c)
        {
            // If the character is a digit
            // then it must be an operand
            if (c >= 48 && c <= 57)
                return true;
            else
                return false;
        }

        // Builds a binary expression from the 2 expressions and an operator
        private static Expression buildExpression(Expression a, Expression b, char op)
        {
            switch (op)
            {
                case '+':
                    return Expression.Add(a, b);
                case '-':
                    return Expression.Subtract(a, b);
                case '/':
                    return Expression.Divide(a, b);
                case '*':
                    return Expression.Multiply(a, b);
            }
            throw new NotSupportedException();
        }

        // Method to evaluate a Prefix Expression
        public static string Evaluate(PreFix exprsn)
        {
            for (int j = exprsn.ToString().Length - 1; j >= 0; j--)
            {
                // Push operand to Stack
                // To convert exprsn[j] to digit subtract
                // '0' from exprsn[j].
                if (isOperand(exprsn.ToString()[j]))
                    stack.Push(Expression.Constant((double)(exprsn.ToString()[j] - 48), typeof(double)));
                else
                {
                    // Operator encountered
                    // Pop two elements from Stack
                    Expression a = stack.Pop();
                    Expression b = stack.Pop();

                    // Use switch case to operate on o1
                    // and o2 and perform o1 O o2.
                    stack.Push(buildExpression(a, b, exprsn.ToString()[j]));
                }
            }

            var compiledExpression = Expression.Lambda<Func<double>>(stack.Peek()).Compile();
            return compiledExpression().ToString();
        }

        // Method to evaluate a Postfix Expression
        public static string Evaluate(PostFix exprsn)
        {
            for (int j = 0; j < exprsn.ToString().Length; j++)
            {
                // Push operand to Stack
                // To convert exprsn[j] to digit subtract
                // '0' from exprsn[j].
                if (isOperand(exprsn.ToString()[j]))
                    stack.Push(Expression.Constant((double)(exprsn.ToString()[j] - 48), typeof(double)));
                else
                {
                    // Operator encountered
                    // Pop two elements from Stack
                    Expression b = stack.Pop();
                    Expression a = stack.Pop();

                    // Use switch case to operate on o1
                    // and o2 and perform o1 O o2.
                    stack.Push(buildExpression(a, b, exprsn.ToString()[j]));
                }
            }
            var compiledExpression = Expression.Lambda<Func<double>>(stack.Peek()).Compile();
            return compiledExpression().ToString();
        }
    }
}

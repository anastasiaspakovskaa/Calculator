using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operations
{
    public class Operations
    {
        public static double Plus(double a, double b)
        {
            double result = a + b;

            if (double.IsInfinity(result))
                throw new OverflowException("The result is too large.");
            return result;
        }

        public static double Minus(double a, double b)
        {
            double result = a - b;

            if (double.IsInfinity(result))
                throw new OverflowException("The result is too large.");
            return result;
        }

        public static double Mul(double a, double b)
        {
            double result = a * b;

            if (double.IsInfinity(result))
                throw new OverflowException("The result is too large.");
            return result;
        }

        public static double Div(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Division by zero.");

            double result = a / b;

            if (double.IsInfinity(result))
                throw new OverflowException("The result is too large.");
            return result;
        }
    }
}

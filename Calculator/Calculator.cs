using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public Calculator()
        {
            Accumulator = 0;
        }

        public double Accumulator { get; private set; } = 0;

        public void Clear()
        {
            Accumulator = 0;
        }

        public double Add(double a, double b)
        {
            Accumulator = a + b;

            return a + b;
        }

        public double Subtract(double a, double b)
        {
            Accumulator = a - b;

            return a - b;
        }

        public double Divide(double a, double b)
        {
            Accumulator = a / b;

            return a / b;
        }

        public double Multiply(double a, double b)
        {
            Accumulator = a * b;

            return a * b;
        }

        public double Exp(double a, double b)
        {
            Accumulator = Math.Pow(a, b);

            return Math.Pow(a, b);
        }

        public double Fac(double a)
        {
            if (a <= 1)
            {
                return 1;
            }

            double result = a * Fac(a - 1);

            Accumulator = result;

            return result;
        }
    }
}

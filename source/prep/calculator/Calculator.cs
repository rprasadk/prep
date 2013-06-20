using System;

namespace prep.calculator
{
    public class Calculator
    {
        public int add(int x, int y)
        {
           if (Math.Sign(x) != Math.Sign(y))
               throw new ArgumentException();

            return x + y;
        }    
    }
}
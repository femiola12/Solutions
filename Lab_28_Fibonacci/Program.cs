using System;

namespace Lab_28_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        
    }

    public class Fiboncci
    {
        public int ReturnFibonciNthItemInSequence(int n)
        {

            int number = 0;
            int number2 = 1;


            for (int i = 0; i < n; i++)
            {
                int temp = number;
                number = number2;
                number2 = temp + number2;
            }

            return number;
        }
    }
}

using System;
using Client;

namespace Server
{
    public class Calculator : ICalculator
    {
        public int Add(int number1, int number2)
        {
            var add = number1 + number2;
            Console.Out.WriteLine("Service called with n1 = {0}, n2 = {1}, result = {2}", number1, number2, add);
            return add;
        }
    }
}
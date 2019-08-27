using System;
using System.Threading;

namespace CP05_DelegateSync {

    public class MathOperations {
        private const int Delay = 3000;

        public static decimal Addition(decimal first, decimal second) {
            Thread.Sleep(MathOperations.Delay);

            return first + second;
        }

        public static decimal Substraction(decimal first, decimal second) {
            Thread.Sleep(MathOperations.Delay);

            return first - second;
        }

        public static decimal Division(decimal first, decimal second) {
            Thread.Sleep(MathOperations.Delay);

            if (second == 0) {
                throw new ArgumentException("Divide by zero");
            }

            return first / second;
        }

        public static decimal Multiplication(decimal first, decimal second) {
            Thread.Sleep(MathOperations.Delay);

            return first * second;
        }
    }

}
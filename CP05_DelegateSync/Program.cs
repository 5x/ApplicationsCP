using System;
using System.Threading;

namespace CP05_DelegateSync {

    class Program {
        static void Main(string[] args) {
            int threadHashCode = Thread.CurrentThread.GetHashCode();
            Console.WriteLine("Main() in Thread {0}", threadHashCode);

            Calculator calculator = new Calculator(0);
            while (true) {
                char operationSymbol = Prompts.PromptOperationSymbol();
                MathOperationDelagate mathOperation =
                    Calculator.GetOperation(operationSymbol);
                decimal value = Prompts.PromtDecimalValue();
                decimal prevSum = calculator.Sum;

                try {
                    decimal sum = calculator.MakeOperation(mathOperation, value);
                    Console.WriteLine("{0} {1} {2} = {3}", prevSum,
                        operationSymbol, value, sum);
                } catch (ArgumentException e) {
                    Console.WriteLine("Error: {0}", e.Message);
                }
            }
        }
    }

}
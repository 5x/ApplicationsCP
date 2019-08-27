using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using CP05_DelegateSync;

namespace CP05_DelegateAsync {

    internal class Program {
        static void CalculatorCallback(IAsyncResult iarResult) {
            int threadHashCode = Thread.CurrentThread.GetHashCode();
            Console.WriteLine("{0}Prossess in Thread {1}",
                Environment.NewLine, threadHashCode);

            AsyncResult result = (AsyncResult) iarResult;
            if (result == null) {
                return;
            }

            var mathOperation = (CalculatorDelagate) result.AsyncDelegate;

            try {
                decimal sum = mathOperation.EndInvoke(iarResult);
                Console.WriteLine("Result({0}): {1}", iarResult.AsyncState, sum);
            } catch (ArgumentException e) {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        static void Main(string[] args) {
            int threadHashCode = Thread.CurrentThread.GetHashCode();
            Console.WriteLine("Main() in Thread {0}", threadHashCode);

            Calculator calculator = new Calculator(0);

            while (true) {
                char operationSymbol = Prompts.PromptOperationSymbol();
                var mathOperation = Calculator.GetOperation(operationSymbol);
                decimal value = Prompts.PromtDecimalValue();
                decimal prevSum = calculator.Sum;

                string statusMessage = String.Format("{0} {1} {2}",
                    prevSum, operationSymbol, value);
                CalculatorDelagate delagate = calculator.MakeOperation;

                delagate.BeginInvoke(
                    mathOperation, value,
                    CalculatorCallback, statusMessage
                );
            }
        }
    }

}
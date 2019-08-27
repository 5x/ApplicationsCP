using System;

namespace CP05_DelegateSync {

    public delegate decimal MathOperationDelagate(decimal first, decimal second);

    public delegate decimal CalculatorDelagate(
        MathOperationDelagate mathOperation, decimal value);

    public class Calculator {
        public decimal Sum { get; set; }

        public Calculator(decimal initalValue) {
            this.Sum = initalValue;
        }

        public decimal MakeOperation(MathOperationDelagate mathOperation,
            decimal value) {
            this.Sum = mathOperation(this.Sum, value);
            return this.Sum;
        }

        public static MathOperationDelagate GetOperation(char key) {
            switch (key) {
                case '+':
                    return MathOperations.Addition;
                case '-':
                    return MathOperations.Substraction;
                case '*':
                    return MathOperations.Multiplication;
                case '/':
                    return MathOperations.Division;
            }
            throw new ArgumentException("Selected operation not supported.");
        }
    }

}
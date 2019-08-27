using System;

namespace CP08_CustomAttribute {

    [Info("Simple Calculator implementation.")]
    [Review("@e426538", "Serhii Zarutskiy",
        "Brackets should be placed on the same line as the definition.")]
    [Review("@da0572f", "Typo in `Multiplication` method.")]
    public class Calculator {
        public static decimal Addition(decimal first, decimal second) {
            return first + second;
        }

        [Info("Substract from the first value the secondary.",
            "Serhii Zarutskiy", 1.1)]
        public static decimal Substraction(decimal first, decimal second) {
            return first - second;
        }

        [Review("@6c211c0", "Require check divide by zero.")]
        [Review("@b08c5a2", "Trow one of the default Exception type.",
            Revision = 2, Issues = "#210")]
        public static decimal Division(decimal first, decimal second) {
            if (second == 0) {
                throw new ArgumentException("Divide by zero");
            }

            return first / second;
        }

        public static decimal Multiplication(decimal first, decimal second) {
            return first * second;
        }
    }

}
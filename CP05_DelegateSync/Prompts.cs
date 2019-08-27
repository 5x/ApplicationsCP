using System;

namespace CP05_DelegateSync {

    public class Prompts {
        public static char PromptOperationSymbol() {
            Console.Write("> Select Math operation(+-/*): ");
            while (true) {
                var keyChar = Console.ReadKey(true).KeyChar;
                switch (keyChar) {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        Console.WriteLine(keyChar);
                        return keyChar;
                }
            }
        }

        public static decimal PromtDecimalValue() {
            Console.Write("> Value: ");
            string userInput = Console.ReadLine();

            try {
                return Convert.ToDecimal(userInput);
            } catch (FormatException) {
                return 0.0m;
            }
        }
    }

}
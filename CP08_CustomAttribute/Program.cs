using System;
using System.Reflection;

namespace CP08_CustomAttribute {

    class Program {
        static void PrintAttributes(ICustomAttributeProvider value) {
            foreach (Attribute attribute in value.GetCustomAttributes(false)) {
                Console.WriteLine(attribute.ToString());
                ReviewAttribute reviewAttribute = attribute as ReviewAttribute;

                if (reviewAttribute != null) {
                    Console.WriteLine(" + {0}: {1}", reviewAttribute.Commit,
                        reviewAttribute.Review);
                }

                InfoAttribute infoAttribute = attribute as InfoAttribute;
                if (infoAttribute != null) {
                    Console.WriteLine(" {0}", infoAttribute.Description);
                }
            }
        }

        static void Main(string[] args) {
            Console.WriteLine("Calculator class has next custom attributes:");
            Type tCalculator = typeof(Calculator);
            Program.PrintAttributes(tCalculator);

            foreach (MethodInfo method in tCalculator.GetMethods()) {
                Console.WriteLine("{0}{1} has next custom attributes:",
                    Environment.NewLine, method.Name);
                Program.PrintAttributes(method);
            }

            Console.ReadKey();
        }
    }

}
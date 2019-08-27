using System;
using System.Reflection;
using Server.Bank;

namespace CP01_DLL {

    internal class Program {
        private static void Main(string[] args) {
            Console.Title = "01.KPP1.2.1 DLL";

            const string customerName = "John Doe";
            Account bankAccount = new Account(customerName);

            const int depositeCount = 3;
            decimal depositeAmount = 123;
            for (int i = depositeCount; i > 0; i--) {
                depositeAmount *= i;
                bankAccount.Deposite(depositeAmount);

                Console.WriteLine("Client: {0} deposite: {1}$.", 
                    customerName, depositeAmount);
                Console.WriteLine("Server: {0} balance: {1}$.",
                    bankAccount.Owner, bankAccount.Balance);

                string serverDomainName = EnvInfo.GetDomainName();
                Console.WriteLine("Server: AppDomain = \"{0}\".\n",
                    serverDomainName);
            }

            string clientDomainName = AppDomain.CurrentDomain.FriendlyName;
            Console.WriteLine("Client: AppDomain = \"{0}\".", clientDomainName);
            Console.WriteLine("Server: Account methods:");

            Type accountClsType = bankAccount.GetType();
            MethodInfo[] methods = accountClsType.GetMethods();

            foreach (MethodInfo method in methods) {
                Console.WriteLine(method.ToString());
            }

            Type tAccount = typeof(Account);
            Assembly accountAssembly = Assembly.GetAssembly(tAccount);
            string accountAssemblyPath = EnvInfo.GetAssemblyPath(accountAssembly);
            Console.WriteLine("Account assembly location: {0}",
                accountAssemblyPath);

            Console.ReadKey();
        }
    }

}
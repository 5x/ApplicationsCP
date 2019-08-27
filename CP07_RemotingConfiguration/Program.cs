using System;
using System.Runtime.Remoting;
using CP03_RemoteHTTPServer;
using Server.Bank;

namespace CP07_RemotingConfiguration_Client {

    class Program {
        static void Main(string[] args) {
            RemotingConfiguration.Configure("CP07_RemotingConfiguration.exe.config", false);

            var types = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            foreach (var clientTypeEntry in types) {
                Console.WriteLine("AssemblyName: {0}", clientTypeEntry.AssemblyName);
                Console.WriteLine("ObjectType: {0}", clientTypeEntry.ObjectType);
                Console.WriteLine("TypeName: {0}", clientTypeEntry.TypeName);
            }

            IAccount bankAccount = new BankAccount();
            const int depositeCount = 3;
            decimal depositeAmount = 123;

            for (int i = depositeCount; i > 0; i--) {
                depositeAmount *= i;
                bankAccount.Deposite(depositeAmount);

                Console.WriteLine("Client: {0} deposite: {1}$.", bankAccount.Owner, depositeAmount);
                Console.WriteLine("Server: {0} balance: {1}$.", bankAccount.Owner, bankAccount.Balance);
            }

            Console.WriteLine("Client stop loop. Press any key to exit.");
            Console.ReadKey();
        }
    }

}
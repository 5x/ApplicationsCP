using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using Server.Bank;


namespace CP03_RemoteHTTPClient {

    internal class Program {
        static void Main(string[] args) {
            HttpChannel channel = new HttpChannel();
            const bool ensureSecurity = false;
            ChannelServices.RegisterChannel(channel, ensureSecurity);

            Type tAccount = typeof(IAccount);
            const string accountUri = @"http://localhost:8080/Account";

            IAccount bankAccount = (IAccount) Activator.GetObject(
                tAccount, accountUri, WellKnownObjectMode.Singleton);

            const int depositeCount = 3;
            decimal depositeAmount = 123;
            for (int i = depositeCount; i > 0; i--) {
                depositeAmount *= i;
                bankAccount.Deposite(depositeAmount);

                Console.WriteLine("Client: {0} deposite: {1}$.",
                    bankAccount.Owner, depositeAmount);
                Console.WriteLine("Server: {0} balance: {1}$.",
                    bankAccount.Owner, bankAccount.Balance);
            }

            string clientDomainName = AppDomain.CurrentDomain.FriendlyName;
            Console.WriteLine("Client: AppDomain = \"{0}\".", clientDomainName);

            Console.ReadKey();
        }
    }

}
using System;
using System.Runtime.Remoting.Channels.Http;

namespace CP04_RemoteHTTPClient {

    internal class Program {
        static void Main(string[] args) {
            string clientDomainName = AppDomain.CurrentDomain.FriendlyName;
            Console.WriteLine("Client: AppDomain = \"{0}\".", clientDomainName);

            HttpChannel chanel = HttpChanelProvider.Instance.Channel;
            Console.WriteLine("Used Channel name: {0}, priority: {1}",
                chanel.ChannelName, chanel.ChannelPriority);

            const string accountUrl = @"http://localhost:8080/Account";
            AccountService service = new AccountService(accountUrl);
            service.Loop();

            Console.WriteLine("Client stop loop. Press any key to exit.");
            Console.ReadKey();
        }
    }

}
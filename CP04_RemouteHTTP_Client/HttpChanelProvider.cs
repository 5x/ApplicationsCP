using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace CP04_RemoteHTTPClient {

    public sealed class HttpChanelProvider {
        public static HttpChanelProvider Instance { get; } = new HttpChanelProvider();

        public HttpChannel Channel { get; }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static HttpChanelProvider() {
        }

        private HttpChanelProvider() {
            this.Channel = new HttpChannel();
            const bool ensureSecurity = false;
            ChannelServices.RegisterChannel(this.Channel, ensureSecurity);
        }

        ~HttpChanelProvider() {
            ChannelServices.UnregisterChannel(this.Channel);
        }
    }

}
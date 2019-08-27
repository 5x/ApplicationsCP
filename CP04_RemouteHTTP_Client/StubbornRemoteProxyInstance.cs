using System.Threading;

namespace CP04_RemoteHTTPClient {

    abstract class StubbornRemoteProxyInstance<T> : RemoteProxyInstance<T> {
        private int failuresCount;

        protected StubbornRemoteProxyInstance(string url) : this(url, 5000, 3) {
        }

        protected StubbornRemoteProxyInstance(string url, int dalay,
            int failuresLimit) : base(url) {
            this.RetryTimeout = dalay;
            this.MaxFailuresCount = failuresLimit;
        }

        public int MaxFailuresCount { get; }

        public int RetryTimeout { get; }

        protected override object InvokeMethod(string methodName,
            params object[] arguments) {
            try {
                return base.InvokeMethod(methodName, arguments);
            } catch (ServiceUnavailableException) {
                this.ServiseTemponaryUnavailable();
                return this.InvokeMethod(methodName, arguments);
            }
        }

        protected override object GetProperty(string propertyName) {
            try {
                return base.GetProperty(propertyName);
            } catch (ServiceUnavailableException) {
                this.ServiseTemponaryUnavailable();
                return this.GetProperty(propertyName);
            }
        }

        protected void ServiseTemponaryUnavailable() {
            this.failuresCount++;

            if (this.IsReconnectLimitExceeded()) {
                this.failuresCount = 0;
                throw new ServiceUnavailableException();
            }

            Thread.Sleep(this.RetryTimeout);
        }

        protected bool IsReconnectLimitExceeded() {
            return (this.failuresCount >= this.MaxFailuresCount);
        }
    }

}
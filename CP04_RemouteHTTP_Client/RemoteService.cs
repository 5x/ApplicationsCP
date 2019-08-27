namespace CP04_RemoteHTTPClient {

    enum ServiceStatus {
        Active,
        Disabled,
    };

    abstract class RemoteService<T> where T : class {
        private RemoteService() {
            this.Status = ServiceStatus.Active;
        }

        protected RemoteService(T proxy) : this() {
            this.ProxyInstance = proxy;
        }

        public ServiceStatus Status { get; protected set; }

        protected T ProxyInstance { get; set; }

        public void Loop() {
            do {
                try {
                    this.NextTick();
                } catch (ServiceUnavailableException) {
                    this.StopServiceLoop();
                    this.ReportUnavailableService();
                }
            } while (this.Status.Equals(ServiceStatus.Active));
        }

        public void StopServiceLoop() {
            this.Status = ServiceStatus.Disabled;
        }

        protected abstract void NextTick();

        protected abstract void ReportUnavailableService();
    }

}
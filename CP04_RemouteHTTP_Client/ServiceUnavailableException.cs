using System;

namespace CP04_RemoteHTTPClient {

    class ServiceUnavailableException : Exception {
        public ServiceUnavailableException()
            : base("The service is unavailable. Try to retry the operation later.") {
        }

        public ServiceUnavailableException(string serviceName)
            : this(serviceName, "Try to retry the operation later.") {
        }

        public ServiceUnavailableException(string serviceName, string message)
            : base(String.Format("The service`{0}` is unavailable. {1}", serviceName, message)) {
        }

        public ServiceUnavailableException(string message, Exception inner)
            : base(message, inner) {
        }
    }

}
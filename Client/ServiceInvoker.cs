using System;

namespace Client
{
    public class ServiceInvoker<T> 
    {
        private readonly ServiceClientFactory serviceClientFactory;

        public ServiceInvoker(ServiceClientFactory serviceClientFactory)
        {
            this.serviceClientFactory = serviceClientFactory;
        }

        public virtual R Invoke<R>(Func<T, R> func)
        {
            var client = serviceClientFactory.CreateClient<T>();
            return func(client);
        }
    }
}
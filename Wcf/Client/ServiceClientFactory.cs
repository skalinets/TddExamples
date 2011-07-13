using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Client
{
    public class ServiceClientFactory
    {
        public virtual T CreateClient<T>() where T : class
        {
//            if (!(typeof(T).Equals(typeof(ICalculator))))
//            {
//                throw new NotImplementedException();
//            }
            var netTcpBinding = new NetTcpBinding();
            var endpointAddress = new EndpointAddress(Addresses.Calculator);
            return new ChannelFactory<T>(netTcpBinding, endpointAddress).CreateChannel();

        }
    }
}
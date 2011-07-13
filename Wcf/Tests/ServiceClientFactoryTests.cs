using System.ServiceModel;
using Client;
using Xunit;

namespace Test
{
    public class ServiceClientFactoryTests
    {
        [Fact]
        public void should_return_IClientChannel()
        {
            var serviceClientFactory = new ServiceClientFactory();
            
            var calculator = serviceClientFactory.CreateClient<ICalculator>();

            IClientChannel clientChannel = calculator as IClientChannel;
            Assert.NotNull(clientChannel);
        }

    }
}
using Client;
using Xunit;

namespace Test
{
    public class ServiceClientFactoryTests
    {
        [Fact]
        public void should_return_CalculatorClient_for_ICalculator()
        {
            var serviceClientFactory = new ServiceClientFactory();
            
            var calculator = serviceClientFactory.CreateClient<ICalculator>();

            Assert.IsType<CalculatorClient>(calculator);
        }

    }
}
using Client;
using Microsoft.Practices.Unity;
using Xunit;

namespace Test
{
    public class AdHocTests
    {
        [Fact(Skip = "Will fail if service is not started. To start service -- run Service project.")]
        public void IntegrationTestOfFactory()
        {
            var calculator = new ServiceClientFactory().CreateClient<ICalculator>();
            calculator.Add(4, 5);
            calculator.Add(40, 50);
            calculator.Add(1, 8);
        }
        
        [Fact(Skip = "Will fail if service is not started. To start service -- run Service project.")]
        public void IntegrationTestOfConsumer()
        {
            UnityContainer container = new UnityContainer();
            container.Resolve<ServiceConsumer>().GetAddResultFor(3, 5);
        }

    }
}
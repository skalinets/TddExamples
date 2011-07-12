using System;
using Client;
using Rhino.Mocks;
using Xunit;

namespace Test
{
    public class ServiceInvokerTests
    {
        public interface IFoo
        {
            int Boo();
        }

        [Fact]
        public void should_take_service_client_from_factory()
        {
            int expected = Guid.NewGuid().GetHashCode();
            var fooClient = MockRepository.GenerateStub<IFoo>();
            fooClient.Stub(_ => _.Boo()).Return(expected);
            var serviceClientFactory = MockRepository.GenerateStub<ServiceClientFactory>();
            serviceClientFactory.Stub(_ => _.CreateClient<IFoo>()).Return(fooClient);
            var serviceInvoker = new ServiceInvoker<IFoo>(serviceClientFactory);

            var actual = serviceInvoker.Invoke(_ => _.Boo());

            Assert.Equal(expected, actual);
        }
    }
}
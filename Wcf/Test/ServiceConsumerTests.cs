using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;
using Xunit;
using Xunit.Extensions;

namespace Test
{
    public class ServiceConsumerTests
    {
        private readonly ServiceClientFactory fakeServiceClientFactory = MockRepository.GenerateStub<ServiceClientFactory>();

        [Theory]
        [InlineData(342, 31129, 3456)]
        public void should_call_service_invoker_and_return_result(int number1, int number2, int expected)
        {
            var calculator = MockRepository.GenerateStub<ICalculator>();
            calculator.Stub(_ => _.Add(number1, number2)).Return(expected);
            var serviceInvoker = MockRepository.GenerateStub<ServiceInvoker<ICalculator>>(fakeServiceClientFactory);
            serviceInvoker
                .Stub(_ => _.Invoke(Arg<Func<ICalculator, int>>.Matches(d => d(calculator) == calculator.Add(number1, number2))))
                .Return(expected);
            var serviceConsumer = new ServiceConsumer(serviceInvoker);

            var actual = serviceConsumer.GetAddResultFor(number1, number2);

            Assert.Equal(expected, actual);
        }
    }

    public class ServiceInvokerTests
    {
        public interface IFoo
        {
            int Boo();
        }

        [Fact]
        public void should_take_service_client_from_factory()
        {
            var serviceClientFactory = MockRepository.GenerateStub<ServiceClientFactory>();
            var fooClient = MockRepository.GenerateStub<IFoo>();
            int expected = Guid.NewGuid().GetHashCode();
            fooClient.Stub(_ => _.Boo()).Return(expected);
            serviceClientFactory.Stub(_ => _.CreateClient<IFoo>()).Return(fooClient);
            var serviceInvoker = new ServiceInvoker<IFoo>(serviceClientFactory);

            var actual = serviceInvoker.Invoke(_ => _.Boo());

            Assert.Equal(expected, actual);
        }
    }
}
   

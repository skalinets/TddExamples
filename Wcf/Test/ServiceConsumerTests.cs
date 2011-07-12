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
        [Theory]
        [InlineData(342, 31129, 3456)]
        public void should_call_wcf_service_and_return_result(int number1, int number2, int expected)
        {
            var calculator = MockRepository.GenerateStub<ICalculator>();
            calculator.Stub(_ => _.Add(number1, number2)).Return(expected);
            var serviceInvoker = MockRepository.GenerateStub<ServiceInvoker<ICalculator>>();
            serviceInvoker
                .Stub(_ => _.Invoke(Arg<Func<ICalculator, int>>.Matches(d => d(calculator) == calculator.Add(number1, number2))))
                .Return(expected);
            var serviceConsumer = new ServiceConsumer(serviceInvoker);

            var actual = serviceConsumer.GetAddResultFor(number1, number2);

            Assert.Equal(expected, actual);
        }
    }
}
   

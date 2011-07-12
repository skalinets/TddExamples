using Client;

namespace Test
{
    public class ServiceConsumer
    {
        private readonly ServiceInvoker<ICalculator> serviceInvoker;

        public ServiceConsumer(ServiceInvoker<ICalculator> serviceInvoker)
        {
            this.serviceInvoker = serviceInvoker;
        }

        public int GetAddResultFor(int number1, int number2)
        {
            return serviceInvoker.Invoke(_ => _.Add(number1, number2));
        }
    }
}
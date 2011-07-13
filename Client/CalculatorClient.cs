using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Client
{
    public class CalculatorClient  : ClientBase<ICalculator>, ICalculator
    {
        public CalculatorClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
        {
        }

        public int Add(int number1, int number2)
        {
            return Channel.Add(number1, number2);
        }
    }
}
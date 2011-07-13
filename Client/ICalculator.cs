using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Client
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        int Add(int number1, int number2);
    }
}

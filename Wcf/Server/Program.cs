using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Client;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceHost = new ServiceHost(typeof(Calculator), new Uri(Addresses.Calculator));
            serviceHost.AddDefaultEndpoints();
//            serviceHost.AddServiceEndpoint(typeof (ICalculator), new NetTcpBinding(), Addresses.Calculator);
            serviceHost.Open();
            Console.Out.WriteLine("Service started... Press any key to close.");
            Console.ReadKey();
        }
    }
}

using System;

namespace Client
{
    public  class ServiceClientFactory
    {
        public virtual T CreateClient<T>(){ throw new NotImplementedException();}
    }
}
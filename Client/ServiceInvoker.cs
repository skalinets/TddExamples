using System;

namespace Client
{
    public class ServiceInvoker<T> 
    {
        public virtual R Invoke<R>(Func<T, R> func)
        {
            throw new NotImplementedException();
        }
    }
}
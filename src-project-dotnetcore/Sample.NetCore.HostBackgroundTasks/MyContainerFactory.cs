using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.NetCore.HostBackgroundTasks
{
    internal class MyContainerFactory : IServiceProviderFactory<MyContainer>
    {
        public MyContainer CreateBuilder(IServiceCollection services)
        {
            return new MyContainer();
        }

        public IServiceProvider CreateServiceProvider(MyContainer containerBuilder)
        {
            throw new NotImplementedException();
        }
    }
}

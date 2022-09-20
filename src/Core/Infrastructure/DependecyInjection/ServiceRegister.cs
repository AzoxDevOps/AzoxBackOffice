namespace Azox.Infrastructure.Core.DependecyInjection
{
    using Azox.Business.Core.Service;
    using Azox.Core.DependencyInjection;
    using Azox.Core.Reflection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            ITypeFinder typeFinder = new TypeFinder();

            foreach (Type entityServiceInterfaceType in typeFinder.FindInterfacesOf<IEntityService>())
            {
                if (entityServiceInterfaceType.ContainsGenericParameters)
                {
                    continue;
                }

                foreach (Type entityServiceImplType in typeFinder.FindClassesOf(entityServiceInterfaceType))
                {
                    services.AddScoped(entityServiceInterfaceType, entityServiceImplType);
                }
            }
        }
    }
}

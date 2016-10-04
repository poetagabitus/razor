using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Razor.Domain;

namespace Razor.Infrastructure
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public DependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<ProductRepository>().InSingletonScope();
            kernel.Bind<IOrderProcessor>().To<OrderProcessor>().InSingletonScope();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
            kernel.Dispose();
        }
    }
}
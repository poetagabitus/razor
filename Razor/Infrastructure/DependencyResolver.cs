using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Razor.Domain;
using Razor.Infrastructure.Abstract;
using Razor.Infrastructure.Concrete;

namespace Razor.Infrastructure
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public DependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            _kernel.Bind<IProductRepository>().To<ProductRepository>().InSingletonScope();
            _kernel.Bind<IOrderProcessor>().To<OrderProcessor>().InSingletonScope();
            _kernel.Bind<IAuthProvider>().To<FormsAuthProvider>().InSingletonScope();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
            _kernel.Dispose();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Windsor;

namespace AutoMapperProfiles.Web
{
    public class WindsorDependencyResolver : IDependencyResolver
    {
        #region IDependencyResolver Members

        private readonly IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            this._container = container;
        }

        public object GetService(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.ResolveAll(serviceType).Cast<object>() : new object[] { };
        }

        #endregion
    }
}
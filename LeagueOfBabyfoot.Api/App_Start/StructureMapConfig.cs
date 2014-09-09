using JEB.BootStrap;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueOfBabyfoot.Api
{
	public class StructureMapBootstrapper : IBootstrapperTask
	{
		public void Execute()
		{
			DependencyResolver.SetResolver(new StructureMapDependencyResolver());
		}
	}

	public class StructureMapDependencyResolver : IDependencyResolver
	{
		IContainer _container;

		public StructureMapDependencyResolver()
		{
			_container = ObjectFactory.Container;
		}

		public object GetService(Type serviceType)
		{
			object instance = _container.TryGetInstance(serviceType);

			if (instance == null && !serviceType.IsAbstract)
			{
				_container.Configure(c => c.AddType(serviceType, serviceType));
				instance = _container.TryGetInstance(serviceType);
			}

			return instance;
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return _container.GetAllInstances(serviceType).Cast<object>();
		}
	}
}
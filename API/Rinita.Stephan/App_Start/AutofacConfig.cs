﻿using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Rinita.Stephan.Helpers;
using Rinita.Stephan.Wrappers;

namespace Rinita.Stephan
{
	public static class AutofacConfig
	{
		public static void Start()
		{
			// Autofac Configuration
			var builder = new ContainerBuilder();

			// Register 
			builder.RegisterType<EntityWrapper>().As<IEntityWrapper>();
			builder.RegisterType<PostHelper>().As<IPostHelper>();
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			// Get your HttpConfiguration.
			var config = GlobalConfiguration.Configuration;

			// Register your Web API controllers.
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			// OPTIONAL: Register the Autofac filter provider.
			builder.RegisterWebApiFilterProvider(config);

			// Set the dependency resolver to be Autofac.
			var container = builder.Build();
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}
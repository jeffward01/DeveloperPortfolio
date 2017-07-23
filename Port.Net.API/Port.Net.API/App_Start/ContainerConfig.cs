using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Port.Net.Business.Managers;
using Port.Net.Data.Infrastructure;
using Port.Net.Data.Providers;
using Port.Net.Data.Repositories;

namespace Port.Net.API
{
    public class ContainerConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(ContainerConfig).Assembly).InstancePerLifetimeScope();
            //This registers 'A'
            builder.RegisterAssemblyModules(typeof(ContainerConfig).Assembly);

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
    //This is 'A'
    public class RegisterServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Add Interfaces here
     
            //____DbContext____
            builder.RegisterType<PortfolioContext>().As<IPortfolioContext>().InstancePerLifetimeScope();

            //___Managers____

            builder.RegisterType<GithubManager>().As<IGithubManager>();
            builder.RegisterType<ProjectImageManager>().As<IProjectImageManager>();
            builder.RegisterType<ProjectManager>().As<IProjectManager>();
            builder.RegisterType<ProjectTechnologyManager>().As<IProjectTechnologyManager>();


            
            //___Providers____
            builder.RegisterType<HttpProvider>().As<IHttpProvider>();
            builder.RegisterType<GithubProvider>().As<IGithubProvider>();



            //____Services____


            //____Repositories____
            builder.RegisterType<AuthRepository>().As<IAuthRepository>();
            builder.RegisterType<ProjectRepository>().As<IProjectRepository>();
            builder.RegisterType<ProjectTechnologyRepository>().As<IProjectTechnologyRepository>();
            builder.RegisterType<ProjectImageRepository>().As<IProjectImageRepository>();



            //Lookup Tables

            base.Load(builder);
        }
    }
}
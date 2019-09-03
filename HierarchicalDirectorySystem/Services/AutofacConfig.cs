using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using HierarchicalDirectorySystem;
using HierarchicalDirectorySystem.Core.Context;
using HierarchicalDirectorySystem.Services;
using System.Data.SqlClient;
using System.Web.Mvc;

public class AutofacConfig
{
    public static void ConfigureContainer()
    {
        var builder = new ContainerBuilder();

        builder.RegisterControllers(typeof(MvcApplication).Assembly);

        //register db context
        var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DirectorySystem"].ConnectionString;
        builder.Register(_ => new DirectorySystemContext(connectionString));

        RegisterTypes(builder);

        var container = builder.Build();

        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }

    public static void RegisterTypes(ContainerBuilder builder)
    {
        builder.RegisterType<NodesService>().AsSelf();
    }
}
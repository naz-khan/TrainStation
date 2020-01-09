using System;
using Autofac;

namespace TrainStation
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<StationFinder>().As<IStationFinder>();
            builder.RegisterType<Application>().As<IApplication>();
            return builder.Build();
        }
    }
}

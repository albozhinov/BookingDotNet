using Autofac;
using Hotel.Commands.Contracts;
using Hotel.Commands.Creating;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using Hotel.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Hotel.Core.InjectionLogic
{
    public class InjectorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            this.RegisterCoreComponents(builder);
            this.RegisterCommands(builder);
            base.Load(builder);
        }

        private void RegisterCoreComponents(ContainerBuilder builder)
        {
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            builder.RegisterType<HotelFactory>().As<IHotelFactory>().SingleInstance();
            builder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
            builder.RegisterType<CommandParser>().As<IParser>().SingleInstance();
            builder.RegisterType<CommandProcessor>().As<IProcessor>().SingleInstance();
        }

        private void RegisterCommands(ContainerBuilder builder)
        {
            //Thanks General
            var assembly = Assembly.GetAssembly(typeof(InquiryCommand));
            var commandTypeInfos = assembly.DefinedTypes
                    .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                    .Where(type => type.Name.ToLower().EndsWith("command"));

            foreach (var commandType in commandTypeInfos)
            {
                builder
                    .RegisterType(commandType.UnderlyingSystemType)
                    .Named<ICommand>(commandType.Name.ToLower().Replace("command", string.Empty))
                    .SingleInstance();
            }
        }
    }
}

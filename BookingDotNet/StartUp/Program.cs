using HotelManagement.Common;
using HotelManagement.Contracts;
using HotelManagement.Models;
using System;
using System.Globalization;
using System.Linq;
using UserManagement.Models;
using Utility;
using Hotel;
using Autofac;
using System.Reflection;
using Hotel.Core.InjectionLogic;
using Hotel.Core.Contracts;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetAssembly(typeof(InjectorModule)));

            var container = builder.Build();
            var engine = container.Resolve<IEngine>();
            engine.Start();

        }
    }
}

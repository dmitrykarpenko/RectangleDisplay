// ----------------------------------------------------------------------------
// <copyright file="Program.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment.Web
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using StartupConfig;

    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            // could specify config file this way, see:
            // https://www.billbogaiv.com/posts/setting-aspnet-host-address-in-net-core-2

            //var config = new ConfigurationBuilder()
            //    .AddJsonFile(@"appsettings.json", optional: true)
            //    .AddCommandLine(args)
            //    .Build();

            return WebHost.CreateDefaultBuilder(args)
                //.UseConfiguration(config)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
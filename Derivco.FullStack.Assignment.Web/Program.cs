// ----------------------------------------------------------------------------
// <copyright file="Program.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment.Web
{
  using Microsoft.AspNetCore;
  using Microsoft.AspNetCore.Hosting;
  using StartupConfig;

  public class Program
  {
    public static void Main(string[] args)
    {
      BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
             .UseStartup<Startup>()
             .Build();
  }
}
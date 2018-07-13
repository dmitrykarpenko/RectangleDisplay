// ----------------------------------------------------------------------------
// <copyright file="DependencyInjectionConfig.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment.Web.StartupConfig
{
  using AutoMapper;
  using Microsoft.Extensions.DependencyInjection;
  using ViewModels;

  public static class DependencyInjectionConfig
  {
    public static void AddAutoMapper(this IServiceCollection services)
    {
      MapperConfiguration config = CreateAutoMapperConfig();
      services.Add(new ServiceDescriptor(typeof(IMapper), config.CreateMapper()));
    }

    public static void AddSolutionCalculator(this IServiceCollection services)
    {
      services.Add(new ServiceDescriptor(typeof(ISolutionCalculator), typeof(SolutionCalculator), ServiceLifetime.Transient));
    }

    public static void AddRectangleGenerator(this IServiceCollection services)
    {
      services.Add(new ServiceDescriptor(typeof(IRectangleGenerator), new RectangleGenerator(1, 10, 1, 30)));
    }

    internal static MapperConfiguration CreateAutoMapperConfig()
    {
      return new MapperConfiguration(
        cfg =>
        {
          cfg.CreateMap<Rectangle, RectangleViewModel>();
          cfg.CreateMap<Solution, SolutionViewModel>();
        });
    }
  }
}
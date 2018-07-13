// ----------------------------------------------------------------------------
// <copyright file="AutoMapperTest.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment.Web.Tests.StartupConfig
{
  using System.Collections.Generic;
  using System.Diagnostics.CodeAnalysis;
  using AutoMapper;
  using FluentAssertions;
  using Microsoft.Extensions.DependencyInjection;
  using NUnit.Framework;
  using Web.StartupConfig;

  [TestFixture]
  [ExcludeFromCodeCoverage]
  [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Test methods.")]
  public class DependencyInjectionTest
  {
    private class ServicesCollectionStub : List<ServiceDescriptor>, IServiceCollection
    {
    }

    [Test]
    public void AddAutoMapper_ShouldAddIMapperService()
    {
      // Arrange
      var services = new ServicesCollectionStub();

      // Act
      services.AddAutoMapper();

      // Assert
      services.Should().Contain(x => x.Lifetime == ServiceLifetime.Singleton && x.ServiceType == typeof(IMapper));
    }

    [Test]
    public void AddSolutionCalculator_ShouldAddsISolutionCalculatorService()
    {
      // Arrange
      var services = new ServicesCollectionStub();

      // Act
      services.AddSolutionCalculator();

      // Assert
      services.Should().Contain(x => x.Lifetime == ServiceLifetime.Transient && x.ServiceType == typeof(ISolutionCalculator));
    }

    [Test]
    public void AddRectangleGenerator_ShouldAddsIRectangleGeneratorService()
    {
      // Arrange
      var services = new ServicesCollectionStub();

      // Act
      services.AddRectangleGenerator();

      // Assert
      services.Should().Contain(x => x.Lifetime == ServiceLifetime.Singleton && x.ServiceType == typeof(IRectangleGenerator));
    }
  }
}
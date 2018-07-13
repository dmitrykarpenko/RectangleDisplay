using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace Derivco.FullStack.Assignment.Web.Tests.StartupConfig
{
  using AutoMapper;
  using Web.StartupConfig;

  [TestFixture]
  [ExcludeFromCodeCoverage]
  [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Test methods.")]
  public class AutoMapperTest
  {
    [Test]
    public void AutoMapperConfig_ShouldBeValid()
    {
      // Arrange
      MapperConfiguration config = DependencyInjectionConfig.CreateAutoMapperConfig();

      // Act & Assert
      config.AssertConfigurationIsValid();
    }
  }
}
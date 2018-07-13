// ----------------------------------------------------------------------------
// <copyright file="RectangleTest.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment.Tests
{
  using System.Collections.Generic;
  using System.Diagnostics.CodeAnalysis;
  using FluentAssertions;
  using NUnit.Framework;
  using Ploeh.AutoFixture;

  [TestFixture]
  [ExcludeFromCodeCoverage]
  [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Test methods.")]
  public class RectangleGeneratorTest
  {
    [SetUp]
    public void SetUp()
    {
      _fixture = new Fixture();
      _fixture.Customizations.Add(new RandomNumericSequenceGenerator(1, 500));
    }

    private Fixture _fixture;

    [Test]
    public void GenerateRandomRectangles_GivenCount_ShouldGenerateCountNonEmptyRectangles()
    {
      // Arrange
      var generator = new RectangleGenerator(1, 20, 1, 20);
      int count = _fixture.Create<int>();

      // Act
      IList<Rectangle> rectangles = generator.GenerateRandomRectangles(count);

      // Assert
      rectangles.Count.Should().Be(count);
      foreach (Rectangle rect in rectangles)
      {
        rect.Width.Should().BeGreaterThan(0);
        rect.Height.Should().BeGreaterThan(0);
      }
    }
  }
}
// ----------------------------------------------------------------------------
// <copyright file="SolutionCalculatorTest.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment.Tests
{
  using System.Collections.Generic;
  using System.Diagnostics.CodeAnalysis;
  using FluentAssertions;
  using NUnit.Framework;

  [TestFixture]
  [ExcludeFromCodeCoverage]
  [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Test methods.")]
  public class SolutionCalculatorTest
  {
    [Test]
    public void Calculate_GivenRectangles_ShouldCalculateCorrectSolution()
    {
      // Arrange
      var calculator = new SolutionCalculator();
      var inputRectangles = new List<Rectangle>
      {
        new Rectangle(2, 3),
        new Rectangle(2, 2)
      };
      var expected = new Rectangle(4, 2);

      // Act
      Solution solution = calculator.Calculate(inputRectangles);

      // Assert
      solution.InputRectangles.ShouldAllBeEquivalentTo(inputRectangles);
      solution.OutputRectangles.Count.Should().Be(1);
      solution.OutputRectangles[0].ShouldBeEquivalentTo(expected);
    }
  }
}
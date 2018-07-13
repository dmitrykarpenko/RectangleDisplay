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
                new Rectangle(2, 2, 2) // should not overlap
            };
            var expected = new Rectangle(4, 2);

            // Act
            Solution solution = calculator.Calculate(inputRectangles);

            // Assert
            solution.InputRectangles.ShouldAllBeEquivalentTo(inputRectangles);
            solution.OutputRectangles.Count.Should().Be(2);
            solution.OutputRectangles[0].ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Calculate_GivenThreeRectangles_ShouldCalculateCorrectSolution()
        {
            // Arrange
            var calculator = new SolutionCalculator();
            var inputRectangles = new List<Rectangle>
            {
                new Rectangle(2, 3, 0, 0),
                new Rectangle(2, 2, 2, 0),
                new Rectangle(4, 8, 4, 0),
            };
            var expected = new Rectangle(8, 2);

            // Act
            Solution solution = calculator.Calculate(inputRectangles);

            // Assert
            solution.InputRectangles.ShouldAllBeEquivalentTo(inputRectangles);
            solution.OutputRectangles.Count.Should().Be(3);
            solution.OutputRectangles[0].ShouldBeEquivalentTo(expected);
        }
    }
}
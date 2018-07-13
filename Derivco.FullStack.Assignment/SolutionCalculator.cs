// ----------------------------------------------------------------------------
// <copyright file="SolutionCalculator.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment
{
  using System.Collections.Generic;

  public class SolutionCalculator : ISolutionCalculator
  {
    #region ISolutionCalculator implementation
    public Solution Calculate(IList<Rectangle> inputRectangles)
    {
      return new Solution
      {
        InputRectangles = inputRectangles,
        OutputRectangles = CalculateSolution(inputRectangles)
      };
    }
    #endregion

    private static IList<Rectangle> CalculateSolution(IList<Rectangle> inputRectangles)
    {
      // TODO: "Rotate" the input rectangles here.
      return inputRectangles;
    }
  }
}
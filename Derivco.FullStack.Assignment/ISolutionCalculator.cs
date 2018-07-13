// ----------------------------------------------------------------------------
// <copyright file="ISolutionCalculator.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment
{
  using System.Collections.Generic;

  public interface ISolutionCalculator
  {
    Solution Calculate(IList<Rectangle> inputRectangles);
  }
}
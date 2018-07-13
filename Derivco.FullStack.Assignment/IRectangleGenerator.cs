// ----------------------------------------------------------------------------
// <copyright file="IRectangleGenerator.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment
{
  using System.Collections.Generic;

  public interface IRectangleGenerator
  {
    IList<Rectangle> GenerateRandomRectangles(int count);
  }
}
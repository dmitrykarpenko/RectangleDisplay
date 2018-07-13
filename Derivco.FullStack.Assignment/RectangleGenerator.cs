// ----------------------------------------------------------------------------
// <copyright file="RectangleGenerator.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class RectangleGenerator : IRectangleGenerator
  {
    public RectangleGenerator(int minWidth, int maxWidth, int minHeight, int maxHeight)
    {
      _minWidth = minWidth;
      _maxWidth = maxWidth;

      _maxHeight = maxHeight;
      _minHeight = minHeight;
    }

    #region IRectangleGenerator implementation
    public IList<Rectangle> GenerateRandomRectangles(int count)
    {
      var random = new Random(Environment.TickCount);
      List<Rectangle> rectangles = Enumerable.Range(1, count)
                                             .Select(_ => new Rectangle(random.Next(_minWidth, _maxWidth), random.Next(_minHeight, _maxHeight)))
                                             .ToList();
      for (int i = 1; i < rectangles.Count; i++)
      {
        Rectangle previous = rectangles[i - 1];
        Rectangle current = rectangles[i];
        current.Left = previous.Left + previous.Width;
      }
      return rectangles;
    }
    #endregion

    private readonly int _minWidth;
    private readonly int _maxWidth;
    private readonly int _minHeight;
    private readonly int _maxHeight;
  }
}
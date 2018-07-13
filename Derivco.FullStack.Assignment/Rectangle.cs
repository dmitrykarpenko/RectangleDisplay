// ----------------------------------------------------------------------------
// <copyright file="Rectangle.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment
{
  public class Rectangle
  {
    public Rectangle()
    {
    }

    public Rectangle(int width, int height, int left = 0, int bottom = 0)
    {
      Left = left;
      Bottom = bottom;
      Width = width;
      Height = height;
    }

    public int Left { get; set; }
    public int Bottom { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
  }
}
// ----------------------------------------------------------------------------
// <copyright file="SolutionViewModel.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment.Web.ViewModels
{
  using System.Collections.Generic;

  public class SolutionViewModel
  {
    public IList<RectangleViewModel> InputRectangles { get; set; }
    public IList<RectangleViewModel> OutputRectangles { get; set; }
  }
}
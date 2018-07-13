// ----------------------------------------------------------------------------
// <copyright file="ErrorViewModel.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment.Web.Models
{
  public class ErrorViewModel
  {
    public string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
  }
}
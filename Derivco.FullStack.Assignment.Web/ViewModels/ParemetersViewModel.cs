// ----------------------------------------------------------------------------
// <copyright file="ParemetersViewModel.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ParemetersViewModel
    {
        [Display(Name = "Rectangle Count")]
        [Range(1, 9000, ErrorMessage = "Please specify a number that is positive and not over 9000")]
        public int RectangleCount { get; set; }
    }
}
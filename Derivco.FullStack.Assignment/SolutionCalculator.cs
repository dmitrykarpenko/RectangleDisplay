// ----------------------------------------------------------------------------
// <copyright file="SolutionCalculator.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        private IList<Rectangle> _outputRectangles;

        private IList<Rectangle> CalculateSolution(IList<Rectangle> inputRectangles)
        {
            _outputRectangles = new List<Rectangle>();
            RotateRectangles(inputRectangles.ToArray(), inputRectangles[0].Bottom);
            return _outputRectangles;
        }

        private void RotateRectangles(
            Rectangle[] inputRectangles,
            int currentGroundBottom)
        {
            var rectanglesInfo = FindIndexOfWithMinHeight(inputRectangles);

            var horizontalRectangle = CreateHorizontalReatangle(
                inputRectangles, rectanglesInfo, currentGroundBottom);

            // side effects - adding results to the collection
            _outputRectangles.Add(horizontalRectangle);

            var iMin = rectanglesInfo.IMin;

            var leftInputs = SubArray(inputRectangles, 0, rectanglesInfo.IMin);
            var rightInputs = SubArray(inputRectangles,
                iMin + 1,
                inputRectangles.Length - 1 - iMin);

            var nextCurrentGroundBottom = inputRectangles[iMin].Height;

            if (leftInputs.Length > 0)
                RotateRectangles(leftInputs, nextCurrentGroundBottom);

            if (rightInputs.Length > 0)
                RotateRectangles(rightInputs, nextCurrentGroundBottom);
        }

        private class RectanglesInfo
        {
            public int IMin { get; set; }
            public int TotalWidth { get; set; }
        }

        private static RectanglesInfo FindIndexOfWithMinHeight(Rectangle[] inputRectangles)
        {
            var iMin = 0;
            var totalWidth = inputRectangles[0].Width;

            for (int i = 1; i < inputRectangles.Length; ++i)
            {
                if (inputRectangles[i].Height < inputRectangles[iMin].Height)
                {
                    iMin = i;
                }
                totalWidth += inputRectangles[i].Width;
            }
            return new RectanglesInfo { IMin = iMin, TotalWidth = totalWidth };
        }

        private Rectangle CreateHorizontalReatangle(
            Rectangle[] inputRectangles,
            RectanglesInfo rectanglesInfo,
            int currentGroundBottom)
        {
            //var right = inputRectangles[0].Left + rectanglesInfo.TotalWidth;
            //var top = inputRectangles[0].Bottom + rectanglesInfo.IMin;

            return new Rectangle
            {
                Left = inputRectangles[0].Left,
                Bottom = inputRectangles[0].Bottom + currentGroundBottom,
                Width = rectanglesInfo.TotalWidth,
                Height = inputRectangles[rectanglesInfo.IMin].Height - currentGroundBottom,
            };
        }


        public static T[] SubArray<T>(T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
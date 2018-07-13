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

        // the algorithm can be made concurrent
        // by making this collection concurrent
        private IList<Rectangle> _outputRectangles;

        private IList<Rectangle> CalculateSolution(IList<Rectangle> inputRectangles)
        {
            _outputRectangles = new List<Rectangle>();

            RotateRectangles(inputRectangles.ToArray(), inputRectangles[0].Bottom);
 
            return _outputRectangles;
        }

        /// <summary>
        /// Creates rotated rectangles and assigns them to _outputRectangles.
        /// The algorithm's idea is similar to QuickSort:
        /// 1. do a linear operation, find a wanted element index;
        /// 2. run the same process for the left and the right part (in regards to the wanted element);
        /// 3. stop when there are no elements in the parts.
        /// 
        /// We do O(n) operations (where n is the length of the current inputRectangles) on each recursion calls,
        /// depth of the stack is O(log(n)) (where n is the length of the initial inputRectangles).
        /// Thus, the whole algorithm is of O(nlog(n)) time complexity.
        /// 
        /// Space complexity is O(n) as we at least have to hold the collection of results.
        /// 
        /// The algorithm can be improved by passing first/last indices
        /// instead of creating leftInputs and rightInputs
        /// and holding initial inputRectangles in a class field.
        /// </summary>
        /// <param name="inputRectangles">
        /// Is of type array in order to use Array.Copy later on
        /// </param>
        private void RotateRectangles(
            Rectangle[] inputRectangles,
            int currentGroundBottom)
        {
            var rectanglesInfo = FindIndexOfWithMinHeight(inputRectangles);

            var horizontalRectangle = CreateHorizontalReatangle(
                inputRectangles, rectanglesInfo, currentGroundBottom);

            // if not a degenerate case, add a result to the collection
            // (i.e. the RotateRectangles' side effect)
            if (horizontalRectangle.Height > 0)
                _outputRectangles.Add(horizontalRectangle);

            var iMin = rectanglesInfo.IMin;
            var nextCurrentGroundBottom = inputRectangles[iMin].Height;

            var leftsLength = iMin;
            if (leftsLength > 0)
            {
                var leftInputs = SubArray(inputRectangles,
                    0, leftsLength);

                RotateRectangles(leftInputs, nextCurrentGroundBottom);
            }

            var rightsLength = inputRectangles.Length - 1 - iMin;
            if (rightsLength > 0)
            {
                var rightInputs = SubArray(inputRectangles,
                    iMin + 1, rightsLength);

                RotateRectangles(rightInputs, nextCurrentGroundBottom);
            }
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
                int currentGroundBottom) =>
            new Rectangle
            {
                Left = inputRectangles[0].Left,
                Bottom = inputRectangles[0].Bottom + currentGroundBottom,
                Width = rectanglesInfo.TotalWidth,
                Height = inputRectangles[rectanglesInfo.IMin].Height - currentGroundBottom,
            };

        public static T[] SubArray<T>(T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
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

        private IList<Rectangle> _inputRectangles;

        // the algorithm can be made concurrent
        // by making this collection concurrent
        private IList<Rectangle> _outputRectangles;

        private IList<Rectangle> CalculateSolution(IList<Rectangle> inputRectangles)
        {
            _inputRectangles = inputRectangles;
            _outputRectangles = new List<Rectangle>();

            RotateRectanglesRecursive(0, _inputRectangles.Count - 1, inputRectangles[0].Bottom);
 
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
        /// Thus, the whole algorithm is of O(nlog(n)) average time complexity.
        /// The algorithm's time complexity can degrade to O(n^2)
        ///  - e.g. for a series of descending (by height) rectangles,
        ///  but such event's probability is insignificant
        ///  if the input rectangles heights are uniformly distributed (as they are),
        ///  so O(nlog(n)) performance is probabilistically guaranteed.
        /// 
        /// Space complexity is O(n) as we at least have to hold the collection of results.
        /// </summary>
        /// <param name="iFirst"> first index of a considered _inputRectangles' subarray </param>
        /// <param name="iLast"> last index of a considered _inputRectangles' subarray </param>
        private void RotateRectanglesRecursive(
            int iFirst, int iLast,
            int currentGroundBottom)
        {
            var rectanglesInfo = FindIndexOfWithMinHeight(iFirst, iLast);

            var horizontalRectangle = CreateHorizontalReatangle(
                iFirst, rectanglesInfo, currentGroundBottom);

            // if not a degenerate case, add a result to the collection
            // (i.e. the RotateRectangles' side effect)
            if (horizontalRectangle.Height > 0)
                _outputRectangles.Add(horizontalRectangle);

            var iMin = rectanglesInfo.IMin;
            var nextCurrentGroundBottom = _inputRectangles[iMin].Height;

            var iLeftsFirst = iFirst;
            var iLeftsLast = iMin - 1;
            if (iLeftsFirst <= iLeftsLast)
            {
                RotateRectanglesRecursive(iLeftsFirst, iLeftsLast, nextCurrentGroundBottom);
            }

            var iRightsFirst = iMin + 1;
            var iRightsLast = iLast;
            if (iRightsFirst <= iRightsLast)
            {
                RotateRectanglesRecursive(iRightsFirst, iRightsLast, nextCurrentGroundBottom);
            }
        }

        private class RectanglesInfo
        {
            public int IMin { get; set; }
            public int TotalWidth { get; set; }
        }
        
        private RectanglesInfo FindIndexOfWithMinHeight(
            int iFirst, int iLast)
        {
            var iMin = iFirst;
            var totalWidth = _inputRectangles[iFirst].Width;
            
            for (int i = iFirst + 1; i <= iLast; ++i)
            {
                if (_inputRectangles[i].Height < _inputRectangles[iMin].Height)
                {
                    iMin = i;
                }
                totalWidth += _inputRectangles[i].Width;
            }
            return new RectanglesInfo { IMin = iMin, TotalWidth = totalWidth };
        }

        private Rectangle CreateHorizontalReatangle(
                int iFirst,
                RectanglesInfo rectanglesInfo,
                int currentGroundBottom) =>
            new Rectangle
            {
                Left = _inputRectangles[iFirst].Left,
                Bottom = _inputRectangles[iFirst].Bottom + currentGroundBottom,
                Width = rectanglesInfo.TotalWidth,
                Height = _inputRectangles[rectanglesInfo.IMin].Height - currentGroundBottom,
            };
    }
}
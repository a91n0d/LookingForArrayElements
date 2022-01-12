using System;

#pragma warning disable S2368

namespace LookingForArrayElements
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches in jagged arrays errors ArgumentException and ArgumentNullException.
        /// </summary>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        public static void ErorrGetCount(this decimal[][] ranges)
        {
            _ = ranges ?? throw new ArgumentNullException(nameof(ranges));
            for (int n = 0; n <= ranges.Length - 1; n++)
            {
                _ = ranges[n] ?? throw new ArgumentNullException(nameof(ranges));
                if (ranges[n].Length != 2 && ranges[n].Length != 0)
                {
                    throw new ArgumentException(null);
                }
            }
        }

        /// <summary>
        /// Searches in arrays errors ArgumentOutOfRangeException, ArgumentNullException.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        public static void ErorrGetCount(this decimal[] arrayToSearch, int startIndex, int count)
        {
            _ = arrayToSearch ?? throw new ArgumentNullException(nameof(arrayToSearch));
            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayToSearch));
            }

            if (startIndex < 0 || startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
            }
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges)
        {
            ErorrGetCount(ranges);
            _ = arrayToSearch ?? throw new ArgumentNullException(nameof(arrayToSearch));
            if (arrayToSearch.Length == 0 || ranges == Array.Empty<decimal[]>())
            {
                return 0;
            }

            int countInt = 0;
            int k = 0;
            do
            {
                int i = 0;
                bool isCount = false;
                do
                {
                    int j = 0;
                    do
                    {
                        if (ranges[i].Length != 0 && arrayToSearch[k] >= ranges[i][j] && arrayToSearch[k] <= ranges[i][j + 1])
                        {
                            countInt += 1;
                            isCount = true;
                        }
                    }
                    while (++j <= ranges[i].Length - 2 && !isCount);
                }
                while (++i <= ranges.Length - 1 && !isCount);
            }
            while (++k <= arrayToSearch.Length - 1);
            return countInt;
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int count)
        {
            ranges.ErorrGetCount();
            arrayToSearch.ErorrGetCount(startIndex, count);
            int countInt = 0;
            for (int j = startIndex; j <= startIndex + count - 1; j++)
            {
                bool isCount = false;
                for (int k = 0; k <= ranges.Length - 1 && !isCount; k++)
                {
                    for (int i = 0; i <= ranges[0].Length - 2 && !isCount; i++)
                    {
                        if (arrayToSearch[j] >= ranges[k][i] && arrayToSearch[j] <= ranges[k][i + 1])
                        {
                            countInt += 1;
                            isCount = true;
                        }
                    }
                }
            }

            return countInt;
        }
    }
}

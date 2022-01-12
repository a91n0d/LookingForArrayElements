using System;

namespace LookingForArrayElements
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd)
        {
            _ = arrayToSearch ?? throw new ArgumentNullException(nameof(arrayToSearch));
            _ = rangeStart ?? throw new ArgumentNullException(nameof(rangeStart));
            _ = rangeEnd ?? throw new ArgumentNullException(nameof(rangeEnd));
            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("rangeStart.Length != rangeEnd.Length");
            }

            int count = 0;
            for (int i = 0; i <= rangeStart.Length - 1; i++)
            {
                if (rangeStart[i] > rangeEnd[i])
                {
                    throw new ArgumentException("rangeStart[i] > rangeEnd[i]");
                }
                else
                {
                    for (int j = 0; j <= arrayToSearch.Length - 1; j++)
                    {
                        count += arrayToSearch[j] >= rangeStart[i] && arrayToSearch[j] <= rangeEnd[i] ? 1 : 0;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
        {
            _ = arrayToSearch ?? throw new ArgumentNullException(nameof(arrayToSearch));
            _ = rangeStart ?? throw new ArgumentNullException(nameof(rangeStart));
            _ = rangeEnd ?? throw new ArgumentNullException(nameof(rangeEnd));
            if (startIndex < 0 || startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentException("startIndex + count > arrayToSearch.Length");
            }

            if (rangeStart.Length == 0 || rangeEnd.Length == 0)
            {
                return 0;
            }

            int cnt = 0;
            int i = 0;
            do
            {
                int j = startIndex;
                do
                {
                    cnt += arrayToSearch[j] >= rangeStart[i] && arrayToSearch[j] <= rangeEnd[i] ? 1 : 0;
                }
                while (++j <= startIndex + count - 1);
            }
            while (++i <= rangeStart.Length - 1);
            return cnt;
        }
    }
}

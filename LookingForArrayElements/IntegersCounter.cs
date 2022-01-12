using System;

namespace LookingForArrayElements
{
    public static class IntegersCounter
    {
        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (elementsToSearchFor is null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor));
            }

            int count = 0;
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                for (int j = 0; j < elementsToSearchFor.Length; j++)
                {
                    count += (arrayToSearch[i] == elementsToSearchFor[j]) ? 1 : 0;
                }
            }

            return count;
        }

        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements withing the range of elements in the <see cref="Array"/> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (elementsToSearchFor is null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor));
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater than arrayToSearch.Length");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
            }

            int lastIndex = startIndex + count;
            if (lastIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count > arrayToSearch.Length");
            }

            int cnt = 0;
            int i = startIndex;
            while (i < startIndex + count)
            {
                int j = 0;
                while (j < elementsToSearchFor.Length)
                {
                    cnt += (arrayToSearch[i] == elementsToSearchFor[j]) ? 1 : 0;
                    j++;
                }

                i++;
            }

            return cnt;
        }
    }
}

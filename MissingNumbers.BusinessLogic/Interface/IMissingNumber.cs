namespace MissingNumbers.BusinessLogic.Interface
{
    using System.Collections.Generic;

    public interface IMissingNumber
    {
        /// <summary>
        /// Method by get the missing number between two list.
        /// </summary>
        /// <param name="n">Length of the first list(real).</param>
        /// <param name="arr">Array type list with numbers.</param>
        /// <param name="m">Length of second list to compare.</param>
        /// <param name="brr">Second array type list with numbers.</param>
        /// <returns>Return list with the number missing.</returns>
        List<int> GetMissingNumbers(int n, List<int> arr, int m, List<int> brr);
    }
}

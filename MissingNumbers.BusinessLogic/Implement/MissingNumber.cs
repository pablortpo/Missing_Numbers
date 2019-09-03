namespace MissingNumbers.BusinessLogic.Implement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MissingNumber : Interface.IMissingNumber
    {
        #region Attributes
        private readonly double MAX_LENGTH_ARRAY;
        private readonly double MAX_VALUE_ARRAY;
        #endregion

        #region Builder
        public MissingNumber()
        {
            this.MAX_LENGTH_ARRAY = Math.Pow(10, 5);
            this.MAX_VALUE_ARRAY = Math.Pow(10, 4);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Method by get the missing number between two list.
        /// </summary>
        /// <param name="n">Length of the first list(real).</param>
        /// <param name="arr">Array type list with numbers.</param>
        /// <param name="m">Length of second list to compare.</param>
        /// <param name="brr">Second array type list with numbers.</param>
        /// <returns>Return list with the number missing.</returns>
        public List<int> GetMissingNumbers(int n, List<int> arr, int m, List<int> brr)
        {
            List<int> returned = new List<int>();
            string messages = this.Validations(n, arr, m, brr);
            if (!string.IsNullOrEmpty(messages))
            {
                throw new ArgumentException(messages);
            }
            else
            {
                returned = ComperItemsList(arr, brr);
            }

            return returned;
        } 
        #endregion

        #region Private Methods
        /// <summary>
        /// This method is to compare the two list.
        /// </summary>
        /// <param name="arr">First list with the numbers.</param>
        /// <param name="brr">Second list with the numbers.</param>
        /// <returns>Number missing list.</returns>
        private List<int> ComperItemsList(List<int> arr, List<int> brr)
        {
            List<int> exceptList = Helpers.ExceptListHelper.ExceptList(arr, brr);
            List<int> orderedList = exceptList.OrderBy(o => o).ToList();
            return orderedList;
        }

        private string Validations(int n, List<int> arr, int m, List<int> brr)
        {
            List<string> messages = new List<string>();
            if (!this.ValidLengthArray(n))
            {
                messages.Add("Error in [n] the length expect is out of range.");
            }

            if (!this.ValidLengthArray(m))
            {
                messages.Add("Error in [m] the length expect is out of range.");
            }

            if (n > m)
            {
                messages.Add("Error in [n], this number cannot be greater than the other");
            }

            if (brr.Any(a => a < 1 || a > this.MAX_VALUE_ARRAY))
            {
                messages.Add("Error in [brr], Any array item's is out of range permited");
            }

            if ((brr.Max() - brr.Min()) > 100)
            {
                messages.Add("Error in [brr], The difference between maximum and minimum number must less than or equal to 100.");
            }

            return string.Join(Environment.NewLine, messages);
        }

        private bool ValidLengthArray(int lengthArray)
        {
            //if (lengthArray < 1 || lengthArray > (2 * this.MAX_LENGTH_ARRAY))
            if (lengthArray >= 1 && lengthArray <= (2 * this.MAX_LENGTH_ARRAY))
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion
    }
}

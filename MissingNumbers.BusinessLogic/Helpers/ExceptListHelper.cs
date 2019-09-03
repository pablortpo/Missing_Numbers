namespace MissingNumbers.BusinessLogic.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Helper class.
    /// </summary>
    public class ExceptListHelper
    {
        #region Public Methods
        /// <summary>
        /// Method by get the missing numbers between both list.
        /// </summary>
        /// <typeparam name="TE">Entity object</typeparam>
        /// <param name="firtList">List that has the real items.</param>
        /// <param name="secundList">List to compere.</param>
        /// <returns></returns>
        public static List<TE> ExceptList<TE>(List<TE> firtList, List<TE> secundList)
            where TE : IComparable<TE>, new()
        {
            List<TE> diferentNumberList = new List<TE>();
            foreach (TE itemListB in secundList.Distinct())
            {
                var countA = firtList.Count(x => x.Equals(itemListB));
                var countB = secundList.Count(x => x.Equals(itemListB));
                if (countA != countB)
                {
                    diferentNumberList.Add(itemListB);
                }
            }

            return diferentNumberList;
        } 
        #endregion
    }
}

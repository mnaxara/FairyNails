using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace NetExtension
{
    /// <summary>
    /// A Contains extension method for <see cref="System.String"/> type.
    /// </summary>
    public static class StringExtensions
    {
        #region fields

        #endregion

        #region properties

        #endregion

        #region methods
        public static String FirstLetterToUppercase (this String value)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(value[0]) + value.Substring(1);
        }
        #endregion
    }
}

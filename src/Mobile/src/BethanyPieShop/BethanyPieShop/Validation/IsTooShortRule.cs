using BethanyPieShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BethanyPieShop.Core.Validation
{
    public class IsTooShortRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set ; }

        public bool Check(T value)
        {
            var strValue = value as string;

            if (strValue != null)
            {
                if (strValue.Length < 4)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}

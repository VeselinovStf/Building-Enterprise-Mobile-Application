using System;

namespace BethanyPieShop.Core.Utility
{
    public static class ValidationGuard
    {
        public static void StringIsNullEmptyWhiteSpace(string str, string message)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(message);
            }
        }

        public static void StringIsLessThen(string str, int than, string message)
        {
            if (str.Length < than)
            {
                throw new ArgumentException(message);
            }
        }

        public static void StringIsValidRange(string str, int lestThen, string message)
        {
            StringIsNullEmptyWhiteSpace(str, message);
            StringIsLessThen(str, lestThen, message);
        }
    }
}

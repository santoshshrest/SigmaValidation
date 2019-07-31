using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Validation
{
    internal static class SouthKoreaPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool IsSouthKoreaPhoneNumber(this string number)
        {
            bool result = IsInternationalCodes(number) || IsAreaCode(number) || IsCellular(number);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsInternationalCodes(string number)
        {
            bool isValid = false;
            int[] lengths = new int[] { 10, 12, 13, 14, 15, 16 };
            if (number.Substring(0, 4).Equals("0082") && lengths.Contains(number.Length))
            {
                isValid = IsLandLine(number, 4) || IsMobileNumber(number, 4);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsAreaCode(string number)
        {
            bool isValid = false;
            if (number.Length.Equals(8) || number.Length.Equals(9))
            {
                isValid = IsLandLine(number, 0);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsCellular(string number)
        {
            bool isValid = false;
            int[] lengths = new int[] { 6, 8, 9, 10, 11, 12 };
            if (lengths.Contains(number.Length))
            {
                isValid = IsMobileNumber(number, 0);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsLandLine(string number, int startIndex)
        {
            bool isValid = false;
            if (DataCollections.KR_AreaCodesTwoDigits.Contains(number.Substring(startIndex, 2)))
            {
                isValid = true;
            }
            else if (DataCollections.KR_AreaCodesOneDigit.Contains(number.Substring(startIndex, 1)))
            {
                isValid = true;
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsMobileNumber(string number, int startIndex)
        {
            bool isValid = number.Substring(startIndex, 1).Equals("1");
            return isValid;
        }
    }
}
using System.Linq;

namespace Core.Validation
{
    internal static class SouthAfricaPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool IsSouthAfricaPhoneNumber(this string number)
        {
            bool result = IsInternationalCode(number) || IsAreaCodeOrCellular(number);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsInternationalCode(string number)
        {
            bool isValid = false;
            if (number.Substring(0, 4).Equals("0027") && number.Length.Equals(13))
            {
                isValid = IsLandLine(number, 4) || IsMobile(number, 4);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsAreaCodeOrCellular(string number)
        {
            bool isValid = false;
            if (number.Length.Equals(9))
            {
                isValid = IsLandLine(number, 0) || IsMobile(number, 0);
                return isValid;
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
            if (DataCollections.ZA_AreaCodesSevenDigits.Contains(number.Substring(startIndex, 7)))
            {
                isValid = true;
            }
            else if (DataCollections.ZA_AreaCodesSixDigits.Contains(number.Substring(startIndex, 6)))
            {
                isValid = true;
            }
            else if (DataCollections.ZA_AreaCodesFiveDigits.Contains(number.Substring(startIndex, 5)))
            {
                isValid = true;
            }
            else if (DataCollections.ZA_AreaCodesFourDigits.Contains(number.Substring(startIndex, 4)))
            {
                isValid = true;
            }
            else if (DataCollections.ZA_AreaCodesTwoDigits.Contains(number.Substring(startIndex, 2)))
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
        private static bool IsMobile(string number, int startIndex)
        {
            bool isValid = false;
            if (DataCollections.ZA_MobileCodesTwoDigits.Contains(number.Substring(startIndex, 2)))
            {
                isValid = true;
            }
            else if (DataCollections.ZA_MobileCodesOneDigit.Contains(number.Substring(startIndex, 1)))
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
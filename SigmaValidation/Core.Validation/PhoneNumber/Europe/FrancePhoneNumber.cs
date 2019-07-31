using System.Linq;

namespace Core.Validation
{
    internal static class FrancePhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool IsFrancePhoneNumber(this string number)
        {
            bool result = IsInternationalCodes(number) || IsCellularOrPhone(number);
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
            if (number.Substring(0, 4).Equals("0033") && number.Length.Equals(13))
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
        private static bool IsCellularOrPhone(string number)
        {
            bool isValid = false;
            if (number.Length.Equals(9))
            {
                isValid = IsLandLine(number, 0) || IsMobile(number, 0);
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
            if (DataCollections.FR_AreaCodesThreeDigits.Contains(number.Substring(startIndex, 3)))
            {
                isValid = true;
            }
            else if (DataCollections.FR_AreaCodesOneDigit.Contains(number.Substring(startIndex, 1)))
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
            bool isValid = DataCollections.FR_MobileCodes.Contains(number.Substring(startIndex, 1));
            return isValid;
        }
    }
}
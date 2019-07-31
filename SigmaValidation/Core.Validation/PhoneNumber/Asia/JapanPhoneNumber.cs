using System.Linq;

namespace Core.Validation
{
    internal static class JapanPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool IsJapanPhoneNumber(this string number)
        {
            bool result = IsInternationalCode(number) || IsAreaCodes(number) || IsCellular(number);
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
            if (number.Substring(0, 4).Equals("0081") && (number.Length == 9 || number.Length == 10))
            {
                isValid = IsLandLine(number, 4) || IsMobile(number, 0);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsAreaCodes(string number)
        {
            bool isValid = false;
            if (number.Length.Equals(9))
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
            if (number.Length.Equals(10))
            {
                isValid = IsMobile(number, 0);
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
            if (DataCollections.JP_AreaCodesThreeDigits.Contains(number.Substring(startIndex, 3)))
            {
                isValid = true;
            }
            else if (DataCollections.JP_AreaCodesTwoDigits.Contains(number.Substring(startIndex, 2)))
            {
                isValid = true;
            }
            else if (DataCollections.JP_AreaCodesOneDigit.Contains(number.Substring(startIndex, 1)))
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
            bool isValid = DataCollections.JP_MobileCodes.Contains(number.Substring(startIndex, 2));
            return isValid;
        }
    }
}
using System.Linq;

namespace Core.Validation
{
    internal static class SwitzerlandPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool IsSwitzerlandPhoneNumber(this string number)
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
            if (number.Substring(0, 4).Equals("0041") && number.Length.Equals(9))
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
            if (number.Length == 9)
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
            bool isValid = DataCollections.CH_AreaCodes.Contains(number.Substring(startIndex, 2));
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
            bool isValid = DataCollections.CH_MobileCodes.Contains(number.Substring(startIndex, 2));
            return isValid;
        }
    }
}
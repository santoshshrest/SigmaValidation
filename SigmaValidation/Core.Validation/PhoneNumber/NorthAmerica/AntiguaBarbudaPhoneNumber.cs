using System.Linq;

namespace Core.Validation
{
    /// <summary>
    /// 
    /// </summary>
    internal static class AntiguaBarbudaPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool IsAntiguaBarbudaPhoneNumber(this string number)
        {
            bool result = IsInternationalCode(number) || IsCellularOrAreaCodes(number);
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
            if (number.Substring(0, 3).Equals("001") && number.Length.Equals(13))
            {
                isValid = IsLandLine(number, 3) && IsMobile(number, 3);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsCellularOrAreaCodes(string number)
        {
            bool isValid = false;
            if (number.Length.Equals(10))
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
            bool isValid = DataCollections.AG_AreaCodesThreeDigits.Contains(number.Substring(startIndex, 3));
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
            bool isValid = DataCollections.AG_MobileCodesFourDigits.Contains(number.Substring(startIndex, 4));
            return isValid;
        }
    }
}
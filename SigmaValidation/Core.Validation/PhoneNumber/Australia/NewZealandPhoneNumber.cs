using System.Linq;

namespace Core.Validation
{
    internal static class NewZealandPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool IsNewZealandPhoneNumber(this string number)
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
            if (number.Substring(0, 4).Equals("0064") && number.Length >= 12 && number.Length <= 14)
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
        private static bool IsAreaCode(string number)
        {
            bool isValid = false;
            if (number.Length == 8)
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
            if (number.Length >= 8 && number.Length <= 10)
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
            bool isValid = DataCollections.NZ_AreaCodes.Contains(number.Substring(startIndex, 1));
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
            if (DataCollections.NZ_MobileCodesThreeDigits.Contains(number.Substring(startIndex, 3)))
            {
                isValid = true;
            }
            else if (DataCollections.NZ_MobileCodesTwoDigits.Contains(number.Substring(startIndex, 2)))
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
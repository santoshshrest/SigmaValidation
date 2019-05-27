using System.Linq;

namespace Core.Validation
{
    internal static class AfghanistanPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool IsAfghanistanPhoneNumber(this string number)
        {
            bool result = IsInternationalCode(number) || IsAreaCode(number) || IsCellular(number);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <returns></returns>
        private static bool IsInternationalCode(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Substring(0, 4) == "0093" && integerValue.Length == 13)
            {
                isValid = IsLandLine(integerValue, 4) || IsMobile(integerValue, 4);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <returns></returns>
        private static bool IsAreaCode(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Length == 9)
            {
                isValid = IsLandLine(integerValue, 0);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <returns></returns>
        private static bool IsCellular(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Length == 9)
            {
                isValid = IsMobile(integerValue, 0);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsLandLine(string integerValue, int startIndex)
        {
            bool isValid = DataCollections.AF_AreaCodesTwoDigits.Contains(integerValue.Substring(startIndex, 2));
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsMobile(string integerValue, int startIndex)
        {
            bool isValid = integerValue.Substring(startIndex, 1).Equals("7");
            return isValid;
        }
    }
}
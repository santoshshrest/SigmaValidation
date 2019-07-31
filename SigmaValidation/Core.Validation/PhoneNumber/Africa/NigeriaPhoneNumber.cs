using System.Linq;

namespace Core.Validation
{
    internal static class NigeriaPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool IsNigeriaPhoneNumber(this string number)
        {
            bool result = IsInternationalCodes(number) || IsAreaCodes(number) || IsCellular(number);
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
            int[] lengths = new int[] { 12, 13, 15 };
            if (number.Substring(0, 5).Equals("00234") && lengths.Contains(number.Length))
            {
                isValid = IsLandLine(number, 5) || IsMobile(number, 5);
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
            if (number.Length.Equals(7) || number.Length.Equals(8))
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
            if (DataCollections.NG_AreaCodesTwoDigits.Contains(number.Substring(startIndex, 2)))
            {
                isValid = true;
            }
            else if (DataCollections.NG_AreaCodesOneDigit.Contains(number.Substring(startIndex, 1)))
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
            bool isValid = DataCollections.NG_MobileCodes.Contains(number.Substring(startIndex, 2));
            return isValid;
        }
    }
}
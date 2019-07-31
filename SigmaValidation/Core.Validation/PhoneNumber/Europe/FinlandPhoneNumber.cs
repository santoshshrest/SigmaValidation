using System.Linq;

namespace Core.Validation
{
    internal static class FinlandPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool IsFinlandPhoneNumber(this string number)
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
            bool isVallid = false;
            if (number.Substring(0, 4).Equals("0358") && number.Length >= 9 && number.Length <= 16)
            {
                isVallid = IsLandLine(number, 4) || IsMobile(number, 4);
            }
            return isVallid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsAreaCode(string number)
        {
            bool isValid = false;
            if (number.Length >= 5 && number.Length <= 12)
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
            if (number.Length.Equals(9))
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
            bool isVallid = false;
            if (DataCollections.FI_AreaCodesTwoDigits.Contains(number.Substring(startIndex, 2)))
            {
                isVallid = true;
            }
            else if (DataCollections.FI_AreaCodesOneDigit.Contains(number.Substring(startIndex, 1)))
            {
                isVallid = true;
            }
            return isVallid;
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
            if (DataCollections.FI_AreaCodesTwoDigits.Contains(number.Substring(startIndex, 2)))
            {
                isValid = true;
            }
            else if (DataCollections.FI_AreaCodesOneDigit.Contains(number.Substring(startIndex, 1)))
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
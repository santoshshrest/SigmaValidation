using System.Linq;

namespace Core.Validation
{
    internal static class ArgentinaPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool IsArgentinaPhoneNumber(this string number)
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
            if (number.Substring(0, 4).Equals("0054") && number.Length.Equals(14) || number.Length.Equals(15))
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
            if (number.Length.Equals(10))
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
            if (number.Length.Equals(11))
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
            if (DataCollections.AR_AreaCodesFourDigits.Contains(number.Substring(startIndex, 4)))
            {
                isValid = true;
            }
            else if (DataCollections.AR_AreaCodesThreeDigits.Contains(number.Substring(startIndex, 3)))
            {
                isValid = true;
            }
            else if (DataCollections.AR_AreaCodesTwoDigits.Contains(number.Substring(startIndex, 2)))
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
            if (number.Substring(startIndex, 1).Equals("9"))
            {
                startIndex++;
                if (DataCollections.AR_AreaCodesFourDigits.Contains(number.Substring(startIndex, 4)))
                {
                    isValid = true;
                }
                else if (DataCollections.AR_AreaCodesThreeDigits.Contains(number.Substring(startIndex, 3)))
                {
                    isValid = true;
                }
                else if (DataCollections.AR_AreaCodesTwoDigits.Contains(number.Substring(startIndex, 2)))
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}
using Core.Validation.Model;
using System.Linq;

namespace Core.Validation
{
    internal static class USPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool IsUSPhoneNumber(this string number)
        {
            bool result = number.Length >= 10 && number.Length <= 13 && CheckInitials(number) && (IsPhone(number, 3) || IsPhone(number, 0));
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <returns></returns>
        private static bool CheckInitials(string integerValue)
        {
            if (integerValue.Substring(0, 2) == "00")
            {
                return integerValue.Substring(0, 3) == "001" && integerValue.Length == 13;
            }
            else
            {
                return integerValue.Length == 10;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsPhone(string integerValue, int startIndex)
        {
            bool isPhone = DataCollections.US_AreaCodes.Contains(integerValue.Substring(startIndex, 3));
            return isPhone;
        }
    }
}
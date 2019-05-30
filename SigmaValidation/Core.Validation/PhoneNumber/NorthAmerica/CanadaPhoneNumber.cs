using System.Linq;

namespace Core.Validation
{
    internal static class CanadaPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool IsCanadaPhoneNumber(this string number)
        {
            bool result = IsInternationalCodes(number) || IsAreaCodes(number);
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
            if (number.Substring(0, 3).Equals("001") && number.Length.Equals(13))
            {
                isValid = IsPhone(number, 3);
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
            if (number.Length.Equals(10))
            {
                isValid = IsPhone(number, 0);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsPhone(string number, int startIndex)
        {
            bool isValid = DataCollections.CA_AreaCodes.Contains(number.Substring(startIndex, 3));
            return isValid;
        }
    }
}
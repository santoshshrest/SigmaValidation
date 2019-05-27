using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Validation
{
    internal static class ChinaPhoneNumber
    {
        /// <summary>
        /// Verifies China phone number. Checks international, area code and cellular phone number.
        /// </summary>
        /// <param name="number">Phone number to be verified</param>
        /// <returns></returns>
        internal static bool IsChinaPhoneNumber(this string number)
        {
            bool result = IsInternationalCode(number) || IsAreaCode(number) || IsCellular(number);
            return result;
        }
        /// <summary>
        /// Verifies phone number for international code applied, checks both landline and cellular
        /// </summary>
        /// <param name="integerValue">phone number to be verified</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsInternationalCode(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Substring(0, 4) == "0086" && (integerValue.Length == 14 || integerValue.Length == 15))
            {
                isValid = IsLandLine(integerValue, 4) || IsMobile(integerValue, 4);
            }
            return isValid;
        }
        /// <summary>
        /// Verifies phone number for area code applied, checks landline
        /// </summary>
        /// <param name="integerValue">phone number to be verified</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsAreaCode(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Length == 10 || integerValue.Length == 11)
            {
                isValid = IsLandLine(integerValue, 0);
            }
            return isValid;
        }
        /// <summary>
        /// Verifies phone number for mobile code appllied, check mobile
        /// </summary>
        /// <param name="integerValue">phone number to be verified</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsCellular(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Length == 10)
            {
                isValid = IsMobile(integerValue, 0);
            }
            return isValid;
        }
        /// <summary>
        /// Verifies phone number for land line
        /// </summary>
        /// <param name="integerValue">phone number to be verified</param>
        /// <param name="startIndex">start of the index with in phone number to compare data from</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsLandLine(string integerValue, int startIndex)
        {
            bool isValid = false;
            if (DataCollections.CN_AreaCodesTwoDigits.Contains(integerValue.Substring(startIndex, 2)))
            {
                isValid = true;
            }
            else if (DataCollections.CN_AreaCodesThreeDigits.Contains(integerValue.Substring(startIndex, 3)))
            {
                isValid = true;
            }
            return isValid;
        }
        /// <summary>
        /// Verifies phone number for mobile
        /// </summary>
        /// <param name="integerValue">phone number to be verified</param>
        /// <param name="startIndex">start of the index with in phone number to compare data from</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsMobile(string integerValue, int startIndex)
        {
            bool isValid = integerValue.Substring(startIndex, 1).Equals("1") && Regex.IsMatch($"{integerValue[1]}", "[3-9]");
            return isValid;
        }
    }
}
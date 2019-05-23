using Core.Validation.Model;
using System.Linq;

namespace Core.Validation
{
    internal static class MalaysiaPhoneNumber
    {
        /// <summary>
        /// Verifies Malaysia phone number. Checks international, area code and cellular phone number.
        /// </summary>
        /// <param name="number">Phone number to be verified</param>
        /// <returns></returns>
        internal static bool IsMalaysiaPhoneNumber(this string number)
        {
            bool result = IsInternationalCode(number) || IsAreaCode(number) || IsCellular(number);
            return result;
        }
        /// <summary>
        /// Verifes phone number for international code applied, checks both landline and cellular
        /// </summary>
        /// <param name="integerValue">phone number to be verified</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsInternationalCode(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Substring(0, 4) == "0060" && (integerValue.Length == 12 || integerValue.Length == 13 || integerValue.Length == 14))
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
            if (integerValue.Length == 8 || integerValue.Length == 9)
            {
                isValid = IsLandLine(integerValue, 0);
            }
            return isValid;
        }
        /// <summary>
        /// Verifies phone number for mobile code applied, check mobile
        /// </summary>
        /// <param name="integerValue">phone number to be verified</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsCellular(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Length == 0 || integerValue.Length == 10)
            {
                isValid = IsMobile(integerValue, 0);
            }
            return isValid;
        }
        /// <summary>
        /// Varifies phone number for land line
        /// </summary>
        /// <param name="integerValue">phone number to be verified</param>
        /// <param name="startIndex">start of the index with in phone number to compare data from</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsLandLine(string integerValue, int startIndex)
        {
            bool isValid = false;
            if (DataCollections.MY_AreaCodesOneDigit.Contains(integerValue.Substring(startIndex, 1)))
            {
                isValid = true;
            }
            else if (DataCollections.MY_AreaCodesTwoDigits.Contains(integerValue.Substring(startIndex, 2)))
            {
                isValid = true;
            }
            return isValid;
        }
        /// <summary>
        /// Varifies phone number for mobile
        /// </summary>
        /// <param name="integerValue">phone number to be verified</param>
        /// <param name="startIndex">start of the index with in phone number to compare data from</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsMobile(string integerValue, int startIndex)
        {
            bool isValid = integerValue.Substring(startIndex, 1).Equals("1");
            return isValid;
        }
    }
}
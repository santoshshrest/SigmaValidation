using Core.Validation.Model;

namespace Core.Validation
{
    internal static class SingaporePhoneNumber
    {
        /// <summary>
        /// Verifies Singapore phone number. Checks international, area code and cellular phone number.
        /// </summary>
        /// <param name="number">Phone number to be verified</param>
        /// <returns></returns>
        internal static bool IsSingaporePhoneNumber(this string number)
        {
            bool result = IsInternationalcode(number) || IsCellularOrPhone(number);
            return result;
        }
        /// <summary>
        /// Verifes phone number for international code applied, checks both landline and cellular
        /// </summary>
        /// <param name="integerValue">Phone number to be verified</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsInternationalcode(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Substring(0, 4) == "0065" && (integerValue.Length == 12))
            {
                isValid = IsLandLine(integerValue, 4) || IsMobile(integerValue, 4);
            }
            return isValid;
        }
        /// <summary>
        /// Verifies phone number for mobile or land line applied, check mobile or land line
        /// </summary>
        /// <param name="integerValue">Phone number to be verified</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsCellularOrPhone(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Length == 8)
            {
                isValid = IsLandLine(integerValue, 0) || IsMobile(integerValue, 0);
            }
            return isValid;
        }
        /// <summary>
        /// Varifies phone number for land line
        /// </summary>
        /// <param name="integerValue">Phone number to be verified</param>
        /// <param name="startIndex">start of the index with in phone number to compare data from</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsLandLine(string integerValue, int startIndex)
        {
            bool isValid = integerValue.Substring(startIndex, 1).Equals("3") || integerValue.Substring(startIndex, 1).Equals("6");
            return isValid;
        }
        /// <summary>
        /// Varifies phone number for mobile
        /// </summary>
        /// <param name="integerValue">Phone number to be verified</param>
        /// <param name="startIndex">start of the index with in phone number to compare data from</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsMobile(string integerValue, int startIndex)
        {
            bool isValid = integerValue.Substring(startIndex, 1).Equals("8") || integerValue.Substring(startIndex, 1).Equals("9");
            return isValid;
        }
    }
}
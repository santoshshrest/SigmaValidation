using Core.Validation.Model;
using System.Linq;

namespace Core.Validation
{
    internal static class ThailandPhoneNumber
    {
        /// <summary>
        /// Verifies Thailand phone number. Checks international, area code and cellular phone number.
        /// </summary>
        /// <param name="number">Phone number to be verified</param>
        /// <returns>Operation result returning result either true or false</returns>
        internal static OperationResult<bool> IsThailandPhoneNumber(this string number)
        {
            var operation = new OperationResult<bool>(false);
            CheckPhoneNumber.ValidatePhoneNumber(number, operation);
            if (operation.Result)
            {
                string integerValue = CheckPhoneNumber.GetNumbers(number);
                if (IsInternationalCode(integerValue) || IsAreaCode(integerValue) || IsCellular(integerValue))
                {
                    operation = new OperationResult<bool>(true, null, "Success");
                }
                else 
                {
                    operation = new OperationResult<bool>(false, null, $"Invalid phone number {number}.");
                }
            }
            return operation;
        }
        /// <summary>
        /// Verifes phone number for international code applied, checks both landline and cellular
        /// </summary>
        /// <param name="integerValue">phone number to be verified</param>
        /// <returns>bool value either true or false</returns>
        private static bool IsInternationalCode(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Substring(0, 4) == "0066" && (integerValue.Length == 12 || integerValue.Length == 13))
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
            if (integerValue.Length == 8)
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
            if (integerValue.Length == 9)
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
            if (DataCollections.TH_AreaCodesOneDigit.Contains(integerValue.Substring(startIndex, 1)))
            {
                isValid = true;
            }
            else if (DataCollections.TH_AreaCodesTwoDigits.Contains(integerValue.Substring(startIndex, 2)))
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
            bool isValid = DataCollections.TH_MobileCodes.Contains(integerValue.Substring(startIndex, 1));
            return isValid;
        }
    }
}
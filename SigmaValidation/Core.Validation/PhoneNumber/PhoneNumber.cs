using Core.Validation.Model;
using System;

namespace Core.Validation
{
    /// <summary>
    /// Validation of phone number provided.
    /// This servie will validate number on randam number if not additional data is provided.
    /// Additional data referes to From Data Dictionary flag and Country code.
    /// On the case of bool flag (isFromDataDictionary) is true it will indentify correct number on the basis of country.
    /// On the case of counry code which has two alphabets, eg; NP for Nepal it will identify phone on the basis of country code provided
    /// </summary>
    public static class PhoneNumber
    {
        /// <summary>
        /// Check whether phone number is valid or not.
        /// Result is true for valid phone number
        /// Result is false for invalid phone number and message is set in error message, if exception has occured while checking then Exception is set
        /// </summary>
        /// <param name="number">number (string) to be validated as valid phone number</param>
        /// <param name="isFromDataDictionary">
        /// Identifies where to validate phone number from data dictionary. Data dictionary has all list of countries and verifies all the blocks of phone  number.
        /// It identifies country, type of number wheter it is land line (fixed) or celluler. If from data dictionary is true then country code must be provided.
        /// Phone numer without country code will be treateded as invalid phone number.
        /// </param>
        /// <returns>operation result with properties, ErrorMessage (string), Exception and Result (bool)</returns>
        public static OperationResult<bool> IsPhoneNumber(this string number, bool isFromDataDictionary = false)
        {
            var operation = number.ValidatePhoneNumber();
            if (operation.Result && isFromDataDictionary)
            {
                operation = number.ValidateWithDictionary();
            }
            return operation;
        }
        /// <summary>
        /// Check whether phone number is valid or not for defined culture
        /// Culture denotes country language code i.e; NP
        /// </summary>
        /// <param name="number">number (string) to be validated as valid phone number</param>
        /// <param name="code">
        /// Country code must be provided to verify the phone number based on country.
        /// It has two alphabetes which is universal. Code cannot be number, empty string or null.
        /// Invalid code will result into invalid phone number.
        /// Example of country code; Nepal = NP, United States = US, Denmark = DK
        /// </param>
        /// <returns>operation result with properties, ErrorMessage (string), Exception and Result (bool)</returns>
        public static OperationResult<bool> IsPhoneNumber(this string number, string code)
        {
            var operation = number.ValidatePhoneNumber();
            if (operation.Result && !string.IsNullOrEmpty(code) && code.Length.Equals(2) && Enum.TryParse(code, out CountryCodes countryCode))
            {
                var integerValue = CheckPhoneNumber.GetNumbers(number);
                operation = ValidateWithCountry(integerValue, code) ? new OperationResult<bool>(true, null, "Success") : new OperationResult<bool>(false, null, $"Invalid phone number {number}.");
            }
            else
            {
                operation = new OperationResult<bool>(false, null, $"Invalid country code {code}.");
            }
            return operation;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private static bool ValidateWithCountry(this string number, string code)
        {
            var operation = new OperationResult<bool>(false);
            bool result = false;
            switch ((CountryCodes)Enum.Parse(typeof(CountryCodes), code, true))
            {
                case CountryCodes.NP:
                    result = number.IsNepaliPhoneNumber();
                    break;
                case CountryCodes.US:
                    result = number.IsUSPhoneNumber();
                    break;
                case CountryCodes.DK:
                    result = number.IsDenmarkPhoneNumber();
                    break;
                case CountryCodes.IN:
                    result = number.IsIndiaPhoneNumber();
                    break;
                case CountryCodes.CN:
                    result = number.IsChinaPhoneNumber();
                    break;
                case CountryCodes.UK:
                    result = number.IsUKPhoneNumber();
                    break;
                case CountryCodes.TH:
                    result = number.IsThailandPhoneNumber();
                    break;
                case CountryCodes.MY:
                    result = number.IsMalaysiaPhoneNumber();
                    break;
                case CountryCodes.SG:
                    result = number.IsSingaporePhoneNumber();
                    break;
                default:
                    break;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static OperationResult<bool> ValidateWithDictionary(this string number)
        {
            bool result = false;
            foreach (var countryCode in Enum.GetNames(typeof(CountryCodes)))
            {
                var integerValue = CheckPhoneNumber.GetNumbers(number);
                result = ValidateWithCountry(integerValue, countryCode);
                if (result)
                {
                    break;
                }
            }
            return result ? new OperationResult<bool>(true, null, "Success") : new OperationResult<bool>(false, null, $"Invalid phone number {number}."); ;
        }
    }
}
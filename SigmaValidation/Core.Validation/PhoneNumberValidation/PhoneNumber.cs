using Core.Validation.Ennumeration;
using Core.Validation.Model;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Core.Validation
{
    public static class PhoneNumber
    {
        /// <summary>
        /// Check whether phone number is valid or not.
        /// Result is true for valid phone number
        /// Result is false for invalid phone number and message is set in error message, if exception has occured while checking then Exception is set
        /// </summary>
        /// <param name="number">number (string) to be validated as valid phone number</param>
        /// <returns>operation result with properties, ErrorMessage (string), Exception and Result (bool)</returns>
        public static OperationResult<bool> IsPhoneNumber(this string number)
        {
            var operation = new OperationResult<bool>(false);
            CheckPhoneNumber.ValidatePhoneNumber(number, operation);
            return operation;
        }
        /// <summary>
        /// Check whether phone number is valid or not for defined culture
        /// Culture denotes country language code i.e; Np
        /// </summary>
        /// <param name="number"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static OperationResult<bool> IsPhoneNumber(this string number, string code)
        {
            var operation = new OperationResult<bool>(false);
            if (code.Length == 2)
            {
                if (Enum.TryParse(code, out CountryCodes countryCode))
                {
                    switch ((CountryCodes)Enum.Parse(typeof(CountryCodes), code, true))
                    {
                        case CountryCodes.NP:
                            operation = number.IsNepaliPhoneNumber();
                            break;
                        case CountryCodes.US:
                            operation = number.IsUSPhoneNumber();
                            break;
                        case CountryCodes.DK:
                            operation = number.IsDenmarkPhoneNumber();
                            break;
                        default:
                            operation = new OperationResult<bool>(false, null, $"Invalid country code {code}.");
                            break;
                    }
                }
                else
                {
                    operation = new OperationResult<bool>(false, null, $"Invalid country code {code}.");
                }
            }
            else
            {
                operation = new OperationResult<bool>(false, null, $"Invalid country code {code}.");
            }
            return operation;
        }
    }
}
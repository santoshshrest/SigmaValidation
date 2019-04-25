using Core.Validation.Model;
using System;
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
            ValidatePhoneNumber(number, operation);
            return operation;
        }

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="operation"></param>
        private static void ValidatePhoneNumber(string phoneNumber, OperationResult<bool> operation)
        {
            try
            {
                string[] splittedNumber = SplitPhoneNumberWithMinusAndSpace(phoneNumber);
                if (splittedNumber.Length > 0)
                {
                    for (int i = 0; i < splittedNumber.Length; i++)
                    {
                        bool hasBracket = CheckForOpenBracket(splittedNumber[i]);
                        ValidateBrackets(splittedNumber[i], operation);
                        if (hasBracket && !operation.Result)
                        {
                            break;
                        }
                        if (!hasBracket && !Regex.IsMatch(splittedNumber[i], "^[0-9]+$"))
                        {
                            operation.Result = false;
                            operation.Message = $"Error: Phone number has error on {splittedNumber[i]} block.";
                            break;
                        }
                        else if (splittedNumber.Length - i == 1)
                        {
                            operation.Result = true;
                            operation.Message = "Success";
                        }
                    }
                }
                else
                {
                    ValidateBrackets(phoneNumber, operation);
                }
            }
            catch (Exception ex)
            {
                operation.Exception = ex;
                operation.Message = ex.ReadException();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private static bool CheckForOpenBracket(string phoneNumber)
        {
            bool hasBracket = false;
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (phoneNumber[i].Equals('('))
                {
                    hasBracket = true;
                    break;
                }
            }
            return hasBracket;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private static string[] SplitPhoneNumberWithMinusAndSpace(string phoneNumber)
        {
            char[] delimeters = { '-', ' ' };
            string[] splittedNumber = phoneNumber.Split(delimeters, StringSplitOptions.None);
            return splittedNumber;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="operation"></param>
        private static void ValidateBrackets(string phoneNumber, OperationResult<bool> operation)
        {
            bool openBracket = false;
            bool hasNumber = false;
            operation.Result = true;
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (phoneNumber[i] == '(')
                {
                    if (openBracket)
                    {
                        operation.Result = false;
                        operation.Message = "Error: Invalid character '" + phoneNumber[i] + "' in" + phoneNumber + "." + Environment.NewLine + "The closing bracket must be entered before each open bracket.";
                        break;
                    }
                    openBracket = true;
                }
                else if (openBracket && Regex.IsMatch(phoneNumber[i].ToString(), "^[0-9]+$"))
                {
                    hasNumber = true;
                }
                else if (phoneNumber[i] == ')')
                {
                    if (!openBracket)
                    {
                        operation.Result = false;
                        operation.Message = "Error: Invalid character '" + phoneNumber[i] + "' in " + phoneNumber + "." + Environment.NewLine + "Enter closing bracket only after open bracket";
                        break;
                    }
                    else if (!hasNumber)
                    {
                        operation.Result = false;
                        operation.Message = "Error: Invalid phone number entered." + Environment.NewLine +
                                                     "Must have number [0-9] in between open and close bracket." + Environment.NewLine +
                                                     "Eg; (123).";
                        break;
                    }
                    openBracket = false;
                }
                else if (!Regex.IsMatch(phoneNumber[i].ToString(), "^[0-9]+$"))
                {
                    operation.Result = false;
                    operation.Message = "Error: Invalid character '" + phoneNumber[i] + "' in " + phoneNumber + "." + Environment.NewLine + "Enter only numeric vlaue inside bracket.";
                    break;
                }
                else if (phoneNumber.Length - i == 1 && openBracket)
                {
                    operation.Result = false;
                    operation.Message = "Error: No closing bracket ')' found in " + phoneNumber + " block.";
                    break;
                }
            }
            if (openBracket && string.IsNullOrWhiteSpace(operation.Message))
            {
                operation.Result = false;
                operation.Message = "Error: No closing bracket ')' found in " + phoneNumber + " block.";
            }
        }
        #endregion
    }
}
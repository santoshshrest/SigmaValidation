using Core.Validation.Model;
using System;
using System.Text.RegularExpressions;

namespace Core.Validation
{
    /// <summary>
    /// Validation of email address provided.
    /// </summary>
    public static class Email
    {
        /// <summary>
        /// Check whether the email is valid or not.
        /// Operation resut is true for vaid email
        /// False if email address is not valid. Message is set and if exception occured exception is set
        /// </summary>
        /// <param name="email">Email address to validate</param>
        /// <returns>operation result with properties, ErrorMessage (string), Exception and Result (bool)</returns>
        public static OperationResult<bool> IsEmail(this string email)
        {
            var operation = new OperationResult<bool>(false);
            CheckEmail(email, operation);
            return operation;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="operation"></param>
        private static void CheckEmail(string email, OperationResult<bool> operation)
        {
            try
            {
                operation.Result = Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                operation.Message = operation.Result ? "Success" : "Invalid Email.";
            }
            catch (RegexMatchTimeoutException rex)
            {
                operation.Exception = rex;
                operation.Message = rex.ReadException();
            }
        }
    }
}
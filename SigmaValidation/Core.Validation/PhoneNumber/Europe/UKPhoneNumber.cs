using Core.Validation.Model;
using System.Linq;

namespace Core.Validation
{
    internal static class UKPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static OperationResult<bool> IsUKPhoneNumber(this string number)
        {
            var operation = new OperationResult<bool>(false);
            CheckPhoneNumber.ValidatePhoneNumber(number, operation);
            if (operation.Result)
            {
                string integerValue = CheckPhoneNumber.GetNumbers(number);
                if (IsInternationalCode(integerValue) || IsAreaCode(integerValue))
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
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <returns></returns>
        private static bool IsInternationalCode(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Substring(0, 4) == "0044" && integerValue.Length == 14)
            {
                isValid = true;
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <returns></returns>
        private static bool IsAreaCode(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Length == 10)
            {
                isValid = IsLandLine(integerValue, 0) || IsMobile(integerValue, 0);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsLandLine(string integerValue, int startIndex)
        {
            bool isValid = false;
            if (DataCollections.UK_AreaCodesTwoDigits.Contains(integerValue.Substring(startIndex, 2)))
            {
                isValid = true;
            }
            else if (DataCollections.UK_AreaCodesThreeDigits.Contains(integerValue.Substring(startIndex, 3)))
            {
                isValid = true;
            }
            else if (DataCollections.UK_AreaCodesFourDigits.Contains(integerValue.Substring(startIndex, 4)))
            {
                isValid = true;
            }
            else if (DataCollections.UK_AreaCodesFiveDigits.Contains(integerValue.Substring(startIndex, 5)))
            {
                isValid = true;
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsMobile(string integerValue, int startIndex)
        {
            bool isValid = integerValue.Substring(0, 1).Equals("7");
            return isValid;
        }
    }
}
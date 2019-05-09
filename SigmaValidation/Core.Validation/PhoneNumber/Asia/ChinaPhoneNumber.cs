using Core.Validation.Model;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Validation
{
    internal static class ChinaPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static OperationResult<bool> IsChinaPhoneNumber(this string number)
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
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <returns></returns>
        internal static bool IsInternationalCode(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Substring(0, 4) == "0086" && (integerValue.Length == 14 || integerValue.Length == 15))
            {
                isValid = IsLandLine(integerValue, 4) || IsMobile(integerValue, 4);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <returns></returns>
        internal static bool IsAreaCode(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Length == 10 || integerValue.Length == 11)
            {
                isValid = IsLandLine(integerValue, 0);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <returns></returns>
        internal static bool IsCellular(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Length == 10)
            {
                isValid = IsMobile(integerValue, 0);
            }
            return isValid;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        internal static bool IsLandLine(string integerValue, int startIndex)
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
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        internal static bool IsMobile(string integerValue, int startIndex)
        {
            bool isValid = integerValue.Substring(startIndex, 1).Equals("1") && Regex.IsMatch($"{integerValue[1]}", "[3-9]");
            return isValid;
        }
    }
}
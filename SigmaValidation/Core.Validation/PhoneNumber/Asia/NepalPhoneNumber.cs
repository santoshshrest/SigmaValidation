using Core.Validation.Model;
using System.Linq;

namespace Core.Validation
{
    internal static class NepalPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static OperationResult<bool> IsNepaliPhoneNumber(this string number)
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
        private static bool IsInternationalCode(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Substring(0, 5) == "00977" && (integerValue.Length == 13 || integerValue.Length == 15))
            {
                isValid = HasCorrectCode(integerValue, 5);
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
            if (integerValue.Substring(0, 1) == "0" && integerValue.Length == 9)
            {
                isValid = IsLandLine(integerValue, 1);
            }
            else if (integerValue.Length == 8)
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
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool HasCorrectCode(string integerValue, int startIndex)
        {
            bool hasCorrectCode = IsLandLine(integerValue, startIndex) || IsMobile(integerValue, startIndex);
            return hasCorrectCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsMobile(string integerValue, int startIndex)
        {
            bool isMobile = DataCollections.NP_MobileCodes.Contains(integerValue.Substring(startIndex, 3));
            return isMobile;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsLandLine(string integerValue, int startIndex)
        {
            bool isLandLine = false;
            string[] phoneInitials = new string[] { "4", "5", "6" };
            if (DataCollections.NP_AreaCodesOneDigit.Contains(integerValue.Substring(startIndex, 1)))
            {
                startIndex += 1;
                isLandLine = phoneInitials.Contains(integerValue.Substring(startIndex, 1));
            }
            else if (DataCollections.NP_AreaCodesTwoDigits.Contains(integerValue.Substring(startIndex, 2)))
            {
                startIndex += 2;
                isLandLine = phoneInitials.Contains(integerValue.Substring(startIndex, 1));
            }
            else if (DataCollections.NP_AreaCodesThreeDigits.Contains(integerValue.Substring(startIndex, 3)))
            {
                startIndex += 3;
                isLandLine = phoneInitials.Contains(integerValue.Substring(startIndex, 1));
            }
            return isLandLine;
        }
    }
}

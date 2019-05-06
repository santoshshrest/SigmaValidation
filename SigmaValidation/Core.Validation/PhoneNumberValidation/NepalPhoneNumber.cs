using Core.Validation.DataHelper;
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
                if (CheckInitials(integerValue) && (HasCorrectCode(integerValue, 5) || HasCorrectCode(integerValue, 1) || HasCorrectCode(integerValue, 0)))
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
        private static bool CheckInitials(string integerValue)
        {
            if (integerValue.Substring(0, 2) == "00")
            {
                return integerValue.Substring(0, 5) == "00977" && (integerValue.Length == 13 || integerValue.Length == 15);
            }
            else if (integerValue.Substring(0, 1) == "0")
            {
                return integerValue.Length == 9;
            }
            else
            {
                return integerValue.Length == 6 || integerValue.Length == 7 || integerValue.Length == 9 || integerValue.Length == 10;
            }
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
            bool isMobile = DataCollections.NP_MobileCodes.Contains(integerValue.Substring(startIndex, 2));
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
            if (DataCollections.NP_AreaCodes.Contains(integerValue.Substring(startIndex, 2)))
            {
                startIndex += 2;
                isLandLine = phoneInitials.Contains(integerValue.Substring(startIndex, 1));
            }
            else if (DataCollections.NP_AreaCodes.Contains(integerValue.Substring(startIndex, 3)))
            {
                startIndex += 3;
                isLandLine = phoneInitials.Contains(integerValue.Substring(startIndex, 1));
            }
            return isLandLine;
        }
    }
}

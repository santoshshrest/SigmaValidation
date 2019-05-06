using Core.Validation.DataHelper;
using Core.Validation.Model;
using System.Linq;

namespace Core.Validation
{
    internal static class DenmarkPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static OperationResult<bool> IsDenmarkPhoneNumber(this string number)
        {
            var operation = new OperationResult<bool>(false);
            CheckPhoneNumber.ValidatePhoneNumber(number, operation);
            if (operation.Result)
            {
                string integerValue = CheckPhoneNumber.GetNumbers(number);
                if (CheckInitials(integerValue) && (HasCorrectCode(integerValue, 4) || HasCorrectCode(integerValue, 0)))
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
            bool hasZeros = integerValue.Substring(0, 2) == "00";
            if (hasZeros)
            {
                return integerValue.Substring(0, 4) == "0045" && integerValue.Length == 12;
            }
            else
            {
                return integerValue.Length == 8;
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
            bool hasCorrectCode = IsMobile(integerValue, 4) || IsLandLine(integerValue, 4) || IsSpare(integerValue, 4) || IsSplitCharge(integerValue, 4) || IsFreePhone(integerValue, 4) || IsPremium(integerValue, 4);
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
            bool isMobile = DataCollections.DK_MobileCodes.Contains(integerValue.Substring(startIndex, 2));
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
            bool isLandLine = DataCollections.DK_MobileCodes.Contains(integerValue.Substring(startIndex, 2));
            return isLandLine;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsSpare(string integerValue, int startIndex)
        {
            bool isSpare = DataCollections.DK_MobileCodes.Contains(integerValue.Substring(startIndex, 2));
            return isSpare;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsSplitCharge(string integerValue, int startIndex)
        {
            bool isSplitCharge = DataCollections.DK_MobileCodes.Contains(integerValue.Substring(startIndex, 2));
            return isSplitCharge;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsFreePhone(string integerValue, int startIndex)
        {
            bool isFreePhone = DataCollections.DK_MobileCodes.Contains(integerValue.Substring(startIndex, 2));
            return isFreePhone;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsPremium(string integerValue, int startIndex)
        {
            bool isPremium = DataCollections.DK_MobileCodes.Contains(integerValue.Substring(startIndex, 2));
            return isPremium;
        }
    }
}

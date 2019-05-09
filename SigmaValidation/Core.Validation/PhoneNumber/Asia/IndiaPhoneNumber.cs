using Core.Validation.Model;
using System.Linq;

namespace Core.Validation
{
    internal static class IndiaPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static OperationResult<bool> IsIndiaPhoneNumber(this string number)
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
            if (integerValue.Substring(0, 4) == "0091" && integerValue.Length == 14)
            {
                isValid = HasCorrectCode(integerValue, 4);
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
                isValid = IsLandLine(integerValue, 0);
            }
            else if (integerValue.Length >= 6 && integerValue.Length <= 8)
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
            bool isValid = IsLandLine(integerValue, startIndex) || IsMobile(integerValue, startIndex);
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
            if (DataCollections.IN_AreaCodesTwoDigits.Contains(integerValue.Substring(startIndex, 2)))
            {
                isValid = true;
            }
            else if (DataCollections.IN_AreaCodesThreeDigits.Contains(integerValue.Substring(startIndex, 3)))
            {
                isValid = true;
            }
            else if (DataCollections.IN_AreaCodesFourDigits.Contains(integerValue.Substring(startIndex, 4)))
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
            bool isValid = DataCollections.IN_Mobile.Contains(integerValue.Substring(startIndex, 1));
            return isValid;
        }
    }
}
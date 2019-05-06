using Core.Validation.DataHelper;
using Core.Validation.Model;
using System.Linq;

namespace Core.Validation
{
    internal static class USPhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static OperationResult<bool> IsUSPhoneNumber(this string number)
        {
            var operation = new OperationResult<bool>(false);
            CheckPhoneNumber.ValidatePhoneNumber(number, operation);
            if (operation.Result)
            {
                string integerValue = CheckPhoneNumber.GetNumbers(number);
                if (integerValue.Length >= 10 && integerValue.Length <= 13)
                {
                    if (CheckInitials(integerValue) && IsPhone(integerValue, 3) || IsPhone(integerValue, 0))
                    {
                        operation = new OperationResult<bool>(true, null, "Success");
                    }
                    else
                    {
                        operation = new OperationResult<bool>(false, null, $"Invalid phone number {number}.");
                    }
                }
                else
                {
                    operation = new OperationResult<bool>(false, null, $"Invalid phone number {number}. Phone number is too long.");
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
                return integerValue.Substring(0, 3) == "001" && integerValue.Length == 13;
            }
            else
            {
                return integerValue.Length == 10;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private static bool IsPhone(string integerValue, int startIndex)
        {
            bool isPhone = DataCollections.US_AreaCodes.Contains(integerValue.Substring(startIndex, 3));
            return isPhone;
        }
    }
}
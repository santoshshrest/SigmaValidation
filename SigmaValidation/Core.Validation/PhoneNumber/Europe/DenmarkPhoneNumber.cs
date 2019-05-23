using Core.Validation.Model;
using System.Linq;

namespace Core.Validation
{
    internal static class DenmarkPhoneNumber
    {
        /// <summary>
        /// Check phone number for Denmark, checks country code then checks all codes such as mobile, land line, spare, split charge, free phone and premium codes
        /// </summary>
        /// <param name="number">phone number to be validated</param>
        /// <returns></returns>
        internal static bool IsDenmarkPhoneNumber(this string number)
        {
            bool result = IsInternationalCodes(number) || IsAreaCode(number);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integerValue"></param>
        /// <returns></returns>
        private static bool IsInternationalCodes(string integerValue)
        {
            bool isValid = false;
            if (integerValue.Substring(0, 4) == "0045" && integerValue.Length == 12)
            {
                isValid = IsMobile(integerValue, 4) || IsLandLine(integerValue, 4) || IsSpare(integerValue, 4) || IsSplitCharge(integerValue, 4) || IsFreePhone(integerValue, 4) || IsPremium(integerValue, 4);
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
            if (integerValue.Length == 8)
            {
                isValid = IsMobile(integerValue, 0) || IsLandLine(integerValue, 0) || IsSpare(integerValue, 0) || IsSplitCharge(integerValue, 0) || IsFreePhone(integerValue, 0) || IsPremium(integerValue, 0);
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
            bool isLandLine = DataCollections.DK_LandLineCodes.Contains(integerValue.Substring(startIndex, 2));
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
            bool isSpare = DataCollections.DK_SpareCodes.Contains(integerValue.Substring(startIndex, 2));
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
            bool isSplitCharge = DataCollections.DK_SplitChargeCodes.Contains(integerValue.Substring(startIndex, 2));
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
            bool isFreePhone = DataCollections.DK_FreePhoneCodes.Contains(integerValue.Substring(startIndex, 2));
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
            bool isPremium = DataCollections.DK_PremiumCodes.Contains(integerValue.Substring(startIndex, 2));
            return isPremium;
        }
    }
}

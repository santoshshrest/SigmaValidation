using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Validation
{
    internal static class SystemTool
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        internal static string ReadException(this Exception exception)
        {
            string errorMessage = "";
            WriteException(exception, ref errorMessage);
            return errorMessage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="errorMessage"></param>
        private static void WriteException(Exception exception, ref string errorMessage)
        {
            errorMessage += exception.Message;
            if (exception.InnerException != null)
            {
                errorMessage += Environment.NewLine;
                WriteException(exception.InnerException, ref errorMessage);
            }
        }
    }
}
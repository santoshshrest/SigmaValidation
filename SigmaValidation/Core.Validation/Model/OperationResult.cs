using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Validation.Model
{
    public class OperationResult<TResult>
    {
        public OperationResult(TResult result, Exception exception = null, string errorMessage = null)
        {
            Result = result;
            Exception = exception;
            Message = errorMessage;
        }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public TResult Result { get; set; }
    }
}

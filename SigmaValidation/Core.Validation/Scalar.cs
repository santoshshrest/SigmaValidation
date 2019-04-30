using Core.Validation.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Validation
{
    public static class Scalar
    {
        public static OperationResult<bool> IsScalar(this object variable)
        {
            var operation = new OperationResult<bool>(false);
            if (variable is string || variable is int || variable is double || variable is bool)
            {
                operation.Result = true;
                operation.Message = "Success";
            }
            else
            {
                operation.Result = false;
                operation.Message = "Provided data is not scalar.";
            }
            return operation;
        }

        public static OperationResult<bool> IsScalar(this object[] variables)
        {
            var operation = new OperationResult<bool>(false);

            return operation;
        }

        public static OperationResult<bool> IsScalar(this IList<object> variables)
        {
            var operation = new OperationResult<bool>(false);

            return operation;
        }
    }
}
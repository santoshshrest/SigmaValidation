using Core.Validation.Model;
using System.Collections.Generic;

namespace Core.Validation
{
    public static class Scalar
    {
        /// <summary>
        /// Check object variable as data type as scalar
        /// object is scalar if data type is string, int, double or bool
        /// </summary>
        /// <param name="variable">object</param>
        /// <returns>OperationResult with bool result, true is correct else false</returns>
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
                operation.Message = $"Provided data is not scalar: {variable}. Data Type: {variable.GetType().Name}";
            }
            return operation;
        }
        /// <summary>
        /// Check array of object as each data type as scalar
        /// array is scalar if all data in array is string, int, double or bool
        /// </summary>
        /// <param name="variables">array of object</param>
        /// <returns>OperationResult with bool result, true is correct else false</returns>
        public static OperationResult<bool> IsScalar(this object[] variables)
        {
            var operation = new OperationResult<bool>(true, null, "Success");
            foreach (var variable in variables)
            {
                if (!(variable is string) && !(variable is int) && !(variable is double) && !(variable is bool))
                {
                    operation.Result = false;
                    operation.Message = $"Provided data is not scalar: {variable}. Data Type: {variable.GetType().Name}";
                    break;
                }
            }
            return operation;
        }
        /// <summary>
        /// Check list of object as each data type as scalar
        /// list is scalar if all data in list is string, int, double or bool
        /// </summary>
        /// <param name="variables">OperationResult with bool result, true is correct else false</param>
        /// <returns>OperationResult with bool result, true is correct else false</returns>
        public static OperationResult<bool> IsScalar(this IList<object> variables)
        {
            var operation = new OperationResult<bool>(false);
            foreach (var variable in variables)
            {
                if (!(variable is string) && !(variable is int) && !(variable is double) && !(variable is bool))
                {
                    operation.Result = false;
                    operation.Message = $"Provided data is not scalar: {variable}. Data Type: {variable.GetType().Name}";
                    break;
                }
            }
            return operation;
        }
    }
}
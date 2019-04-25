# SigmaValidation
## Validating Data
### OperationResult<T>
- `Result`: Dynamic type data (bool, int, object)
- `Message`: String value denoting success and failure of request or operation
- `Exception`: Exception is set if there is any exception occured during operation
## Methods
- `IsPhoneNumber`:  * Check whether phone number is valid or not.
                    * Result is true for valid phone number
                    * Result is false for invalid phone number and message is set in error message, if exception has occured while checking then Exception is set
- `IsEmail`: * Check whether the email is valid or not. 					
             * Operation resut is true for vaid email
             * False if email address is not valid. Message is set and if exception occured exception is set
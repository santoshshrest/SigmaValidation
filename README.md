# Summary
## Validation Plugin under active development. Functionality and documentation my change without notice. ##

This plugin provides programmatic access to several data valiadtion functions. It consists of three validating modules.
Each modules consists of one or more actions that perform an operation against your data validation process.
All of the methods will return result object indicating success or failure, any exceptions thrown and the resulting data.

### Target Framework: .NetFramework 4.5/4.6, .Net Standard 2.0 ###

# SigmaValidation
## Validating Data
### OperationResult<T>
- `Result`: Dynamic type data (bool, int, object)
- `Message`: String value denoting success and failure of request or operation
- `Exception`: Exception is set if there is any exception occured during operation
## Phone Number Validation
    Validates phone number.
    namespace: Core.Validation
    
## Methods
### `IsPhoneNumber`:  
    - Check whether phone number is valid or not.
    - Result is true for valid phone number
    - Result is false for invalid phone number and message is set in error message, if exception has occured while checking then Exception is set
    - Eg;   
                var phoneNumber = "+9779876543210";
                var result = phoneNumber.IsPhoneNumber();

### `IsPhoneNumber(string code)`:  
    - Check whether phone number is valid or not for provided country.
    - Support country, currently available;
        - Nepal (NP)
        - United States (US)
        - Denmark (DK)
        - India (IN)
        - China (CN)
        - United Kingdom (UK)
        - Thailand (TH)
        - Malaysia (MY)
        - Singapore (SG)
        - Afghanistan (AF)
        - Germany (DE)
        - Sweden (SE)
        - Switzerland (CH)
        - Canada (CA)
        - Australia (AU)
        - South Africa (ZA)
        - Japan (JP)
        - Franch (FR)
        - Finland (FI)
        - Argentina (AR)
        - South Korea (KR)
        - Nigeria (NG)
        - Antigua Barbuda (AG)
    - Result is true for valid phone number
    - Result is false for invalid phone number and message is set in error message, if exception has occured while checking then Exception is set
    - Eg;   
                var phoneNumber = "+9779876543210";
                var result = phoneNumber.IsPhoneNumber("NP");
## Email Validation
    Validates email.
    namespace: Core.Validation
	
### `IsEmail`: 
    - Check whether the email is valid or not.
    - Operation resut is true for vaid email
    - False if email address is not valid. Message is set and if exception occured exception is set
    - Eg;   
                var email = "someemail@somedomain.com";
                var result = email.IsEmail();
## Data Validation
    Validates data types.
    namespace: Core.Validation

### `IsScalar`:
    - Check whether the data provided is scalar
    - Data is scalar if the data type is either of string, int, double or 
    - Operation result is true for valid data type
    - False if email address is not valid. Message is set and if exception occured exception is set
    - Eg;   1) Simple data
                        var variable = "test data 1";
                        var result =  variable.IsScalar();
              2) Array data
                        var variables = new object[] { "test 1", 1, 1.1, true };
                        var result = variables.IsScalar();
              3) List data
                        var variables = new List<object> { "test", 1, 1.1, true };
                        var result = variables.IsScalar();
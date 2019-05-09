# Summary
## Validation Plugin under active development. Functionality and documentation my change without notice. ##
<pre>
This plugin provides programmatic access to several data valiadtion functions. It consists of three validating modules.
Each modules consists of one or more actions that perform an operation against your data validation process.
All of the methods will return result object indicating success or failure, any exceptions thrown and the resulting data.
<hr/>
<b> Target Framework: .NetFramework 4.5/4.6, .Net Standard 2.0</b>
</pre>
# SigmaValidation
## Validating Data
### OperationResult<T>
- `Result`: Dynamic type data (bool, int, object)
- `Message`: String value denoting success and failure of request or operation
- `Exception`: Exception is set if there is any exception occured during operation
## Phone Number Validation
<pre>
    Validates phone number.
    namespace: Core.Validation
</pre>
    
### Methods
- `IsPhoneNumber`:  
    - Check whether phone number is valid or not.
    - Result is true for valid phone number
    - Result is false for invalid phone number and message is set in error message, if exception has occured while checking then Exception is set
    - Eg;   <pre>
                var phoneNumber = "+9779876543210";
                var result = phoneNumber.IsPhoneNumber();
            </pre> 

- `IsPhoneNumber(string code)`:  
    - Check whether phone number is valid or not for provided country.
    - Support country currently available;
        - Nepal (NP)
        - United States (US)
        - Denmark (DK)
        - India (IN)
        - China (CN)
        - United Kingdom (UK)

    - Result is true for valid phone number
    - Result is false for invalid phone number and message is set in error message, if exception has occured while checking then Exception is set
    - Eg;   <pre>
                var phoneNumber = "+9779876543210";
                var result = phoneNumber.IsPhoneNumber("NP");
            </pre>
        
- `IsEmail`: 
    - Check whether the email is valid or not.
    - Operation resut is true for vaid email
    - False if email address is not valid. Message is set and if exception occured exception is set
    - Eg;   <pre>
                var email = "someemail@somedomain.com";
                var result = email.IsEmail();
            </pre>

- `IsSalar`:
    - Check whether the data provided is scalar
    - Data is scalar if the data type is either of string, int, double or 
    - Operation result is true for valid data type
    - False if email address is not valid. Message is set and if exception occured exception is set
    - Eg;   <b>1) Simple data</b><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <code>
                    var variable = "test data 1";<br/>&nbsp;&nbsp;&nbsp;&nbsp;
                    var result =  variable.IsScalar();
                </code><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <b>2) Array data</b><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <code>
                    var variables = new object[] { "test 1", 1, 1.1, true };<br/>&nbsp;&nbsp;&nbsp;&nbsp;
                    var result = variables.IsScalar();
                </code><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <b>3) List data</b><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <code>
                    var variables = new List<object> { "test", 1, 1.1, true };<br/>&nbsp;&nbsp;&nbsp;&nbsp;
                    var result = variables.IsScalar();
                </code>
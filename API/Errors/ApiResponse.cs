using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            // ?? = null coalescing operator?
            // ?? means that if what is to the left of the operator is equal to null then execute the
            // logic to the right of it - like a shorthand for an if statement maybe
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        

        public int StatusCode { get; set; }

        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side.  Errors lead to anger.  Anger leads to hate.  Hate leads to career change",

                // _ = default case for the switch statement it seems
                _ => null

            };
        }
    }
}
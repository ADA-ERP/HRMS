﻿namespace Shared.Abstractions.Exceptions
{
    public class ApiResponse
    {
        public ApiResponse()
        {

        }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }

        

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request you have made",
                401 => "Authorized, your not",
                404=>  "Resource found, it's not",
                500=>  "Error oops!..",
                _ => string.Empty
            };
        }
    }
}

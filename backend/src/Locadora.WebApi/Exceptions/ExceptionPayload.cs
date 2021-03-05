using Locadora.Core.Exceptions;
using System;
using System.Text.Json.Serialization;

namespace Locadora.WebApi.Exceptions
{
    public class ExceptionPayload
    {
        public int Status { get; set; }

        public string Error { get; set; }

        public string Message { get; set; }

        [JsonIgnore]
        public Exception Exception { get; set; }

        public static ExceptionPayload New<T>(T exception) where T : Exception
        {
            int statusCode;
            string error;

            if (exception is BussinessException)
            {
                statusCode = (exception as BussinessException).StatusCodes.GetHashCode();
                error = (exception as BussinessException).StatusCodes.ToString();
            }
            else
            {
                statusCode = StatusCodes.Unhandled.GetHashCode();
                error = StatusCodes.Unhandled.ToString();
            }

            return new ExceptionPayload
            {
                Status = statusCode,
                Error = error,
                Message = exception.Message,
                Exception = exception,
            };
        }
    }
}

using Locadora.Core.Exceptions;
using System;

namespace Locadora.WebApi.Exceptions
{
    public class ExceptionPayload
    {
        public ExceptionPayload(int status, string error, string message, Exception exception)
        {
            Status = status;
            Error = error;
            Message = message;
            _exception = exception;
        }

        private Exception _exception;
        public int Status { get; set; }

        public string Error { get; set; }

        public string Message { get; set; }

        public Exception GetException() => _exception;

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

            return new ExceptionPayload(statusCode, error, exception.Message, exception);
        }
    }
}

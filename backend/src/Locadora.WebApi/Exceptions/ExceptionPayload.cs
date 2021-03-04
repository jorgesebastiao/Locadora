﻿using Locadora.Core.Exceptions;
using System;
using System.Text.Json.Serialization;

namespace Locadora.WebApi.Exceptions
{
    public class ExceptionPayload
    {
        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        [JsonIgnore]
        public Exception Exception { get; set; }

        public static ExceptionPayload New<T>(T exception) where T : Exception
        {
            int errorCode;

         /*   if (exception is BussinessException)
            //    errorCode = (exception as BussinessException).ErrorCode.GetHashCode();
            else
              //  errorCode = ErrorCodes.Unhandled.GetHashCode();
         */
            return new ExceptionPayload
            {
                ErrorCode = 400,
                ErrorMessage = exception.Message,
                Exception = exception,
            };
        }
    }
}

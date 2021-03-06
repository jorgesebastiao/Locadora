﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Locadora.Core.Exceptions;
using Locadora.Core.Results;
using Locadora.WebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Locadora.WebApi.Controllers.Common
{
    public class ApiControllerBase: ControllerBase
    {

        public IActionResult HandleCommand<TFailure, TSuccess>(Result<TFailure, TSuccess> callback) where TFailure : Exception
        {
            return callback.IsFailure ? HandleFailure(callback.Failure) : Ok(callback.Success);
        }

        public IActionResult HandleQuery<TSource, TResult>(Result<Exception, TSource> callback)
        {
            return callback.IsFailure ? HandleFailure(callback.Failure) : Ok(Mapper.Map<TSource, TResult>(callback.Success));
        }

        public  async Task<IActionResult> HandleQueryable<TSource, TResult>(Result<Exception, IQueryable<TSource>> callback)
        {
            if (callback.IsFailure)
                return HandleFailure(callback.Failure);

            var query = callback.Success;

            var result = query.AsQueryable().ProjectTo<TResult>();

            return Ok(await result.ToListAsync());
        }

        public IActionResult HandleFailure<T>(T exceptionToHandle) where T : Exception
        {
            if (exceptionToHandle is ValidationException)
                return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), (exceptionToHandle as ValidationException).Errors);

            var exceptionPayload = ExceptionPayload.New(exceptionToHandle);

            return exceptionToHandle is BussinessException ?
                StatusCode(HttpStatusCode.BadRequest.GetHashCode(), exceptionPayload) :
                StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), exceptionPayload);
        }
    }
}

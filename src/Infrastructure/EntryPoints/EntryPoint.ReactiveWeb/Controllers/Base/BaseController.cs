using Domain.Models.Entities.Base;
using Domain.Models.Enums;
using Helpers.Commons.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace EntryPoint.ReactiveWeb.Controllers.Base
{
    /// <summary>
    /// BaseController
    /// </summary>
    /// <typeparam name="TController"></typeparam>
    [ApiController]
    public class BaseController<TController> : ControllerBase
    {
        private readonly ILogger<TController> _loggerService;

        /// <summary>
        /// BaseController
        /// </summary>
        /// <param name="loggerService"></param>
        public BaseController(ILogger<TController> loggerService)
        {
            _loggerService = loggerService;
        }

        public async Task<IActionResult> HandleRequestAsync<TResult>(Func<Task<TResult>> requestHandler)
        {
            MethodBase? method = MethodBase.GetCurrentMethod();
            string? function = Request.Path.Value, message = string.Empty;
            int errorCode = 0;
            bool error = false;
            dynamic? data = null;

            try
            {
                data = await requestHandler();
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message, method, ex);
                error = true;
                errorCode = (int)ExceptionsDetail.UnhandledException;
                message = ExceptionsDetail.UnhandledException.GetDescription();
            }

            ResponseEntity response = new ResponseEntity().Build(function, message, errorCode, error, data);

            return error
                ? BadRequest(response)
                : Ok(response);
        }

    }
}

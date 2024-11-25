using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using My.Custom.Template.Domain.Models;
using My.Custom.Template.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Presentation.Filters
{
    public class ResultTransformerActionFilter : ActionFilterAttribute
    {
        private readonly ILogger<ResultTransformerActionFilter> _logger;

        public ResultTransformerActionFilter(ILogger<ResultTransformerActionFilter> logger)
        {

            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                        .SelectMany(v => v.Errors)
                        .Select(v => v.ErrorMessage)
                        .ToList();
                context.Result = new ObjectResult(new BadRequestResponse()
                {
                    Error = new DataError() { Message = string.Join(System.Environment.NewLine, errors), Code = ResponseCodes.BadRequest }
                });
                context.HttpContext.Response.StatusCode = ResponseCodes.BadRequest;

                _logger.LogError($"The request has: [{ResponseCodes.BadRequest}] code with: {string.Join(System.Environment.NewLine, errors)} ");

            }

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            switch (context.Result)
            {
                case ObjectResult p:
                    switch (p.Value)
                    {
                        case object v:

                            var responseType = typeof(SingleResponseModel<>).MakeGenericType(p.Value.GetType());
                            var response = Activator.CreateInstance(responseType, p.Value);
                            context.Result = new ObjectResult(response);
                            break;

                        case null:
                            context.Result = new ObjectResult(new NotFoundResponse()
                            {
                                Error = new DataError() { Message = ResponseCodes.NotFoundResponse, Code = ResponseCodes.NotFound }
                            });
                            context.HttpContext.Response.StatusCode = ResponseCodes.NotFound;

                            break;
                    }
                    break;
                case null:
                    context.Result = new ObjectResult(new NotFoundResponse());
                    context.HttpContext.Response.StatusCode = ResponseCodes.NotFound;
                    break;
            }

            base.OnActionExecuted(context);
        }
    }
}

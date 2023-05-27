using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests;
using LocalMarketer.ApplicationServices.API.Domain.Responses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;

namespace LocalMarketer.Controllers
{
        public abstract class ApiControllerBase : ControllerBase
        {
                protected readonly IMediator mediator;
                protected ApiControllerBase(IMediator mediator)
                {
                        this.mediator = mediator;
                }
                protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
                    where TRequest : RequestBase, IRequest<TResponse>
                    where TResponse : ErrorResponseBase

                {
                        if (!this.ModelState.IsValid)
                        {
                                var modelStateErrors = this.ModelState.Where(x => x.Value.Errors.Any())
                                        .Select(x => new
                                        {
                                                error = x.Value.Errors
                                        .Select(v => v.ErrorMessage).FirstOrDefault(), });
                                foreach(var error in modelStateErrors)
                                {
                                        Debug.WriteLine(error);
                                }
                                


                                return this.BadRequest(
                                    this.ModelState
                                        .Where(x => x.Value.Errors.Any())
                                        .Select(x => new
                                        {
                                                error = x.Value.Errors
                                        .Select(v => v.ErrorMessage).FirstOrDefault(),
                                        }).FirstOrDefault());
                        }

                        var hasAccess = (this.User.FindFirstValue(ClaimTypes.AuthorizationDecision));

                        if(hasAccess == "False")
                        {
                                return this.ErrorResponse(new ErrorModel(ErrorType.Unauthorized));
                        }

                        var loggedUserRole = this.User.FindFirstValue(ClaimTypes.Role);
                        request.LoggedUserRole = loggedUserRole;
                        var loggedUSerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                        request.LoggedUserId = loggedUSerId;
                        var loggedUserFullName = this.User.FindFirstValue(ClaimTypes.Name);
                        request.LoggedUserFullName = loggedUserFullName;


                        var response = await this.mediator.Send(request);
                        if (response.Error != null)
                        {
                                return this.ErrorResponse(response.Error);
                        }
                        return this.Ok(response);
                }

                private IActionResult ErrorResponse(ErrorModel errorModel)
                {
                        var httpCode = GetHttpStatusCode(errorModel.Error);
                        return StatusCode((int)httpCode, errorModel);
                }
                private static HttpStatusCode GetHttpStatusCode(string errorType)
                {
                        switch (errorType)
                        {
                                case ErrorType.NotFound:
                                        return HttpStatusCode.NotFound;
                                case ErrorType.InternalServerError:
                                        return HttpStatusCode.InternalServerError;
                                case ErrorType.Unauthorized:
                                        return HttpStatusCode.Unauthorized;
                                case ErrorType.RequestTooLarge:
                                        return HttpStatusCode.RequestEntityTooLarge;
                                case ErrorType.UnsupportedMediaType:
                                        return HttpStatusCode.UnsupportedMediaType;
                                case ErrorType.UnsupportedMethod:
                                        return HttpStatusCode.MethodNotAllowed;
                                case ErrorType.TooManyRequests:
                                        return (HttpStatusCode)429;
                                default:
                                        return HttpStatusCode.BadRequest;
                        }
                }
        }
}

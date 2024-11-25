using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Domain.Utils
{
    public class ResponseCodes
    {
        public const int Success = (int)HttpStatusCode.OK;
        public const int Failure = (int)HttpStatusCode.InternalServerError;
        public const int BadRequest = (int)HttpStatusCode.BadRequest;
        public const int Unauthorized = (int)HttpStatusCode.Unauthorized;
        public const int NotFound = (int)HttpStatusCode.NotFound;
        public const string BadRequestResponse = "Bad Request";
        public const string SuccessResponse = "Success";
        public const string NotFoundResponse = "Not Found";
        public const string FailureResponse = "Internal Error";
        public const string UnauthorizedResponse = "Unauthorized Request";
    }
}

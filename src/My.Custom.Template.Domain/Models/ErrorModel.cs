using My.Custom.Template.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Domain.Models
{
    public class ErrorResponse : ResponseBase<string>
    {
        public ErrorResponse() { }

        public ErrorResponse(bool result, string error) : base(result, error)
        {

        }

        public static ResponseBase<string> BadRequest(string error)
        {
            return new ErrorResponse(false, error) { Description = ResponseCodes.BadRequestResponse, Data = string.Empty };
        }
    }
}

using My.Custom.Template.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Domain.Models
{
    public class SingleResponseModel<TItems> : ResponseBase<TItems>
    {
        public SingleResponseModel(TItems data)
        {
            Data = data;
        }
    }
    public class NotFoundResponse : ResponseBase<string>
    {
        public NotFoundResponse()
        {
            Code = ResponseCodes.NotFound;
            Description = ResponseCodes.NotFoundResponse;
        }
    }

    public class BadRequestResponse : ResponseBase<string>
    {
        public BadRequestResponse()
        {
            Code = ResponseCodes.BadRequest;
            Description = ResponseCodes.BadRequestResponse;
        }
    }
}

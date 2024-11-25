using My.Custom.Template.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Domain.Models
{
    public class ResponseBase<TItems>
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public TItems Data { get; set; }
        public DataError Error { get; set; }
        public ResponseBase()
        {
            Code = ResponseCodes.Success;
        }

        public ResponseBase(bool result, string error)
        {
            Code = result ? ResponseCodes.Success : ResponseCodes.Failure;
            Error = !result ? new DataError { Code = ResponseCodes.Failure, Message = error } : null;
            if (!result)
                Description = ResponseCodes.FailureResponse;
        }


    }
    public class DataError
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}

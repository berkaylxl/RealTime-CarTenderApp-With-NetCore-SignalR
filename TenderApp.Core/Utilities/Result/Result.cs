using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TenderApp.Core.Utilities.Result.ResultStatus;

namespace TenderApp.Core.Utilities.Result
{
    public class Result : IResult
    {
        public Result(Status resultStatus)
        {
            Status = resultStatus;
        }
        public Result(Status resultStatus,string message):this(resultStatus)
        {
            Message = message;
        }
        public Result(Status resultStatus, string message,Exception exception) : this(resultStatus,message)
        {
           Exception = exception;
        }

        public Status Status {get; set;}

        public string Message { get; set; }

        public Exception Exception { get; set; }
    }
}

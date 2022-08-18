using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TenderApp.Core.Utilities.Result.ResultStatus;

namespace TenderApp.Core.Utilities.Result
{
    public interface IResult
    {
        public Status Status { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}

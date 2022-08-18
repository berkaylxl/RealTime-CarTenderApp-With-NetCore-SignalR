using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TenderApp.Core.Utilities.Result.ResultStatus;

namespace TenderApp.Core.Utilities.Result
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult( T data)
        {
            Data = data;
        }
        public DataResult(Status resultStatus,T data):this(data)
        {
            Status = resultStatus;
        }
        public DataResult(Status resultStatus, T data,string message):this(resultStatus, data)
        {
            Message = message;
        }
        public DataResult(Status resultStatus, T data, string message,Exception exception) : this(resultStatus, data,message)
        {
            Exception=exception;
        }
        public DataResult(Status resultStatus, T data, Exception exception) : this(resultStatus, data)
        {
            Exception = exception;
        }
        public T Data { get; }

        public Status Status { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.General.Result
{
    public class SuccessResult<T> : Result<T>
    {
        private readonly T _data;
        public SuccessResult(T data)
        {
            _data = data;
        }
        public override ResultType ResultType => ResultType.Ok;

        public override List<string> Errors => new List<string>();

        public override T Data => _data;
    }

    public class SuccessResult : Result
    {
        public SuccessResult(string message):base(ResultType.Ok, message)
        {
        }
    }
}

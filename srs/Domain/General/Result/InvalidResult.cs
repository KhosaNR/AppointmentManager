﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.General.Result
{
    public class InvalidResult<T> : Result<T>
    {
        private string _error;
        public InvalidResult(string error)
        {
            _error = error;
        }
        public override ResultType ResultType => ResultType.Invalid;

        public override List<string> Errors => new List<string> { _error ?? "The input was invalid." };

        public override T Data => default(T);
    }

    public class InvalidResult : Result
    {
        public InvalidResult(string message): base(ResultType.Invalid,message?? "The input was invalid.")
        {
        }
    }
}

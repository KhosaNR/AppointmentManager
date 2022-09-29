﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.General.Result
{
    public class UnexpectedResult<T> : Result<T>
    {
        public override ResultType ResultType => ResultType.Unexpected;

        public override List<string> Errors => new List<string> { "There was an unexpected problem" };

        public override T Data => default(T);
    }

    public class UnexpectedResult : Result
    {
        public UnexpectedResult(string message) : base(ResultType.Unexpected, message)
        {
        }
    }
}

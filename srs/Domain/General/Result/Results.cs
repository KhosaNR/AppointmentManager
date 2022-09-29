using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.General.Result
{
    public class Results
    {
        List<Result> ResultList { get; set; } = new();
        public Results() { }
        public bool IsOk()
        {
            if (ResultList == null) return true;
            if (ResultList.Count == 0) return true;
            return !ResultList.Any(r=>r.ResultType!= ResultType.Ok);
        }

        public void Add(Result result)
        {
            ResultList.Add(result);
        }

    }
}

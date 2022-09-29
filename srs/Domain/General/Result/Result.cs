using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.General.Result
{
    public abstract class Result<T>
    {
        public abstract ResultType ResultType { get; }
        public abstract List<string> Errors { get; }
        public abstract T Data { get; }
    }
    public abstract class ResultBase
    {
        public ResultBase() { }
        public abstract ResultType ResultType { get; }
        public abstract List<string> Messages { get; }

    }

    public class Result: ResultBase
    {
        protected ResultType _resultType;
        protected List<string> _messages = new List<string>();

        public Result(ResultType resultType, string message)
        {
            _resultType = resultType;
            _messages = new() {message};
        }
        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
        public override ResultType ResultType => _resultType;

        public override List<string> Messages => _messages;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success)
        {
            Success = success;
        }
        public Result(bool success, string title, string message) : this(success)
        {
            Title = title;
            Message = message;
        }

        public bool Success { get; }
        public string Title { get; }
        public string Message { get; }
    }
}

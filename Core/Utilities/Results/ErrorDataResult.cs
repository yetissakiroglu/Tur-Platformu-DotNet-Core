using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data,string title, string message) : base(data, false,title, message)
        {
        }

        public ErrorDataResult(T data) : base(data, false)
        {
        }

        public ErrorDataResult(string title, string message) : base(default, false,title, message)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}

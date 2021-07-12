using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string title, string message) : base(data, true, title, message)
        {
        }

        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult(string title, string message) : base(default, true, title, message)
        {

        }

        public SuccessDataResult() : base(default, true)
        {

        }
    }

}

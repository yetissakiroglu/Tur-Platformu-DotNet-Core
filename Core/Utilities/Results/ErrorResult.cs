using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string title, string message) : base(false,title, message)
        {
        }

        public ErrorResult() : base(false)
        {
        }
    }
}

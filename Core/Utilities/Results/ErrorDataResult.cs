using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class ErrorResult<T>: DataResult<T>
    {
        public ErrorResult(T data, string message): base(data,false,message)
        {

        }
        public ErrorResult(T data): base(data, false)
        {

        }
        public ErrorResult(string message): base(default, false, message)
        {

        }
        public ErrorResult(): base(default, false)
        {

        }
    }
}

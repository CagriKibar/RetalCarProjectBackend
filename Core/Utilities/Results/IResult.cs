using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        bool Success
        {
            get;  //sadece okunabilir bir özellik verdik. bool vermemizin sebebi true ve false şeklinde iki cevap almasıdır.
        }
        string Message { get; }
    }
}

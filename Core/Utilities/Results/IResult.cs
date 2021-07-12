using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        //Yapılan İşlem Durumu
        bool Success { get; }
        //Yapılan İşlem Başlığı
        string Title { get; }
        //Yapılan İşlem Mesajı
        string Message { get; }
    }
}

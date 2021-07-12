using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class tour: Core.Entities.IEntity
    {
        [Key]
        public int tour_id { get; set; }  //turun id'si
        public string tour_title { get; set; } // turun başlığı
        public string tour_description { get; set; } //turun açıklaması
        public int  bus_id { get; set; } //otobüs id'si
        public int quant { get; set; } //turun kotası
        public bool? state { get; set; } // turun aktif pasif özelliği
        public bool? IsChecked { get; set; } //turun silinme durumu



    }
}

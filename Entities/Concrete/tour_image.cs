using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class tour_image: Core.Entities.IEntity
    {
        [Key]
        public int image_id { get; set; } // tur resim id
        public int tour_id { get; set; } //tur id
        public string  image_title { get; set; } //resim başlığı
        public string path_url { get; set; } //resim yolu
        public bool? state { get; set; } //resim görünüp görünmediği
        public bool? IsChecked { get; set; } // turun silinip silinmediği
    }
}

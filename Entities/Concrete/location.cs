using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Location: IEntity
    {
        [Key]
        [Display(Name = "Lokasyon Id")]
        public int location_Id { get; set; } //lokasyon id
        [Display(Name = "Üst Lokasyon Id")]
        public int topLocation_Id { get; set; }
        [Display(Name = "Lokasyon Başlığı")]
        public string title { get; set; } //lokasyon başlık
        [Display(Name = "Lokasyon Anahtar Kelimleri")]
        public string keywords { get; set; } // keywords seo açıklama
        [Display(Name = "Lokasyon Description")]
        public string description { get; set; } // lokasyon seo açıklama
        public string content { get; set; } // lokasyon içerik
        public string imgPath { get; set; } // lokasyon kapak resmi
        public int image_Id { get; set; } //lokasyon resim Id ////////////////////////////////////////////
        public int row { get; set; } //bölge sırası////////////////////////////////////////////
        public bool state { get; set; } //lokasyon görünme durumu
        public bool IsChecked { get; set; } //lokasyon silinip silinmediği
    }
}

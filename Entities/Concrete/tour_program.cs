using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class tour_program: Core.Entities.IEntity
    {
        [Key]
        public int tour_program_id { get; set; } //tur program id
        public int date_id { get; set; } //tarih id
        public string title { get; set; } //tur program başlığı
        public string description { get; set; } //tur program açıklaması
        public int hotel_id { get; set; } //otel id
        public bool? state { get; set; } //tur programı görünme durumu
        public bool? IsChecked { get; set; } //tur programı silinip silinmediği

    }
}

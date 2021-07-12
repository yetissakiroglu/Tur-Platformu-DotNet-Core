using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class tour_date: Core.Entities.IEntity
    {
        [Key]
        public int date_id { get; set; } //tarih id
        public int tour_id { get; set; } //tur id
        public DateTime start_date { get; set; } //tur başlangıç tarihi
        public DateTime end_date { get; set; } //tur bitiş tarihi
        public bool? state { get; set; } //tur tarihinin görünüp görünmeyeceği
        public bool? IsChecked { get; set; } //tur tarihinin silinip silinmediği

    }
}

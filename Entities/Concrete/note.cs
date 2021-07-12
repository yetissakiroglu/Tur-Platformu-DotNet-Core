using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class note: Core.Entities.IEntity
    {
        [Key]
        public int note_id { get; set; }    //not id
        public string title { get; set; }   //not başlığı
        public string description { get; set; }  //not açıklaması
        public bool? state { get; set; }        //not görünürlük durumu
        public bool? IsChecked { get; set; }    //notun silinip silinmediği

    }
}

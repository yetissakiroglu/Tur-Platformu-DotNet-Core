using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class comments: Core.Entities.IEntity
    {
        [Key]
        public int comments_id { get; set; }   //yorumlar id
        public int date_id { get; set; }      //tarih id
        public int user_id { get; set; }     //yorum yapan kişi id
        public DateTime date { get; set; }   //yorum tarihi
        public string comment { get; set; }  //yorumlar
        public bool? state { get; set; }     //yorum görünme durumu
        public bool? IsChecked { get; set; }  //yorumun silinip silinmediği



    }
}

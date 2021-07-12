using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class paid_services: Core.Entities.IEntity
    {
        [Key]
        public int paid_services_id { get; set; }  //ücretli hizmetler id
        public string title { get; set; }            //ücretli hizmetler başlık
        public bool? state { get; set; }            //ücretli hizmetler görünürlük
        public bool? InChecked { get; set; }       //ücretli hizmetler silinip silinmediği

    }
}

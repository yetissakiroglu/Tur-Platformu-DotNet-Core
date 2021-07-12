using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class tour_paid_services: Core.Entities.IEntity
    {
        [Key]
        public int tour_paid_services_id { get; set; }   //ücretli servis turu id
        public int tour_id { get; set; }                //tur id
        public int paid_services_id { get; set; }      //ücretli servis id

    }
}

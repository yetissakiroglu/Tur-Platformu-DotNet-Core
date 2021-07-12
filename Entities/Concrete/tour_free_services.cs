using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class tour_free_services: Core.Entities.IEntity
    {
        [Key]
        public int tour_free_services_id { get; set; } //ücretsiz servis turu id
        public int tour_id { get; set; }              //tur id
        public int free_services_id { get; set; }      //ücretsiz servis id
    }
}

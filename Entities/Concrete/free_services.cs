using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class free_services: Core.Entities.IEntity
    {
         [Key]
        public int free_services_id { get; set; } // Ücretsiz servis id
        public string title { get; set; }        //başlık
        public bool? state { get; set; }        //ücretsiz servis durumu
        public bool? InChecked { get; set; }   //ücretsiz servisin silinip silinmediği

    }
}

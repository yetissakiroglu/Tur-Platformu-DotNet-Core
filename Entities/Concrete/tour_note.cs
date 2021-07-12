using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class tour_note: Core.Entities.IEntity
    {
        [Key]
        public int tour_not_id { get; set; }  //tur not id
        public int tour_id { get; set; }     //tur id
        public int note_id { get; set; }    //not id

    }
}

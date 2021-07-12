using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class tour_program_location: Core.Entities.IEntity
    {
        [Key]
        public int tour_prog_loc_id { get; set; } // tur programı lokasyon id
        public int tour_program_id { get; set; } // tur program id
        public int location_id { get; set; } //lokasyon id
    }
}

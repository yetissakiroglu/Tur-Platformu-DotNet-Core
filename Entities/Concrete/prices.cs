using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class prices: Core.Entities.IEntity
    {
        [Key]
        public int prices_id { get; set; }                     //fiyat id
        public int one_people_price { get; set; }              //bir kişilik oda fiyatı
        public int two_people_price { get; set; }              //iki kişilik oda fiyatı
        public int three_people_price { get; set; }            //üç kişilik oda fiyatı
        public int three_six_children_price { get; set; }      //3-6 yaş arası çocuk fiyatı
        public int seven_twelve_children_price { get; set; }   //7-12 yaş arası çocuk fiyatı
        public int zero_two_children_price { get; set; }       //0-2 yaş çocuk fiyatı
        public int tour_type { get; set; }                     //tur tipi
        public int excursion_fee { get; set; }                 //gezi ücreti
        public string information { get; set; }               //tur bilgisi
        public int date_id { get; set; }                      //
        public bool? state { get; set; }                      //fiyat görünürlük durumu
        public bool? IsChecked { get; set; }                  //fiyatın silinip silinmediği





    }
}

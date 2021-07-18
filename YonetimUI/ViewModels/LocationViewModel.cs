using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YonetimUI.ViewModels
{
    public class LocationViewModel
    {

        public string title { get; set; }
        public string message { get; set; }

        public IFormFile imgFile { get; set; }

        public Location Location { get; set; }
        public List<Location> Locations { get; set; }

        //Bölgeler Listesi (Lokasyon kategorileri)
        public IEnumerable<SelectListItem> TopLocationListItem { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public TopLocationViewModelHelper TopLocationViewModelHelper { get; set; }

        public string Search { get; set; }
        public int Limit { get; set; }

        //Bölge Idsi 
        public int topLocation_Id { get; set; }

    }
}

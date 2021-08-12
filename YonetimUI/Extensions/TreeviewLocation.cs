using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YonetimUI.Extensions
{
    public class TreeviewLocation : ITreeviewLocation
    {
        List<SelectListItem> notelocation = new List<SelectListItem>();
       
        public List<SelectListItem> TreeViewNote(List<Location> note)
        {

            notelocation.Insert(0, new SelectListItem() { Value = "0", Text = " --- Lokasyon Seçiniz --- " });
            notelocation.Insert(1, new SelectListItem() { Value = "-1", Text = " --- Üst Lokasyon -- " });

            // Get the top level parents
            var parents = note.Where(x => x.topLocation_Id == -1);

            foreach (var parent in parents)
            {
                // Add SelectListItem for the parent
                notelocation.Add(new SelectListItem()
                {
                    Value = parent.location_Id.ToString(),
                    Text = parent.title
                });

                TreeViewNote_Down(parent.location_Id, 1, note);
            }

            return notelocation;
        }

        public void TreeViewNote_Down(int ID, int sira, List<Location> locations)
        {
            string noktalar = "";
            for (int i = 0; i < sira; i++)
            {
                noktalar += "--- ";
            }
            var parents = locations.Where(x => x.topLocation_Id == ID);

            foreach (var item in parents)
            {
                // Add SelectListItem for the parent
                notelocation.Add(new SelectListItem()
                {
                    Value = item.location_Id.ToString(),
                    Text = noktalar+ item.title
                });

                TreeViewNote_Down(item.location_Id, sira+1, locations);

            }

        }
    }
}

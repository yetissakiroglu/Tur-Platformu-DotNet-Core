using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YonetimUI.Extensions
{
    public interface ITreeviewLocation
    {
        List<SelectListItem>  TreeViewNote(List<Location> note);
    }
}

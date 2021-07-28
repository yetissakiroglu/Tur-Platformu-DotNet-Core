using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YonetimUI.ViewModels;

namespace YonetimUI.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "TopLocation")]
    [HtmlTargetElement("dd", Attributes = "TopLocation")]

    public class LocationHelpers : TagHelper
    {


        [HtmlAttributeName("TopLocation")]
        public int TopLocation { get; set; }

        public TopLocationViewModelHelper PageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<span class='badge badge-primary btn-clean font-weight-bold'>");




            foreach (var item in PageModel.Locations)
            {
                if (item.location_Id == TopLocation)
                {
                    stringBuilder.Append(item.title);
                }


            }


            stringBuilder.Append("</span>");

            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);

        }



    }
}

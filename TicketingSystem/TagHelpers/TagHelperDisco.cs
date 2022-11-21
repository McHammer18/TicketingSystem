using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Immutable;

namespace TicketingSystem.TagHelpers
{
    public class LabelTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("Morgan", "All Labels");
        }
    }

    [HtmlTargetElement("label")]
    public class MyLabelTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("Morgan2", "All Lavels from Attribbute");  
        }
    }

    [HtmlTargetElement("label", Attributes = "asp-for", ParentTag = "form")]
    public class FormLabelTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("Morgan3", "Labels with asp-for");
        }
    }
}

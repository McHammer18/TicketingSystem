using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TicketingSystem.TagHelpers
{
    public class ButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "btn btn-primary");
            output.Attributes.SetAttribute("Submit", "status");
        }
    }
}

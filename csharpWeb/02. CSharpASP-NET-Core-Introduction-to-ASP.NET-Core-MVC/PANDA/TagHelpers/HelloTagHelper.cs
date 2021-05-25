using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.TagHelpers
{
    [HtmlTargetElement("h1", Attributes = "testing")]
    public class HelloTagHelper : TagHelper
    {
        public string GreetingName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreElement.SetContent(this.GreetingName);
            output.Content.SetContent(this.GreetingName);
            output.PostElement.SetContent(this.GreetingName);
            output.Attributes.SetAttribute("Gosho", this.GreetingName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FirstAspDotNetCore.CustomTagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        
        private string defaultDoamin => "ymail.com";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var hasDomainAttr = context.AllAttributes.TryGetAttribute("domain", out TagHelperAttribute domainAttr);
            var content = await output.GetChildContentAsync();
            var domain = hasDomainAttr ? domainAttr.Value.ToString() : defaultDoamin;
            var target =$"{content.GetContent()}@{domain}" ;
            output.Attributes.SetAttribute("href", $"mailto:{target}");
            output.Content.SetContent($"{target}");
        }


    }
}

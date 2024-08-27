using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace ECommerce.WebUI.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHelper : TagHelper
    {
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; } = 1;
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }
        [HtmlAttributeName("order-by-name")]
        public string? OrderByName { get; set; }

		[HtmlAttributeName("order-by-price")]
		public string? OrderByPrice { get; set; }
        [HtmlAttributeName("controller-name")]
        public string? ControllerName {  get; set; } 
		public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            StringBuilder sb = new StringBuilder();
            if (PageCount > 1)
            {
                sb.Append("<nav>");
                sb.Append("<ul class=\"pagination\">");

                sb.AppendFormat("<li class='page-item {0}'>", CurrentPage == 1 ? "disabled" : "");
                sb.AppendFormat("<a  class='page-link' href='/{4}/index?page={0}&category={1}&orderByName={2}&orderByPrice={3}'> Previous </a>",
               CurrentPage-1, CurrentCategory,OrderByName,OrderByPrice,ControllerName);
                sb.Append("</li>");

                for (int i = 1; i <= PageCount; i++)
                {
                    sb.AppendFormat("<li class='{0}'>", (i == CurrentPage) ? "page-item active" : "page-item");
                    sb.AppendFormat("<a  class='page-link' href='/{5}/index?page={0}&category={1}&orderByName={2}&orderByPrice={3}'> {4} </a>",
                        i, CurrentCategory, OrderByName, OrderByPrice, i,ControllerName);
                    sb.Append("</li>");
                }
                sb.AppendFormat("<li class='page-item {0}'>", CurrentPage == PageCount ? "disabled" : "");
                sb.AppendFormat("<a  class='page-link' href='/{4}/index?page={0}&category={1}&orderByName={2}&orderByPrice={3}'> Next </a>",
               CurrentPage + 1, CurrentCategory,OrderByName,OrderByPrice, ControllerName);
                sb.Append("</li>");
                 
                sb.Append("</ul>");
                sb.Append("</nav>");
            }
            output.Content.SetHtmlContent(sb.ToString());



        }

    }
}

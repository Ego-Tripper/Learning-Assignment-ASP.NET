using CarMagazineISP_41.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace CarMagazineISP_41.Data.Infostructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper//дескрипторный вспомогательный класс
    {
        public static int categoryId;

        private IUrlHelperFactory _urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        
        public ViewContext ViewContext { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix ="page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; }= new Dictionary<string, object>();
        public string PageAction { get; set; }
        public PagingInfo? PageModel { get; set; }
        public bool PageClassesEnabled {  get; set; }=false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected {  get; set; }
        public string Class {  get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder divTag = new TagBuilder("div");
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder aTag = new TagBuilder("a");

                PageUrlValues["category"] = categoryId;
                PageUrlValues["page"] = i;

                aTag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                if (PageClassesEnabled)
                {
                    aTag.AddCssClass(PageClass);
                    aTag.AddCssClass(i==PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                aTag.InnerHtml.Append(i.ToString());
                divTag.InnerHtml.AppendHtml(aTag);
            }

            output.Content.AppendHtml(divTag.InnerHtml);

        }
    }
}

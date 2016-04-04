using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstMVC5App.Component.Helpers
{
    public static class ImageHelper
    {
        //public static MvcHtmlString DisplayImage(this HtmlHelper html, IDictionary<string, object> htmlAttributes )
        public static MvcHtmlString DisplayImage(this HtmlHelper html, object routeValueDictionary)
        {
            IDictionary<string, object> attributesDictionary = routeValueDictionary.GetType()
                .GetProperties()
                .ToDictionary(
                    x => x.Name,
                    x => x.GetValue(routeValueDictionary, null));
            //TagBuilder img = new TagBuilder("img");
            TagBuilder img = new TagBuilder("img");
            //foreach (var attribute in d)
           // {
            img.MergeAttributes(attributesDictionary);
          //  }
            //img.MergeAttributes(routeValueDictionary.);
            //img.SetInnerText(value);
            return new MvcHtmlString(img.ToString(TagRenderMode.SelfClosing));
        }

        //public static MvcHtmlString DisplayImageFor<TModel, TValue>(this HtmlHelper<TModel> html,
        //    Expression<Func<TModel, TValue>> src, object routeValueDictionary)
        //{
        //    var compile = src.Compile();
        //    var model = compile(html.ViewData.Model);

        //    //routeValueDictionary.GetType().;

        //    return DisplayImage(html, attributesDictionary); //new MvcHtmlString(img.ToString(TagRenderMode.SelfClosing));
        //}
    }
}
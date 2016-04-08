using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC5App.Component.Helpers
{
    public static class PaginatorHelper
    {
        //http://metanit.com/sharp/mvc5/5.13.php

        public static MvcHtmlString DisplayPaginatorLinks(this HtmlHelper helper, string actionName, object routeValueDictionary, Paging paging)
        {
            IDictionary<string, object> dictionary = routeValueDictionary.GetType()
                .GetProperties()
                .ToDictionary(
                    x => x.Name,
                    x => x.GetValue(routeValueDictionary));
            //todo: в imageHelper посылается атрибут null пофиксить работу метода GetValue
            //todo: возможно понадобиться посыть несколько свойст. Необходимо предусмотреть foreach


            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("text-center");
            
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            
            for (int i = 0; i < paging.TotalPage; i++)
            {
                TagBuilder li = new TagBuilder("li");

                TagBuilder a = new TagBuilder("a");

                if ((i + 1) == (int)dictionary.FirstOrDefault().Value)
                    li.AddCssClass("active");
                else
                    a.MergeAttribute("href", Path.Combine(String.Format("/{0}/?{1}={2}", actionName, dictionary.FirstOrDefault().Key, (i + 1))));


                a.SetInnerText(Convert.ToString((i + 1)));
                li.InnerHtml += a.ToString();
                ul.InnerHtml += li.ToString();
            }

            div.InnerHtml += ul.ToString();
            return new MvcHtmlString(div.ToString());
        }
    }
}
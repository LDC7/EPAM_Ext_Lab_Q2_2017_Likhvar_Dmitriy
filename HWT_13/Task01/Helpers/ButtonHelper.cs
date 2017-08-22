using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task01.Helpers
{
    public class ButtonHelper
    {

        public static MvcHtmlString Button(string innerHtml, object htmlAttributes)
        {
            return Button(innerHtml, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Button(string text, string method)
        {
            var builder = new TagBuilder("input");
            builder.Attributes.Add("type", "button");
            builder.Attributes.Add("value", text);
            builder.Attributes.Add("onclick", string.Format("location.href = 'Home/{0}'", method));
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}
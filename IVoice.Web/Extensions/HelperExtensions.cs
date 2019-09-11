using IVoice.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace IVoice.Extensions
{
    public static class HelperExtensions
    {
        public static int NumMaxEl = 1;

        public static MvcHtmlString DropDownListAutoCompleteFor<TModel, TValue>(this HtmlHelper<TModel> helper,
                                    Expression<Func<TModel, TValue>> expression,
                                    IEnumerable<SelectListItem> list, string label = "", object htmlAttributes = null)
        {
            var attributes = new Dictionary<string, object>();
            if (htmlAttributes != null)
            {
                foreach (var property in htmlAttributes.GetType().GetProperties())
                    attributes[property.Name] = property.GetValue(htmlAttributes);
            }

            var numMaxEl = HelperExtensions.NumMaxEl;
            attributes["data-live-search"] = (list.Count() > numMaxEl) ? "true" : "false";
            attributes["data-none-selected-Text"] = "Select...";

            attributes["class"] = (
                attributes.ContainsKey("class") ?
                attributes["class"] as string :
                ""
            ) + " selectpicker";

            return SelectExtensions.DropDownListFor(helper, expression, list, label, attributes);
        }


        public static MvcHtmlString DropDownListMultipleChoiceFor<TModel, TValue>(this HtmlHelper<TModel> helper,
                              Expression<Func<TModel, TValue>> expression,
                              IEnumerable<SelectListItem> list, string label = "", object htmlAttributes = null)
        {
            var attributes = new Dictionary<string, object>();
            if (htmlAttributes != null)
            {
                foreach (var property in htmlAttributes.GetType().GetProperties())
                    attributes[property.Name] = property.GetValue(htmlAttributes);
            }

            var numMaxEl = HelperExtensions.NumMaxEl;
            attributes["data-live-search"] = (list.Count() > numMaxEl) ? "true" : "false";
            attributes["data-actions-box"] = "true";
            attributes["data-size"] = "10";
            attributes["multiple"] = "multiple";

            attributes["data-select-all-Text"] = "Select All";
            attributes["data-deselect-all-Text"] = "Deselect All";
            attributes["data-none-selected-Text"] = "Select...";

            attributes["class"] = (
                attributes.ContainsKey("class") ?
                attributes["class"] as string :
                ""
            ) + " selectpicker";

            return SelectExtensions.ListBoxFor(helper, expression, list, attributes);
        }


        public static SelectList ToSelectList<Tkey>(this List<SelectListItem_Custom> currentList, Func<SelectListItem_Custom, Tkey> orderBy)
        {
            if (orderBy == null)
                return new SelectList(currentList.Select(x => new
                {
                    Id = x.Id,
                    Description = x.Description
                }), "Id", "Description");
            else
                return new SelectList(currentList.OrderBy(orderBy).Select(x => new
                {
                    Id = x.Id,
                    Description = x.Description
                }), "Id", "Description");
        }
    }
}
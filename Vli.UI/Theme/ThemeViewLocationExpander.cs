/**
*
* 功 能： N/A
* 类 名： ThemeViewLocationExpander
* 作 者： weili
* 时 间： 2019/5/25 21:49:42
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Text;
using Vli.Static;

namespace Vli.UI.Theme
{
    public class ThemeViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            List<string> vws = new List<string>();
            string theme = context.Values["theme"];
            foreach (var item in viewLocations)
            {
                if (!item.StartsWith("/Pages/"))
                {
                    vws.Add(item.Replace("/Views/", $"/Themes/{theme}/"));
                }
                vws.Add(item);
            }

            foreach (string item in vws)
            {
                yield return item;
            }
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            HttpContext httpcontext = context.ActionContext.HttpContext;
            string theme = "Default";

            if (httpcontext != null && httpcontext.Request.HttpContext.Items.ContainsKey(SysDict.VLI_THEME))
            {
                if (httpcontext.Request.HttpContext.Items[SysDict.VLI_THEME] != null)
                {
                    theme = httpcontext.Request.HttpContext.Items[SysDict.VLI_THEME].ToString();
                }
            }
            context.Values["theme"] = theme;
        }
    }
}

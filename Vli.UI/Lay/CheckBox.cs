/**
*
* 功 能： N/A
* 类 名： CheckBox
* 作 者： weili
* 时 间： 2019/5/12 21:01:33
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace Vli.UI.Lay
{
    /// <summary>
    /// 复选框
    /// </summary>
    [HtmlTargetElement("cbk")]
    public class CheckBox : BaseTag
    {
        [HtmlAttributeName("vi-use-lay")]
        public bool UseLay { set; get; }

        public CheckBox(IHtmlGenerator generator) : base(generator)
        {

        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output = WidgetOutput;

            Dictionary<string, string> keyValues = new Dictionary<string, string>();

            // 循环获取属性，排除 “mk-” 开始
            foreach (var item in context.AllAttributes)
            {
                if (!keyValues.ContainsKey(item.Name) && !item.Name.Trim().StartsWith("vi-"))
                {
                    keyValues.Add(item.Name, item.Value.ToString());
                }
            }

            // 是否原生态控件
            if (!keyValues.ContainsKey("lay-skin") && !UseLay)
            {
                keyValues.Add("lay-skin", "primary");
            }

            TagBuilder input = Generator.GenerateCheckBox(ViewContext, For.ModelExplorer, For.Name, null, null);
            input.MergeAttributes(keyValues);

            WidgetRoot.InnerHtml.AppendHtml(input);
            WidgetRoot.InnerHtml.AppendHtml(WidgetSpan);
            output.Content.AppendHtml(WidgetLabel);
            output.Content.AppendHtml(WidgetRoot);
        }
    }
}

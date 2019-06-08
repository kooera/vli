/**
*
* 功 能： N/A
* 类 名： Switch
* 作 者： weili
* 时 间： 2019/5/12 22:22:27
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Vli.UI.Lay
{
    /// <summary>
    /// 开关形式的复选框
    /// </summary>
    [HtmlTargetElement("swi")]
    public class Switch : BaseTag
    {
        public Switch(IHtmlGenerator generator) : base(generator)
        {
        }

        /// <summary>
        /// 业务处理
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
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

            if (!keyValues.ContainsKey("lay-skin"))
            {
                keyValues.Add("lay-skin", "switch");
            }

            if (!keyValues.ContainsKey("lay-text"))
            {
                keyValues.Add("lay-text", "是|否");
            }

            TagBuilder input = Generator.GenerateCheckBox(ViewContext, For.ModelExplorer, For.Name, null, null);
            input.MergeAttributes(keyValues);

            WidgetRoot.InnerHtml.AppendHtml(input);
            if (!string.IsNullOrEmpty(Description))
            {
                WidgetRoot.InnerHtml.AppendHtml(WidgetSpan);
            }
            output.Content.AppendHtml(WidgetLabel);
            output.Content.AppendHtml(WidgetRoot);
        }
    }
}

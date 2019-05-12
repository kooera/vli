/**
*
* 功 能： N/A
* 类 名： DropDownList
* 作 者： weili
* 时 间： 2019/5/12 21:05:24
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.TagHelpers.Internal;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections;
using System.Collections.Generic;

namespace Vli.UI.Lay
{
    /// <summary>
    /// 下拉选择
    /// </summary>
    [HtmlTargetElement("ddl")]
    public class DropDownList : BaseTag
    {
        private bool allowMultiple;
        private ICollection<string> currentValues;

        /// <summary>
        /// 数据源
        /// </summary>
        [HtmlAttributeName("vi-src")]
        public IEnumerable<SelectListItem> SelectLists { get; set; }

        public DropDownList(IHtmlGenerator generator) : base(generator)
        {
        }

        public override void Init(TagHelperContext context)
        {
            base.Init(context);

            var realModelType = For.ModelExplorer.ModelType;
            allowMultiple = typeof(string) != realModelType &&
                typeof(IEnumerable).IsAssignableFrom(realModelType);
            currentValues = Generator.GetCurrentValues(ViewContext, For.ModelExplorer, For.Name, allowMultiple);

            var _currentValues = currentValues == null ? null : new CurrentValues(currentValues);
            context.Items[typeof(SelectTagHelper)] = _currentValues;
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

            TagBuilder select = Generator.GenerateSelect(ViewContext, For.ModelExplorer, null, For.Name, SelectLists, currentValues, allowMultiple, null);

            select.MergeAttributes(keyValues);

            WidgetRoot.InnerHtml.AppendHtml(select);
            if (!string.IsNullOrEmpty(Description))
            {
                WidgetRoot.InnerHtml.AppendHtml(WidgetSpan);
            }

            output.Content.AppendHtml(WidgetLabel);
            output.Content.AppendHtml(WidgetRoot);
        }
    }
}

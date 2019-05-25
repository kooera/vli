/**
*
* 功 能： N/A
* 类 名： Label
* 作 者： weili
* 时 间： 2019/5/25 22:14:15
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Vli.UI.Lay
{
    /// <summary>
    /// Label标签
    /// </summary>
    [HtmlTargetElement("lab")]
    public class Label : TagHelper
    {
        /// <summary>
        /// 标题，显示于标签前面
        /// </summary>
        [HtmlAttributeName("vi-title")]
        public string Title { get; set; }

        /// <summary>
        /// 提示信息，鼠标移过标签显示
        /// </summary>
        [HtmlAttributeName("vi-hint")]
        public string Hint { get; set; }

        /// <summary>
        /// 图标样式
        /// </summary>
        [HtmlAttributeName("vi-i-class")]
        public string InnerIconClass { get; set; }

        /// <summary>
        /// 绑定属性
        /// </summary>
        [HtmlAttributeName("vi-for")]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            output.TagName = "label";
            output.Attributes.Add("data-toggle", "tooltip");
            output.Attributes.Add("data-placement", "right");
            output.Content.Append(Title);

            if (!string.IsNullOrEmpty(Hint))
            {
                output.Attributes.Add("title", Hint);
            }
            else
            {
                output.Attributes.Add("title", Title);
            }

            if (For != null && !string.IsNullOrEmpty(For.Name))
            {
                output.Attributes.Add("for", For.Name);
            }

            TagBuilder i = new TagBuilder("i");
            if (string.IsNullOrEmpty(InnerIconClass))
            {
                i.AddCssClass("icon iconfont icon-info-circle");
            }
            else
            {
                i.Attributes.Add("class", InnerIconClass);
            }

            output.Content.AppendHtml(i);
        }
    }
}

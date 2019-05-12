/**
*
* 功 能： N/A
* 类 名： BaseTag
* 作 者： weili
* 时 间： 2019/5/12 20:00:47
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Vli.UI.Lay
{
    public class BaseTag : TagHelper
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
        /// 绑定属性
        /// </summary>
        [HtmlAttributeName("vi-for")]
        public ModelExpression For { get; set; }

        /// <summary>
        /// 描述信息，位于标签后面
        /// </summary>
        [HtmlAttributeName("vi-desc")]
        public string Description { get; set; }

        /// <summary>
        /// 控件Label标签
        /// </summary>
        public TagBuilder WidgetLabel { get; set; } 

        /// <summary>
        /// 控件直系父标签
        /// </summary>
        public TagBuilder WidgetRoot { get; set; }

        /// <summary>
        /// 控件提示标签
        /// </summary>
        public TagBuilder WidgetSpan { get; set; }

        /// <summary>
        /// 输出标签
        /// </summary>
        protected TagHelperOutput WidgetOutput { get; set; }

        /// <summary>
        /// 视图内容
        /// </summary>
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public IHtmlGenerator Generator { get; }

        public override int Order => -1000;

        public BaseTag(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        public override void Init(TagHelperContext context)
        {
            base.Init(context);

            #region 标题标签                  

            WidgetLabel = new TagBuilder("label");
            WidgetLabel.AddCssClass("layui-form-label");
            WidgetLabel.Attributes.Add("data-toggle", "tooltip");
            WidgetLabel.Attributes.Add("data-placement", "right");

            if (!string.IsNullOrEmpty(Hint))
            {
                WidgetLabel.Attributes.Add("title", Hint);
            }
            else
            {
                WidgetLabel.Attributes.Add("title", Title);
            }

            WidgetLabel.InnerHtml.Append(Title);

            TagBuilder i = new TagBuilder("i");
            i.AddCssClass("icon iconfont icon-info-circle");
            WidgetLabel.InnerHtml.AppendHtml(i);

            #endregion

            #region 直系父级标签

            WidgetRoot = new TagBuilder("div");
            WidgetRoot.AddCssClass("layui-inline");

            #endregion

            #region 描述信息

            WidgetSpan = new TagBuilder("span");
            WidgetSpan.AddCssClass("Validform_checktip");
            if (!string.IsNullOrEmpty(Description))
            {
                WidgetSpan.InnerHtml.Append(Description);
            }

            #endregion
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            WidgetOutput = output;
            WidgetOutput.Attributes.Clear();
            WidgetOutput.TagName = "div";
            WidgetOutput.Attributes.Add("class", "layui-form-item");
        }
    }
}

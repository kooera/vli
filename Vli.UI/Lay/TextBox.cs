/**
*
* 功 能： N/A
* 类 名： TextBox
* 作 者： weili
* 时 间： 2019/5/13 21:22:11
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace Vli.UI.Lay
{
    /// <summary>
    /// 文本框标签
    /// </summary>
    [HtmlTargetElement("txt")]
    public class TextBox : BaseTag
    {
        /// <summary>
        /// 是否为textarea
        /// </summary>
        [HtmlAttributeName("vi-is-area")]
        public bool IsTextArea { get; set; }

        /// <summary>
        /// 是否为tagedit标签
        /// </summary>
        [HtmlAttributeName("vi-is-tag")]
        public bool IsTagEdit { get; set; }

        /// <summary>
        /// tagedit 数据源 url
        /// </summary>
        [HtmlAttributeName("vi-tag-src")]
        public string SourceUrl { get; set; }

        private IJsonHelper JsonHelper { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="generator"></param>
        public TextBox(IHtmlGenerator generator, IJsonHelper jsonHelper) : base(generator)
        {
            JsonHelper = jsonHelper;
        }

        /// <summary>
        /// 处理逻辑
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            // 创建div标签
            output = WidgetOutput;

            Dictionary<string, string> keyValues = new Dictionary<string, string>();

            // 循环获取属性，排除 “mk-” 开始
            foreach (var item in context.AllAttributes)
            {
                if (!keyValues.ContainsKey(item.Name) && !item.Name.Trim().StartsWith("vi-"))
                {
                    if (item.Name.ToLower() == "class")
                    {
                        if (IsTextArea)
                        {
                            keyValues.Add(item.Name, "layui-textarea " + item.Value.ToString());
                        }
                        else
                        {
                            keyValues.Add(item.Name, "layui-input " + item.Value.ToString());
                        }
                        continue;
                    }
                    keyValues.Add(item.Name, item.Value.ToString());
                }
            }

            if (!keyValues.ContainsKey("class"))
            {
                keyValues.Add("class", "layui-input");
            }

            TagBuilder input = Generator.GenerateTextBox(ViewContext, For.ModelExplorer, For.Name, For.ModelExplorer.Model, null, null);

            if (IsTextArea || IsTagEdit)
            {
                input = Generator.GenerateTextArea(ViewContext, For.ModelExplorer, For.Name, 0, 0, null);
            }
            input.MergeAttributes(keyValues);

            WidgetRoot.InnerHtml.AppendHtml(input);

            if (!string.IsNullOrEmpty(Description))
            {
                WidgetRoot.InnerHtml.AppendHtml(WidgetSpan);
            }

            output.Content.AppendHtml(WidgetLabel);
            output.Content.AppendHtml(WidgetRoot);

            if (IsTagEdit && !string.IsNullOrEmpty(SourceUrl))
            {
                var dat = For.Model == null ? JsonHelper.Serialize("") : JsonHelper.Serialize(For.Model);

                HtmlContentBuilder builder = new HtmlContentBuilder();
                string script = @"  <script>
                                        $(function () {
                                            $('#" + For.Name + @"').tagEditor({
                                                initialTags: " + dat + @",
                                                delimiter: ', ',
                                                autocomplete: {
                                                    delay: 0,
                                                    source: '" + SourceUrl + @"'
                                                }
                                            });
                                        })
                                    </script>";

                builder.AppendHtml(script);
                output.Content.AppendHtml(builder);
            }
        }
    }
}

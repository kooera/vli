/**
*
* 功 能： N/A
* 类 名： Upload
* 作 者： weili
* 时 间： 2019/5/13 21:33:58
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using Vli.Extension;

namespace Vli.UI.Lay
{
    /// <summary>
    /// 上传控件
    /// </summary>
    [HtmlTargetElement("up")]
    public class Upload : BaseTag
    {
        /// <summary>
        /// 是否显示按钮icon
        /// </summary>
        [HtmlAttributeName("vi-show-icon")]
        public bool ShowIconBtn { get; set; }

        /// <summary>
        /// 默认icon按钮
        /// </summary>
        [HtmlAttributeName("vi-default-icon")]
        public string DefaultIcon { get; set; }

        /// <summary>
        /// 按钮皮肤
        /// </summary>
        [HtmlAttributeName("vi-btn-skin")]
        public string ButtonSkin { get; set; }

        /// <summary>
        /// 上传处理url
        /// </summary>
        [HtmlAttributeName("vi-process-url")]
        public string HandleUrl { get; set; }

        protected JavaScriptEncoder JavaScriptEncoder { get; }

        public Upload(IHtmlGenerator generator, JavaScriptEncoder javaScriptEncoder) : base(generator)
        {
            this.JavaScriptEncoder = javaScriptEncoder;
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
                    if (item.Name.ToLower() == "class")
                    {
                        keyValues.Add(item.Name, "layui-input " + item.Value.ToString());
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
            input.MergeAttributes(keyValues);

            WidgetRoot.InnerHtml.AppendHtml(input);
            if (!string.IsNullOrEmpty(Description))
            {
                WidgetRoot.InnerHtml.AppendHtml(WidgetSpan);
            }
            output.Content.AppendHtml(WidgetLabel);
            output.Content.AppendHtml(WidgetRoot);

            // id前缀
            string idPre = "font";
            string value = "";
            string idBtn = "";
            if (For != null)
            {
                if (!string.IsNullOrEmpty(For.Name))
                {
                    idPre = For.Name;
                }
                if (For.Model != null)
                {
                    value = For.Model.ToString();
                }
            }

            // 图标按钮
            if (ShowIconBtn)
            {
                // 外层
                var iconBtnDiv = new TagBuilder("div");
                iconBtnDiv.AddCssClass("layui-inline");

                // 按钮
                var _iconBtn = new TagBuilder("button");
                if (!string.IsNullOrEmpty(ButtonSkin))
                {
                    _iconBtn.AddCssClass("layui-btn " + ButtonSkin);
                }
                else
                {
                    _iconBtn.AddCssClass("layui-btn layui-btn-primary");
                }
                _iconBtn.GenerateId(idPre + "_icon_btn", "".Guid());
                _iconBtn.Attributes.Add("type", "button");

                // i
                var __i = new TagBuilder("i");
                __i.GenerateId(idPre + "_icon_i", "".Guid());
                if (!string.IsNullOrEmpty(value))
                {
                    __i.AddCssClass(value.Replace(".", " "));
                }
                else if (!string.IsNullOrEmpty(DefaultIcon))
                {
                    __i.AddCssClass(DefaultIcon);
                }
                else
                {
                    __i.AddCssClass("icon iconfont icon-info-circle");
                }
                __i.Attributes.Add("icon", "font-i-icon");

                _iconBtn.InnerHtml.AppendHtml(__i);
                _iconBtn.InnerHtml.Append(" 字体图标");

                iconBtnDiv.InnerHtml.AppendHtml(_iconBtn);
                output.Content.AppendHtml(iconBtnDiv);
            }

            // 上传按钮
            var btnDiv = new TagBuilder("div");
            btnDiv.AddCssClass("layui-inline");

            var _btn = new TagBuilder("div");
            if (!string.IsNullOrEmpty(ButtonSkin))
            {
                _btn.AddCssClass("layui-btn " + ButtonSkin);
            }
            else
            {
                _btn.AddCssClass("layui-btn layui-btn-primary");
            }
            idBtn = idPre + "_icon_upload";
            _btn.GenerateId(idBtn, "".Guid());

            var __btn_i = new TagBuilder("i");
            __btn_i.AddCssClass("icon iconfont icon-upload");

            _btn.InnerHtml.AppendHtml(__btn_i);
            _btn.InnerHtml.Append(" 请选择...");

            btnDiv.InnerHtml.AppendHtml(_btn);
            output.Content.AppendHtml(btnDiv);

            string url = "/api/com/filesave";

            if (!string.IsNullOrEmpty(HandleUrl))
            {
                url = HandleUrl;
            }

            // script
            HtmlContentBuilder builder = new HtmlContentBuilder();
            string script = @"<script>
                                layui.use('upload', function () {
                                     var $ = layui.jquery
                                     , upload = layui.upload;
                                     upload.render({
                                         elem: '#" + idBtn + @"',
                                         url: '" + url + @"',
                                         accept: 'file',
                                         multiple: 'true',
                                         done: function (res) {
                                             if (res.code == 'success') {
                                                 $('#" + idPre + @"').val(res.data.path);
                                             }
                                         }
                                     });
                                 });
                            </script> ";

            builder.AppendHtml(script);
            output.Content.AppendHtml(builder);
        }
    }
}

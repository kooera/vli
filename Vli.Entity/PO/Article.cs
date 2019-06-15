/**
*
* 功 能： N/A
* 类 名： Article
* 作 者： weili
* 时 间： 2019/6/15 14:13:18
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System.ComponentModel.DataAnnotations;

namespace Vli.Entity.PO
{
    public sealed class Article : BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        [MaxLength(150)]
        public string SubTitle { get; set; }

        /// <summary>
        /// 概要
        /// </summary>
        [MaxLength(500)]
        public string Summary { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// SEO标题
        /// </summary>
        [MaxLength(100)]
        public string SeoTitle { get; set; }

        /// <summary>
        /// SEO关键词
        /// </summary>
        [MaxLength(200)]
        public string SeoKeyword { get; set; }

        /// <summary>
        /// SEO描述
        /// </summary>
        [MaxLength(500)]
        public string SeoDescription { get; set; }
    }
}

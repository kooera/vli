/**
*
* 功 能： N/A
* 类 名： ArticleTag
* 作 者： weili
* 时 间： 2019/6/15 14:16:08
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vli.Entity.PO
{
    public sealed class ArticleTag : BaseEntity
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        public long ArticleId { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        [MaxLength(20)]
        public string TagName { get; set; }

        /// <summary>
        /// 点击量
        /// </summary>
        public long ClickCount { get; set; }
    }
}

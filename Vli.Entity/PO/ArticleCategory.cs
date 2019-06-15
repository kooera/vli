/**
*
* 功 能： N/A
* 类 名： ArticleCategory
* 作 者： weili
* 时 间： 2019/6/15 14:15:39
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
    public sealed class ArticleCategory : BaseEntity
    {
        /// <summary>
        /// 父级Id
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        public int Level { get; set; }
    }
}

/**
*
* 功 能： N/A
* 类 名： ArticlePhoto
* 作 者： weili
* 时 间： 2019/6/15 14:15:48
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System;
using System.Collections.Generic;
using System.Text;
using Vli.Enums;

namespace Vli.Entity.PO
{
    public sealed class ArticlePhoto : BaseEntity
    {
        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }        

        /// <summary>
        /// 图片类型
        /// </summary>
        public PhotoType PhotoType { get; set; }
    }
}

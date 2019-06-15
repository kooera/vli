/**
*
* 功 能： N/A
* 类 名： ArticleExtend
* 作 者： weili
* 时 间： 2019/6/15 14:16:26
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Vli.Entity.PO
{
    public sealed class ArticleExtend : BaseEntity
    {
        /// <summary>
        /// 封面图片
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 点击量
        /// </summary>
        public long ClickCount { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 是否顶置
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        public bool IsHot { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecommend { get; set; }

        /// <summary>
        /// 是否幻灯片
        /// </summary>
        public bool IsFlash { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool IsHide { get; set; }

        /// <summary>
        /// 喜欢数量
        /// </summary>
        public int LikeCount { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public long Author { get; set; }
    }
}

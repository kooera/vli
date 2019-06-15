/**
*
* 功 能： N/A
* 类 名： ArticleRelation
* 作 者： weili
* 时 间： 2019/6/15 14:15:57
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/


namespace Vli.Entity.PO
{
    public sealed class ArticleRelation : BaseEntity
    {

        /// <summary>
        /// 文章Id
        /// </summary>
        public long ArticleId { get; set; }

        /// <summary>
        /// 关联Id
        /// </summary>
        public long RelationId { get; set; }
    }
}

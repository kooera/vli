/**
*
* 功 能： N/A
* 类 名： Navigation
* 作 者： weili
* 时 间： 2019/5/25 22:57:30
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vli.Entity.PO
{
    public class Navigation : BaseEntity
    {
        /// <summary>
        /// 父级ID
        /// </summary>
        public int IdParent { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string SimpleName { get; set; }

        /// <summary>
        /// 唯一编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [Required]
        public string Url { get; set; }

        /// <summary>
        /// 控制器
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// Action
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 频道ID
        /// </summary>
        public int IdChannel { get; set; }

        /// <summary>
        /// 是否系统预设
        /// </summary>
        public bool IsSys { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool IsLock { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DefaultValue(100)]
        public int Sort { get; set; }

        /// <summary>
        /// 是否站内
        /// </summary>
        public bool IsInnerSite { get; set; }

        /// <summary>
        /// 链接图标
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// 目标
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// 创建IP
        /// </summary>
        public string CreateIP { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(255)]
        public string Remark { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public int Layer { get; set; }

        /// <summary>
        /// 可操作
        /// </summary>
        public string Actions { get; set; }
    }
}

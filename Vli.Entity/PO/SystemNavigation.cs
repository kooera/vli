/**
*
* 功 能： N/A
* 类 名： SystemNavigation
* 作 者： weili
* 时 间： 2019/2/16 15:17:37
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vli.Entity.PO
{
    public sealed class SystemNavigation : BaseEntity
    {
        public SystemNavigation()
        {
            Sort = 100;
            IsActive = true;
            IsInnerSite = true;
            IsSystem = true;
        }

        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentId { get; set; }

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
        public int ChannelId { get; set; }

        /// <summary>
        /// 是否系统预设
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

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
        [Description("创建IP")]
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

        [NotMapped]
        public List<SystemNavigation> SystemNavigations { get; set; }
    }
}

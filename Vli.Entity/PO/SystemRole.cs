/**
*
* 功 能： N/A
* 类 名： SystemRole
* 作 者： weili
* 时 间： 2019/2/16 14:57:53
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System.ComponentModel.DataAnnotations;

namespace Vli.Entity.PO
{
    public sealed class SystemRole : BaseEntity
    {
        public SystemRole()
        {
            IsActive = true;
        }

        /// <summary>
        /// 上级ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required]
        public string RoleName { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
    }
}

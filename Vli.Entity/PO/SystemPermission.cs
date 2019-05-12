/**
*
* 功 能： N/A
* 类 名： SystemPermission
* 作 者： weili
* 时 间： 2019/2/16 15:00:11
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System.ComponentModel.DataAnnotations;

namespace Vli.Entity.PO
{
    public sealed class SystemPermission : BaseEntity
    {
        public SystemPermission()
        {
            IsActive = true;
        }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; } 

        /// <summary>
        /// 授权类型
        /// </summary>
        public string GrantType { get; set; }

        /// <summary>
        /// 授权项
        /// </summary>
        [Required]
        public string GrantItem { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
    }
}

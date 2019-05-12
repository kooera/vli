/**
*
* 功 能： N/A
* 类 名： SystemRight
* 作 者： weili
* 时 间： 2019/2/17 1:30:02
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System.ComponentModel.DataAnnotations;

namespace Vli.Entity.PO
{
    public sealed class SystemRight : BaseEntity
    {
        public SystemRight()
        {
            IsActive = true;
        }
        /// <summary>
        /// 上级ID
        /// </summary>
        public int ParentId { get; set; }

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

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }
    }
}

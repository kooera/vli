/**
*
* 功 能： N/A
* 类 名： SystemGroup
* 作 者： weili
* 时 间： 2019/2/16 14:59:18
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
   public sealed class SystemGroup:BaseEntity
    {
        public SystemGroup()
        {
            IsActive = true;
        }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 组名称
        /// </summary>
        [Required]
        public string GropuName { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
    }
}

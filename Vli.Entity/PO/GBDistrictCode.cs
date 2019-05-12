/**
*
* 功 能： N/A
* 类 名： GBDistrictCode
* 作 者： weili
* 时 间： 2019/2/16 15:29:36
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System;
using System.ComponentModel.DataAnnotations;

namespace Vli.Entity.PO
{
    public sealed class GBDistrictCode : BaseEntity
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        public int ParentId { get; set; }

        public DateTime EndDate { get; set; }
        public string Version { get; set; }
        public string Remark { get; set; }
    }
}

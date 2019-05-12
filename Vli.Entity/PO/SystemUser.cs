/**
*
* 功 能： N/A
* 类 名： SystemUser
* 作 者： weili
* 时 间： 2019/2/16 14:21:25
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System.ComponentModel.DataAnnotations;

namespace Vli.Entity.PO
{
    public sealed class SystemUser : BaseEntity
    {
        public SystemUser()
        {
            IsLock = false;
            IsActive = true;
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Pwd { get; set; }

        public string RealName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Avatar { get; set; }

        public bool IsLock { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }
    }
}

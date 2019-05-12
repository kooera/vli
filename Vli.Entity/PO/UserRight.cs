/**
*
* 功 能： N/A
* 类 名： UserRight
* 作 者： weili
* 时 间： 2019/2/17 1:35:39
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System.ComponentModel.DataAnnotations;

namespace Vli.Entity.PO
{
    public sealed class UserRight : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RightId { get; set; }
    }
}

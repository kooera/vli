/**
*
* 功 能： N/A
* 类 名： SystemParameter
* 作 者： weili
* 时 间： 2019/2/16 15:07:52
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System.ComponentModel.DataAnnotations;
namespace Vli.Entity.PO
{
    public sealed class SystemParameter : BaseEntity
    {
        public SystemParameter()
        {
            IsActive = true;
        }

        /// <summary>
        /// 参数类型
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        [Required]
        public string Keyword { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Required]
        public string Value { get; set; }

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

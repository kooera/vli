/**
*
* 功 能： N/A
* 类 名： Email
* 作 者： weili
* 时 间： 2019/6/16 0:31:37
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System.ComponentModel.DataAnnotations;

namespace Vli.Entity.PO
{
    public class Email : BaseEntity
    {
        /// <summary>
        /// 主题
        /// </summary>
        [MaxLength(150)]
        public string Subjct { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 发件人
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// 抄送
        /// </summary>
        public string CC { get; set; }

        /// <summary>
        /// 密送
        /// </summary>
        public string BCC { get; set; }

        /// <summary>
        /// 主机IP
        /// </summary>
        public string HostIp { get; set; }

        /// <summary>
        /// 是否使用ssl
        /// </summary>
        public bool IsSsl { get; set; }

        /// <summary>
        /// 附件列表
        /// </summary>
        public string Attachments { get; set; }

        /// <summary>
        /// 正文是否为Html
        /// </summary>
        public bool IsBodyHtml { get; set; }
    }
}

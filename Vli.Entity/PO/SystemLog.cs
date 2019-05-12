/**
*
* 功 能： N/A
* 类 名： SystemLog
* 作 者： weili
* 时 间： 2019/2/17 1:41:16
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/


namespace Vli.Entity.PO
{
    public sealed class SystemLog : BaseEntity
    {
        /// <summary>
        /// 线程
        /// </summary>
        public string Thread { get; set; }
        /// <summary>
        /// 消息等级
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 配置项
        /// </summary>
        public string Logger { get; set; }
        /// <summary>
        /// 默认消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 异常详细
        /// </summary>
        public string Exception { get; set; }
        /// <summary>
        /// 记录者
        /// </summary>
        public string Operator { get; set; }
    }
}

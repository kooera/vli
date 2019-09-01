/**
*
* 功 能： N/A
* 类 名： Cnaps
* 作 者： weili
* 时 间： 2019/8/29 23:45:33
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/


namespace Vli.Entity.PO
{
    public class Cnaps : BaseEntity
    {
        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 支行名称
        /// </summary>
        public string BranchName { get; set; }

        /// <summary>
        /// 联行号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public string Lat { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string Lng { get; set; }
    }
}

/**
*
* 功 能： N/A
* 类 名： AccessRecord
* 作 者： weili
* 时 间： 2019/5/11 23:41:24
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/


namespace Vli.Entity.PO
{
    public sealed class AccessRecord : BaseEntity
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { set; get; }
        /// <summary>
        /// 所属国家
        /// </summary>
        public string Country { set; get; }
        /// <summary>
        /// 所属国家编码
        /// </summary>
        public string CountryCode { set; get; }
        /// <summary>
        /// 国际区号
        /// </summary>
        public string Region { set; get; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string RegionName { set; get; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { set; get; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string Zip { set; get; }
        /// <summary>
        /// 经度
        /// </summary>
        public string Lat { set; get; }
        /// <summary>
        /// 维度
        /// </summary>
        public string Lon { set; get; }
        /// <summary>
        /// 时区
        /// </summary>
        public string Timezone { set; get; }
        /// <summary>
        /// 运营商
        /// </summary>
        public string ISP { set; get; }
        /// <summary>
        /// 组织名称
        /// </summary>
        public string ORG { set; get; }
        /// <summary>
        /// 路由区域
        /// </summary>
        public string AS { set; get; }
        /// <summary>
        /// ip映射域名
        /// </summary>
        public string Reverse { set; get; }
        /// <summary>
        /// 是否手机访问
        /// </summary>
        public string Mobile { set; get; }
        /// <summary>
        /// 是否代理
        /// </summary>
        public string Proxy { set; get; }
        /// <summary>
        /// 查询IP
        /// </summary>
        public string Query { set; get; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { set; get; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { set; get; }
        /// <summary>
        /// 浏览器名称
        /// </summary>
        public string Browser { set; get; }
        /// <summary>
        /// 浏览器版本
        /// </summary>
        public string Version { set; get; }
        /// <summary>
        /// 浏览器内核
        /// </summary>
        public string LayoutEngine { set; get; }
        /// <summary>
        /// 访问平台
        /// </summary>
        public string Platform { set; get; }
        /// <summary>
        /// 浏览器代理
        /// </summary>
        public string UserAgent { set; get; }
        /// <summary>
        /// 用户语言
        /// </summary>
        public string UserLanguages { set; get; }
        /// <summary>
        /// 访问方式
        /// </summary>
        public string HttpMethod { set; get; }
        /// <summary>
        /// 访问来源地址
        /// </summary>
        public string AccessFrom { set; get; }
        /// <summary>
        /// 被访问的地址
        /// </summary>
        public string AccessTo { set; get; }
    }
}

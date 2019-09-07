/**
*
* 功 能： N/A
* 类 名： GBAddress
* 作 者： weili
* 时 间： 2019/9/7 20:16:01
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

namespace Vli.Entity.PO
{
    public class GBAddress : BaseEntity
    {
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 省份编码
        /// </summary>
        public string ProvinceCode { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 城市编码
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// 区/县
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// 区/县编码
        /// </summary>
        public string CountyCode { get; set; }

        /// <summary>
        /// 镇/街道
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// 镇/街道编码
        /// </summary>
        public string TownCode { get; set; }

        /// <summary>
        /// 村
        /// </summary>
        public string Village { get; set; }

        /// <summary>
        /// 村编码
        /// </summary>
        public string VillageCode { get; set; }

        /// <summary>
        /// 城乡分类代码
        /// </summary>
        public string ClassificationCode { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }
    }
}

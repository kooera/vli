/**
*
* 功 能： N/A
* 类 名： UserInfo
* 作 者： weili
* 时 间： 2019/5/11 23:52:41
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/


namespace Vli.Entity.VO
{
    public sealed class UserInfo
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Pwd { get; set; }

        public string RealName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Avatar { get; set; }

        public bool IsLock { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl { get; set; }

        public string AuthenticationType { get; set; }
    }
}

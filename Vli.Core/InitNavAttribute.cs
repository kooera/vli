/**
*
* 功 能： N/A
* 类 名： InitNavAttribute
* 作 者： weili
* 时 间： 2019/5/27 21:40:29
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System;

namespace Vli.Core
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    public class InitNavAttribute : Attribute
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public int Layer { get; set; }
    }
}

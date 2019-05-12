/**
*
* 功 能： N/A
* 类 名： Result
* 作 者： weili
* 时 间： 2019/2/17 19:20:48
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

namespace Vli.Entity.VO
{
    public class Result<T> where T : class
    {
        public string Code { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }

        public bool Status { get; set; }
    }
}

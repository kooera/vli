/**
*
* 功 能： N/A
* 类 名： HttpExt
* 作 者： weili
* 时 间： 2019/5/12 0:59:49
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
namespace Vli.Extension
{
    public static class HttpExt
    {
        /// <summary>
        /// 获取参数值
        /// </summary>
        public static string GetValue(this HttpRequest request, string key, string defaultValue = "")
        {
            try
            {
                if (request.Query != null && request.Query.ContainsKey(key))
                {
                    request.Query.TryGetValue(key, out StringValues vs);
                    if (vs.Count > 0)
                    {
                        return vs.ToString();
                    }
                }
                if (request.HasFormContentType && request.Form != null && request.Form.ContainsKey(key))
                {
                    request.Form.TryGetValue(key, out StringValues fvs);
                    if (fvs.Count > 0)
                    {
                        return fvs.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"获取参数{key}时出现异常，{ex.Message}");
            }
            return defaultValue;
        }
    }
}

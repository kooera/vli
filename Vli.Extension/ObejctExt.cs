


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
/**
*
* 功 能： N/A
* 类 名： ObejctExt
* 作 者： weili
* 时 间： 2019/5/12 0:58:23
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/
namespace Vli.Extension
{
    public static class ObejctExt
    {
        /// <summary>
        /// 将对象转为model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ToModel<T>(this object obj)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(obj.ToJson());
            }
            catch (Exception ex)
            {
                throw new Exception($"Json转对象发生错误!,Json:{obj}", ex);
            }
        }

        /// <summary>
        /// 将json串转为model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ToModel<T>(this string obj)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Json转对象发生错误!,Json:{obj}", ex);
            }
        }

        /// <summary>
        /// 转为Json数据
        /// </summary>
        public static string ToJson(this object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                throw new Exception($"对象转Json发生错误!,对象:{obj}", ex);
            }
        }

        /// <summary>
        /// 获取实体键值对
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<object, object> GetProperties(this object obj)
        {
            var result = new Dictionary<object, object>();
            if (obj == null) { return null; }
            PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (properties.Length <= 0) { return null; }
            foreach (PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(obj, null);
                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    result.Add(name, value);
                }
            }
            return result;
        }
    }
}

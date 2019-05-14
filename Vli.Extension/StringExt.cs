/**
 *
 * 功 能： N/A
 * 类 名： StringExt
 * 作 者： weili
 * 时 间： 2019/5/12 0:08:28
 * 版 本： 1.0.0.0
 * 版 权： Copyright (c) 2019 Mainki. All rights reserved.
 *
 */

using System;
using System.Text.RegularExpressions;

namespace Vli.Extension {
    public static class StringExt {
        public static string Guid (this string str) {
            return System.Guid.NewGuid ().ToString ("N");
        }

        public static bool ToBool (this string str) {
            bool.TryParse (str, out bool res);
            return res;
        }

        public static int ToInt (this string str) {
            int.TryParse (str, out int res);
            return res;
        }

        public static long ToLong (this string str) {
            long.TryParse (str, out long res);
            return res;
        }

        public static DateTime ToDateTime (this string str) {
            DateTime.TryParse (str, out DateTime dt);
            return dt;
        }

        /// <summary>
        /// 用指定字符生成指定长度的字符串
        /// </summary>
        /// <param name="str">指定字符</param>
        /// <param name="length">指定长度</param>
        /// <returns>字符串</returns>
        public static string StringOfChar (this string str, int length) {
            string res = "";
            for (int i = 0; i < length; i++) {
                res += str;
            }

            return res;
        }

        /// <summary>
        /// Md5加密
        /// </summary>
        public static string Md5 (this string str) {
            return Security.Md5.Encrypt (str);
        }

        public static string AesEncrypt (this string str) {
            Security.Aes aes = new Security.Aes ();
            return aes.Encrypt (str);
        }

        public static string AesEncrypt (this string str, string key) {
            Security.Aes aes = new Security.Aes ();
            return aes.Encrypt (str, key);
        }

        public static string AesDecrypt (this string str) {
            Security.Aes aes = new Security.Aes ();
            return aes.Decrypt (str);
        }

        public static string AesDecrypt (this string str, string key) {
            Security.Aes aes = new Security.Aes ();
            return aes.Decrypt (str, key);
        }

        /// <summary>
        /// 判断是否为IP
        /// </summary>
        public static bool IsIP (this string ip) {
            if (string.IsNullOrEmpty (ip))
                return false;
            return Regex.IsMatch (ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
    }
}
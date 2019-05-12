/**
*
* 功 能： N/A
* 类 名： Md5
* 作 者： weili
* 时 间： 2019/5/12 16:05:48
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System.Security.Cryptography;
using System.Text;

namespace Vli.Security
{
    public class Md5
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encrypt(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = Encoding.Default.GetBytes(str);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            string result = "";
            for (int i = 0; i < md5data.Length; i++)
            {
                result += md5data[i].ToString("x").PadLeft(2, '0');

            }
            return result;
        }
    }
}

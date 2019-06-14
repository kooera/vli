/**
*
* 功 能： N/A
* 类 名： DirFileHelper
* 作 者： weili
* 时 间： 2019/5/13 23:01:04
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System.IO;

namespace Vli.Helper
{
    /// <summary>
    /// 文件/目录 辅助类
    /// </summary>
    public class DirFileHelper
    {
        public static string[] GetFileNames(string directoryPath, string searchPattern, bool isSearchChild)
        {
            //如果目录不存在，则抛出异常
            if (!IsExistDirectory(directoryPath))
            {
                throw new FileNotFoundException();
            }

            try
            {
                if (isSearchChild)
                {
                    return Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);
                }
                else
                {
                    return Directory.GetFiles(directoryPath, searchPattern, SearchOption.TopDirectoryOnly);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        public static string ReadFile(string Path)
        {
            string s = "";
            if (!File.Exists(Path))
            {
                s = "不存在相应的目录";
            }
            else
            {
                StreamReader f2 = new StreamReader(Path, System.Text.Encoding.GetEncoding("gb2312"));
                s = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }
            return s;
        }

        public static bool IsExistDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }


        #region 写文件

        public static void WriteFile(string Path, string Strings)
        {
            if (!File.Exists(Path))
            {
                FileStream f = File.Create(Path);
                f.Close();
                f.Dispose();
            }
            StreamWriter f2 = new StreamWriter(Path, true, System.Text.Encoding.UTF8);
            f2.WriteLine(Strings);
            f2.Close();
            f2.Dispose();
        }

        #endregion
    }
}

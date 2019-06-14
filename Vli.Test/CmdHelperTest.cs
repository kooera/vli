/**
*
* 功 能： N/A
* 类 名： CmdHelperTest
* 作 者： weili
* 时 间： 2019/6/9 13:51:36
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Vli.Helper;

namespace Vli.Test
{
    [TestClass]
    public class CmdHelperTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            CmdHelper cmd = new CmdHelper();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("E: \n");
            stringBuilder.Append(@"cd E:\Code-CSharp\MKTBK");
            stringBuilder.Append("\n");
            stringBuilder.Append("dotnet build");

            cmd.Execute(stringBuilder.ToString());
        }

        [TestMethod]
        public void ExecuteTaskTest()
        {
            CmdHelper cmd = new CmdHelper();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("E: \n");
            stringBuilder.Append(@"cd E:\Code-CSharp\MKTBK");
            stringBuilder.Append("\n");
            stringBuilder.Append("dotnet build");

            cmd.ExecuteTask(stringBuilder.ToString());
        }
    }
}

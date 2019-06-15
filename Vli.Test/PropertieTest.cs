/**
*
* 功 能： N/A
* 类 名： PropertieTest
* 作 者： weili
* 时 间： 2019/6/15 18:06:52
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Vli.Entity.PO;
using Vli.Extension;

namespace Vli.Test
{
    [TestClass]
    public class PropertieTest
    {
        [TestMethod]
        public void Test001()
        {
            SystemUser user = new SystemUser();
            user.Email = "sss";
            user.IsActive = true;

            Dictionary<object, object> re = user.GetProperties();
        }
    }
}

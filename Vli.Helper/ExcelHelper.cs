


using Aspose.Cells;
using System;
using System.Data;
/**
*
* 功 能： N/A
* 类 名： ExcelHelper
* 作 者： weili
* 时 间： 2019/5/13 22:56:59
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/
namespace Vli.Helper
{
    public class ExcelHelper
    {
        /// <summary>
        /// 导入文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataTable ImportFromExcel(string path)
        {
            Workbook workbook = new Workbook(path);
            try
            {
                Worksheet worksheet = workbook.Worksheets[0];
                Cells cells = worksheet.Cells;
                return cells.ExportDataTable(0, 0, cells.MaxDataRow + 1, cells.MaxDataColumn + 1, true);
            }
            catch (Exception ex)
            {
                throw new Exception("导入Excel数据失败", ex);
            }
        }
    }
}

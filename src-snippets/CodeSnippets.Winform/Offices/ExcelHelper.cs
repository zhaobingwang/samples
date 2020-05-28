using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Winform.Offices
{
    public class ExcelHelper
    {
        /// <summary>
        /// 读取Excel
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="stream">文件流</param>
        /// <param name="startIndex">起始行索引</param>
        /// <param name="sheetIndex">sheet索引</param>
        /// <returns></returns>
        public static IList<T> GetList<T>(Stream stream, int startIndex, int sheetIndex = 0)
            where T : class
        {
            IList<T> ts = new List<T>();
            try
            {
                IWorkbook workbook = WorkbookFactory.Create(stream);
                var sheet = workbook.GetSheetAt(sheetIndex);
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    //一行最后一个cell的编号 即总的列数
                    int cellCount = firstRow.LastCellNum;
                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startIndex; i <= rowCount; ++i)
                    {
                        //获取行的数据
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　
                        {
                            T model = Activator.CreateInstance<T>();
                            for (int j = row.FirstCellNum; j < cellCount; ++j)
                            {
                                if (row.GetCell(j) != null)
                                {
                                    var rowTemp = row.GetCell(j);
                                    string value = null;
                                    if (rowTemp.CellType == CellType.Numeric)
                                    {
                                        short format = rowTemp.CellStyle.DataFormat;
                                        if (format == 14 || format == 31 || format == 57 || format == 58 || format == 20)
                                            value = rowTemp.DateCellValue.ToString("yyyy-MM-dd");
                                        else
                                            value = rowTemp.NumericCellValue.ToString();
                                    }
                                    else
                                        value = rowTemp.ToString();
                                    //赋值
                                    foreach (System.Reflection.PropertyInfo item in typeof(T).GetProperties())
                                    {
                                        var column = item.GetCustomAttributes(true).First(x => x is ColumnAttribute) as ColumnAttribute;
                                        if (column.Index == j)
                                        {
                                            item.SetValue(model, value);
                                            break;
                                        }
                                    }
                                }
                            }
                            ts.Add(model);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (stream != null) stream.Close();
            }
            return ts;
        }
    }

    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(int index)
        {
            Index = index;
        }
        public int Index { get; set; }
    }
}

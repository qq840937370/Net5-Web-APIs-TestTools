/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：数据库相关的工具类                                                   
*│　作    者：执笔小白-https://www.cnblogs.com/whpepsi/p/3779217.html                                 
*│　版    本：1.0                                       
*│　创建时间：2021-10-13 15:40:56                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: WMSTOMESTT                               
*│　类    名：DataTools                                     
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CommonTools
{
    public class DataTools
    {

        /// <summary>
        /// DataSet装换为泛型集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p_DataSet">DataSet</param>
        /// <param name="p_TableIndex">待转换数据表索引</param>
        /// <returns></returns>
        public static List<T> DataSetToIList<T>(DataSet p_DataSet, int p_TableIndex)
        {
            if (p_DataSet == null || p_DataSet.Tables.Count < 0)
                return null;
            if (p_TableIndex > p_DataSet.Tables.Count - 1)
                return null;
            if (p_TableIndex < 0)
                p_TableIndex = 0;

            DataTable p_Data = p_DataSet.Tables[p_TableIndex];
            // 返回值初始化
            List<T> result = new List<T>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < p_Data.Columns.Count; i++)
                    {
                        // 属性与字段名称一致的进行赋值 (枚举类型无法转换，单独拎出来)
                        if (pi.Name.Equals(p_Data.Columns[i].ColumnName))
                        {
                            // 数据库NULL值单独处理
                            if (p_Data.Rows[j][i] != DBNull.Value)
                                pi.SetValue(_t, p_Data.Rows[j][i], null);
                            else
                                pi.SetValue(_t, null, null);
                            break;
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }
    }
    // 示例
    public class DatatoolTest
    {
        // DataSet装换为泛型集合例子
        public void DataSetToIListTest()
        {
            //List<BilClass> bilClass = DataTools.DataSetToIList<BilClass>(dataSet, 0);
        }
    }
}

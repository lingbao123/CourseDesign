using System;
using System.Collections.Generic;
using System.Data;
using CourseDesign.Models;
using CourseDesign.Util;

namespace CourseDesign.Dao;

public class PersonTypeDao
{
    /// <summary>
    /// 获取所有人员类型
    /// </summary>
    public List<string> GetAll()
    {
        string sql = "SELECT * FROM Note PersonType";
        return MapTableToList(MySqlHelper.ExecuteDataTable(sql));
    }

    /// <summary>
    /// 映射为 List<string>
    /// </summary>
    private List<string> MapTableToList(DataTable table)
    {
        var list = new List<string>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(row["PersonTypeName"].ToString());
        }
        return list;
    }

}
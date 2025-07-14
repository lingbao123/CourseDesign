using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CourseDesign.Models;
using CourseDesign.Util;

namespace CourseDesign.Dao;

public class PersonRecordDao
{
    /// <summary>
    /// 添加记录
    /// </summary>
    public static bool Add(PersonRecord record)
    {
        string sql = "INSERT INTO PersonRecord (PersonId, OperatorId, Action) VALUES (@id, @operator, @action)";
        int rowsAffected = CourseDesign.Util.MySqlHelper.ExecuteNonQuery(sql,
            new MySqlParameter("@id", record.PersonId),
            new MySqlParameter("@operator", record.OperatorId),
            new MySqlParameter("@action", record.Action));
        return rowsAffected > 0;
    }
    
    /// <summary>
    /// 获取所有笔记
    /// </summary>
    public List<PersonRecord> GetAll()
    {
        string sql = "SELECT * FROM PersonRecord ORDER BY Time";
        return MapTableToList(CourseDesign.Util.MySqlHelper.ExecuteDataTable(sql));
    }

  
    /// <summary>
    /// 把 DataTable 映射为 List PersonRecord
    /// </summary>
    private List<PersonRecord> MapTableToList(DataTable table)
    {
        var list = new List<PersonRecord>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(new PersonRecord()
            {
                PersonRecordId = row.Field<int>("PersonRecordId"),          // 假设非空主键
                PersonId = row.Field<int?>("PersonId") ?? 0,
                OperatorId = row.Field<int?>("OperatorId") ?? 0,            // 假设允许为空，默认0
                Action = row.Field<string>("Action") ?? "",                  // 字符串null转空字符串
                Time = row.Field<DateTime?>("Time") ?? DateTime.MinValue    // 时间可空，默认最小时间
            });

        }
        return list;
    }

}
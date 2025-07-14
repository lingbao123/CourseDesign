using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CourseDesign.Models;
using CourseDesign.Util;

namespace CourseDesign.Dao;

public class LoginRecordDao
{
    /// <summary>
    /// 添加记录
    /// </summary>
    public static bool Add(LoginRecord record)
    {
        string sql = "INSERT INTO LoginRecord (PersonId, IpAddress, SuccessOrNot,Result) VALUES (@id, @ip, @success, @result)";
        int rowsAffected = CourseDesign.Util.MySqlHelper.ExecuteNonQuery(sql,
            new MySqlParameter("@id", record.PersonId),
            new MySqlParameter("@ip", record.IpAddress),
            new MySqlParameter("@success", record.SuccessOrNot),
            new MySqlParameter("@result", record.Result));
        return rowsAffected > 0;
    }
    
    /// <summary>
    /// 获取所有记录
    /// </summary>
    public List<LoginRecord> GetAll()
    {
        string sql = "SELECT * FROM LoginRecord ORDER BY Time";
        return MapTableToList(CourseDesign.Util.MySqlHelper.ExecuteDataTable(sql));
    }

  
    /// <summary>
    /// 把 DataTable 映射为 List PersonRecord
    /// </summary>
    private List<LoginRecord> MapTableToList(DataTable table)
    {
        var list = new List<LoginRecord>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(new LoginRecord()
            {
                LoginRecordId = row.Field<int>("LoginRecordId"),          // 假设非空主键
                PersonId = row.Field<int?>("PersonId") ?? 0,
                //IpAddress = row.Field<string>("OperatorId") ?? "",            // 假设允许为空，默认0
                //Result = row.Field<string>("Result") ?? "", 
                //IpAddress = row.Field<string>("OperatorId") ?? "", 
                //Action = row.Field<string>("Action") ?? "",                  // 字符串null转空字符串
                Time = row.Field<DateTime?>("Time") ?? DateTime.MinValue    // 时间可空，默认最小时间
            });

        }
        return list;
    }

}
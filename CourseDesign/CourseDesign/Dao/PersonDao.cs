using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CourseDesign.Models;
using CourseDesign.Util;

namespace CourseDesign.Dao;

public class PersonDao
{
    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="person"></param>
    public static bool Add(Person person)
    {
        string sql = "INSERT INTO Person (PersonName, Password, PersonType) VALUES (@name, @password, @type)";
        int rowsAffected = CourseDesign.Util.MySqlHelper.ExecuteNonQuery(sql,
            new MySqlParameter("@name", person.PersonName),
            new MySqlParameter("@password", person.Password),
            new MySqlParameter("@type", person.PersonType));
        return rowsAffected > 0;
    }
    
    /// <summary>
    /// 检查用户名是否存在
    /// </summary>
    public static bool Exists(string PersonName)
    {
        string sql = "SELECT COUNT(*) FROM Person WHERE PersonName = @name";
        var param = new MySqlParameter("@name", PersonName);
        int count = Convert.ToInt32(CourseDesign.Util.MySqlHelper.ExecuteScalar(sql, param));
        return count > 0;
    }
    
    /// <summary>
    /// 根据用户名获取密码
    /// </summary>
    /// <param name="PersonName">用户名</param>
    /// <returns>密码字符串（找不到则返回 null）</returns>
    public static string? GetPasswordByUsername(string PersonName)
    {
        string sql = "SELECT Password FROM Person WHERE PersonName = @name";
        var param = new MySqlParameter("@name", PersonName);

        object? result = CourseDesign.Util.MySqlHelper.ExecuteScalar(sql, param);
    
        return result != null ? result.ToString() : null;
    }
    
    /// <summary>
    /// 根据用户名获取id
    /// </summary>
    /// <param name="PersonName">用户名</param>
    /// <returns>密码字符串（找不到则返回 null）</returns>
    public static string GetIdByUsername(string PersonName)
    {
        string sql = "SELECT PersonId FROM Person WHERE PersonName = @name";
        var param = new MySqlParameter("@name", PersonName);

        object? result = CourseDesign.Util.MySqlHelper.ExecuteScalar(sql, param);
    
        return result != null ? result.ToString() : null;
    }

}
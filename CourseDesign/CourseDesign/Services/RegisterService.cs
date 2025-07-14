using CourseDesign.Dao;
using CourseDesign.Models;
using CourseDesign.Models.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CourseDesign.Services;

public class RegisterService
{
    /// <summary>
    /// 注册用户
    /// </summary>
    /// <param name="view">待注册的用户</param>
    /// <param name="message">返回注册成功或失败的信息</param>
    /// <returns>是否注册成功</returns>
    public bool Register(RegisterView view, out string message)
    {
        string hash = CourseDesign.Util.PasswordHelper.HashPassword(view.Password);

        Person person = new Person
        {
            PersonName = view.Name,
            Password = hash,
            PersonType = "student"
        };

        if (PersonDao.Exists(view.Name))
        {
            message = "这个名字有人用过了";
            return false;
        }

        bool success = PersonDao.Add(person);
        message = success ? "注册成功！" : "注册失败，请重试。";

        if (success)
        {
            PersonRecord record = new PersonRecord();
            string id = PersonDao.GetIdByUsername(view.Name);
            int.TryParse(id, out int id_num);
            record.PersonId = id_num;
            record.OperatorId = id_num;
            record.Action = "register";
            PersonRecordDao.Add(record);
        }
        
        return success;
    }
}
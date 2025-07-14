using CourseDesign.Dao;
using CourseDesign.Models;
using CourseDesign.Models.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Net;

namespace CourseDesign.Services;

public class LoginService
{
    public bool Login(LoginView view, out string message)
    {
        string hostName = Dns.GetHostName(); // 获取主机名
        string ip = Dns.GetHostEntry(hostName)
            .AddressList
            .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            ?.ToString();

        Console.WriteLine("本机IP地址是：" + ip);

        if (!PersonDao.Exists(view.Name))
        {
            message = "用户名或密码错误";
        }y`y
        string hash = CourseDesign.Util.PasswordHelper.HashPassword(view.Password);
        
        string password=PersonDao.GetPasswordByUsername(view.Name);

        if (hash != password)
        {
            message = "用户名或密码错误";
        }
    }
}
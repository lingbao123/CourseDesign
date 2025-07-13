using CourseDesign.Dao;
using CourseDesign.Models;
using System;
using System.Windows.Forms;

namespace CourseDesign.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly UserDAO _userDao = new UserDAO();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("用户名和密码不能为空！");
                return;
            }

            bool result = _userDao.Register(new User { Username = username, Password = password });
            if (result)
            {
                MessageBox.Show("注册成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("注册失败！");
            }
        }
    }
}

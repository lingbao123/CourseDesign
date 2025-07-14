using CourseDesign.Dao;
using CourseDesign.Models;
using CourseDesign.Models.ViewModels;
using CourseDesign.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CourseDesign.Forms
{

    public class LoginForm : Form
    {
        private TextBox txtName;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnToRegister;
        private Label lblToRegister;
        private Label lblName;
        private Label lblPassword;
        public LoginForm(string name = "", string password = "")
        {
            this.Text = "登录";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeLayout(name, password);
        }
        
        private void InitializeLayout(string name, string password )//界面布局
        {
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "登录";

            // 初始化控件
            lblName = new Label()
            {
                Text = "用户名：",
                Location = new Point(300, 100),
                Size = new Size(80, 30)
            };

            txtName = new TextBox()
            {
                Text = name,
                Location = new Point(400, 100),
                Size = new Size(200, 30)
            };

            lblPassword = new Label()
            {
                Text = "密码：",
                Location = new Point(300, 160),
                Size = new Size(80, 30)
            };

            txtPassword = new TextBox()
            {
                Text = password,
                Location = new Point(400, 160),
                Size = new Size(200, 30),
                PasswordChar = '*'
            };

            btnLogin = new Button()
            {
                Text = "登录",
                Location = new Point(400, 280),
                Size = new Size(90, 35)
            };

            lblToRegister = new Label()
            {
                Text = "没有账号？",
                Location = new Point(350, 330),
                Size = new Size(110, 25)
            };

            btnToRegister = new Button()
            {
                Text = "去注册",
                Location = new Point(440, 325),
                Size = new Size(90, 35),
            };
            
            btnToRegister.FlatStyle = FlatStyle.Flat;
            btnToRegister.FlatAppearance.BorderSize = 0;
            btnToRegister.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnToRegister.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnToRegister.BackColor = Color.Transparent;

            // 添加控件到窗口
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(lblToRegister);
            this.Controls.Add(btnToRegister);

            btnLogin.Click += BtnLogin_click;
            btnToRegister.Click += BtnToRegister_click;
        }

        private void BtnLogin_click(object sender, EventArgs e)
        {
            var view = new LoginView
            {
                Name = txtName.Text.Trim(),
                Password = txtPassword.Text,
            };
            if (string.IsNullOrEmpty(view.Name))
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(view.Password))
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            
            var service = new LoginService();
            bool success = service.Login(view, out string message);

            MessageBox.Show(message);

            if (success)
            {
                LoginForm loginForm = new LoginForm(txtName.Text,txtPassword.Text);
                
                txtName.Text = "";
                txtPassword.Text = "";
                
                loginForm.Show();
                this.Close();
            }
        }

        private void BtnToRegister_click(object sender, EventArgs e)
        {
            Form registerForm = new RegisterForm();
            registerForm.Show();
            this.Close();
        }
    }
}
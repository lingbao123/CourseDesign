using CourseDesign.Dao;
using CourseDesign.Models;
using CourseDesign.Models.ViewModels;
using CourseDesign.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CourseDesign.Forms
{
    public class RegisterForm : Form
    {
        private TextBox txtName;
        private TextBox txtPassword;
        private TextBox txtCheckPassword;
        private Button btnRegister;
        private Button btnToLogin;
        private Label lblToLogin;
        private Label lblName;
        private Label lblPassword;
        private Label lblCheckPassword;

        public RegisterForm()
        {
            this.Text = "注册";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeLayout();
        }

        private void InitializeLayout()//界面布局
        {
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "注册";

            // 初始化控件
            lblName = new Label()
            {
                Text = "用户名：",
                Location = new Point(300, 100),
                Size = new Size(80, 30)
            };

            txtName = new TextBox()
            {
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
                Location = new Point(400, 160),
                Size = new Size(200, 30),
                PasswordChar = '*'
            };

            lblCheckPassword = new Label()
            {
                Text = "确认密码：",
                Location = new Point(300, 220),
                Size = new Size(100, 30)
            };

            txtCheckPassword = new TextBox()
            {
                Location = new Point(400, 220),
                Size = new Size(200, 30),
                PasswordChar = '*'
            };

            btnRegister = new Button()
            {
                Text = "注册",
                Location = new Point(400, 280),
                Size = new Size(90, 35)
            };

            lblToLogin = new Label()
            {
                Text = "已有账号？",
                Location = new Point(350, 330),
                Size = new Size(110, 25)
            };

            btnToLogin = new Button()
            {
                Text = "去登录",
                Location = new Point(440, 325),
                Size = new Size(90, 35),
            };
            
            btnToLogin.FlatStyle = FlatStyle.Flat;
            btnToLogin.FlatAppearance.BorderSize = 0;
            btnToLogin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnToLogin.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnToLogin.BackColor = Color.Transparent;

            // 添加控件到窗口
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblCheckPassword);
            this.Controls.Add(txtCheckPassword);
            this.Controls.Add(btnRegister);
            this.Controls.Add(lblToLogin);
            this.Controls.Add(btnToLogin);

            btnRegister.Click += BtnRegister_click;
            btnToLogin.Click += BtnToLogin_click;
        }

        private void BtnRegister_click(object sender, EventArgs e)
        {
            var view = new RegisterView
            {
                Name = txtName.Text.Trim(),
                Password = txtPassword.Text,
                CheckPassword = txtCheckPassword.Text
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
            if (string.IsNullOrEmpty(view.CheckPassword))
            {
                MessageBox.Show("请再确认一遍密码");
                return;
            }
            if (view.Password != view.CheckPassword)
            {
                MessageBox.Show("两次密码不一致！");
                return;
            }
            
            var service = new RegisterService();
            bool success = service.Register(view, out string message);

            MessageBox.Show(message);

            if (success)
            {
                LoginForm loginForm = new LoginForm(txtName.Text,txtPassword.Text);
                
                txtName.Text = "";
                txtPassword.Text = "";
                txtCheckPassword.Text = "";
                
                loginForm.Show();
                this.Close();
            }
        }

        private void BtnToLogin_click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}

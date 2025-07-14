using System;
using System.Windows.Forms;

namespace CourseDesign.Forms;

public class MainEntryForm : Form
{
    public MainEntryForm()
    {
        this.Load += MainEntryForm_Load;
        this.WindowState = FormWindowState.Minimized;
        this.ShowInTaskbar = false;
    }

    private void MainEntryForm_Load(object sender, EventArgs e)
    {
        this.Hide(); // 启动就隐藏
        var loginForm = new LoginForm(); // 打开其他窗体
        loginForm.ShowDialog();

        //this.Close(); // 可以是 this.Close() 或 Application.Exit()

    }
}
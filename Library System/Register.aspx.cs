using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
public partial class Register : System.Web.UI.Page
{
    static classLogin myLogin = new classLogin();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string username = tbUsername.Text;
        string name = tbName.Text;
        string password = tbPass.Text;
        string md5pass= System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
        string email = tbEmail.Text;
        string sql1 = "select * from Users where username='" + username + "'";
        int result = 0;
        result = myLogin.Select(sql1);
        if (username.Length == 0 || name.Length == 0 || password.Length == 0|| email.Length == 0)
            Response.Write("<script>alert('输入不能为空！')</script>");
        else if (result == 1)
            Response.Write("<script>alert('用户名已存在！')</script>");
        else if (password.Length < 6)
            Response.Write("<script>alert('密码不能小于6位！')</script>");
        else if (!Regex.IsMatch(tbPass.Text, "^[A-Za-z0-9]*$"))
            Response.Write("<script>alert('密码只能包含数字和字母！')</script>");
        else if (!Regex.IsMatch(tbEmail.Text, "^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$"))
            Response.Write("<script>alert('请输入正确的邮箱格式！')</script>");
        else if(rbMan.Checked == false && rbWoman.Checked == false)
            Response.Write("<script>alert('请选择性别！')</script>");
        else
        {
            string sex = "0";
            if (rbMan.Checked)
                sex = "男";
            if (rbWoman.Checked)
                sex = "女";
            string sql2 = "insert into Users values('" + username + "','" + md5pass + "',N'"+name+"',N'"+sex+"','"+email+"','open','user','0')";
            classLogin.Save(sql2);
            Response.Write("<script>alert('注册成功！');location='Login.aspx'</script>");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void rbMan_CheckedChanged(object sender, EventArgs e)
    {
        rbWoman.Checked = false;
    }

    protected void rbWoman_CheckedChanged(object sender, EventArgs e)
    {
        rbMan.Checked = false;
    }
}
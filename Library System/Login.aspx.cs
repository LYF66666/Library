using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

public partial class Login : System.Web.UI.Page
{
    static classLogin myLogin = new classLogin();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtName.Text;
        string password = txtPwd.Text;
        string md5pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
        string sql1 = "select * from Users where username='" + username + "'";
        string sql2 = "select * from Users where username='" + username + "' and password='" + md5pass + "'";
        int result = myLogin.Select(sql2);
        if (username.Length == 0 || password.Length == 0)
            Response.Write("<script>alert('输入不能为空！');</script>");
        else if (myLogin.Select(sql1) == 0)
            Response.Write("<script>alert('用户名不存在！')</script>");
        else if (!Regex.IsMatch(txtPwd.Text, "^[A-Za-z0-9]*$"))
            Response.Write("<script>alert('密码只能包含数字和字母！')</script>");
        else if (result == 0)
            Response.Write("<script>alert('密码不正确！')</script>");
        else if (result == 1)
        {
            if (classLogin.DataT(sql1).Rows[0][6].ToString() == "close")
                Response.Write("<script>alert('您的账号已被查封！')</script>");
            else if (classLogin.DataT(sql1).Rows[0][7].ToString() == "administrant")
                Response.Write("<script>alert('请选择管理员登录！');location='Login.aspx'</script>");
            else
            {
                Response.Write("<script>alert('登录成功！');location='Welcome.aspx'</script>");
                Session["username"] = username;
                string sql = "select * from Users where username='" + username + "'";
                Session["email"] = classLogin.DataT(sql).Rows[0][5].ToString();
                string classification = classLogin.DataT(sql1).Rows[0][7].ToString();
                Session["classification"] = classification;
            }
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    protected void btnAdminLogin_Click(object sender, EventArgs e)
    {
        string username = txtName.Text;
        string password = txtPwd.Text;
        string md5pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
        string sql1 = "select * from Users where username='" + username + "'";
        string sql2 = "select * from Users where username='" + username + "' and password='" + md5pass + "'";        
        int result = myLogin.Select(sql2);
        if (username.Length == 0 || password.Length == 0)
            Response.Write("<script>alert('输入不能为空！');</script>");
        else if (myLogin.Select(sql1) == 0)
            Response.Write("<script>alert('用户名不存在！')</script>");
        else if (!Regex.IsMatch(txtPwd.Text, "^[A-Za-z0-9]*$"))
            Response.Write("<script>alert('密码只能包含数字和字母！')</script>");
        else if (result == 0)
            Response.Write("<script>alert('密码不正确！')</script>");
        else if (result == 1)
        {
            if (classLogin.DataT(sql1).Rows[0][6].ToString() == "close")
                Response.Write("<script>alert('您的账号已被查封！')</script>");
            else if (classLogin.DataT(sql1).Rows[0][7].ToString() == "user")
                Response.Write("<script>alert('您还不是管理员！');location='Login.aspx'</script>");
            else
            {
                Response.Write("<script>alert('登录成功！');location='Admin.aspx'</script>");
                Session["username"] = username;
                string classification = classLogin.DataT(sql1).Rows[0][7].ToString();
                Session["classification"] = classification;
            }
        }
    }

    

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class PassEditor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["classification"] != null)
        {
            string classification = Session["classification"].ToString();
            if (classification != "user")
                Response.Redirect("Login.aspx");
        }
        else
            Response.Redirect("Login.aspx");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string password = tbPass.Text;
        string md5pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
        string newpass = tbNewpass.Text;
        string newmd5pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newpass, "MD5");
        string username = Session["username"].ToString();
        string sql1 = "select * from Users where username='" + username + "'";
        if(password.Length == 0 || newpass.Length == 0)
            Response.Write("<script>alert('输入不能为空！');</script>");
        else if (classLogin.DataT(sql1).Rows[0][2].ToString() != md5pass)
            Response.Write("<script>alert('原密码不正确！');</script>");
        else
        {
            string sql2 = "update Users set password='" + newmd5pass + "' where username='" + username + "'";
            classLogin.Save(sql2);
            Response.Write("<script>alert('修改成功！');location='IDinformation.aspx'</script>");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("IDinformation.aspx");
    }
}
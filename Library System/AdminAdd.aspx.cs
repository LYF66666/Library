using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAdd : System.Web.UI.Page
{
    static classLogin myLogin = new classLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["classification"] != null)
        {
            string classification = Session["classification"].ToString();
            if (classification == "user")
                Response.Redirect("Login.aspx");
        }
        else
            Response.Redirect("Login.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string username = tbUsername.Text;
        string name = tbName.Text;
        string password = tbPass.Text;
        string email = tbEmail.Text;
        string sql1 = "select * from Users where username='" + username + "'";
        int result = 0;
        result = myLogin.Select(sql1);
        if (username.Length == 0 || name.Length == 0 || password.Length == 0 || email.Length == 0)
            Response.Write("<script>alert('输入不能为空！')</script>");
        else if (result == 1)
            Response.Write("<script>alert('用户名已存在！')</script>");
        else if (password.Length < 6)
            Response.Write("<script>alert('密码不能小于6位！')</script>");
        else if (!Regex.IsMatch(tbPass.Text, "^[A-Za-z0-9]*$"))
            Response.Write("<script>alert('密码只能包含数字和字母！')</script>");
        else if (!Regex.IsMatch(tbEmail.Text, "^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$"))
            Response.Write("<script>alert('请输入正确的邮箱格式！')</script>");
        else if (rbMan.Checked == false && rbWoman.Checked == false)
            Response.Write("<script>alert('请选择性别！')</script>");
        else
        {
            string sex = "0";
            if (rbMan.Checked)
                sex = "男";
            if (rbWoman.Checked)
                sex = "女";
            string sql2 = "insert into Users values('" + username + "','" + password + "',N'" + name + "',N'" + sex + "','" + email + "','open','administrant')";
            classLogin.Save(sql2);
            Response.Write("<script>alert('添加成功！');location='SearchUser.aspx'</script>");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchUser.aspx");
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
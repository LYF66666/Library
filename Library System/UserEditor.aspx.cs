using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class UserEditor : System.Web.UI.Page
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
        /*if (!IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string sql = "select * from Users where id='" + id + "'";
            int result = myLogin.Select(sql);
            if(result==1)
            {
                DataTable dt = new DataTable();
                dt = classLogin.DataT(sql);
                string password = dt.Rows[0][2].ToString();
                tbPass.Text = password;
            }            
        }*/
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string password = tbPass.Text;
        string md5pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
        string sql = "update Users set password='" + md5pass + "' where id='" + id + "'";
        if(password.Length == 0)
            Response.Write("<script>alert('输入不能为空！');location='UserEditor.aspx'</script>");
        else if(password.Length < 6)
            Response.Write("<script>alert('密码不能小于六位！');location='UserEditor.aspx'</script>");
        else if (!Regex.IsMatch(tbPass.Text, "^[A-Za-z0-9]*$"))
            Response.Write("<script>alert('密码只能包含数字和字母！')</script>");
        else
        {
            classLogin.Save(sql);
            Response.Write("<script>alert('修改成功！');location='SearchUser.aspx'</script>");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchUser.aspx");
    }
}
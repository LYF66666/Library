using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyLibrary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["classification"] != null)
        {            
            string classification = Session["classification"].ToString();
            if (classification != "user")
                Response.Redirect("Login.aspx");
            string username = Session["username"].ToString();
            string sql = "select * from Record where username='" + username + "'";
            DataTable dt = new DataTable();
            dt = classLogin.DataT(sql);
            this.rptLibrary.DataSource = dt;
            this.rptLibrary.DataBind();
        }
        else
            Response.Redirect("Login.aspx");        
    }

    protected void rptLibrary_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Return")
        {
            string bookid = e.CommandArgument.ToString();
            string sql = "select * from Record where bookid='" + bookid + "'";
            string ISBN = classLogin.DataT(sql).Rows[0][4].ToString();
            string bookname = classLogin.DataT(sql).Rows[0][2].ToString();
            string sql1= "delete from Record where bookid='"+bookid+"'";
            classLogin.Save(sql1);
            string sql2 = "update Book set storage=storage+1 where ISBN='" + ISBN + "'";
            classLogin.Save(sql2);
            string sql3 = "insert into BookInformation values('"+bookid+"',N'" + bookname + "','" + ISBN + "')";
            classLogin.Save(sql3);
            Response.Write("<script>alert('归还成功！');location='MyLibrary.aspx'</script>");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Welcome.aspx");
    }
}
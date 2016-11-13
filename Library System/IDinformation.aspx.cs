using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IDinformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["classification"] != null)
        {
            string classification = Session["classification"].ToString();
            if (classification != "user")
                Response.Redirect("Login.aspx");
            string username = Session["username"].ToString();
            string sql = "select * from Users where username='" + username + "'";
            DataTable dt = new DataTable();
            dt = classLogin.DataT(sql);
            this.rptID.DataSource = dt;
            this.rptID.DataBind();
        }
        else
            Response.Redirect("Login.aspx");    
    }

    protected void rptID_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("PassEditor.aspx");
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("welcome.aspx");
    }
}
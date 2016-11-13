using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Record : System.Web.UI.Page
{
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
        string ISBN = Request.QueryString["ISBN"];
        string sql = "select * from Record where ISBN='"+ISBN+"'";
        DataTable dt = new DataTable();
        dt = classLogin.DataT(sql);
        this.rptRecord.DataSource = dt;
        this.rptRecord.DataBind();
    }

    protected void rptRecord_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminSearch.aspx");
    }
}
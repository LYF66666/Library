using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Welcome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["classification"] != null)
        {
            string username = Session["username"].ToString();
            lblUser.Text = username;
            string classification = Session["classification"].ToString();
            if (classification != "user")
                Response.Redirect("Login.aspx");
        }
        else
            Response.Redirect("Login.aspx");
      
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }

    protected void btnLibrary_Click(object sender, EventArgs e)
    {
        Response.Redirect("MyLibrary.aspx");
    }

    protected void btnID_Click(object sender, EventArgs e)
    {
        Response.Redirect("IDinformation.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("BookSearch.aspx");
    }
}
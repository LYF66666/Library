using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
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
        
    }

    protected void btnUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchUser.aspx");
    }

    protected void btnBook_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminSearch.aspx");
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}
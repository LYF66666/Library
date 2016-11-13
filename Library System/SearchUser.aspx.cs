using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchUser : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            DataBindToRepeater(1);
        }
        if (Session["classification"].ToString() != "topadministrant")
            btnAdd.Visible = false;
    }

    void DataBindToRepeater(int currentPage)
    {
        string sql;
        if (Session["classification"].ToString() == "topadministrant")
            sql = "select * from Users where classification='user' or classification='administrant'";
        else
            sql = "select * from Users where classification='user'";
        DataTable dt = new DataTable();
        dt = classLogin.DataT(sql);
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 5;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage - 1;
        rptUser.DataSource = pds;
        rptUser.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string username = tbSearch.Text;
        string sql = "Select * from Users";
        if (username.Length == 0)
            sql = "Select * from Users";
        else
            sql = "Select * from Users where username='" + username + "'";
        int result = myLogin.Select(sql);
        if (result == 0)
            Response.Write("<script>alert('搜索无结果！')</script>");
        else
        {
            DataTable dt = new DataTable();
            dt = classLogin.DataT(sql);
            this.rptUser.DataSource = dt;
            this.rptUser.DataBind();
        }
        string classification = Session["classification"].ToString();
        if (classification == "user")
            Response.Redirect("Login.aspx");
    }

    protected void btnLogoff_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string sql = "delete from Users where id='" + id + "'";
            classLogin.Save(sql);
            Response.Write("<script>alert('删除成功！');location='SearchUser.aspx'</script>");
        }
        if (e.CommandName == "Close")
        {
            string username = e.CommandArgument.ToString();
            string sql = "update Users set status='close' where username='" + username + "'";
            classLogin.Save(sql);
            Response.Write("<script>alert('查封成功！');location='SearchUser.aspx'</script>");
        }
        if (e.CommandName == "Open")
        {
            string username = e.CommandArgument.ToString();
            string sql = "update Users set status='open' where username='" + username + "'";
            classLogin.Save(sql);
            Response.Write("<script>alert('解封成功！');location='SearchUser.aspx'</script>");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminAdd.aspx");
    }

    protected void btnUp_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lbNow.Text) - 1 < 1)
            lbNow.Text = "1";
        else
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) - 1);
        DataBindToRepeater(Convert.ToInt32(lbNow.Text));
    }

    protected void btnDrow_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lbNow.Text) + 1 > Convert.ToInt32(lbTotal.Text))
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));
        else
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) + 1);
        DataBindToRepeater(Convert.ToInt32(lbNow.Text));
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        lbNow.Text = "1";
        DataBindToRepeater(Convert.ToInt32(lbNow.Text));
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));
        DataBindToRepeater(Convert.ToInt32(lbNow.Text));
    }

    protected void btnJump_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (int.TryParse(txtJump.Text, out i))
        {
            if (Convert.ToInt32(txtJump.Text) < 1)
                lbNow.Text = "1";
            else if (Convert.ToInt32(txtJump.Text) > Convert.ToInt32(lbTotal.Text))
                lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));
            else
                lbNow.Text = Convert.ToString(Convert.ToInt32(txtJump.Text));
        }
        else
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));
        DataBindToRepeater(Convert.ToInt32(lbNow.Text));
    }
}
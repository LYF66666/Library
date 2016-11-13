using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSearch : System.Web.UI.Page
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
    }

    void DataBindToRepeater(int currentPage)
    {
        string sql = "select * from Book";
        DataTable dt = new DataTable();
        dt = classLogin.DataT(sql);
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 5;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage - 1;
        rptBook.DataSource = pds;
        rptBook.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string text = tbSearch.Text;
        string sql = "Select * from Book";
        if (text.Length == 0)
            sql = "Select * from Book";
        else
        {
            if (rbBookname.Checked == true)
                sql = "Select * from Book where bookname like N'%" + text + "%'";
            else if (rbAuthor.Checked == true)
                sql = "Select * from Book where author like N'%" + text + "%'";
            else if (rbType.Checked == true)
                sql = "Select * from Book where type = N'" + text + "'";
            else if (rbISBN .Checked == true)
                sql = "Select * from Book where ISBN = '" + text + "'";

        }
        int result = myLogin.Select(sql);
        if (result == 0)
            Response.Write("<script>alert('搜索无结果！')</script>");
        else
        {
            DataTable dt = new DataTable();
            dt = classLogin.DataT(sql);
            this.rptBook.DataSource = dt;
            this.rptBook.DataBind();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("BookAdd.aspx");
    }

    protected void rptBook_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            string ISBN = e.CommandArgument.ToString();
            string sql = "delete from Book where ISBN='" + ISBN + "'";
            classLogin.Save(sql);
            Response.Write("<script>alert('删除成功！');location='AdminSearch.aspx'</script>");
        }
    }



    protected void rbBookname_CheckedChanged(object sender, EventArgs e)
    {
        rbAuthor.Checked = false;
        rbType.Checked = false;
        rbISBN.Checked = false;
    }

    protected void rbAuthor_CheckedChanged(object sender, EventArgs e)
    {
        rbBookname.Checked = false;
        rbType.Checked = false;
        rbISBN.Checked = false;
    }

    protected void rbType_CheckedChanged(object sender, EventArgs e)
    {
        rbBookname.Checked = false;
        rbAuthor.Checked = false;
        rbISBN.Checked = false;
    }

    protected void rbISBN_CheckedChanged(object sender, EventArgs e)
    {
        rbBookname.Checked = false;
        rbAuthor.Checked = false;
        rbType.Checked = false;
    }

    protected void btnLogoff_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.aspx");
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookSearch : System.Web.UI.Page
{
    static classLogin myLogin = new classLogin();
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
        string sql="Select * from Book";
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
            else if (rbISBN.Checked == true)
                sql = "Select * from Book where ISBN = '" + text + "'";
           
        }
        int result = myLogin.Select(sql);
        if(result==0)
            Response.Write("<script>alert('搜索无结果！')</script>");
        else
        {
            DataTable dt = new DataTable();
            dt = classLogin.DataT(sql);
            this.rptBook.DataSource = dt;
            this.rptBook.DataBind();
        }
    }

    protected void rptBook_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Lend")
        {
            string ISBN = e.CommandArgument.ToString();
            string username = Session["username"].ToString();
            string sql1 = "select * from Book where ISBN='" + ISBN + "'";
            string sql2 = "select * from Users where username='" + username + "'";
            string sql = "select top 1 * from BookInformation where ISBN='" + ISBN + "'";
            DataTable dt = new DataTable();
            dt = classLogin.DataT(sql1);
            string id = classLogin.DataT(sql2).Rows[0][0].ToString();
            string bookname = dt.Rows[0][1].ToString();
            string author = dt.Rows[0][3].ToString();
            string type = dt.Rows[0][2].ToString();
            string time = DateTime.Now.ToString();
            string deadline = DateTime.Now.AddMinutes(3d).ToString();
            if (myLogin.Select(sql) == 0)
                Response.Write("<script>alert('该图书暂时无法借阅！')</script>");
            else
            {
                string bookid = classLogin.DataT(sql).Rows[0][0].ToString();
                int storage = Convert.ToInt32(dt.Rows[0][4].ToString());
                string sql6 = "select * from Record where username='" + username + "'";
                DataTable DT = new DataTable();
                DT = classLogin.DataT(sql6);
                int result = myLogin.Select(sql6);
                int i, leap = 1;
                if (result == 1)
                {
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        DateTime t1 = DateTime.Now;
                        DateTime t2 = DateTime.Parse(DT.Rows[i][7].ToString());
                        System.TimeSpan t3 = t1 - t2;
                        double getSeconds = t3.TotalSeconds;
                        if (getSeconds > 0)
                        {
                            leap = 0;
                            break;
                        }
                    }
                }
                else
                    leap = 1;
                if (leap != 1)
                    Response.Write("<script>alert('您有图书过期尚未归还，暂时无法借阅！')</script>");
                else
                {
                    string sql3 = "insert into Record values('" + id + "','" + username + "',N'" + bookname + "','" + bookid + "','" + ISBN + "',N'" + type + "','" + time + "','" + deadline + "')";
                    classLogin.Save(sql3);
                    string sql4 = "update Book set storage=storage-1 where ISBN='" + ISBN + "'";
                    classLogin.Save(sql4);
                    string sql5 = "delete from BookInformation where bookid='" + bookid + "'";
                    classLogin.Save(sql5);
                    Response.Write("<script>alert('借阅成功！');location='BookSearch.aspx'</script>");
                }
            }
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
        Response.Redirect("Welcome.aspx");
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
        if(Convert.ToInt32(lbNow.Text) + 1 > Convert.ToInt32(lbTotal.Text))
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
        if(int.TryParse(txtJump.Text,out i))
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
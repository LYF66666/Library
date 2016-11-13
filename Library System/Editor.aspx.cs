using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Editor : System.Web.UI.Page
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
            string ISBN = Request.QueryString["ISBN"];
            string sql = "select * from Book where ISBN='" + ISBN + "'";
            int result = myLogin.Select(sql);
            if (result == 1)
            {
                DataTable dt = new DataTable();
                dt = classLogin.DataT(sql);
                string bookname = dt.Rows[0][1].ToString();
                string type = dt.Rows[0][2].ToString();
                string author = dt.Rows[0][3].ToString();
                string storage = dt.Rows[0][4].ToString();
                string totalstorage = dt.Rows[0][5].ToString();
                tbBookname.Text = bookname;
                tbType.Text = type;
                tbAuthor.Text = author;
                tbTotal.Text = totalstorage;
            }
            else
                Response.Redirect("BookSearch.aspx");      
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string ISBN = Request.QueryString["ISBN"];
        string bookname = tbBookname.Text;
        string type = tbType.Text;
        string author = tbAuthor.Text;
        string totalstorage = tbTotal.Text;
        if (ISBN.Length == 0 || bookname.Length == 0 || type.Length == 0 || author.Length == 0 || totalstorage.Length == 0)
        {
            Response.Write("<script>alert('输入不能为空！');</script>");
        }
        else
        {
            string sql1 = "select * from Book where ISBN='" + ISBN + "'";
            int storage = Convert.ToInt32(classLogin.DataT(sql1).Rows[0][4].ToString());
            int m = Convert.ToInt32(classLogin.DataT(sql1).Rows[0][5].ToString());
            int n = Convert.ToInt32(totalstorage);
            int k = m - n;
            string sql2 = "Update Book set bookname=N'" + bookname + "',type=N'" + type + "',author=N'" + author + "',storage = storage - " + k + ",totalstorage='" + totalstorage + "' where ISBN='" + ISBN + "'";
            if (n < 0)
                Response.Write("<script>alert('请输入正确的数量！')</script>");
            else
            {
                if (n > m)
                {
                    int i;
                    string sql3;
                    for (i = m; i < n; i++)
                    {
                        sql3 = "insert into BookInformation values('" + ISBN + "" + i + "',N'" + bookname + "','" + ISBN + "')";
                        classLogin.Save(sql3);
                    }
                }
                else if (n < m)
                {
                    string sql4 = "select * from BookInformation where ISBN='" + ISBN + "' order by bookid desc";
                    int i;
                    for (i = 0; i < k; i++)
                    {
                        string id = classLogin.DataT(sql4).Rows[i][0].ToString();
                        string sql5 = "delete from BookInformation where bookid='" + id + "'";
                        classLogin.Save(sql5);
                    }
                }
                classLogin.Save(sql2);
                Response.Write("<script>alert('修改成功！');location='AdminSearch.aspx'</script>");
            }
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminSearch.aspx");
    }
}
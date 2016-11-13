using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookAdd : System.Web.UI.Page
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
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string ISBN = tbISBN.Text;
        string bookname = tbBookname.Text;
        string type = tbType.Text;
        string author = tbAuthor.Text;
        string totalstorage = tbTotal.Text;
        string sql1 = "select * from Book where ISBN='" + ISBN + "'";
        string sql2 = "select * from Type where type=N'" + type + "'";
        int result = 0;
        result = myLogin.Select(sql1);
        if (ISBN.Length == 0 || bookname.Length == 0 || type.Length == 0 || author.Length == 0 || totalstorage.Length == 0 )
            Response.Write("<script>alert('输入不能为空！')</script>");
        else if (myLogin.Select(sql1) == 1)
            Response.Write("<script>alert('该ISBN已被添加！')</script>");
        else if(Convert.ToInt32(totalstorage) < 0)
            Response.Write("<script>alert('请输入正确的数量！')</script>");
        else
        {           
            if (myLogin.Select(sql2) == 1)
            {                
                string sql5 = "update Type set amount = amount + 1 where type=N'" + type + "'";
                classLogin.Save(sql5);
            }
            else
            {
                string sql6 = "insert into Type values(N'" + type + "','1')";
                classLogin.Save(sql6);
            }
            string sql3 = "insert into Book values('" + ISBN + "',N'" + bookname + "',N'" + type + "',N'" + author + "','" + totalstorage + "','" + totalstorage + "')";
            classLogin.Save(sql3);
            int i;
            string sql4;
            for (i = 0; i < Convert.ToInt32(totalstorage); i++)
            {
                sql4 = "insert into BookInformation values('" + ISBN + ""+i+"',N'" + bookname + "','" + ISBN + "')";
                classLogin.Save(sql4);
            }
            Response.Write("<script>alert('添加成功！');location='AdminSearch.aspx'</script>");
        }      
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminSearch.aspx");
    }
}
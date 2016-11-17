using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Class1 的摘要说明
/// </summary>
public class classLogin
{
    private static string str = @"server=(localdb)\v11.0;Integrated Security=SSPI;database=Library;";
    public classLogin()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static void Save(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public static int Select(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        System.Data.DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        int count = dt.Rows.Count, result = 0;
        if (count > 0)
            result = 1;
        else
            result = 0;
        conn.Close();
        return result;
    }



    public static DataTable DataT(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        System.Data.DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        return dt;
    }


    //发送邮件
    public static void Sends(string email, string formto, string content, string body, string upass)
    {
        string name = "wewq8987@126.com";
        string smtp = "smtp.126.com";
        int port = 25;
        SmtpClient _smtpClient = new SmtpClient();
        _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
        _smtpClient.Host = smtp; //指定SMTP服务器
        _smtpClient.Port = port;
        _smtpClient.Credentials = new System.Net.NetworkCredential(name, upass);//用户名和密码
        MailMessage _mailMessage = new MailMessage();//发件人，发件人名
        _mailMessage.From = new MailAddress(formto, "图书馆");//收件人 
        _mailMessage.To.Add(email);
        _mailMessage.SubjectEncoding = System.Text.Encoding.GetEncoding("gb2312");
        _mailMessage.Subject = content;//主题
        _mailMessage.Body = body;//内容
        _mailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("gb2312");//正文编码
        _mailMessage.IsBodyHtml = true;//设置为HTML格式
        _mailMessage.Priority = MailPriority.High;//优先级
        try
        {
            _smtpClient.Send(_mailMessage);
        }
        catch (Exception)
        {

        }
    }

}
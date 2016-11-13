using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer t = new System.Timers.Timer(1000);   //实例化Timer类，设置间隔时间为10000毫秒； 
            t.Elapsed += new System.Timers.ElapsedEventHandler(ontime); //到达时间的时候执行事件；   
            t.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
            t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件； 
            System.Timers.Timer T = new System.Timers.Timer(1000);
            T.Elapsed += new System.Timers.ElapsedEventHandler(getfine);    
            T.AutoReset = true; 
            T.Enabled = true;
            for (;;);
        }

        public static void ontime(object source, System.Timers.ElapsedEventArgs e)
        {
            string sql1 = "select * from Record";
            DataTable dt = new DataTable();
            dt = classLogin.DataT(sql1);
            int i;
            for(i=0;i<dt.Rows.Count;i++)
            {
                string deadline = dt.Rows[i][7].ToString();
                DateTime t1 = DateTime.Now;
                DateTime t2 = DateTime.Parse(deadline);
                System.TimeSpan t3 = t2 - t1;
                double getMinute = t3.TotalMinutes;
                if(getMinute == 1 )
                {
                    string username = dt.Rows[i][1].ToString();
                    string bookname= dt.Rows[i][2].ToString();
                    string bookid= dt.Rows[i][3].ToString();
                    string sql2 = "select * from Users where username='" + username + "'";
                    string email = classLogin.DataT(sql2).Rows[0][5].ToString();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("亲爱的" + username + "您好：<br/><br/>");
                    sb.Append("您借阅的图书《" + bookname + "》即将到期，请及时归还！<br/><br/>");
                    string MessageBody = sb.ToString();
                    string sql = "select * from Record where bookid='" + bookid + "'";
                    if (classLogin.Select(sql) != 0)
                        classLogin.Sends(email, "wewq8987@126.com", "图书馆借阅到期提醒", MessageBody, "zzxiaofang123");
                }
            }
        }

        public static void getfine(object source, System.Timers.ElapsedEventArgs e)
        {
            string sql1 = "select * from Record";
            DataTable dt = new DataTable();
            dt = classLogin.DataT(sql1);
            int i;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                string deadline = dt.Rows[i][7].ToString();
                DateTime t1 = DateTime.Now;
                DateTime t2 = DateTime.Parse(deadline);
                System.TimeSpan t3 = t1 - t2;
                double getMinute = t3.TotalMinutes;
                if (getMinute > 0)
                {
                    string username = dt.Rows[i][1].ToString();
                    string sql2 = "select * from Users where username='" + username + "'";
                    string originalfine = classLogin.DataT(sql2).Rows[0][8].ToString();
                    int fine = (int)getMinute * 2;
                    if (fine > 0)
                    {
                        string updatesql = "update Users set fine= '" + originalfine + "' + " + fine + " where username ='" + username + "' ";
                        classLogin.Save(updatesql);
                    }
                }
            }
        }
    }
}

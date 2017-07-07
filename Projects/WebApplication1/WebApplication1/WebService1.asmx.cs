using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net;
using mail = System.Net.Mail;
using my = MySql.Data;


namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://SampleWebApp1.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {


        public class Stock
        {
            public string stockTicker;
            public double price;

            public Stock(string stockTicker, double price)
            {
                this.stockTicker = stockTicker;
                this.price = price;
            }

            public Stock()
            {
                this.stockTicker = "";
                this.price = 0.0;
            }
            public override string ToString(){
                return stockTicker + " " + price;
            }

        }

        public my.MySqlClient.MySqlConnection connectToDatabase()
        {

            my.MySqlClient.MySqlConnection conn = null;

            string strConnectionString = "Server=localhost;Database=test;Uid=root;Pwd=1234;";

            conn = new my.MySqlClient.MySqlConnection(strConnectionString);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return conn;
        }

        public List<Stock> LocalSetupGet(my.MySqlClient.MySqlConnection conn)
        {
            string strQuery = String.Empty;

            List<Stock> results = new List<Stock>();

            strQuery = string.Format("SELECT stockName, currentPrice from test.sampledata");

            my.MySqlClient.MySqlCommand cmd = new my.MySqlClient.MySqlCommand(strQuery, conn);

            my.MySqlClient.MySqlDataReader myReader = null;

            try
            {
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    int n = 0;
                    Stock result = new Stock();
                    result.stockTicker = myReader.GetString(n);
                    result.price = myReader.GetDouble(n+1);
                    results.Add(result);
                    n = n + 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            if (myReader != null)
            {
                if (myReader.IsClosed == false)
                {
                    myReader.Close();
                    myReader.Dispose();
                }
            }

            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return results;
        }

        public void LocalSetupInsert(my.MySqlClient.MySqlConnection conn)
        {
            string strQuery = String.Empty;

            Stock Microsoft = new Stock();

            strQuery = string.Format("INSERT INTO `test`.`sampledata` (`StockName`, `currentPrice`) VALUES ('MSFT', '902.10')");

            my.MySqlClient.MySqlCommand cmd = new my.MySqlClient.MySqlCommand(strQuery, conn);
            try
            {
              //cmd.Parameters.AddWithValue("@STOCKNAME", "MSFT");
              //cmd.Parameters.AddWithValue("@CURRENTPRICE", 69.41);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void LocalSetupDelete(my.MySqlClient.MySqlConnection conn)
        {
            string strQuery = String.Empty;

            strQuery = string.Format("DELETE FROM test.sampledata WHERE StockName = 'FAKE'");

            my.MySqlClient.MySqlCommand cmd = new my.MySqlClient.MySqlCommand(strQuery, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        [WebMethod]
        public List<Stock> printSQLTable()
        {
            List<Stock> empty = new List<Stock>();
            my.MySqlClient.MySqlConnection conn = connectToDatabase();
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    LocalSetupInsert(conn);
                    LocalSetupDelete(conn);
                    return LocalSetupGet(conn);
                }
            }
            return empty;
        }

        private void send_email(object sender, EventArgs e)
        {
            try
            {
                mail.MailMessage message;
                mail.SmtpClient smtp;
                message = new mail.MailMessage("aluthra1@pride.hofstra.edu", "aluthra1@pride.hofstra.edu", "Test", "Sample Body");
                mail.Attachment att1 = new mail.Attachment(@"C:\Users\fcs-bithub1\Documents\Hello.txt");
                //mail.Attachment att2 = new mail.Attachment(@"C:\Users\fcs-bithub1\Documents\Hello.txt");
                //mail.Attachment att3 = new mail.Attachment(@"C:\Users\fcs-bithub1\Documents\Hello.txt");
                message.Attachments.Add(att1);
                //message.Attachments.Add(att2);
                //message.Attachments.Add(att3);

                //----------------------------------------------------------------
                //SMTP INFORMATION

                smtp = new mail.SmtpClient("mta.hofstra.edu");
                smtp.Send(message);
                smtp.Dispose();
                
                Console.WriteLine("Report Has Been Sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




    }
}

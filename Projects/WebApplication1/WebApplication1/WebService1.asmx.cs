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
        String filepath = @"C:\bithubReports\report.txt"; //FilePath for report
        
        public my.MySqlClient.MySqlConnection connectToDatabase()
        {

            my.MySqlClient.MySqlConnection conn = null;

            //string strConnectionString = "Server=147.4.3.31;Database=app_performance;Uid=app_performance_ws;Pwd=appperformancews;";
            string strConnectionString = "Server=localhost;Database=app_performance;Uid=root;Pwd=1234;";

            conn = new my.MySqlClient.MySqlConnection(strConnectionString);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message + "   ConnectToDatabase");
                //Console.WriteLine(ex.Message.ToString());
            }

            return conn;
        }

        
        public String LocalSetupGet(my.MySqlClient.MySqlConnection conn)
        {
            string strQuery = String.Empty;
     
            strQuery = string.Format("SELECT username, domain, ipaddress, computer_name, process_name, process_path, process_starttime, processid, process_description, process_exittime, version, productname, companyname, semester, process_path_commandline, sid, fullname, department, role, idactivity FROM app_performance.activity WHERE process_exittime BETWEEN '2016-10-06 11:00:30' AND '2016-11-09 20:21:30'");
 
            my.MySqlClient.MySqlCommand cmd = new my.MySqlClient.MySqlCommand(strQuery, conn);


            my.MySqlClient.MySqlDataReader myReader = null;
     


            try
            {
  
                myReader = cmd.ExecuteReader();
                int n = 0;

                try { 
                    System.IO.Directory.CreateDirectory(@"C:\bithubReports");
                } catch(Exception ex){
  
                    return ex.Message.ToString();
                }

                //var filepath = @"C:\bithubReports\report.txt";

                var csv = new System.Text.StringBuilder();
      

                while (myReader.Read())
                {

                    HttpContext.Current.Response.Write(myReader.GetString(0) + "\n");
                    string result = "";
                    string name, domain, ip, cpu, proc, procPath, procStart, procID, procDesc, procExit, v, pName, cName, sem, ppcl, sid, fName, dep, role, id;
                    if (myReader.IsDBNull(0))
                    {
                        name = " ";
                    } else {
                        name = String.Format("{0}", myReader.GetString(0));
                    }
                    if (myReader.IsDBNull(1))
                    {
                        domain = " ";
                    }
                    else
                    {
                        domain = String.Format("{0}", myReader.GetString(1));
                    }
                    if (myReader.IsDBNull(2))
                    {
                        ip = " ";
                    }
                    else
                    {
                        ip = String.Format("{0}", myReader.GetString(2));
                    }
                    if (myReader.IsDBNull(3))
                    {
                        cpu = " ";
                    }
                    else
                    {
                        cpu = String.Format("{0}", myReader.GetString(3));
                    }
                    if (myReader.IsDBNull(4))
                    {
                        proc = " ";
                    }
                    else
                    {
                        proc = String.Format("{0}", myReader.GetString(4));
                    }
                    if (myReader.IsDBNull(5))
                    {
                        procPath = " ";
                    }
                    else
                    {
                        procPath = String.Format("{0}", myReader.GetString(5));
                    }
                    if (myReader.IsDBNull(6))
                    {
                        procStart = " ";
                    }
                    else
                    {
                        procStart = String.Format("{0}", myReader.GetDateTime(6));
                    }
                    if (myReader.IsDBNull(7))
                    {
                        procID = " ";
                    }
                    else
                    {
                        procID = String.Format("{0}", myReader.GetInt64(7));
                    }
                    if (myReader.IsDBNull(8))
                    {
                        procDesc = " ";
                    }
                    else
                    {
                        procDesc = String.Format("{0}", myReader.GetString(8));
                    }
                    if (myReader.IsDBNull(9))
                    {
                        procExit = " ";
                    }
                    else
                    {
                        procExit = String.Format("{0}", myReader.GetDateTime(9));
                    }
                    if (myReader.IsDBNull(10))
                    {
                        v = " ";
                    }
                    else
                    {
                        v = String.Format("{0}", myReader.GetString(10));
                    }
                    if (myReader.IsDBNull(11))
                    {
                        pName = " ";
                    }
                    else
                    {
                        pName = String.Format("{0}", myReader.GetString(11));
                    }
                    if (myReader.IsDBNull(12))
                    {
                        cName = " ";
                    }
                    else
                    {
                        cName = String.Format("{0}", myReader.GetString(12));
                    }
                    if (myReader.IsDBNull(13))
                    {
                        sem = " ";
                    }
                    else
                    {
                        sem = String.Format("{0}", myReader.GetString(13));
                    }
                    if (myReader.IsDBNull(14))
                    {
                        ppcl = " ";
                    }
                    else
                    {
                        ppcl = String.Format("{0}", myReader.GetString(14));
                    }
                    if (myReader.IsDBNull(15))
                    {
                        sid = " ";
                    }
                    else
                    {
                        sid = String.Format("{0}", myReader.GetString(15));
                    }
                    if (myReader.IsDBNull(16))
                    {
                        fName = " ";
                    }
                    else
                    {
                        fName = String.Format("{0}", myReader.GetString(16));
                    }
                    if (myReader.IsDBNull(17))
                    {
                        dep = " ";
                    }
                    else
                    {
                        dep = String.Format("{0}", myReader.GetString(17));
                    }
                    if (myReader.IsDBNull(18))
                    {
                        role = " ";
                    }
                    else
                    {
                        role = String.Format("{0}", myReader.GetString(18));
                    }
                    if (myReader.IsDBNull(19))
                    {
                        id = " ";
                    }
                    else
                    {
                        id = String.Format("{0}", myReader.GetString(19));
                    }
  
                    result = name + "," + domain + "," + ip + "," + cpu + "," + proc + "," + procPath + "," + procStart + "," + procID + "," + procDesc + "," + procExit + "," + v + "," + pName + "," + cName + "," + sem + "," + ppcl + "," + sid + "," + fName + "," + dep + "," + role + "," + id;

                    string line = result;

                    try{
                        csv.AppendLine(line);
                    } catch(Exception ex){
                        return ex.Message.ToString();
                    }
                    n = 0;
                }


                try{
                    System.IO.File.WriteAllText(filepath, csv.ToString());
                } catch (Exception ex){
                    return ex.Message.ToString();
                }
            }
            catch (Exception ex)
            {
                return(ex.Message.ToString());
            }

            try
            {
                String email = "aluthra1@pride.hofstra.edu";
                send_email(email);
            }
            catch (Exception ex)
            {
                return (ex.Message.ToString());
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
            HttpContext.Current.Response.Write("Success");
            return "Success";
            }
       
        
        public void LocalSetupInsert(my.MySqlClient.MySqlConnection conn) //alter for opscan
        {
            string strQuery = String.Empty;

            strQuery = string.Format("INSERT INTO app_performance.activity (username, domain, ipaddress, computer_name, process_name, process_path, process_starttime, processid, process_description, process_exittime, version, productname, companyname, semester, process_path_commandline, sid, fullname, department, role, idactivity) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}', '{7}', '{8}', '{9}', '{10}', '{11}','{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}')");

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
        public void OpScan()
        {
            my.MySqlClient.MySqlConnection conn = connectToDatabase();
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    LocalSetupGet(conn);
                }
            }
        }

        private void send_email(string to)
        {
            try
            {

                mail.MailMessage message;
                mail.SmtpClient smtp;
                message = new mail.MailMessage("aluthra1@pride.hofstra.edu", to, "OpScan Report", "Sample Body");
                mail.Attachment att1 = new mail.Attachment(filepath);
                //mail.Attachment att2 = new mail.Attachment(@"C:\Users\fcs-bithub1\Documents\Hello.txt");
                //mail.Attachment att3 = new mail.Attachment(@"C:\Users\fcs-bithub1\Documents\Hello.txt");
                message.Attachments.Add(att1);
                //message.Attachments.Add(att2);
                //message.Attachments.Add(att3);

                //----------------------------------------------------------------
                //SMTP INFORMATION

                smtp = new mail.SmtpClient("mta.hofstra.edu",23);
                smtp.Send(message);
                smtp.Dispose();

                Console.WriteLine("Report Has Been Sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void save_into_csv()
        {
            try
            {
                var filepath = "NULL"; //Add A filepath - parameter?
                var csv = new System.Text.StringBuilder();
                int count = 0;
                //csv.AppendLine(line);

                System.IO.File.WriteAllText(filepath, csv.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        private void add_read_send(object sender, EventArgs e)
        {
            try
            {
                //Connect to Database
                my.MySqlClient.MySqlConnection conn = connectToDatabase();

                //Add Data to table using LocalSetupInsert - needs altering
                LocalSetupInsert(conn);

                //Read Data from table using LocalSetupGet
                LocalSetupGet(conn);

                //Save data into csv file
                //save_into_csv(results); 

                //close connection to table
                if (conn != null)
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }

                //call send_email function
                send_email("Bob.Khatami@Hofstra.edu");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

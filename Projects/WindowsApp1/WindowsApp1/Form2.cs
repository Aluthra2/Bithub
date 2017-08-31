using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using mail = System.Net.Mail;

namespace WindowsApp1
{
    public partial class InitialView : Form
    {   
        public InitialView()
        {
            InitializeComponent();
            setFromCustomFormat();
            setToCustomFormat();
        }

        private void btn_Setup_Click(object sender, EventArgs e)
        {
            AddressBook adressbook = new AddressBook();
            adressbook.ShowDialog();
            adressbook.Dispose();
        }

        private void btn_SendReport_Click(object sender, EventArgs e)
        {
            String filepath = @"C:\bithubReports\Report.txt";

            try
            {
                mail.MailMessage message;
                mail.SmtpClient smtp;
                message = new mail.MailMessage("aluthra1@pride.hofstra.edu", "aluthra1@pride.hofstra.edu", "OpScan Report", "Sample Body");
                mail.Attachment att1 = new mail.Attachment(filepath);
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
                this.Close();
                MessageBox.Show("Report Has Been Sent!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setFromCustomFormat()
        {
            d_From.Format = DateTimePickerFormat.Custom;
            d_From.CustomFormat = "MM-dd-yyyy";

        }

        private void setToCustomFormat()
        {
            d_To.Format = DateTimePickerFormat.Custom;
            d_To.CustomFormat = "MM-dd-yyyy";

        }

        private void d_From_ValueChanged(object sender, EventArgs e)
        {
            string strTest = string.Empty;

            string strTest1 = d_From.Value.Date.Year.ToString();
            string strTest2 = d_From.Value.Date.Month.ToString();
            string strTest3 = d_From.Value.Date.Day.ToString();

            string strTest4 = d_From.Value.ToString("yyyy-MM-dd");

            MessageBox.Show(strTest4);
            //MessageBox.Show(strTest2);
            //MessageBox.Show(strTest3);


            Console.WriteLine(d_From);
        }

        private void d_To_ValueChanged(object sender, EventArgs e)
        {
            string strTest = string.Empty;

            string strTest1 = d_To.Value.Date.Year.ToString();
            string strTest2 = d_To.Value.Date.Month.ToString();
            string strTest3 = d_To.Value.Date.Day.ToString();

            string strTest4 = d_To.Value.ToString("yyyy-MM-dd");

            MessageBox.Show(strTest4);
            //MessageBox.Show(strTest2);
            //MessageBox.Show(strTest3);


            Console.WriteLine(d_To);
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {

        }
    }
}

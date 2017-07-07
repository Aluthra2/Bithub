using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApp1
{
    public partial class AddressBook : Form
    {
        public AddressBook()
        {
            InitializeComponent();
        }

        public String InsertWildCard(string invalue)
        {
            return invalue.Replace(" ", "*");
        }

        public string ADOnDisplayNameAliasGet2(string inUserName)
        {
            string DisplayName = "";

            string searchType = searchType = "(sAMAccountName= *";

            DirectorySearcher searcher = new DirectorySearcher(searchType + inUserName.ToUpper() + "*)");

            searcher.Sort.Direction = System.DirectoryServices.SortDirection.Descending;

            SearchResultCollection coll = null;

            try
            {
                searcher.FindAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (coll == null)
                return "Could not resolve name " + inUserName;

            for (int i = 0; i < coll.Count; i++)
            {
                try { DisplayName = coll[i].Properties["DisplayName"][0].ToString(); }
                catch (Exception ex) { ex.Message.ToString(); DisplayName = " "; };
            }

            return DisplayName;
        }


        /*private void TestFunc()
        {
            int nCount = 1;

            PrincipalContext ctx = new PrincipalContext(ContextType.Machine);

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "employees"))
            {
                using (PrincipalSearcher searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    foreach (var result in searcher.FindAll())
                    {
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        //Console.WriteLine("SAM account name   : " + de.Properties["samAccountName"].Value);

                        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, de.Properties["samAccountName"].Value.ToString());
                        if (user != null)
                        {
                            string displayName = user.DisplayName;
                            if (displayName != null)
                                MessageBox.Show(displayName);
                                //listBox1.Items.Add(displayName);

                            if (nCount == 20)
                                return;

                            nCount++;

                            //MessageBox.Show(user.BadLogonCount.ToString());
                            if (user.IsAccountLockedOut())
                            {
                                // do something here....   
                                MessageBox.Show("Yes");
                            }
                        }
                    }
                }
            }
            // find a user
        }
        */

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                UseWaitCursor = true;
                lvAddressBook.Items.Clear();

                string inSearchType = cbSearchType.Text;// "DISPLAY NAME";
                string searchType = "";
                string inUserName = txtSearch.Text;
                string outCount = "";

                if (inSearchType.ToUpper().CompareTo("DISPLAY NAME") == 0)
                {
                    string strRet = InsertWildCard(inUserName);
                    inUserName = strRet;
                    searchType = "(displayName= *";
                }
                else if (inSearchType.ToUpper().CompareTo("NETWORK ID") == 0)
                    searchType = "(sAMAccountName= *";
                else if (inSearchType.ToUpper().CompareTo("FIRST NAME") == 0)
                    searchType = "(givenName= *";
                else if (inSearchType.ToUpper().CompareTo("LAST NAME") == 0)
                    searchType = "(sn= *";
                else if (inSearchType.ToUpper().CompareTo("EMPLOYEE ID") == 0)
                    searchType = "(hofEmployeeID= *";
                else if (inSearchType.ToUpper().CompareTo("TITLE") == 0)
                    searchType = "(title= *";
                else if (inSearchType.ToUpper().CompareTo("DEPARTMENT") == 0)
                    searchType = "(department= *";
                else if (inSearchType.ToUpper().CompareTo("EMAIL") == 0)
                    searchType = "(mail= *";
                else if (inSearchType.ToUpper().CompareTo("POSITION") == 0)
                {
                    inUserName.ToUpper();
                    searchType = "(hofPosition= *";
                }

                //DirectoryEntry de = new DirectoryEntry(null, "Employees");


                DirectorySearcher searcher = new DirectorySearcher( searchType + inUserName.ToUpper() + "*)");

                searcher.Sort.Direction = System.DirectoryServices.SortDirection.Descending;

                SearchResultCollection coll = searcher.FindAll();

                outCount = coll.Count.ToString();

                if (coll == null)
                    return;// "Could not resolve name " + inUserName;

                string displayname, alias, phone, office, email, title, department, empid, hofposition;
                for (int i = 0; i < coll.Count; i++)
                {
                    try { displayname = coll[i].Properties["displayName"][0].ToString(); }
                    catch (Exception ex) { ex.Message.ToString(); displayname = " "; };

                    try { alias = coll[i].Properties["sAMAccountName"][0].ToString(); }
                    catch (Exception ex) { ex.Message.ToString(); alias = " "; };

                    try { title = coll[i].Properties["title"][0].ToString(); }
                    catch (Exception ex) { ex.Message.ToString(); title = " "; };

                    try { email = coll[i].Properties["mail"][0].ToString(); }
                    catch (Exception ex) { ex.Message.ToString(); email = " "; };

                    try { office = coll[i].Properties["physicalDeliveryOfficeName"][0].ToString(); }
                    catch (Exception ex) { ex.Message.ToString(); office = " "; };

                    try { department = coll[i].Properties["Department"][0].ToString(); }
                    catch (Exception ex) { ex.Message.ToString(); department = " "; };

                    try { phone = coll[i].Properties["telephoneNumber"][0].ToString(); }
                    catch (Exception ex) { ex.Message.ToString(); phone = " "; };

                    try { empid = coll[i].Properties["hofEmployeeId"][0].ToString(); }
                    catch (Exception ex) { ex.Message.ToString(); empid = " "; };

                    try { hofposition = coll[i].Properties["hofPosition"][0].ToString(); }
                    catch (Exception ex) { ex.Message.ToString(); hofposition = " "; };

                    ListViewItem lv = lvAddressBook.Items.Add(displayname);
                    lv.SubItems.Add(email);
                    lv.SubItems.Add(department);
                    lv.SubItems.Add(title);
                    lv.SubItems.Add(phone);
                    lv.SubItems.Add(office);
                    lv.SubItems.Add(alias);
                    lv.SubItems.Add(hofposition);

                    //if(i % 2 == 0)
                    //    lv.SubItems[0].BackColor = Color.Aqua;
                }
            }
            catch (Exception ex)
            {
                UseWaitCursor = false;
                Console.WriteLine("EXCEPTION " + ex.Message);
            }
            UseWaitCursor = false;
        }

        private void AddressBook_Load(object sender, EventArgs e)
        {
            //ADOnDisplayNameAliasGet2("fcsbzk");

            //TestFunc();

            cbSearchType.Items.Add("Display Name");
            cbSearchType.Items.Add("Network ID");
            cbSearchType.Items.Add("First Name");
            cbSearchType.Items.Add("Last Name");
            cbSearchType.Items.Add("Employee ID");
            cbSearchType.Items.Add("Title");
            cbSearchType.Items.Add("Email");
            cbSearchType.Items.Add("Position");

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
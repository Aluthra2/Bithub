namespace WindowsApp1
{
    partial class AddressBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvAddressBook = new System.Windows.Forms.ListView();
            this.cbSearchType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(13, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(209, 93);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvAddressBook
            // 
            this.lvAddressBook.Location = new System.Drawing.Point(13, 111);
            this.lvAddressBook.Name = "lvAddressBook";
            this.lvAddressBook.Size = new System.Drawing.Size(894, 384);
            this.lvAddressBook.TabIndex = 4;
            this.lvAddressBook.UseCompatibleStateImageBehavior = false;
            // 
            // cbSearchType
            // 
            this.cbSearchType.FormattingEnabled = true;
            this.cbSearchType.Location = new System.Drawing.Point(228, 12);
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.Size = new System.Drawing.Size(464, 33);
            this.cbSearchType.TabIndex = 5;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(228, 60);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(464, 31);
            this.txtSearch.TabIndex = 6;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(698, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(209, 93);
            this.btn_Close.TabIndex = 7;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // AddressBook
            // 
            this.ClientSize = new System.Drawing.Size(919, 504);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearchType);
            this.Controls.Add(this.lvAddressBook);
            this.Controls.Add(this.btnSearch);
            this.Name = "AddressBook";
            this.Text = "Address Book";
            this.Load += new System.EventHandler(this.AddressBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvAddressBook;
        private System.Windows.Forms.ComboBox cbSearchType;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btn_Close;
    }
}


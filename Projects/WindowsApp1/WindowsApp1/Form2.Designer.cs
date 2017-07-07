namespace WindowsApp1
{
    partial class InitialView
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
            this.btn_Setup = new System.Windows.Forms.Button();
            this.btn_SendReport = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.list_Results = new System.Windows.Forms.ListView();
            this.d_From = new System.Windows.Forms.DateTimePicker();
            this.lbl_From = new System.Windows.Forms.Label();
            this.d_To = new System.Windows.Forms.DateTimePicker();
            this.lbl_To = new System.Windows.Forms.Label();
            this.btn_Go = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Setup
            // 
            this.btn_Setup.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Setup.Location = new System.Drawing.Point(13, 13);
            this.btn_Setup.Name = "btn_Setup";
            this.btn_Setup.Size = new System.Drawing.Size(164, 72);
            this.btn_Setup.TabIndex = 0;
            this.btn_Setup.Text = "Setup...";
            this.btn_Setup.UseVisualStyleBackColor = false;
            this.btn_Setup.Click += new System.EventHandler(this.btn_Setup_Click);
            // 
            // btn_SendReport
            // 
            this.btn_SendReport.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SendReport.Location = new System.Drawing.Point(183, 13);
            this.btn_SendReport.Name = "btn_SendReport";
            this.btn_SendReport.Size = new System.Drawing.Size(165, 73);
            this.btn_SendReport.TabIndex = 1;
            this.btn_SendReport.Text = "Send Report";
            this.btn_SendReport.UseVisualStyleBackColor = false;
            this.btn_SendReport.Click += new System.EventHandler(this.btn_SendReport_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Close.Location = new System.Drawing.Point(729, 14);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(165, 72);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // list_Results
            // 
            this.list_Results.Location = new System.Drawing.Point(13, 184);
            this.list_Results.Name = "list_Results";
            this.list_Results.Size = new System.Drawing.Size(881, 429);
            this.list_Results.TabIndex = 3;
            this.list_Results.UseCompatibleStateImageBehavior = false;
            // 
            // d_From
            // 
            this.d_From.CustomFormat = "MM-dd-yyyy";
            this.d_From.Location = new System.Drawing.Point(88, 116);
            this.d_From.Name = "d_From";
            this.d_From.Size = new System.Drawing.Size(188, 31);
            this.d_From.TabIndex = 4;
            this.d_From.ValueChanged += new System.EventHandler(this.d_From_ValueChanged);
            // 
            // lbl_From
            // 
            this.lbl_From.AutoSize = true;
            this.lbl_From.Location = new System.Drawing.Point(21, 116);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(61, 25);
            this.lbl_From.TabIndex = 5;
            this.lbl_From.Text = "From";
            // 
            // d_To
            // 
            this.d_To.CustomFormat = "MM-dd-yyyy";
            this.d_To.Location = new System.Drawing.Point(423, 116);
            this.d_To.Name = "d_To";
            this.d_To.Size = new System.Drawing.Size(188, 31);
            this.d_To.TabIndex = 6;
            this.d_To.ValueChanged += new System.EventHandler(this.d_To_ValueChanged);
            // 
            // lbl_To
            // 
            this.lbl_To.AutoSize = true;
            this.lbl_To.Location = new System.Drawing.Point(380, 116);
            this.lbl_To.Name = "lbl_To";
            this.lbl_To.Size = new System.Drawing.Size(37, 25);
            this.lbl_To.TabIndex = 7;
            this.lbl_To.Text = "To";
            // 
            // btn_Go
            // 
            this.btn_Go.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Go.Location = new System.Drawing.Point(729, 92);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(165, 73);
            this.btn_Go.TabIndex = 8;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = false;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // InitialView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(906, 625);
            this.Controls.Add(this.btn_Go);
            this.Controls.Add(this.lbl_To);
            this.Controls.Add(this.d_To);
            this.Controls.Add(this.lbl_From);
            this.Controls.Add(this.d_From);
            this.Controls.Add(this.list_Results);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_SendReport);
            this.Controls.Add(this.btn_Setup);
            this.Name = "InitialView";
            this.Text = "Report Program";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Setup;
        private System.Windows.Forms.Button btn_SendReport;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ListView list_Results;
        private System.Windows.Forms.DateTimePicker d_From;
        private System.Windows.Forms.Label lbl_From;
        private System.Windows.Forms.DateTimePicker d_To;
        private System.Windows.Forms.Label lbl_To;
        private System.Windows.Forms.Button btn_Go;
    }
}
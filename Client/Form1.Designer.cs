namespace Client
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.ticketUserControl1 = new TicketLibrary.TicketUserControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NameTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(91, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 65);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Disconnected";
            // 
            // NameTxt
            // 
            this.NameTxt.Location = new System.Drawing.Point(54, 31);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(38, 20);
            this.NameTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(0, 12);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(85, 48);
            this.ConnectBtn.TabIndex = 3;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // ticketUserControl1
            // 
            this.ticketUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ticketUserControl1.Location = new System.Drawing.Point(0, 70);
            this.ticketUserControl1.Name = "ticketUserControl1";
            this.ticketUserControl1.Size = new System.Drawing.Size(210, 126);
            this.ticketUserControl1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 208);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.ticketUserControl1);
            this.Name = "Form1";
            this.Text = "TicTacToe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TicketLibrary.TicketUserControl ticketUserControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Timer timer1;
    }
}


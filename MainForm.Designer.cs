namespace UCCPSample
{
    partial class MainForm
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonClickIM = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.textBoxIM = new System.Windows.Forms.TextBox();
            this.groupBoxIM = new System.Windows.Forms.GroupBox();
            this.buttonEndIM = new System.Windows.Forms.Button();
            this.groupBoxVoIP = new System.Windows.Forms.GroupBox();
            this.buttonEndCall = new System.Windows.Forms.Button();
            this.buttonClickCall = new System.Windows.Forms.Button();
            this.textBoxIMInput = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBoxIM.SuspendLayout();
            this.groupBoxVoIP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(109, 25);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(116, 23);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(286, 25);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(116, 23);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonClickIM
            // 
            this.buttonClickIM.Enabled = false;
            this.buttonClickIM.Location = new System.Drawing.Point(23, 29);
            this.buttonClickIM.Name = "buttonClickIM";
            this.buttonClickIM.Size = new System.Drawing.Size(116, 24);
            this.buttonClickIM.TabIndex = 2;
            this.buttonClickIM.Text = "Click to IM";
            this.buttonClickIM.UseVisualStyleBackColor = true;
            this.buttonClickIM.Click += new System.EventHandler(this.buttonClickIM_Click);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.AllowDrop = true;
            this.textBoxInfo.Location = new System.Drawing.Point(212, 73);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ReadOnly = true;
            this.textBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInfo.Size = new System.Drawing.Size(272, 101);
            this.textBoxInfo.TabIndex = 6;
            // 
            // textBoxIM
            // 
            this.textBoxIM.Location = new System.Drawing.Point(212, 180);
            this.textBoxIM.Multiline = true;
            this.textBoxIM.Name = "textBoxIM";
            this.textBoxIM.ReadOnly = true;
            this.textBoxIM.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxIM.Size = new System.Drawing.Size(272, 155);
            this.textBoxIM.TabIndex = 7;
            // 
            // groupBoxIM
            // 
            this.groupBoxIM.Controls.Add(this.buttonEndIM);
            this.groupBoxIM.Controls.Add(this.buttonClickIM);
            this.groupBoxIM.Location = new System.Drawing.Point(12, 87);
            this.groupBoxIM.Name = "groupBoxIM";
            this.groupBoxIM.Size = new System.Drawing.Size(168, 114);
            this.groupBoxIM.TabIndex = 8;
            this.groupBoxIM.TabStop = false;
            this.groupBoxIM.Text = "IM";
            // 
            // buttonEndIM
            // 
            this.buttonEndIM.Enabled = false;
            this.buttonEndIM.Location = new System.Drawing.Point(23, 74);
            this.buttonEndIM.Name = "buttonEndIM";
            this.buttonEndIM.Size = new System.Drawing.Size(116, 23);
            this.buttonEndIM.TabIndex = 4;
            this.buttonEndIM.Text = "End IM";
            this.buttonEndIM.UseVisualStyleBackColor = true;
            this.buttonEndIM.Click += new System.EventHandler(this.buttonEndIM_Click);
            // 
            // groupBoxVoIP
            // 
            this.groupBoxVoIP.Controls.Add(this.buttonEndCall);
            this.groupBoxVoIP.Controls.Add(this.buttonClickCall);
            this.groupBoxVoIP.Location = new System.Drawing.Point(12, 210);
            this.groupBoxVoIP.Name = "groupBoxVoIP";
            this.groupBoxVoIP.Size = new System.Drawing.Size(168, 125);
            this.groupBoxVoIP.TabIndex = 9;
            this.groupBoxVoIP.TabStop = false;
            this.groupBoxVoIP.Text = "VoIP";
            // 
            // buttonEndCall
            // 
            this.buttonEndCall.Enabled = false;
            this.buttonEndCall.Location = new System.Drawing.Point(23, 79);
            this.buttonEndCall.Name = "buttonEndCall";
            this.buttonEndCall.Size = new System.Drawing.Size(116, 24);
            this.buttonEndCall.TabIndex = 1;
            this.buttonEndCall.Text = "End Call";
            this.buttonEndCall.UseVisualStyleBackColor = true;
            this.buttonEndCall.Click += new System.EventHandler(this.buttonEndCall_Click);
            // 
            // buttonClickCall
            // 
            this.buttonClickCall.Enabled = false;
            this.buttonClickCall.Location = new System.Drawing.Point(23, 31);
            this.buttonClickCall.Name = "buttonClickCall";
            this.buttonClickCall.Size = new System.Drawing.Size(116, 24);
            this.buttonClickCall.TabIndex = 0;
            this.buttonClickCall.Text = "Click to Call";
            this.buttonClickCall.UseVisualStyleBackColor = true;
            this.buttonClickCall.Click += new System.EventHandler(this.buttonClickCall_Click);
            // 
            // textBoxIMInput
            // 
            this.textBoxIMInput.AcceptsReturn = true;
            this.textBoxIMInput.Location = new System.Drawing.Point(212, 329);
            this.textBoxIMInput.Multiline = true;
            this.textBoxIMInput.Name = "textBoxIMInput";
            this.textBoxIMInput.ReadOnly = true;
            this.textBoxIMInput.Size = new System.Drawing.Size(272, 54);
            this.textBoxIMInput.TabIndex = 11;
            this.textBoxIMInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxIMInput_KeyUp);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10000;
            this.trackBar1.Location = new System.Drawing.Point(151, 341);
            this.trackBar1.Maximum = 65535;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(251, 45);
            this.trackBar1.SmallChange = 100;
            this.trackBar1.TabIndex = 12;
            this.trackBar1.TickFrequency = 1000;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 395);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.textBoxIMInput);
            this.Controls.Add(this.groupBoxVoIP);
            this.Controls.Add(this.groupBoxIM);
            this.Controls.Add(this.textBoxIM);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonLogin);
            this.Name = "MainForm";
            this.Text = "IM and VoIP Sample";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxIM.ResumeLayout(false);
            this.groupBoxVoIP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonClickIM;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.TextBox textBoxIM;
        private System.Windows.Forms.GroupBox groupBoxIM;
        private System.Windows.Forms.GroupBox groupBoxVoIP;
        private System.Windows.Forms.Button buttonEndCall;
        private System.Windows.Forms.Button buttonClickCall;
        private System.Windows.Forms.TextBox textBoxIMInput;
        private System.Windows.Forms.Button buttonEndIM;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}


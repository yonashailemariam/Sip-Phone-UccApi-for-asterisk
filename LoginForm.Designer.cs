namespace UCCPSample
{
    partial class LoginForm
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
            this.textBoxSignInName = new System.Windows.Forms.TextBox();
            this.textBoxServerName = new System.Windows.Forms.TextBox();
            this.labelSignInName = new System.Windows.Forms.Label();
            this.labelServer = new System.Windows.Forms.Label();
            this.labelConnectUsing = new System.Windows.Forms.Label();
            this.radioButtonTCP = new System.Windows.Forms.RadioButton();
            this.radioButtonTLS = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxUri = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDomain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            //
            // textBoxSignInName
            //
            this.textBoxSignInName.Location = new System.Drawing.Point(151, 23);
            this.textBoxSignInName.Name = "textBoxSignInName";
            this.textBoxSignInName.Size = new System.Drawing.Size(207, 20);
            this.textBoxSignInName.TabIndex = 0;
            this.textBoxSignInName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxSignInName_Validating);
            //
            // textBoxServerName
            //
            this.textBoxServerName.Location = new System.Drawing.Point(148, 19);
            this.textBoxServerName.Name = "textBoxServerName";
            this.textBoxServerName.Size = new System.Drawing.Size(207, 20);
            this.textBoxServerName.TabIndex = 1;
            this.textBoxServerName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxServerName_Validating);
            //
            // labelSignInName
            //
            this.labelSignInName.AutoSize = true;
            this.labelSignInName.Location = new System.Drawing.Point(74, 23);
            this.labelSignInName.Name = "labelSignInName";
            this.labelSignInName.Size = new System.Drawing.Size(71, 13);
            this.labelSignInName.TabIndex = 2;
            this.labelSignInName.Text = "Sign-in name:";
            //
            // labelServer
            //
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(6, 22);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(136, 13);
            this.labelServer.TabIndex = 3;
            this.labelServer.Text = "Server name or IP Address:";
            //
            // labelConnectUsing
            //
            this.labelConnectUsing.AutoSize = true;
            this.labelConnectUsing.Location = new System.Drawing.Point(64, 58);
            this.labelConnectUsing.Name = "labelConnectUsing";
            this.labelConnectUsing.Size = new System.Drawing.Size(78, 13);
            this.labelConnectUsing.TabIndex = 4;
            this.labelConnectUsing.Text = "Connect using:";
            //
            // radioButtonTCP
            //
            this.radioButtonTCP.AutoSize = true;
            this.radioButtonTCP.Checked = true;
            this.radioButtonTCP.Location = new System.Drawing.Point(148, 76);
            this.radioButtonTCP.Name = "radioButtonTCP";
            this.radioButtonTCP.Size = new System.Drawing.Size(46, 17);
            this.radioButtonTCP.TabIndex = 5;
            this.radioButtonTCP.TabStop = true;
            this.radioButtonTCP.Text = "TCP";
            this.radioButtonTCP.UseVisualStyleBackColor = true;
            //
            // radioButtonTLS
            //
            this.radioButtonTLS.AutoSize = true;
            this.radioButtonTLS.Location = new System.Drawing.Point(148, 99);
            this.radioButtonTLS.Name = "radioButtonTLS";
            this.radioButtonTLS.Size = new System.Drawing.Size(45, 17);
            this.radioButtonTLS.TabIndex = 6;
            this.radioButtonTLS.TabStop = true;
            this.radioButtonTLS.Text = "TLS";
            this.radioButtonTLS.UseVisualStyleBackColor = true;
            //
            // buttonCancel
            //
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(227, 310);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.buttonCancel.CausesValidation = false;
            //
            // buttonOK
            //
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(97, 310);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            this.buttonOK.CausesValidation = true;
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.textBoxUri);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDomain);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxSignInName);
            this.groupBox1.Controls.Add(this.labelSignInName);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 150);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login account info";
            //
            // textBoxUri
            //
            this.textBoxUri.Location = new System.Drawing.Point(151, 116);
            this.textBoxUri.Name = "textBoxUri";
            this.textBoxUri.Size = new System.Drawing.Size(207, 20);
            this.textBoxUri.TabIndex = 8;
            this.textBoxUri.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxUri_Validating);
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Uri:";
            //
            // textBoxDomain
            //
            this.textBoxDomain.Location = new System.Drawing.Point(151, 85);
            this.textBoxDomain.Name = "textBoxDomain";
            this.textBoxDomain.Size = new System.Drawing.Size(207, 20);
            this.textBoxDomain.TabIndex = 6;
            this.textBoxDomain.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDomainName_Validating);
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Domain:";
            //
            // textBoxPassword
            //
            this.textBoxPassword.Location = new System.Drawing.Point(151, 54);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(207, 20);
            this.textBoxPassword.TabIndex = 4;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password:";
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.radioButtonTCP);
            this.groupBox2.Controls.Add(this.textBoxServerName);
            this.groupBox2.Controls.Add(this.labelServer);
            this.groupBox2.Controls.Add(this.labelConnectUsing);
            this.groupBox2.Controls.Add(this.radioButtonTLS);
            this.groupBox2.Location = new System.Drawing.Point(9, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 122);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection setting";
            //
            // LoginForm
            //
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 345);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Name = "LoginForm";
            this.Text = "Connection settings";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSignInName;
        private System.Windows.Forms.TextBox textBoxServerName;
        private System.Windows.Forms.Label labelSignInName;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Label labelConnectUsing;
        private System.Windows.Forms.RadioButton radioButtonTCP;
        private System.Windows.Forms.RadioButton radioButtonTLS;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxDomain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUri;
        private System.Windows.Forms.Label label3;
    }
}

/*=====================================================================
  This file is part of the Microsoft Unified Communications Code Samples.

  Copyright (C) 2006 Microsoft Corporation.  All rights reserved.

This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation.  See these other
materials for detailed information regarding Microsoft code samples.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace UCCPSample
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load form and read default configuration info from xml file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                ReadLoginInfoFromXMLFile("config.xml");
            }
            catch (XmlException)
            {
                // no default xml file. The blank form will be brought out.
                MessageBox.Show("Error reading the config file. Using defaults.", "Xml Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public string SignInName { get { return textBoxSignInName.Text; } }
        public string ServerName { get { return textBoxServerName.Text; } }
        public string Password { get { return textBoxPassword.Text; } }
        public string Domain { get { return textBoxDomain.Text; } }
        public string Uri { get { return textBoxUri.Text; } }

        public string Transport()
        {
            return (radioButtonTCP.Checked)? "TCP" : "TLS";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Validate the input string in textBoxSignInName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSignInName_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxSignInName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("You must enter your sign in name.", "Sign in Name Entry Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
            e.Cancel = false;
        }

        /// <summary>
        /// /// Validate the input string in textBoxUri
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxUri_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxUri.Text.Trim() == string.Empty)
            {
                MessageBox.Show("You must enter your Uri", "Uri entry error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
            e.Cancel = false;
        }

        /// <summary>
        /// Validate the input string in textBoxDomainName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDomainName_Validating(object sender, CancelEventArgs e)
        {

            if (textBoxDomain.Text.Trim() == string.Empty)
            {
                MessageBox.Show("You must enter the domain name", "Domain Name Entry Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
            e.Cancel = false;
        }

        /// <summary>
        /// Validate the input string in textBoxServerName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxServerName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            if (textBoxServerName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("You must enter server name or IP address", "Server Name Entry Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
            e.Cancel = false;
        }

        private void ReadLoginInfoFromXMLFile(string filename)
        {
            XmlTextReader variableReader = null;

            variableReader = new XmlTextReader(filename);

            if (variableReader == null)
            {
                return;
            }

            while (variableReader.Read())
            {
                if (variableReader.NodeType == XmlNodeType.Element)
                {
                    string variableValue = variableReader.GetAttribute("VALUE");
                    if (String.IsNullOrEmpty(variableValue) != true)
                    {
                        if (variableReader.LocalName.ToUpper().Equals("SERVER"))
                        {
                            this.textBoxServerName.Text = variableValue;
                        }
                        else if (variableReader.LocalName.ToUpper().Equals("USER_URI"))
                        {
                            this.textBoxUri.Text = variableValue;
                        }
                        else if (variableReader.LocalName.ToUpper().Equals("DOMAIN"))
                        {
                            this.textBoxDomain.Text = variableValue;
                        }
                        else if (variableReader.LocalName.ToUpper().Equals("USER_NAME"))
                        {
                            this.textBoxSignInName.Text = variableValue;
                        }
                        else if (variableReader.LocalName.ToUpper().Equals("PASSWORD"))
                        {
                            this.textBoxPassword.Text = variableValue;
                        }
                        else if (variableReader.LocalName.ToUpper().Equals("CONNECTION"))
                        {
                            if (variableValue == "TCP")
                            {
                                this.radioButtonTCP.Checked = true;
                            }
                            else if (variableValue == "TLS")
                            {
                                this.radioButtonTLS.Checked = true;
                            }
                            else
                            {
                                this.radioButtonTCP.Checked = true;
                            }
                        }
                    }
                }
            }
            return;
        }
    }
}

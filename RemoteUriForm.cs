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
    public partial class RemoteUriForm : Form
    {
        public RemoteUriForm()
        {
            InitializeComponent();
        }

        private void RemoteUriForm_Load(object sender, EventArgs e)
        {
            try
            {
                ReadLoginInfoFromXMLFile("config.xml");
            }
            catch (Exception)
            {
                // no default xml file. The blank form will be brought out.
            }
        }

        public string RemoteUri { get { return this.textBoxRemoteUri.Text; } }

        private void buttonOK_Click(object sender, EventArgs e)
        {
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Validate the input string textBoxRemoteUri.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxRemoteUri_Validating(object sender, CancelEventArgs e)
        {
            base.OnValidating(e);
            e.Cancel = true;

            if (textBoxRemoteUri.Text == string.Empty)
            {
                MessageBox.Show("You must enter your Uri", "Uri entry error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxRemoteUri.Focus();
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
                    if (variableValue != null)
                    {
                        if (variableReader.LocalName.ToUpper().Equals("REMOTE_URI"))
                        {
                            this.textBoxRemoteUri.Text = variableValue;
                        }
                    }
                }
            }
            return;
        }
    }
}

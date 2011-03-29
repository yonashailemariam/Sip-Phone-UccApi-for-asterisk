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
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.UccApi;

namespace UCCPSample
{
    public partial class MainForm : Form
    {
        UccController uccControl = null;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create UccPlatform while loading the main form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.uccControl = new UccController(this);
        }

        /// <summary>
        /// Shutdown platform on Form closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.uccControl.Logout();
            this.uccControl.ShutdownPlatform();
        }

        /// <summary>
        /// Login a user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (this.uccControl == null)
            {
                WriteStatusMessage("Creating UCCP platform. Please try login later.");
                return;
            }

            if (this.uccControl.Endpoint != null)
            {
                return;
            }

            LoginForm logForm = new LoginForm();
            DialogResult result = logForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    this.buttonLogin.Enabled = false;
                    WriteStatusMessage("User " + logForm.SignInName + " is logging in ...");
                    this.uccControl.CreateLoginSession(logForm.SignInName,
                        logForm.Password, logForm.Domain, logForm.ServerName,
                        logForm.Transport(), logForm.Uri);

                }
                catch (COMException ex)
                {
                    WriteStatusMessage("Login failed. Error: " + ex.Message);
                    this.buttonLogin.Enabled = true;
                }
            }

            logForm.Dispose();

        }

        /// <summary>
        /// Logout the current user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (this.uccControl.Endpoint == null)
                return;
            try
            {
                WriteStatusMessage("User " + this.uccControl.SignName + " is logging out ...");
                this.uccControl.Logout();

            }
            catch (COMException ex)
            {
                WriteStatusMessage("Logout failed. Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Start instance message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClickIM_Click(object sender, EventArgs e)
        {
            if (this.uccControl == null)
            {
                WriteStatusMessage("Creating UCCP platform. Please try login later.");
                return;
            }

            if (this.uccControl.Endpoint == null)
            {
                WriteStatusMessage("ERROR: You must login first.");
                return;
            }

            if (this.uccControl.IMSession != null)
            {
                WriteStatusMessage("The App only supports one active IM session. " +
                    "Please end current active seesion and try again.");
                return;
            }

            RemoteUriForm remoteUriForm = new RemoteUriForm();
            DialogResult result = remoteUriForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    this.uccControl.StartIMSession(remoteUriForm.RemoteUri);
                    WriteStatusMessage("IM session is connecting with " + remoteUriForm.RemoteUri);
                }
                catch (COMException ex)
                {
                    WriteStatusMessage("IM connection failed. Error: " + ex.Message);
                    this.uccControl.IMSession = null;
                }
            }

            remoteUriForm.Dispose();
        }


        /// <summary>
        /// End instance message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEndIM_Click(object sender, EventArgs e)
        {
            if (this.uccControl.IMSession == null)
            {
                WriteStatusMessage("ERROR: There is no active IM session.");
                return;
            }
            try
            {
                WriteStatusMessage("Ending IM session ...");
                this.uccControl.EndIMSession();
            }
            catch (COMException ex)
            {
                WriteStatusMessage("Failed to end IM session. Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Start a call.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClickCall_Click(object sender, EventArgs e)
        {
            if (this.uccControl == null)
            {
                WriteStatusMessage("Creating UCCP platform. Please try login later.");
                return;
            }

            if (this.uccControl.Endpoint == null)
            {
                WriteStatusMessage("ERROR: You must login first.");
                return;
            }

            if (this.uccControl.AVSession != null)
            {
                WriteStatusMessage("The App only supports one active AV session. " +
                    "Please end current active seesion and try again.");
                return;
            }

            RemoteUriForm remoteUriForm = new RemoteUriForm();
            DialogResult result = remoteUriForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    this.uccControl.StartAVSession(remoteUriForm.RemoteUri);
                    WriteStatusMessage("AV session is connecting with " + remoteUriForm.RemoteUri);
                }
                catch (COMException ex)
                {
                    WriteStatusMessage("AV connection failed. Error: " + ex.Message);
                    this.uccControl.AVSession = null;
                }
            }
            remoteUriForm.Dispose();
        }

        /// <summary>
        /// End a call
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEndCall_Click(object sender, EventArgs e)
        {
            if (this.uccControl.AVSession == null)
            {
                WriteStatusMessage("ERROR: There is no active AV session.");
                return;
            }
            try
            {
                WriteStatusMessage("Ending AV session ...");
                this.uccControl.EndAVSession();
            }
            catch (COMException ex)
            {
                WriteStatusMessage("Failed to end AV session. Error:" + ex.Message);
            }

        }

        /// <summary>
        /// Catch keyup events in IM input text box. When Enter is hit, send the message
        /// and clear the text for further input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxIMInput_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.uccControl.SessionSendMessage(this.textBoxIMInput.Text);
                    this.textBoxIMInput.Text = string.Empty;
                }
            }
            catch (COMException ex)
            {
                WriteStatusMessage(ex.Message);
            }
        }

        /// <summary>
        /// Write message to textBoxInfo box.
        /// </summary>
        /// <param name="message"></param>
        public void WriteStatusMessage(string message)
        {
            this.textBoxInfo.AppendText(message + "\r\n\r\n");
            this.textBoxIMInput.Focus();
        }

        /// <summary>
        /// Write instance message to textBoxIM.
        /// </summary>
        /// <param name="message"></param>

        public void WriteIMMessage(string message)
        {
            this.textBoxIM.AppendText(message + "\r\n");
            this.textBoxIMInput.Focus();
        }

        /// <summary>
        /// Set instance message related buttons when there is no active IM sesssion
        /// </summary>
        public void SetIMOn()
        {
            this.buttonClickIM.Enabled = true;
            this.buttonEndIM.Enabled = false;
            this.textBoxIMInput.ReadOnly = true;
        }

        /// <summary>
        /// Set instance message related buttons when there is active IM sesssion
        /// </summary>
        public void SetIMOff()
        {
            this.buttonClickIM.Enabled = false;
            this.buttonEndIM.Enabled = true;
            this.textBoxIMInput.ReadOnly = false;
            this.textBoxIMInput.Focus();
        }

        /// <summary>
        /// Set VoIP related buttons' state
        /// when there is no active AV sesssion
        /// </summary>
        public void SetVoipOn()
        {
            this.buttonClickCall.Enabled = true;
            this.buttonEndCall.Enabled = false;
        }

        /// <summary>
        /// Set VoIP related buttons's state
        /// when there is an active AV sesssion
        /// </summary>
        public void SetVoIPOff()
        {
            this.buttonClickCall.Enabled = false;
            this.buttonEndCall.Enabled = true;
        }

        /// <summary>
        /// Set related buttons' state after login.
        /// </summary>
        public void SetButtonsAfterLogin()
        {
            SetIMOn();
            SetVoipOn();
            this.buttonLogin.Enabled = false;
            this.buttonLogout.Enabled = true;
        }

        /// <summary>
        /// Set related buttons' state after logout
        /// </summary>
        public void SetButtonsAfterLogout()
        {
            this.buttonClickIM.Enabled = false;
            this.buttonEndIM.Enabled = false;
            this.textBoxIMInput.ReadOnly = true;
            this.buttonClickCall.Enabled = false;
            this.buttonEndCall.Enabled = false;
            this.buttonLogin.Enabled = true;
            this.buttonLogout.Enabled = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.uccControl.setMicroLevel(trackBar1.Value);
        }
    }
}

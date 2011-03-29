/*=====================================================================
  This file is part of the Microsoft Unified Communications Code Samples.

  Copyright (C) 2007 Microsoft Corporation.  All rights reserved.

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
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.UccApi;
using System.Windows.Forms;

namespace UCCPSample
{
    public partial class UccController : _IUccPlatformEvents,
                                    _IUccEndpointEvents,
        _IUccSessionDescriptionEvaluator, _IUccSubscriptionEvents, _IUccSessionCallControlEvents
        //,        _IUccServerSignalingSettingsEvents
        //_IUccSessionEvents
    {
        private string signName;
        private string password;
        private string domain;
        private string serverName;
        private string transport;
        private string uri;
        private string imRemoteUri;
        private string avRemoteUri;
        private MainForm mainForm = null;
        private IUccPlatform platform = null;
        private IUccEndpoint endpoint = null;
        private IUccEndpoint proxyendpoint = null;
        
        private int operationId = 10;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainForm"></param>
        public UccController(MainForm mainForm)
        {
            this.mainForm = mainForm;
            CreatePlatform();

        }

        /// <summary>
        /// Create platform
        /// </summary>
        public void CreatePlatform()
        {

            this.platform = new UccPlatformClass();
            if (this.platform != null)
            {
                // Register this client with the platform to receive
                // notifications of the platform events
                Advise<_IUccPlatformEvents>(this.platform, this);

                // Initialize the platform
                this.platform.Initialize("UccpSample", null);                 
                IUccTraceSettings traceSettings = (IUccTraceSettings)this.platform;
                
                traceSettings.EnableTracing();

                SetupAudioMicro();

            }
        }

        private void SetupAudioMicro()
        {
            IUccMediaDeviceManager mediaDevMan = platform as IUccMediaDeviceManager;
            
            IUccCollection col = mediaDevMan.GetDevices(UCC_MEDIA_TYPES.UCCMT_AUDIO, UCC_MEDIA_DIRECTIONS.UCCMD_RECEIVE);
            foreach (IUccMediaDevice dev in col)
            {
                IUccMediaDevice selected = mediaDevMan.GetRecommendedDevice(UCC_AUDIO_VIDEO_DEVICE_CATEGORY.UCCAVDC_AUDIO_VIDEO_CALL_DEVICE, UCC_MEDIA_TYPES.UCCMT_AUDIO, UCC_MEDIA_DIRECTIONS.UCCMD_RECEIVE);
                mediaDevMan.SetSelectedDevice(UCC_AUDIO_VIDEO_DEVICE_CATEGORY.UCCAVDC_AUDIO_VIDEO_CALL_DEVICE, UCC_MEDIA_TYPES.UCCMT_AUDIO, UCC_MEDIA_DIRECTIONS.UCCMD_RECEIVE, dev);
                //mediaDevMan.SetSelectedDevice(UCC_AUDIO_VIDEO_DEVICE_CATEGORY.UCCAVDC_AUDIO_VIDEO_CALL_NONPRIVATE_DEVICE, UCC_MEDIA_TYPES.UCCMT_AUDIO, UCC_MEDIA_DIRECTIONS.UCCMD_SEND, dev);

                IUccAudioMediaDevice devAudio = dev as IUccAudioMediaDevice;
                devAudio.Volume = UccConstants.UCCMSC_MAX_AUDIO_VOLUME;
                devAudio.IsMuted = false;
                
            }
        }

        internal void setMicroLevel(int p)
        {
            IUccMediaDeviceManager mediaDevMan = platform as IUccMediaDeviceManager;

            IUccCollection col = mediaDevMan.GetDevices(UCC_MEDIA_TYPES.UCCMT_AUDIO, UCC_MEDIA_DIRECTIONS.UCCMD_SEND);
            foreach (IUccMediaDevice dev in col)
            {
                IUccMediaDevice selected = mediaDevMan.GetRecommendedDevice(UCC_AUDIO_VIDEO_DEVICE_CATEGORY.UCCAVDC_AUDIO_VIDEO_CALL_DEVICE, UCC_MEDIA_TYPES.UCCMT_AUDIO, UCC_MEDIA_DIRECTIONS.UCCMD_SEND);
                mediaDevMan.SetSelectedDevice(UCC_AUDIO_VIDEO_DEVICE_CATEGORY.UCCAVDC_AUDIO_VIDEO_CALL_DEVICE, UCC_MEDIA_TYPES.UCCMT_AUDIO, UCC_MEDIA_DIRECTIONS.UCCMD_SEND, dev);
                //mediaDevMan.SetSelectedDevice(UCC_AUDIO_VIDEO_DEVICE_CATEGORY.UCCAVDC_AUDIO_VIDEO_CALL_NONPRIVATE_DEVICE, UCC_MEDIA_TYPES.UCCMT_AUDIO, UCC_MEDIA_DIRECTIONS.UCCMD_SEND, dev);

                IUccAudioMediaDevice devAudio = dev as IUccAudioMediaDevice;
                devAudio.Volume = p;
                devAudio.IsMuted = false;

            }
        }

        /// <summary>
        /// Shutdown the platform
        /// </summary>
        public void ShutdownPlatform()
        {
            if (this.platform != null)
            {
                // Shutdown platform
                UccOperationContext context = new UccOperationContextClass();
                context.Initialize(operationId++, null);
                this.platform.Shutdown(context);
            }
        }

        /// <summary>
        /// Create Endpoint and associate to related events
        /// </summary>
        public void CreateEndpoint()
        {

            // Create endpoint
            UccUriManager uriManager = new UccUriManager();
            this.endpoint = this.platform.CreateEndpoint(UCC_ENDPOINT_TYPE.UCCET_PRINCIPAL_SERVER_BASED, uriManager.ParseUri(uri), null, null);

            // Configure the endpoint
            IUccServerSignalingSettings settings = (IUccServerSignalingSettings)this.endpoint;

            // Add the credentials -- note: "*" means any realm
            UccCredential credential = settings.CredentialCache.CreateCredential(signName, password, domain);
            settings.CredentialCache.SetCredential("*", credential);

            // Set the server to use
            //settings.Server = settings.CreateSignalingServer(serverName, (transport == "TCP") ? UCC_TRANSPORT_MODE.UCCTM_TCP : UCC_TRANSPORT_MODE.UCCTM_TLS);
            settings.Server = settings.CreateSignalingServer(serverName, UCC_TRANSPORT_MODE.UCCTM_TCP);
            
            //settings.


            // Set the allowed authentication modes
            //settings.AllowedAuthenticationModes = (int)UCC_AUTHENTICATION_MODES.UCCAM_KERBEROS
            //                                        | (int)UCC_AUTHENTICATION_MODES.UCCAM_NTLM;
            settings.AllowedAuthenticationModes = (int)UCC_AUTHENTICATION_MODES.UCCAM_DIGEST;
            // Register this client to receive event
            // notifications when the login session changes.
            Advise<_IUccEndpointEvents>(this.endpoint, this);
            //Advise<_IUcc>(this.endpoint, this);
            Advise<_IUccSessionManagerEvents>(this.endpoint, this);
            //Advise<IUccIncomingRequestEvent>(this.endpoint, this);

            //IUccSessionManager manager = (IUccSessionManager)this.endpoint;
                //manager.RegisterSessionDescriptionEvaluator(this);
            string proxyEndpointTelId = "tel:1234;phone-context=AB32-cdp.AB32-udp";
            string proxyEndpointSipURI = "sip:AB32-LAB@PBXServer.contoso.com";

            //proxyendpoint = this.platform.CreateProxyEndpoint(UCC_ENDPOINT_TYPE.UCCET_PROXY_TELEPHONY, endpoint, uriManager.ParseUri(uri), proxyEndpointTelId, null);
            // notifications when the login session changes.
            //Advise<_IUccEndpointEvents>(this.proxyendpoint, this);
            //Advise<_IUcc>(this.endpoint, this);
            //Advise<_IUccSessionManagerEvents>(this.proxyendpoint, this);
        }

        /// <summary>
        /// Enable the endpoint
        /// </summary>
        public void EnableEndpoint()
        {
            if (endpoint != null)
            {
                this.endpoint.Enable(null);                 
              
            }
        }

        /// <summary>
        /// Disable endpoint
        /// </summary>
        public void DisableEndpoint()
        {
            if (this.endpoint != null)
            {
                this.endpoint.Disable(null);
            }
        }

        /// <summary>
        /// Login - Create and enable endpoint
        /// </summary>
        public void CreateLoginSession(
                string signName,
                string password,
                string domain,
                string serverName,
                string transport,
                string uri)
        {
            this.signName = signName;
            this.password = password;
            this.domain = domain;
            this.serverName = serverName;
            this.transport = transport;
            this.uri = uri;

            if (this.platform != null)
            {
                // Create an endpoint for the specified user.
                CreateEndpoint();
                // Enable the endpoint
                EnableEndpoint();
            }
        }

        /// <summary>
        /// Logout - End active sessions and disable endpoint
        /// </summary>
        public void Logout()
        {
            // End active IM Session if there is any
            EndIMSession();
            // End active AV Session if there is any
            EndAVSession();
            // Disable endpoint
            DisableEndpoint();
        }

        public string SignName { get { return this.signName; } }
        public IUccEndpoint Endpoint { get { return this.endpoint; } }

        /// <summary>
        /// Register to receive event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="sink"></param>
        static void Advise<T>(object source, T sink)
        {

            IConnectionPointContainer container = (IConnectionPointContainer)source;
            IConnectionPoint cp;
            int cookie;
            Guid guid = typeof(T).GUID;
            container.FindConnectionPoint(ref guid, out cp);
            cp.Advise(sink, out cookie);
        }

        #region _IUccPlatformEvents Member

        void _IUccPlatformEvents.OnShutdown(
                UccPlatform eventSource,
                IUccOperationProgressEvent eventData)
        {
            if (eventData.IsComplete)
            {
                if (eventData.StatusCode >= 0)
                {
                    this.platform = null;
                }
                else
                {
                    this.mainForm.WriteStatusMessage("Failed to shutdown platform. Error: " +
                        eventData.StatusCode.ToString("X"));
                }
            }
        }

        void _IUccPlatformEvents.OnIpAddrChange(
                UccPlatform eventSource,
                object eventData)
        {
        }

        #endregion _IUccPlatformEvents

        #region _IUccEndpointEvents Members

        /// <summary>
        /// Display information when endpoint fires OnEnable event
        /// </summary>
        /// <param name="eventSource"></param>
        /// <param name="eventData"></param>
        void _IUccEndpointEvents.OnEnable(
                IUccEndpoint eventSource,
                IUccOperationProgressEvent eventData)
        {
            if (eventData.IsComplete)
            {
                if (eventData.StatusCode >= 0)
                {
                    this.mainForm.WriteStatusMessage("User " + this.signName + " login successfully.");
                    this.mainForm.SetButtonsAfterLogin();
                   //eventData.
                }
                else
                {
                    this.endpoint = null;
                    string formatMessage = string.Format("User {0} failed to login. Error: {1}",
                        this.signName, eventData.StatusCode.ToString("X"));
                    this.mainForm.WriteStatusMessage(formatMessage);
                    this.mainForm.SetButtonsAfterLogout();
                }
            }
        }

        /// <summary>
        /// Display information when endpoint fires OnDisable event
        /// </summary>
        /// <param name="eventSource"></param>
        /// <param name="eventData"></param>
        void _IUccEndpointEvents.OnDisable(
                     IUccEndpoint eventSource,
                     IUccOperationProgressEvent eventData)
        {
            if (eventData.IsComplete)
            {
                if (eventData.StatusCode >= 0)
                {
                    this.endpoint = null;
                    this.mainForm.SetButtonsAfterLogout();
                    this.mainForm.WriteStatusMessage("User " + this.signName +
                        " is logged out successfully.");
                }
                else
                {
                    string formatMessage = string.Format("User {0} failed to logout. Error: {1}",
                        this.signName, eventData.StatusCode.ToString("X"));
                    this.mainForm.WriteStatusMessage(formatMessage);
                }
            }
        }

        #endregion _IUccEndpointEvents




        #region _IUccSessionDescriptionEvaluator Members

        public bool Evaluate(string bstrContentType, string bstrSessionDescription)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region _IUccSubscriptionEvents Members

        public void OnQuery(UccSubscription pSubscription, UccSubscriptionEvent pEventInfo)
        {
            throw new NotImplementedException();
        }

        public void OnSubscribe(UccSubscription pSubscription, UccSubscriptionEvent pEventInfo)
        {
            throw new NotImplementedException();
        }

        public void OnUnsubscribe(UccSubscription pSubscription, UccSubscriptionEvent pEventInfo)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region _IUccSessionCallControlEvents Members

        public void OnAlternate(IUccSession pEventSource, IUccOperationProgressEvent pEventData)
        {
            throw new NotImplementedException();
        }

        public void OnIncomingTransfer(IUccSession pEventSource, UccIncomingSessionTransferEvent pEventData)
        {
            throw new NotImplementedException();
        }

        public void OnTransferProgress(IUccSession pEventSource, UccSessionTransferProgressEvent pEventData)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

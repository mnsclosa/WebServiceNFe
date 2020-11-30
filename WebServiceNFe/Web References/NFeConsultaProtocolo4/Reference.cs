﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Este código-fonte foi gerado automaticamente por Microsoft.VSDesigner, Versão 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace ServiceNFe.NFeConsultaProtocolo4 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="NFeConsultaProtocolo4Soap12", Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4")]
    public partial class NFeConsultaProtocolo4 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback nfeConsultaNFOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public NFeConsultaProtocolo4() {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = global::ServiceNFe.Properties.Settings.Default.ServiceNFe_NFeConsultaProtocolo4_NFeConsultaProtocolo4;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event nfeConsultaNFCompletedEventHandler nfeConsultaNFCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4/nfeConsultaNF", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("nfeResultMsg", Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4")]
        public System.Xml.XmlNode nfeConsultaNF([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4")] System.Xml.XmlNode nfeDadosMsg) {
            object[] results = this.Invoke("nfeConsultaNF", new object[] {
                        nfeDadosMsg});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void nfeConsultaNFAsync(System.Xml.XmlNode nfeDadosMsg) {
            this.nfeConsultaNFAsync(nfeDadosMsg, null);
        }
        
        /// <remarks/>
        public void nfeConsultaNFAsync(System.Xml.XmlNode nfeDadosMsg, object userState) {
            if ((this.nfeConsultaNFOperationCompleted == null)) {
                this.nfeConsultaNFOperationCompleted = new System.Threading.SendOrPostCallback(this.OnnfeConsultaNFOperationCompleted);
            }
            this.InvokeAsync("nfeConsultaNF", new object[] {
                        nfeDadosMsg}, this.nfeConsultaNFOperationCompleted, userState);
        }
        
        private void OnnfeConsultaNFOperationCompleted(object arg) {
            if ((this.nfeConsultaNFCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.nfeConsultaNFCompleted(this, new nfeConsultaNFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void nfeConsultaNFCompletedEventHandler(object sender, nfeConsultaNFCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class nfeConsultaNFCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal nfeConsultaNFCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591
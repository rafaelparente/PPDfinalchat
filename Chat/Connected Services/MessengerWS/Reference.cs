﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chat.MessengerWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://messenger/", ConfigurationName="MessengerWS.MessengerItf")]
    public interface MessengerItf {
        
        // CODEGEN: Parameter 'arg0' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://messenger/MessengerItf/saveMessageRequest", ReplyAction="http://messenger/MessengerItf/saveMessageResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Chat.MessengerWS.saveMessageResponse saveMessage(Chat.MessengerWS.saveMessageRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://messenger/MessengerItf/saveMessageRequest", ReplyAction="http://messenger/MessengerItf/saveMessageResponse")]
        System.Threading.Tasks.Task<Chat.MessengerWS.saveMessageResponse> saveMessageAsync(Chat.MessengerWS.saveMessageRequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://messenger/MessengerItf/getMessagesRequest", ReplyAction="http://messenger/MessengerItf/getMessagesResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        Chat.MessengerWS.getMessagesResponse getMessages(Chat.MessengerWS.getMessagesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://messenger/MessengerItf/getMessagesRequest", ReplyAction="http://messenger/MessengerItf/getMessagesResponse")]
        System.Threading.Tasks.Task<Chat.MessengerWS.getMessagesResponse> getMessagesAsync(Chat.MessengerWS.getMessagesRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://messenger/")]
    public partial class message : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string senderField;
        
        private string contentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string Sender {
            get {
                return this.senderField;
            }
            set {
                this.senderField = value;
                this.RaisePropertyChanged("Sender");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string Content {
            get {
                return this.contentField;
            }
            set {
                this.contentField = value;
                this.RaisePropertyChanged("Content");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="saveMessage", WrapperNamespace="http://messenger/", IsWrapped=true)]
    public partial class saveMessageRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://messenger/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Chat.MessengerWS.message arg0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://messenger/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg1;
        
        public saveMessageRequest() {
        }
        
        public saveMessageRequest(Chat.MessengerWS.message arg0, string arg1) {
            this.arg0 = arg0;
            this.arg1 = arg1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="saveMessageResponse", WrapperNamespace="http://messenger/", IsWrapped=true)]
    public partial class saveMessageResponse {
        
        public saveMessageResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getMessages", WrapperNamespace="http://messenger/", IsWrapped=true)]
    public partial class getMessagesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://messenger/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        public getMessagesRequest() {
        }
        
        public getMessagesRequest(string arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getMessagesResponse", WrapperNamespace="http://messenger/", IsWrapped=true)]
    public partial class getMessagesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://messenger/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Chat.MessengerWS.message[] @return;
        
        public getMessagesResponse() {
        }
        
        public getMessagesResponse(Chat.MessengerWS.message[] @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MessengerItfChannel : Chat.MessengerWS.MessengerItf, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MessengerItfClient : System.ServiceModel.ClientBase<Chat.MessengerWS.MessengerItf>, Chat.MessengerWS.MessengerItf {
        
        public MessengerItfClient() {
        }
        
        public MessengerItfClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MessengerItfClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessengerItfClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessengerItfClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Chat.MessengerWS.saveMessageResponse Chat.MessengerWS.MessengerItf.saveMessage(Chat.MessengerWS.saveMessageRequest request) {
            return base.Channel.saveMessage(request);
        }
        
        public void saveMessage(Chat.MessengerWS.message arg0, string arg1) {
            Chat.MessengerWS.saveMessageRequest inValue = new Chat.MessengerWS.saveMessageRequest();
            inValue.arg0 = arg0;
            inValue.arg1 = arg1;
            Chat.MessengerWS.saveMessageResponse retVal = ((Chat.MessengerWS.MessengerItf)(this)).saveMessage(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Chat.MessengerWS.saveMessageResponse> Chat.MessengerWS.MessengerItf.saveMessageAsync(Chat.MessengerWS.saveMessageRequest request) {
            return base.Channel.saveMessageAsync(request);
        }
        
        public System.Threading.Tasks.Task<Chat.MessengerWS.saveMessageResponse> saveMessageAsync(Chat.MessengerWS.message arg0, string arg1) {
            Chat.MessengerWS.saveMessageRequest inValue = new Chat.MessengerWS.saveMessageRequest();
            inValue.arg0 = arg0;
            inValue.arg1 = arg1;
            return ((Chat.MessengerWS.MessengerItf)(this)).saveMessageAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Chat.MessengerWS.getMessagesResponse Chat.MessengerWS.MessengerItf.getMessages(Chat.MessengerWS.getMessagesRequest request) {
            return base.Channel.getMessages(request);
        }
        
        public Chat.MessengerWS.message[] getMessages(string arg0) {
            Chat.MessengerWS.getMessagesRequest inValue = new Chat.MessengerWS.getMessagesRequest();
            inValue.arg0 = arg0;
            Chat.MessengerWS.getMessagesResponse retVal = ((Chat.MessengerWS.MessengerItf)(this)).getMessages(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Chat.MessengerWS.getMessagesResponse> Chat.MessengerWS.MessengerItf.getMessagesAsync(Chat.MessengerWS.getMessagesRequest request) {
            return base.Channel.getMessagesAsync(request);
        }
        
        public System.Threading.Tasks.Task<Chat.MessengerWS.getMessagesResponse> getMessagesAsync(string arg0) {
            Chat.MessengerWS.getMessagesRequest inValue = new Chat.MessengerWS.getMessagesRequest();
            inValue.arg0 = arg0;
            return ((Chat.MessengerWS.MessengerItf)(this)).getMessagesAsync(inValue);
        }
    }
}
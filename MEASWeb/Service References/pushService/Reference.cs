﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MEASWeb.pushService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://fc.qust.com/", ConfigurationName="pushService.MyPushServiceDelegate")]
    public interface MyPushServiceDelegate {
        
        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        MEASWeb.pushService.PushMessageResponse PushMessage(MEASWeb.pushService.PushMessageRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<MEASWeb.pushService.PushMessageResponse> PushMessageAsync(MEASWeb.pushService.PushMessageRequest request);
        
        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        MEASWeb.pushService.PushMessageByTopicResponse PushMessageByTopic(MEASWeb.pushService.PushMessageByTopicRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<MEASWeb.pushService.PushMessageByTopicResponse> PushMessageByTopicAsync(MEASWeb.pushService.PushMessageByTopicRequest request);
        
        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        MEASWeb.pushService.PushMessageByTopicSSSResponse PushMessageByTopicSSS(MEASWeb.pushService.PushMessageByTopicSSSRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<MEASWeb.pushService.PushMessageByTopicSSSResponse> PushMessageByTopicSSSAsync(MEASWeb.pushService.PushMessageByTopicSSSRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PushMessage", WrapperNamespace="http://fc.qust.com/", IsWrapped=true)]
    public partial class PushMessageRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://fc.qust.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        public PushMessageRequest() {
        }
        
        public PushMessageRequest(string arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PushMessageResponse", WrapperNamespace="http://fc.qust.com/", IsWrapped=true)]
    public partial class PushMessageResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://fc.qust.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public PushMessageResponse() {
        }
        
        public PushMessageResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PushMessageByTopic", WrapperNamespace="http://fc.qust.com/", IsWrapped=true)]
    public partial class PushMessageByTopicRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://fc.qust.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://fc.qust.com/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg1;
        
        public PushMessageByTopicRequest() {
        }
        
        public PushMessageByTopicRequest(string arg0, string arg1) {
            this.arg0 = arg0;
            this.arg1 = arg1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PushMessageByTopicResponse", WrapperNamespace="http://fc.qust.com/", IsWrapped=true)]
    public partial class PushMessageByTopicResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://fc.qust.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public PushMessageByTopicResponse() {
        }
        
        public PushMessageByTopicResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PushMessageByTopicSSS", WrapperNamespace="http://fc.qust.com/", IsWrapped=true)]
    public partial class PushMessageByTopicSSSRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://fc.qust.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("arg0", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string[] arg0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://fc.qust.com/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg1;
        
        public PushMessageByTopicSSSRequest() {
        }
        
        public PushMessageByTopicSSSRequest(string[] arg0, string arg1) {
            this.arg0 = arg0;
            this.arg1 = arg1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PushMessageByTopicSSSResponse", WrapperNamespace="http://fc.qust.com/", IsWrapped=true)]
    public partial class PushMessageByTopicSSSResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://fc.qust.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public PushMessageByTopicSSSResponse() {
        }
        
        public PushMessageByTopicSSSResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MyPushServiceDelegateChannel : MEASWeb.pushService.MyPushServiceDelegate, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyPushServiceDelegateClient : System.ServiceModel.ClientBase<MEASWeb.pushService.MyPushServiceDelegate>, MEASWeb.pushService.MyPushServiceDelegate {
        
        public MyPushServiceDelegateClient() {
        }
        
        public MyPushServiceDelegateClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyPushServiceDelegateClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyPushServiceDelegateClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyPushServiceDelegateClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        MEASWeb.pushService.PushMessageResponse MEASWeb.pushService.MyPushServiceDelegate.PushMessage(MEASWeb.pushService.PushMessageRequest request) {
            return base.Channel.PushMessage(request);
        }
        
        public int PushMessage(string arg0) {
            MEASWeb.pushService.PushMessageRequest inValue = new MEASWeb.pushService.PushMessageRequest();
            inValue.arg0 = arg0;
            MEASWeb.pushService.PushMessageResponse retVal = ((MEASWeb.pushService.MyPushServiceDelegate)(this)).PushMessage(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<MEASWeb.pushService.PushMessageResponse> MEASWeb.pushService.MyPushServiceDelegate.PushMessageAsync(MEASWeb.pushService.PushMessageRequest request) {
            return base.Channel.PushMessageAsync(request);
        }
        
        public System.Threading.Tasks.Task<MEASWeb.pushService.PushMessageResponse> PushMessageAsync(string arg0) {
            MEASWeb.pushService.PushMessageRequest inValue = new MEASWeb.pushService.PushMessageRequest();
            inValue.arg0 = arg0;
            return ((MEASWeb.pushService.MyPushServiceDelegate)(this)).PushMessageAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        MEASWeb.pushService.PushMessageByTopicResponse MEASWeb.pushService.MyPushServiceDelegate.PushMessageByTopic(MEASWeb.pushService.PushMessageByTopicRequest request) {
            return base.Channel.PushMessageByTopic(request);
        }
        
        public int PushMessageByTopic(string arg0, string arg1) {
            MEASWeb.pushService.PushMessageByTopicRequest inValue = new MEASWeb.pushService.PushMessageByTopicRequest();
            inValue.arg0 = arg0;
            inValue.arg1 = arg1;
            MEASWeb.pushService.PushMessageByTopicResponse retVal = ((MEASWeb.pushService.MyPushServiceDelegate)(this)).PushMessageByTopic(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<MEASWeb.pushService.PushMessageByTopicResponse> MEASWeb.pushService.MyPushServiceDelegate.PushMessageByTopicAsync(MEASWeb.pushService.PushMessageByTopicRequest request) {
            return base.Channel.PushMessageByTopicAsync(request);
        }
        
        public System.Threading.Tasks.Task<MEASWeb.pushService.PushMessageByTopicResponse> PushMessageByTopicAsync(string arg0, string arg1) {
            MEASWeb.pushService.PushMessageByTopicRequest inValue = new MEASWeb.pushService.PushMessageByTopicRequest();
            inValue.arg0 = arg0;
            inValue.arg1 = arg1;
            return ((MEASWeb.pushService.MyPushServiceDelegate)(this)).PushMessageByTopicAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        MEASWeb.pushService.PushMessageByTopicSSSResponse MEASWeb.pushService.MyPushServiceDelegate.PushMessageByTopicSSS(MEASWeb.pushService.PushMessageByTopicSSSRequest request) {
            return base.Channel.PushMessageByTopicSSS(request);
        }
        
        public int PushMessageByTopicSSS(string[] arg0, string arg1) {
            MEASWeb.pushService.PushMessageByTopicSSSRequest inValue = new MEASWeb.pushService.PushMessageByTopicSSSRequest();
            inValue.arg0 = arg0;
            inValue.arg1 = arg1;
            MEASWeb.pushService.PushMessageByTopicSSSResponse retVal = ((MEASWeb.pushService.MyPushServiceDelegate)(this)).PushMessageByTopicSSS(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<MEASWeb.pushService.PushMessageByTopicSSSResponse> MEASWeb.pushService.MyPushServiceDelegate.PushMessageByTopicSSSAsync(MEASWeb.pushService.PushMessageByTopicSSSRequest request) {
            return base.Channel.PushMessageByTopicSSSAsync(request);
        }
        
        public System.Threading.Tasks.Task<MEASWeb.pushService.PushMessageByTopicSSSResponse> PushMessageByTopicSSSAsync(string[] arg0, string arg1) {
            MEASWeb.pushService.PushMessageByTopicSSSRequest inValue = new MEASWeb.pushService.PushMessageByTopicSSSRequest();
            inValue.arg0 = arg0;
            inValue.arg1 = arg1;
            return ((MEASWeb.pushService.MyPushServiceDelegate)(this)).PushMessageByTopicSSSAsync(inValue);
        }
    }
}

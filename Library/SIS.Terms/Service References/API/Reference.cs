﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Com.Pearson.Pdn.Learningstudio.SIS.Terms.API {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StandardTermEx", Namespace="http://CCWS-Services.eCollege.com/EnterpriseServices/Types/v2.2/")]
    [System.SerializableAttribute()]
    public partial class StandardTermEx : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] AssociatedEPOrganizationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BillingClassificationTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ClientStringField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TimeFrame CourseActualTimeFrameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TimeFrame DropAddPeriodTimeFrameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TermIdentifier IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TimeFrame RegistrationTimeFrameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TimeFrame TermTimeFrameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TermType TermTypeCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime WithdrawPeriodEndsOnField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] AssociatedEPOrganization {
            get {
                return this.AssociatedEPOrganizationField;
            }
            set {
                if ((object.ReferenceEquals(this.AssociatedEPOrganizationField, value) != true)) {
                    this.AssociatedEPOrganizationField = value;
                    this.RaisePropertyChanged("AssociatedEPOrganization");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BillingClassificationType {
            get {
                return this.BillingClassificationTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.BillingClassificationTypeField, value) != true)) {
                    this.BillingClassificationTypeField = value;
                    this.RaisePropertyChanged("BillingClassificationType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ClientString {
            get {
                return this.ClientStringField;
            }
            set {
                if ((object.ReferenceEquals(this.ClientStringField, value) != true)) {
                    this.ClientStringField = value;
                    this.RaisePropertyChanged("ClientString");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TimeFrame CourseActualTimeFrame {
            get {
                return this.CourseActualTimeFrameField;
            }
            set {
                if ((object.ReferenceEquals(this.CourseActualTimeFrameField, value) != true)) {
                    this.CourseActualTimeFrameField = value;
                    this.RaisePropertyChanged("CourseActualTimeFrame");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TimeFrame DropAddPeriodTimeFrame {
            get {
                return this.DropAddPeriodTimeFrameField;
            }
            set {
                if ((object.ReferenceEquals(this.DropAddPeriodTimeFrameField, value) != true)) {
                    this.DropAddPeriodTimeFrameField = value;
                    this.RaisePropertyChanged("DropAddPeriodTimeFrame");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TermIdentifier ID {
            get {
                return this.IDField;
            }
            set {
                if ((object.ReferenceEquals(this.IDField, value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TimeFrame RegistrationTimeFrame {
            get {
                return this.RegistrationTimeFrameField;
            }
            set {
                if ((object.ReferenceEquals(this.RegistrationTimeFrameField, value) != true)) {
                    this.RegistrationTimeFrameField = value;
                    this.RaisePropertyChanged("RegistrationTimeFrame");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TimeFrame TermTimeFrame {
            get {
                return this.TermTimeFrameField;
            }
            set {
                if ((object.ReferenceEquals(this.TermTimeFrameField, value) != true)) {
                    this.TermTimeFrameField = value;
                    this.RaisePropertyChanged("TermTimeFrame");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TermType TermTypeCode {
            get {
                return this.TermTypeCodeField;
            }
            set {
                if ((this.TermTypeCodeField.Equals(value) != true)) {
                    this.TermTypeCodeField = value;
                    this.RaisePropertyChanged("TermTypeCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime WithdrawPeriodEndsOn {
            get {
                return this.WithdrawPeriodEndsOnField;
            }
            set {
                if ((this.WithdrawPeriodEndsOnField.Equals(value) != true)) {
                    this.WithdrawPeriodEndsOnField = value;
                    this.RaisePropertyChanged("WithdrawPeriodEndsOn");
                }
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TimeFrame", Namespace="http://CCWS-Services.eCollege.com/EnterpriseServices/Types/v2.2/")]
    [System.SerializableAttribute()]
    public partial class TimeFrame : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime StartDateField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime EndDate {
            get {
                return this.EndDateField;
            }
            set {
                if ((this.EndDateField.Equals(value) != true)) {
                    this.EndDateField = value;
                    this.RaisePropertyChanged("EndDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime StartDate {
            get {
                return this.StartDateField;
            }
            set {
                if ((this.StartDateField.Equals(value) != true)) {
                    this.StartDateField = value;
                    this.RaisePropertyChanged("StartDate");
                }
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TermIdentifier", Namespace="http://CCWS-Services.eCollege.com/EnterpriseServices/Types/v2.2/")]
    [System.SerializableAttribute()]
    public partial class TermIdentifier : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.MappedTermIDType MappingTypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ID {
            get {
                return this.IDField;
            }
            set {
                if ((object.ReferenceEquals(this.IDField, value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.MappedTermIDType MappingType {
            get {
                return this.MappingTypeField;
            }
            set {
                if ((this.MappingTypeField.Equals(value) != true)) {
                    this.MappingTypeField = value;
                    this.RaisePropertyChanged("MappingType");
                }
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TermType", Namespace="http://CCWS-Services.eCollege.com/EnterpriseServices/Types/v2.2/")]
    public enum TermType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Standard = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SelfPaced = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        K12 = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Special = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Inventory = 4,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MappedTermIDType", Namespace="http://CCWS-Services.eCollege.com/EnterpriseServices/Types/v2.2/")]
    public enum MappedTermIDType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TermID = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SourcedID = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:eclg:coursecopy:enterpriseterm", ConfigurationName="API.EnterpriseTermService")]
    public interface EnterpriseTermService {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:eclg:coursecopy:enterpriseterm:createstandardterm:request", ReplyAction="urn:eclg:coursecopy:enterpriseterm:createstandardterm:reply")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ArgumentException), Action="urn:eclg:coursecopy:enterpriseterm/EnterpriseTermService/CreateStandardTermArgume" +
            "ntExceptionFault", Name="ArgumentException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TermIdentifier CreateStandardTerm(Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.StandardTermEx standardTermRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:eclg:coursecopy:enterpriseterm:createstandardterm:request", ReplyAction="urn:eclg:coursecopy:enterpriseterm:createstandardterm:reply")]
        System.Threading.Tasks.Task<Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TermIdentifier> CreateStandardTermAsync(Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.StandardTermEx standardTermRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:eclg:coursecopy:enterpriseterm:updatestandardterm:request", ReplyAction="urn:eclg:coursecopy:enterpriseterm:updatestandardterm:reply")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ArgumentException), Action="urn:eclg:coursecopy:enterpriseterm/EnterpriseTermService/UpdateStandardTermArgume" +
            "ntExceptionFault", Name="ArgumentException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TermIdentifier UpdateStandardTerm(Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.StandardTermEx standardTermUpdateRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:eclg:coursecopy:enterpriseterm:updatestandardterm:request", ReplyAction="urn:eclg:coursecopy:enterpriseterm:updatestandardterm:reply")]
        System.Threading.Tasks.Task<Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TermIdentifier> UpdateStandardTermAsync(Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.StandardTermEx standardTermUpdateRequest);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface EnterpriseTermServiceChannel : Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.EnterpriseTermService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EnterpriseTermServiceClient : System.ServiceModel.ClientBase<Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.EnterpriseTermService>, Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.EnterpriseTermService {
        
        public EnterpriseTermServiceClient() {
        }
        
        public EnterpriseTermServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EnterpriseTermServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EnterpriseTermServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EnterpriseTermServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TermIdentifier CreateStandardTerm(Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.StandardTermEx standardTermRequest) {
            return base.Channel.CreateStandardTerm(standardTermRequest);
        }
        
        public System.Threading.Tasks.Task<Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TermIdentifier> CreateStandardTermAsync(Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.StandardTermEx standardTermRequest) {
            return base.Channel.CreateStandardTermAsync(standardTermRequest);
        }
        
        public Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TermIdentifier UpdateStandardTerm(Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.StandardTermEx standardTermUpdateRequest) {
            return base.Channel.UpdateStandardTerm(standardTermUpdateRequest);
        }
        
        public System.Threading.Tasks.Task<Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.TermIdentifier> UpdateStandardTermAsync(Com.Pearson.Pdn.Learningstudio.SIS.Terms.API.StandardTermEx standardTermUpdateRequest) {
            return base.Channel.UpdateStandardTermAsync(standardTermUpdateRequest);
        }
    }
}

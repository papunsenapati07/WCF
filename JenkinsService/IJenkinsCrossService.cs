using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JenkinsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IJenkinsCrossService" in both code and config file together.
    [ServiceContract]
    public interface IJenkinsCrossService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        string GetData();

        [OperationContract]
        void FetchDataFromRemedy(string remedyValues);

    }

    [DataContract]
    public class RemedyValuesModel
    {
        //  string stringValue = "Hello ";
        string resourceGroupName;
        string vnetName;
        string subnetName;
        string imageOffer;
        string imagePublisher;
        string imageSku;
        string vmSize;
        string vmName;
        string managedDiskSize;
        string subscriptionId;
        string businessOwner;
        string technicalOwner;
        string costCode;
        string project;
        string scheduleType;

        [DataMember]
        public string ResourceGroupName
        {
            get { return resourceGroupName; }
            set { resourceGroupName = value; }
        }
        [DataMember]
        public string VnetName
        {
            get { return vnetName; }
            set { vnetName = value; }
        }
        [DataMember]
        public string SubnetName
        {
            get { return subnetName; }
            set { subnetName = value; }
        }
        [DataMember]
        public string ImageOffer
        {
            get { return imageOffer; }
            set { imageOffer = value; }
        }
        [DataMember]
        public string ImagePublisher
        {
            get { return imagePublisher; }
            set { imagePublisher = value; }
        }
        [DataMember]
        public string ImageSku
        {
            get { return imageSku; }
            set { imageSku = value; }
        }
        [DataMember]
        public string VmSize
        {
            get { return vmSize; }
            set { vmSize = value; }
        }
        [DataMember]
        public string VmName
        {
            get { return vmName; }
            set { vmName = value; }
        }
        [DataMember]
        public string ManagedDiskSize
        {
            get { return managedDiskSize; }
            set { managedDiskSize = value; }
        }

        [DataMember]
        public string SubscriptionId
        {
            get { return subscriptionId; }
            set { subscriptionId = value; }
        }
        [DataMember]
        public string BusinessOwner
        {
            get { return businessOwner; }
            set { businessOwner = value; }
        }
        [DataMember]
        public string TechnicalOwner
        {
            get { return technicalOwner; }
            set { technicalOwner = value; }
        }
        [DataMember]
        public string CostCode
        {
            get { return costCode; }
            set { costCode = value; }
        }
        [DataMember]
        public string Project
        {
            get { return project; }
            set { project = value; }
        }
        [DataMember]
        public string ScheduleType
        {
            get { return scheduleType; }
            set { scheduleType = value; }
        }
    }
}


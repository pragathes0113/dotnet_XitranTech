using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.Collections.ObjectModel;
using VHMS.Entity;
using System.IO;


public partial interface IVHMSService
{

    #region NewCustomer
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetAllCustomer();

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetNewCustomerByID(int ID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddNewCustomer(VHMS.Entity.Billing.NewCustomer Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdateNewCustomer(VHMS.Entity.Billing.NewCustomer Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeleteNewCustomer(int ID);
    #endregion

    #region HouseType
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetHouseType();

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetHouseTypeByID(int ID);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string AddHouseType(VHMS.Entity.Billing.HouseType Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string UpdateHouseType(VHMS.Entity.Billing.HouseType Objdata);

    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string DeleteHouseType(int ID);
    #endregion

}
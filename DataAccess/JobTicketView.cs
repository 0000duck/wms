//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WMS.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class JobTicketView
    {
        public int ID { get; set; }
        public Nullable<int> ShipmentTicketID { get; set; }
        public string JobTicketNo { get; set; }
        public string JobType { get; set; }
        public string JobGroupName { get; set; }
        public string State { get; set; }
        public Nullable<int> PrintedTimes { get; set; }
        public string AssignmentArea { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> LastUpdateUserID { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
        public string ShipmentTicketNo { get; set; }
        public string ProjectName { get; set; }
        public string WarehouseName { get; set; }
        public string CreateUserUsername { get; set; }
        public string CreateUserPassword { get; set; }
        public Nullable<int> CreateUserAuthority { get; set; }
        public string CreateUserAuthorityName { get; set; }
        public Nullable<int> CreateUserSupplierID { get; set; }
        public string LastUpdateUserUsername { get; set; }
        public string LastUpdateUserPassword { get; set; }
        public Nullable<int> LastUpdateUserAuthority { get; set; }
        public string LastUpdateUserAuthorityName { get; set; }
        public Nullable<int> LastUpdateUserSupplierID { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> PersonID { get; set; }
        public string ShipmentTicketNumber { get; set; }
        public string PersonName { get; set; }
    }
}

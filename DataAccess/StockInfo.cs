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
    
    public partial class StockInfo
    {
        public int ID { get; set; }
        public Nullable<int> ReceiptTicketItemID { get; set; }
        public Nullable<decimal> ReceiptAreaAmount { get; set; }
        public Nullable<decimal> SubmissionAmount { get; set; }
        public Nullable<decimal> OverflowAreaAmount { get; set; }
        public Nullable<decimal> ShipmentAreaAmount { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<decimal> RejectAreaAmount { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}

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
    
    public partial class PutOutStorageTicketItemView
    {
        public int ID { get; set; }
        public Nullable<int> StockInfoID { get; set; }
        public int PutOutStorageTicketID { get; set; }
        public Nullable<decimal> ExceedStockAmount { get; set; }
        public string PutOutStorageTicketNo { get; set; }
        public Nullable<int> ReceiptTicketItemReceiptTicketID { get; set; }
        public Nullable<int> ReceiptTicketItemComponentID { get; set; }
        public string ProjectName { get; set; }
        public string WarehouseName { get; set; }
        public Nullable<decimal> ScheduledAmount { get; set; }
        public Nullable<decimal> RealAmount { get; set; }
        public string State { get; set; }
        public string ComponentNo { get; set; }
        public Nullable<int> ComponentProjectID { get; set; }
        public string ComponentNumber { get; set; }
        public string ComponentName { get; set; }
        public Nullable<int> ComponentWarehouseID { get; set; }
        public string SupplierNumber { get; set; }
        public string SupplierName { get; set; }
        public string JobPersonName { get; set; }
        public string ConfirmPersonName { get; set; }
    }
}

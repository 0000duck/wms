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
    
    public partial class PutawayTicketItemView
    {
        public int ID { get; set; }
        public int PutawayTicketID { get; set; }
        public Nullable<int> ReceiptTicketItemID { get; set; }
        public string DisplacementPositionNo { get; set; }
        public string TargetStorageLocation { get; set; }
        public string BoardNo { get; set; }
        public string State { get; set; }
        public Nullable<decimal> ScheduledMoveCount { get; set; }
        public Nullable<decimal> DistrabuteCount { get; set; }
        public Nullable<decimal> MoveCount { get; set; }
        public string OperatePerson { get; set; }
        public string OperateTime { get; set; }
        public Nullable<int> ReceiptTicketItemComponentID { get; set; }
        public Nullable<decimal> ReceiptTicketItemExpectedAmount { get; set; }
        public Nullable<decimal> ReceiptTicketItemReceiviptAmount { get; set; }
        public Nullable<decimal> ReceiptTicketItemWrongComponentAmount { get; set; }
        public Nullable<decimal> ReceiptTicketItemShortageAmount { get; set; }
        public Nullable<decimal> ReceiptTicketItemDisqualifiedAmount { get; set; }
        public Nullable<int> ReceiptTicketSupplierID { get; set; }
        public string ProjectName { get; set; }
        public string WarehouseName { get; set; }
        public string SupplierName { get; set; }
        public string ComponentNo { get; set; }
        public string ComponentName { get; set; }
        public Nullable<int> PutawayTicketProjectID { get; set; }
        public Nullable<int> PutawayTicketWarehouseID { get; set; }
        public string PutawayTicketState { get; set; }
        public Nullable<int> PutawayReceiptTicketID { get; set; }
        public string PutawayTicketNo { get; set; }
        public Nullable<decimal> ReceiptTicketItemExpectedPackageAmount { get; set; }
        public string ReceiptTicketItemState { get; set; }
        public string ReceiptTicketState { get; set; }
        public string ReceiptTicketNo { get; set; }
        public string ReceiptTicketNumber { get; set; }
        public string SupplierNumber { get; set; }
        public string ComponentNumber { get; set; }
    }
}

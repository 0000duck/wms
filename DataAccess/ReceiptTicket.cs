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
    
    public partial class ReceiptTicket
    {
        public ReceiptTicket()
        {
            this.PutawayTicketComponentInfo = new HashSet<PutawayTicketComponentInfo>();
            this.PutInStorageTicketComponentInfo = new HashSet<PutInStorageTicketComponentInfo>();
            this.StockInfo = new HashSet<StockInfo>();
            this.SubmissionTicket = new HashSet<SubmissionTicket>();
        }
    
        public int ID { get; set; }
        public int Warehouse { get; set; }
        public string SerialNumber { get; set; }
        public string TypeName { get; set; }
        public string TicketNo { get; set; }
        public string DeliverTicketNo { get; set; }
        public string VoucherSource { get; set; }
        public string VoucherNo { get; set; }
        public string VoucherLineNo { get; set; }
        public Nullable<System.DateTime> VoucherYear { get; set; }
        public string ReletedVoucherNo { get; set; }
        public string ReletedVoucherLineNo { get; set; }
        public Nullable<System.DateTime> ReletedVoucherYear { get; set; }
        public string HeadingText { get; set; }
        public Nullable<System.DateTime> PostCountDate { get; set; }
        public string InwardDeliverTicketNo { get; set; }
        public string InwardDeliverLineNo { get; set; }
        public string OutwardDeliverTicketNo { get; set; }
        public string OutwardDeliverLineNo { get; set; }
        public string PurchaseTicketNo { get; set; }
        public string PurchaseTicketLineNo { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string ReceiptStorageLocation { get; set; }
        public string BoardNo { get; set; }
        public int ComponentID { get; set; }
        public string ComponentNo { get; set; }
        public string ReceiptPackage { get; set; }
        public Nullable<decimal> ExpectedAmount { get; set; }
        public Nullable<decimal> ReceiptCount { get; set; }
        public string StockState { get; set; }
        public Nullable<System.DateTime> InventoryDate { get; set; }
        public string ReceiptTacketNo { get; set; }
        public string ManufactureNo { get; set; }
        public Nullable<System.DateTime> ManufactureDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string ProjectInfo { get; set; }
        public string ProjectPhaseInfo { get; set; }
        public string RealRightProperty { get; set; }
        public int SupplierID { get; set; }
        public string Supplier { get; set; }
        public string AssignmentPerson { get; set; }
        public Nullable<int> PostedCount { get; set; }
        public string BoxNo { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Creater { get; set; }
        public string LastUpdatePerson { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
        public string MoveType { get; set; }
        public string Source { get; set; }
    
        public virtual Component Component { get; set; }
        public virtual ICollection<PutawayTicketComponentInfo> PutawayTicketComponentInfo { get; set; }
        public virtual ICollection<PutInStorageTicketComponentInfo> PutInStorageTicketComponentInfo { get; set; }
        public virtual Supplier Supplier1 { get; set; }
        public virtual Warehouse Warehouse1 { get; set; }
        public virtual ICollection<StockInfo> StockInfo { get; set; }
        public virtual ICollection<SubmissionTicket> SubmissionTicket { get; set; }
    }
}
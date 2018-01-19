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
            this.ReceiptTicketItem = new HashSet<ReceiptTicketItem>();
        }
    
        public int ID { get; set; }
        public int WarehouseID { get; set; }
        public string Type { get; set; }
        public string DeliverTicketNoSRM { get; set; }
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
        public string ReceiptPackage { get; set; }
        public Nullable<decimal> ReceiptCount { get; set; }
        public string State { get; set; }
        public string No { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> PersonID { get; set; }
        public string BoxNo { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
        public string MoveType { get; set; }
        public string Source { get; set; }
        public int ProjectID { get; set; }
        public Nullable<int> LastUpdateUserID { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string Number { get; set; }
        public string StorageArea { get; set; }
        public string StorageLocation { get; set; }
        public string HasPosted { get; set; }
        public string HasPutawayTicket { get; set; }
        public string UseUnit { get; set; }
        public string ReceiptUnit { get; set; }
        public string Comment { get; set; }
        public string RefuseComment { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual ICollection<ReceiptTicketItem> ReceiptTicketItem { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}

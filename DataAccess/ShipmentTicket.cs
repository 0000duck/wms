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
    
    public partial class ShipmentTicket
    {
        public ShipmentTicket()
        {
            this.ShipmentTicketItem = new HashSet<ShipmentTicketItem>();
        }
    
        public int ID { get; set; }
        public int WarehouseID { get; set; }
        public string No { get; set; }
        public string Type { get; set; }
        public string TypeNo { get; set; }
        public string Source { get; set; }
        public Nullable<decimal> SegmentationChainCount { get; set; }
        public string RelatedTicketNo { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> TicketNum { get; set; }
        public Nullable<System.DateTime> RequireArriveDate { get; set; }
        public string State { get; set; }
        public Nullable<decimal> ScheduledAmount { get; set; }
        public Nullable<decimal> AllocatedAmount { get; set; }
        public Nullable<decimal> PickingAmount { get; set; }
        public Nullable<decimal> ShipmentAmount { get; set; }
        public Nullable<decimal> ExceedStorageAmount { get; set; }
        public string Station { get; set; }
        public string ReverseTicketNo { get; set; }
        public string SortType { get; set; }
        public string ProductionLine { get; set; }
        public string ReceivingPersonName { get; set; }
        public string ContactAddress { get; set; }
        public string DeliveryPath { get; set; }
        public string Description { get; set; }
        public string CloseReason { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
        public Nullable<int> PrintTimes { get; set; }
        public Nullable<int> WaitingToBeDone { get; set; }
        public string DeliveryTicketNo { get; set; }
        public string OuterPhysicalDistributionPath { get; set; }
        public string DeliveryPoint { get; set; }
        public Nullable<int> Emergency { get; set; }
        public string ShipmentPlaceNo { get; set; }
        public Nullable<int> BoardPrintedTimes { get; set; }
        public int ProjectID { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<int> LastUpdateUserID { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<ShipmentTicketItem> ShipmentTicketItem { get; set; }
    }
}

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
    
    public partial class PutOutStorageTicketItem
    {
        public int ID { get; set; }
        public Nullable<int> StockInfoID { get; set; }
        public int PutOutStorageTicketID { get; set; }
        public Nullable<decimal> ExceedStockAmount { get; set; }
        public Nullable<decimal> ScheduledAmount { get; set; }
        public Nullable<decimal> RealAmount { get; set; }
        public string State { get; set; }
        public Nullable<int> JobPersonID { get; set; }
        public Nullable<int> ConfirmPersonID { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> UnitAmount { get; set; }
        public Nullable<int> JobTicketItemID { get; set; }
        public Nullable<decimal> ReturnAmount { get; set; }
        public string ReturnType { get; set; }
        public Nullable<System.DateTime> ReturnTime { get; set; }
        public string ReturnUnit { get; set; }
        public Nullable<decimal> ReturnUnitAmount { get; set; }
        public Nullable<System.DateTime> LoadingTime { get; set; }
    
        public virtual PutOutStorageTicket PutOutStorageTicket { get; set; }
    }
}

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
    
    public partial class SubmissionTicketItem
    {
        public int ID { get; set; }
        public Nullable<int> SubmissionTicketID { get; set; }
        public string LineItem { get; set; }
        public Nullable<int> ComponentID { get; set; }
        public string ComponentNo { get; set; }
        public string ComponentName { get; set; }
        public string ArriveAmount { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> SubmissionAmount { get; set; }
        public Nullable<decimal> ReturnAmount { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string BatchNo { get; set; }
        public string SubmissionResult { get; set; }
        public string Comment { get; set; }
    
        public virtual Component Component { get; set; }
        public virtual SubmissionTicket SubmissionTicket { get; set; }
    }
}
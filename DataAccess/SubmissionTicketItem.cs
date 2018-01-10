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
        public int SubmissionTicketID { get; set; }
        public string LineItem { get; set; }
        public Nullable<decimal> ArriveAmount { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> SubmissionAmount { get; set; }
        public Nullable<decimal> ReturnAmount { get; set; }
        public string Comment { get; set; }
        public string State { get; set; }
        public Nullable<int> ReceiptTicketItemID { get; set; }
        public Nullable<int> JobPersonID { get; set; }
        public Nullable<int> ConfirmPersonID { get; set; }
        public Nullable<decimal> RejectAmount { get; set; }
        public Nullable<decimal> UnitAmount { get; set; }
    
        public virtual ReceiptTicketItem ReceiptTicketItem { get; set; }
        public virtual SubmissionTicket SubmissionTicket { get; set; }
    }
}

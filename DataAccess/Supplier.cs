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
    
    public partial class Supplier
    {
        public Supplier()
        {
            this.Component = new HashSet<Component>();
            this.ReceiptTicket = new HashSet<ReceiptTicket>();
            this.SupplierAnnualInfo = new HashSet<SupplierAnnualInfo>();
            this.User = new HashSet<User>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContractNo { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> InvoiceDelayMonth { get; set; }
        public Nullable<decimal> BalanceDelayMonth { get; set; }
        public string FullName { get; set; }
        public string TaxpayerNumber { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string BankNo { get; set; }
        public string ZipCode { get; set; }
        public string RecipientName { get; set; }
        public string Number { get; set; }
        public string ContractState { get; set; }
        public Nullable<int> IsHistory { get; set; }
    
        public virtual ICollection<Component> Component { get; set; }
        public virtual ICollection<ReceiptTicket> ReceiptTicket { get; set; }
        public virtual ICollection<SupplierAnnualInfo> SupplierAnnualInfo { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}

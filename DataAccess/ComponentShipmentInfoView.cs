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
    
    public partial class ComponentShipmentInfoView
    {
        public int ID { get; set; }
        public int ComponentID { get; set; }
        public string BoxType { get; set; }
        public Nullable<decimal> BoxLength { get; set; }
        public Nullable<decimal> BoxWidth { get; set; }
        public Nullable<decimal> BoxHeight { get; set; }
        public Nullable<decimal> UnitAmount { get; set; }
        public Nullable<int> ComponentProjectID { get; set; }
        public Nullable<int> ComponentWarehouseID { get; set; }
        public Nullable<int> ComponentSupplierID { get; set; }
        public string ComponentContainerNo { get; set; }
        public string ComponentFactroy { get; set; }
        public string ComponentWorkPosition { get; set; }
        public string ComponentNo { get; set; }
        public string ComponentName { get; set; }
        public string ComponentSupplierType { get; set; }
        public string ComponentType { get; set; }
        public string ComponentSize { get; set; }
        public string ComponentCategory { get; set; }
        public string ComponentGroupPrincipal { get; set; }
        public Nullable<decimal> ComponentSingleCarUsageAmount { get; set; }
        public Nullable<decimal> ComponentCharge1 { get; set; }
        public Nullable<decimal> ComponentCharge2 { get; set; }
        public Nullable<decimal> ComponentInventoryRequirement1Day { get; set; }
        public Nullable<decimal> ComponentInventoryRequirement3Day { get; set; }
        public Nullable<decimal> ComponentInventoryRequirement5Day { get; set; }
        public Nullable<decimal> ComponentInventoryRequirement10Day { get; set; }
        public string ProjectName { get; set; }
        public string WarehouseName { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierContractNo { get; set; }
        public Nullable<System.DateTime> SupplierStartDate { get; set; }
        public Nullable<System.DateTime> SupplierEndDate { get; set; }
        public Nullable<System.DateTime> SupplierInvoiceDate { get; set; }
        public Nullable<System.DateTime> SupplierBalanceDate { get; set; }
        public string SupplierFullName { get; set; }
        public string SupplierTaxpayerNumber { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierTel { get; set; }
        public string SupplierBankName { get; set; }
        public string SupplierBankAccount { get; set; }
        public string SupplierBankNo { get; set; }
        public string SupplierZipCode { get; set; }
        public string SupplierRecipientName { get; set; }
    }
}

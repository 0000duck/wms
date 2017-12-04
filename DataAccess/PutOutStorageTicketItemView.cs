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
        public int StockInfoID { get; set; }
        public int PutOutStorageTicketID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> ExceedStockAmount { get; set; }
        public Nullable<int> PutOutStorageTicketJobTicketID { get; set; }
        public string PutOutStorageTicketNo { get; set; }
        public string PutOutStorageTicketTruckLoadingTicketNo { get; set; }
        public string PutOutStorageTicketSourse { get; set; }
        public string PutOutStorageTicketWorkFlow { get; set; }
        public string PutOutStorageTicketState { get; set; }
        public string PutOutStorageTicketCarNum { get; set; }
        public string PutOutStorageTicketDriver { get; set; }
        public string PutOutStorageTicketSerialNo { get; set; }
        public string PutOutStorageTicketOriginalTicketType { get; set; }
        public string PutOutStorageTicketPullTicketNo { get; set; }
        public string PutOutStorageTicketCrossingNo { get; set; }
        public string PutOutStorageTicketReceiverNo { get; set; }
        public string PutOutStorageTicketSortTypeNo { get; set; }
        public Nullable<System.DateTime> PutOutStorageTicketTruckLoadingTime { get; set; }
        public Nullable<System.DateTime> PutOutStorageTicketDeliverTime { get; set; }
        public Nullable<int> PutOutStorageTicketCreateUserID { get; set; }
        public Nullable<System.DateTime> PutOutStorageTicketCreateTime { get; set; }
        public Nullable<int> PutOutStorageTicketLastUpdateUserID { get; set; }
        public Nullable<System.DateTime> PutOutStorageTicketLastUpdateTime { get; set; }
        public Nullable<int> JobTicketShipmentTicketID { get; set; }
        public string JobTicketJobTicketNo { get; set; }
        public string JobTicketJobType { get; set; }
        public string JobTicketJobGroupName { get; set; }
        public Nullable<decimal> JobTicketScheduledAmount { get; set; }
        public Nullable<decimal> JobTicketRealAmount { get; set; }
        public string JobTicketState { get; set; }
        public Nullable<int> JobTicketPrintedTimes { get; set; }
        public string JobTicketAssignmentArea { get; set; }
        public string JobTicketPersonInCharge { get; set; }
        public Nullable<int> JobTicketCreateUserID { get; set; }
        public Nullable<System.DateTime> JobTicketCreateTime { get; set; }
        public Nullable<int> JobTicketLastUpdateUserID { get; set; }
        public Nullable<System.DateTime> JobTicketLastUpdateTime { get; set; }
        public Nullable<int> ShipmentTicketProjectID { get; set; }
        public Nullable<int> ShipmentTicketWarehouseID { get; set; }
        public string ShipmentTicketNo { get; set; }
        public string ShipmentTicketType { get; set; }
        public string ShipmentTicketTypeNo { get; set; }
        public string ShipmentTicketSource { get; set; }
        public Nullable<decimal> ShipmentTicketSegmentationChainCount { get; set; }
        public string ShipmentTicketRelatedTicketNo { get; set; }
        public Nullable<System.DateTime> ShipmentTicketDate { get; set; }
        public Nullable<int> ShipmentTicketTicketNum { get; set; }
        public Nullable<System.DateTime> ShipmentTicketRequireArriveDate { get; set; }
        public string ShipmentTicketState { get; set; }
        public Nullable<decimal> ShipmentTicketScheduledAmount { get; set; }
        public Nullable<decimal> ShipmentTicketAllocatedAmount { get; set; }
        public Nullable<decimal> ShipmentTicketPickingAmount { get; set; }
        public Nullable<decimal> ShipmentTicketShipmentAmount { get; set; }
        public Nullable<decimal> ShipmentTicketExceedStorageAmount { get; set; }
        public string ShipmentTicketStation { get; set; }
        public string ShipmentTicketReverseTicketNo { get; set; }
        public string ShipmentTicketSortType { get; set; }
        public string ShipmentTicketProductionLine { get; set; }
        public string ShipmentTicketReceivingPersonName { get; set; }
        public string ShipmentTicketContactAddress { get; set; }
        public string ShipmentTicketDeliveryPath { get; set; }
        public string ShipmentTicketDescription { get; set; }
        public string ShipmentTicketCloseReason { get; set; }
        public Nullable<int> ShipmentTicketCreateUserID { get; set; }
        public Nullable<System.DateTime> ShipmentTicketCreateTime { get; set; }
        public Nullable<int> ShipmentTicketLastUpdateUserID { get; set; }
        public Nullable<System.DateTime> ShipmentTicketLastUpdateTime { get; set; }
        public Nullable<int> ShipmentTicketPrintTimes { get; set; }
        public Nullable<int> ShipmentTicketWaitingToBeDone { get; set; }
        public string ShipmentTicketDeliveryTicketNo { get; set; }
        public string ShipmentTicketOuterPhysicalDistributionPath { get; set; }
        public string ShipmentTicketDeliveryPoint { get; set; }
        public Nullable<int> ShipmentTicketEmergency { get; set; }
        public string ShipmentTicketShipmentPlaceNo { get; set; }
        public Nullable<int> ShipmentTicketBoardPrintedTimes { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> StockInfoPutawayTicketItemID { get; set; }
        public Nullable<int> PutawayTicketItemPutawayTicketID { get; set; }
        public Nullable<int> PutawayTicketItemReceiptTicketItemID { get; set; }
        public string PutawayTicketItemDisplacementPositionNo { get; set; }
        public string PutawayTicketItemTargetStorageLocation { get; set; }
        public string PutawayTicketItemBoardNo { get; set; }
        public string PutawayTicketItemState { get; set; }
        public Nullable<decimal> PutawayTicketItemScheduledMoveCount { get; set; }
        public Nullable<decimal> PutawayTicketItemDistrabuteCount { get; set; }
        public Nullable<decimal> PutawayTicketItemMoveCount { get; set; }
        public string PutawayTicketItemOperatePerson { get; set; }
        public string PutawayTicketItemOperateTime { get; set; }
        public string PutawayTicketNo { get; set; }
        public string PutawayTicketType { get; set; }
        public Nullable<int> PutawayTicketReceiptTicketID { get; set; }
        public string PutawayTicketState { get; set; }
        public Nullable<decimal> PutawayTicketScheduledDisplacementAmount { get; set; }
        public Nullable<decimal> PutawayTicketDisplacementAmount { get; set; }
        public Nullable<decimal> PutawayTicketDistributeAmount { get; set; }
        public Nullable<decimal> PutawayTicketPrintTimes { get; set; }
        public string PutawayTicketJobGroupName { get; set; }
        public Nullable<int> PutawayTicketCreateUserID { get; set; }
        public Nullable<System.DateTime> PutawayTicketCreateTime { get; set; }
        public Nullable<int> PutawayTicketLastUpdateUserID { get; set; }
        public Nullable<System.DateTime> PutawayTicketLastUpdateTime { get; set; }
        public Nullable<int> ReceiptTicketItemReceiptTicketID { get; set; }
        public Nullable<int> ReceiptTicketItemComponentID { get; set; }
        public string ReceiptTicketItemPackageName { get; set; }
        public Nullable<decimal> ReceiptTicketItemExpectedPackageAmount { get; set; }
        public Nullable<decimal> ReceiptTicketItemExpectedAmount { get; set; }
        public Nullable<decimal> ReceiptTicketItemReceiviptAmount { get; set; }
        public Nullable<decimal> ReceiptTicketItemWrongComponentAmount { get; set; }
        public Nullable<decimal> ReceiptTicketItemShortageAmount { get; set; }
        public Nullable<decimal> ReceiptTicketItemDisqualifiedAmount { get; set; }
        public string ReceiptTicketItemManufactureNo { get; set; }
        public Nullable<System.DateTime> ReceiptTicketItemInventoryDate { get; set; }
        public Nullable<System.DateTime> ReceiptTicketItemManufactureDate { get; set; }
        public Nullable<System.DateTime> ReceiptTicketItemExpiryDate { get; set; }
        public string ReceiptTicketItemRealRightProperty { get; set; }
        public string ReceiptTicketItemBoxNo { get; set; }
        public Nullable<int> ReceiptTicketProjectID { get; set; }
        public Nullable<int> ReceiptTicketWarehouse { get; set; }
        public Nullable<int> ReceiptTicketSupplierID { get; set; }
        public string ReceiptTicketNo { get; set; }
        public string ReceiptTicketType { get; set; }
        public string ReceiptTicketState { get; set; }
        public string ReceiptTicketDeliverTicketNoSRM { get; set; }
        public string ReceiptTicketVoucherSource { get; set; }
        public string ReceiptTicketVoucherNo { get; set; }
        public string ReceiptTicketVoucherLineNo { get; set; }
        public Nullable<System.DateTime> ReceiptTicketVoucherYear { get; set; }
        public string ReceiptTicketReletedVoucherNo { get; set; }
        public string ReceiptTicketReletedVoucherLineNo { get; set; }
        public Nullable<System.DateTime> ReceiptTicketReletedVoucherYear { get; set; }
        public string ReceiptTicketHeadingText { get; set; }
        public Nullable<System.DateTime> ReceiptTicketPostCountDate { get; set; }
        public string ReceiptTicketInwardDeliverTicketNo { get; set; }
        public string ReceiptTicketInwardDeliverLineNo { get; set; }
        public string ReceiptTicketOutwardDeliverTicketNo { get; set; }
        public string ReceiptTicketOutwardDeliverLineNo { get; set; }
        public string ReceiptTicketPurchaseTicketNo { get; set; }
        public string ReceiptTicketPurchaseTicketLineNo { get; set; }
        public Nullable<System.DateTime> ReceiptTicketOrderDate { get; set; }
        public string ReceiptTicketReceiptStorageLocation { get; set; }
        public string ReceiptTicketBoardNo { get; set; }
        public string ReceiptTicketReceiptPackage { get; set; }
        public Nullable<decimal> ReceiptTicketExpectedAmount { get; set; }
        public Nullable<decimal> ReceiptTicketReceiptCount { get; set; }
        public string ReceiptTicketMoveType { get; set; }
        public string ReceiptTicketSource { get; set; }
        public string ReceiptTicketAssignmentPerson { get; set; }
        public Nullable<int> ReceiptTicketPostedCount { get; set; }
        public string ReceiptTicketBoxNo { get; set; }
        public Nullable<int> ReceiptTicketCreateUserID { get; set; }
        public Nullable<System.DateTime> ReceiptTicketCreateTime { get; set; }
        public Nullable<int> ReceiptTicketLastUpdateUserID { get; set; }
        public Nullable<System.DateTime> ReceiptTicketLastUpdateTime { get; set; }
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
    }
}

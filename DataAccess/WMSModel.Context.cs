﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WMSEntities : DbContext
    {
        public WMSEntities()
            : base("name=WMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Component> Component { get; set; }
        public DbSet<JobTicket> JobTicket { get; set; }
        public DbSet<JobTicketItem> JobTicketItem { get; set; }
        public DbSet<PackageUnit> PackageUnit { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<PutawayTicket> PutawayTicket { get; set; }
        public DbSet<PutawayTicketItem> PutawayTicketItem { get; set; }
        public DbSet<PutOutStorageTicket> PutOutStorageTicket { get; set; }
        public DbSet<PutOutStorageTicketItem> PutOutStorageTicketItem { get; set; }
        public DbSet<ReceiptTicket> ReceiptTicket { get; set; }
        public DbSet<ReceiptTicketItem> ReceiptTicketItem { get; set; }
        public DbSet<ShipmentTicket> ShipmentTicket { get; set; }
        public DbSet<ShipmentTicketItem> ShipmentTicketItem { get; set; }
        public DbSet<StockInfo> StockInfo { get; set; }
        public DbSet<StockInfoCheckTicket> StockInfoCheckTicket { get; set; }
        public DbSet<StockInfoCheckTicketItem> StockInfoCheckTicketItem { get; set; }
        public DbSet<SubmissionTicket> SubmissionTicket { get; set; }
        public DbSet<SubmissionTicketItem> SubmissionTicketItem { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierStorageInfo> SupplierStorageInfo { get; set; }
        public DbSet<Supply> Supply { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<ComponentView> ComponentView { get; set; }
        public DbSet<JobTicketItemView> JobTicketItemView { get; set; }
        public DbSet<JobTicketView> JobTicketView { get; set; }
        public DbSet<PackageUnitView> PackageUnitView { get; set; }
        public DbSet<PersonView> PersonView { get; set; }
        public DbSet<ProjectView> ProjectView { get; set; }
        public DbSet<PutawayTicketItemView> PutawayTicketItemView { get; set; }
        public DbSet<PutawayTicketView> PutawayTicketView { get; set; }
        public DbSet<PutOutStorageTicketItemView> PutOutStorageTicketItemView { get; set; }
        public DbSet<PutOutStorageTicketView> PutOutStorageTicketView { get; set; }
        public DbSet<ReceiptTicketItemView> ReceiptTicketItemView { get; set; }
        public DbSet<ReceiptTicketView> ReceiptTicketView { get; set; }
        public DbSet<ShipmentTicketItemView> ShipmentTicketItemView { get; set; }
        public DbSet<ShipmentTicketView> ShipmentTicketView { get; set; }
        public DbSet<StockInfoCheckTicketItemView> StockInfoCheckTicketItemView { get; set; }
        public DbSet<StockInfoCheckTicketView> StockInfoCheckTicketView { get; set; }
        public DbSet<StockInfoView> StockInfoView { get; set; }
        public DbSet<SubmissionTicketItemView> SubmissionTicketItemView { get; set; }
        public DbSet<SubmissionTicketView> SubmissionTicketView { get; set; }
        public DbSet<SupplierStorageInfoView> SupplierStorageInfoView { get; set; }
        public DbSet<SupplierView> SupplierView { get; set; }
        public DbSet<SupplyView> SupplyView { get; set; }
        public DbSet<UserView> UserView { get; set; }
        public DbSet<WarehouseView> WarehouseView { get; set; }
    }
}

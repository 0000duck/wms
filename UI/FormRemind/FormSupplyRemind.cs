﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using WMS.UI.FormReceipt;
using WMS.UI.FormBase;
using WMS.DataAccess;
using System.Diagnostics;
using System.Threading;
using System.Data.SqlClient;
namespace WMS.UI
{
    public partial class FormSupplyRemind : Form
    {
        string remind;
        //       
        public  StringBuilder stringBuilder = new StringBuilder();
        private int projectID = GlobalData.ProjectID;
        private int warehouseID = GlobalData.WarehouseID;
        Button  button= null;
        string remind_Text;
        public FormSupplyRemind(Button button,string remind_Text)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.button = button;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.remind_Text = remind_Text;
            
            //计时
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 10000;//执行间隔时间,单位为毫秒  一千分之一
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Elapsed);
        }

        private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            RemindStockinfo();
            RefreshDate();
            //MessageBox.Show("执行了一次程序");
        }

        public void RemindStockinfo()
        {
            this.stringBuilder = new StringBuilder();
            try
            {
                WMSEntities  wmsEntities = new WMSEntities();
                string sql = "";
                sql = "select TOP 50 SupplyView.SupplierName,SupplyView.ComponentName,SupplyView.No,(select (sum(StockInfoView.ShipmentAreaAmount)+sum(StockInfoView.OverflowAreaAmount)) from StockInfoView where SupplyView.No =StockInfoView.SupplyNo) stock_Sum,SupplyView.SafetyStock from SupplyView where (select (sum(StockInfoView.ShipmentAreaAmount)+sum(StockInfoView.OverflowAreaAmount)) from StockInfoView where SupplyView.No =StockInfoView.SupplyNo)<SupplyView.SafetyStock and IsHistory =0";
                sql = sql + "and ProjectID=" + GlobalData.ProjectID;
                sql = sql + "and WarehouseID=" + GlobalData.WarehouseID;
                wmsEntities.Database.Connection.Open();
                DataTable DataTabledt1 = new DataTable();// 实例化数据表
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, (SqlConnection)wmsEntities.Database.Connection);
                sqlDataAdapter.Fill(DataTabledt1);
                wmsEntities.Database.Connection.Close();
                int count = DataTabledt1.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    string SupplierName = DataTabledt1.Rows[i][0].ToString();
                    string ComponentName = DataTabledt1.Rows[i][1].ToString();
                    string No = DataTabledt1.Rows[i][2].ToString();
                    string stock_Sum = DataTabledt1.Rows[i][3].ToString();
                    string SaftyStock = DataTabledt1.Rows[i][4].ToString();
                    stringBuilder.Append(SupplierName + " " + ComponentName + " " + No + " " + "库存量" + " " + stock_Sum + " " + "已小于安全库存" + " " + SaftyStock + "\r\n" + "\r\n");
                }
                //日期查询
                string sql1 = "";
                sql1 = @"select TOP 50 StockInfoView.SupplierName,StockInfoView.ComponentName,StockInfoView.SupplyNo,StockInfoView.InventoryDate ,
                       (select SupplyView.ValidPeriod  from SupplyView where StockInfoView.SupplyID = SupplyView.ID  )ValidPeriod,(select SupplyView.IsHistory from SupplyView where StockInfoView.SupplyID = SupplyView.ID )IsHIstory,
                       GETDATE() Date_Now,(select dateadd(day, (select SupplyView.ValidPeriod from SupplyView where StockInfoView.SupplyID = SupplyView.ID), StockInfoView.InventoryDate))EndDate ,datediff(day, GETDATE(), (select dateadd(day, (select SupplyView.ValidPeriod from SupplyView where StockInfoView.SupplyID = SupplyView.ID), StockInfoView.InventoryDate))) dayss
                       from StockInfoView where(select SupplyView.IsHistory from SupplyView where StockInfoView.SupplyID= SupplyView.ID)= 0
                        and datediff(day, GETDATE(), (select dateadd(day, (select SupplyView.ValidPeriod from SupplyView where StockInfoView.SupplyID= SupplyView.ID), StockInfoView.InventoryDate)))<= 30";

                sql1 = sql1 + "and ProjectID=" + GlobalData.ProjectID;
                sql1 = sql1 + "and WarehouseID=" + GlobalData.WarehouseID;

                DataTable DataTabledt2 = new DataTable();// 实例化数据表
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sql1, (SqlConnection)wmsEntities.Database.Connection);
                sqlDataAdapter2.Fill(DataTabledt2);
                int count2 = DataTabledt2.Rows.Count;
                wmsEntities.Database.Connection.Close();

                for (int j = 0; j < count2; j++)
                {
                    string SupplierName = DataTabledt2.Rows[j][0].ToString();
                    string ComponentName = DataTabledt2.Rows[j][1].ToString();
                    string SupplyNo = DataTabledt2.Rows[j][2].ToString();
                    string InventoryDate = DataTabledt2.Rows[j][3].ToString();
                    string days = DataTabledt2.Rows[j][8].ToString();
                    if (Convert.ToInt32(days) <= 0)
                    {
                        stringBuilder.Append(SupplierName + "  " + ComponentName + "  " + SupplyNo + "  " + "存货日期" + " " + InventoryDate + "  " + "已过期" + "\r\n" + "\r\n");
                    }
                    else if (Convert.ToInt32(days) > 0)

                    {
                        stringBuilder.Append(SupplierName + "  " + ComponentName + "  " + SupplyNo + "  " + "存货日期" + " " + InventoryDate + "  " + "有效期还剩" + days + "天" + "\r\n" + "\r\n");
                    }

                }
            }
            catch
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Append("刷新失败，请检查网络连接");            
                return;
            }
        }






        //public void ClearTextBox()
        // {
        //     this.stringBuilder = new StringBuilder();
        // }

        // public void RefreshID()
        // {
        //     this.projectID = GlobalData.ProjectID;
        //     this.warehouseID = GlobalData.WarehouseID;
        // }

        //public   void RemindSupply()
        //{
        //    DateTime before = DateTime.Now;
        //    //存货有效期
        //    WMSEntities wmsEntities = new WMSEntities();
        //    StockInfoView[] stockInfoView = null;
        //    try
        //    {
        //        stockInfoView = (from u in wmsEntities.StockInfoView
        //                         where u.ProjectID ==this.projectID &&
        //                         u.WarehouseID ==this.warehouseID 
        //                         select u).ToArray();

        //        if(stockInfoView ==null)
        //        {
        //            return;
        //        }

        //        for (int i = 0; i < stockInfoView.Length; i++)
        //        {
        //            //找到每个零件的保质期
        //            string ComponentName = stockInfoView[i].ComponentName;
        //            string SupplierName = stockInfoView[i].SupplierName;
        //            string SupplyNo = stockInfoView[i].SupplyNo;
        //            if (ComponentName == null || SupplierName == null || SupplyNo == null || stockInfoView[i].InventoryDate == null)
        //            {

        //                continue;
        //            }
        //            DateTime InventoryDate = Convert.ToDateTime(stockInfoView[i].InventoryDate);
        //            var SafetyDate1 = (from u in wmsEntities.SupplyView
        //                               where u.ComponentName == ComponentName &&
        //                               u.SupplierName == SupplierName &&
        //                               u.No == SupplyNo&&u.ProjectID ==this.projectID 
        //                               &&u.WarehouseID ==this.warehouseID &&u.IsHistory ==0
        //                               select u).FirstOrDefault();
        //            if(SafetyDate1 == null)
        //            {
        //                continue;
        //            }

        //            //到期日期
        //            if (SafetyDate1.ValidPeriod == null)
        //            {
        //                continue;
        //            }
        //            var SafetyDate = InventoryDate.AddDays(Convert.ToDouble(SafetyDate1.ValidPeriod));
        //            int day;
        //            day = ( SafetyDate-DateTime .Now ).Days;
        //            if (day<=30&&day>0)
        //            {
        //                stringBuilder.Append(SupplierName + "  " + ComponentName + "  " + SupplyNo + "  " + "存货日期" + " " + InventoryDate +"  " +"有效期还剩"+day+"天"+"\r\n" + "\r\n");
        //            }
        //            else if (day <= 0)
        //            {
        //                stringBuilder.Append(SupplierName + "  " + ComponentName + "  " + SupplyNo + "  " + "存货日期" + " " + InventoryDate + "  " + "已过期"  + "\r\n" + "\r\n");
        //            }

        //        }
        //    }catch

        //    {
        //        stringBuilder = new StringBuilder();
        //        stringBuilder.Append("刷新失败,请检查网络连接");
        //        return;
        //    }
        //    Console.WriteLine("刷新供货预警提醒花费时间：{0}毫秒", (DateTime.Now - before).TotalMilliseconds);
        //}

        //public void RemindStock()
        //{
        //    DateTime before = DateTime.Now;
        //    WMSEntities wmsEntities = new WMSEntities();
        //    SupplyView[] supplyView = null;
        //    try
        //    {
        //        supplyView = (from u in wmsEntities.SupplyView
        //                      where u.ProjectID ==this.projectID 
        //                      &&u.WarehouseID ==this.warehouseID 
        //                      &&u.IsHistory ==0
        //                      select u).ToArray();

        //        if(supplyView ==null)
        //        {
        //            return;
        //        }
        //        for (int i = 0; i < supplyView.Length; i++)
        //        {
        //            decimal amount = 0;
        //            string ComponentName = supplyView[i].ComponentName;
        //            string SupplierName = supplyView[i].SupplierName;
        //            string SupplyNo = supplyView[i].No;
        //            decimal SaftyStock;
        //            StockInfoView[] stockInfo = null;
        //            if (supplyView[i].SafetyStock == null)
        //            {
        //                continue;
        //            }
        //            int suppluID = supplyView[i].ID;
        //            stockInfo = (from kn in wmsEntities.StockInfoView
        //                         where kn.SupplyID == suppluID &&
        //                         kn.WarehouseID ==this.warehouseID &&
        //                         kn.ProjectID ==this.projectID 
        //                         select kn).ToArray();
        //            if (stockInfo == null)
        //            {
        //                continue;
        //            }
        //            SaftyStock = Convert.ToDecimal(supplyView[i].SafetyStock);

        //            for (int j = 0; j < stockInfo.Length; j++)

        //            {
        //                amount = amount+Convert.ToDecimal(stockInfo[j].OverflowAreaAmount) + Convert.ToDecimal(stockInfo[j].ShipmentAreaAmount);
        //            }

        //            if (amount < SaftyStock)
        //            {
        //                stringBuilder.Append(SupplierName + "  " + ComponentName + "  " + SupplyNo + "  " + "库存量" + "  " + amount + "  " + "已小于安全库存" + "   " + SaftyStock + "\r\n" + "\r\n");

        //            }
        //        }
        //    }
        //    catch
        //    {
        //        stringBuilder = new StringBuilder();
        //        stringBuilder.Append("刷新失败2,请检查网络连接");
        //        return;
        //    }
        //    Console.WriteLine("刷新库存提醒花费时间：{0}毫秒",(DateTime.Now - before).TotalMilliseconds);
        //}

        public void TextDeliver()
        {
            

        }

        private void FormSupplyRemind_Load(object sender, EventArgs e)
        {    
            this.Left = 3;
            this.Top = (int)(0.7 * Screen.PrimaryScreen.Bounds.Height);
            this.Width = (int)(0.35 * Screen.PrimaryScreen.Bounds.Width );
            this.Height = (int)(0.25 * Screen.PrimaryScreen.Bounds.Height);//75
            this.textBox1.Text = "数据加载中...";                  
            this.ShowInTaskbar = false;///使窗体不显示在任务栏           
           //Thread thread = new Thread(loadData1);
            new Thread(() =>
            {
                textBox1.Text = this.remind_Text;
                if (this.textBox1.Text == "刷新失败，请检查网络连接")
                {
                    this.textBox1.ForeColor = Color.Red;
                }
                else
                {
                    this.textBox1.ForeColor = Color.Black;
                }
            }).Start();

        }

        private void loadData1()
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.BeginInvoke(new Action(() => textBox1.Text = this.remind_Text ));
            }
            if (this.textBox1.Text == "刷新失败，请检查网络连接")
            {
                this.textBox1.ForeColor = Color.Red;
            }
            else
            {
                this.textBox1.ForeColor = Color.Black;
            }
        }


        public void loadData()
        {
            //加载数据         

            if (textBox1.InvokeRequired)
            {
                textBox1.BeginInvoke(new Action(() => textBox1.Text = this.stringBuilder .ToString () ));
            }

            if (this.textBox1.Text == "刷新失败，请检查网络连接")
            {
                this.textBox1.ForeColor = Color.Red;
            }
            else
            {
                this.textBox1.ForeColor = Color.Black;
            }
        }
        public void RefreshDate()
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //Thread thread = new Thread(loadData);
            //thread.Start();
            //this.textBox1.Text = "数据加载中...";
            //new Thread(() =>
            //{
            string a = stringBuilder.ToString();
            //sw.Stop();
            //TimeSpan ts = sw.Elapsed;
            //MessageBox.Show("转换所用时间" + ts.ToString());
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            this.textBox1.Text = a;
            sw1.Stop();
            TimeSpan ts3 = sw1.Elapsed;
            MessageBox.Show("显示所用时间" + ts3.ToString());
            if (this.textBox1.Text == "刷新失败，请检查网络连接")
            {
                this.textBox1.ForeColor = Color.Red;
            }
            else
            {
                this.textBox1.ForeColor = Color.Black;
             }

            //}).Start();

        }

        private void FormSupplyRemind_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            this.button.Visible = true;           
        }
    }

    
}

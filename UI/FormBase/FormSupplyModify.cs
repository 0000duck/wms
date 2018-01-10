﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.DataAccess;
using System.Reflection;

namespace WMS.UI
{
    public partial class FormSupplyModify : Form
    {
        private int projectID = -1;
        private int warehouseID = -1;
        private int userID = -1;
        private int supplyID = -1;
        private int supplierID = -1;
        private int componenID = -1;
        private WMSEntities wmsEntities = new WMSEntities();
        private Action<int> modifyFinishedCallback = null;
        private Action<int> addFinishedCallback = null;
        private FormMode mode = FormMode.ALTER;
        private int history_save = 0;

        public FormSupplyModify(int projectID, int warehouseID, int supplierID, int userID, int supplyID = -1)
        {
            InitializeSupply();
            this.warehouseID = warehouseID;
            this.userID = userID;
            this.projectID = projectID;
            this.supplierID = supplierID;
            this.supplyID = supplyID;
        }
        
        private void FormSupplyModify_Load(object sender, EventArgs e)
        { 
            if (this.mode == FormMode.ALTER && this.supplyID == -1)
            {
                throw new Exception("未设置源零件信息");
            }

            Utilities.CreateEditPanel(this.tableLayoutPanelTextBoxes, SupplyViewMetaData.supplykeyNames);
            TextBox textboxsuppliername = (TextBox)this.Controls.Find("textBoxSupplierName", true)[0];
            TextBox textboxsuppliernumber = (TextBox)this.Controls.Find("textBoxSupplierNumber", true)[0];
            TextBox textboxLastUpdateUserUsername = (TextBox)this.Controls.Find("textBoxLastUpdateUserUsername", true)[0];
            TextBox textboxCreateUserUsername = (TextBox)this.Controls.Find("textBoxCreateUserUsername", true)[0];
            textboxsuppliername.ReadOnly = true;
            textboxsuppliernumber.ReadOnly = true;
            textboxLastUpdateUserUsername.ReadOnly = true;
            textboxCreateUserUsername.ReadOnly = true;


            if (this.mode == FormMode.ALTER)
            {
               
                try
                {
                    SupplyView supplyView = (from s in this.wmsEntities.SupplyView
                                                  where s.ID == this.supplyID
                                                  select s).Single();
                    Utilities.CopyPropertiesToTextBoxes(supplyView, this);
                }
                catch (Exception)
                {
                    MessageBox.Show("修改失败，请检查网络连接", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

            }

            this.Controls.Find("textBoxSupplierName", true)[0].Click += textBoxSupplierName_Click;
            this.Controls.Find("textBoxComponentName", true)[0].Click += textBoxComponentName_Click;
        }
        private void textBoxSupplierName_Click(object sender, EventArgs e)
        {
           
            var formSelectSupplier = new FormSelectSupplier();
            formSelectSupplier.SetSelectFinishCallback((selectedID) =>
            {
                WMSEntities wmsEntities = new WMSEntities();
                var supplierName = (from s in wmsEntities.SupplierView
                                       where s.ID == selectedID
                                       select s).FirstOrDefault();
                if (supplierName.Name == null)
                {
                    MessageBox.Show("选择供应商失败，供应商不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.supplierID = selectedID;
                this.Controls.Find("textBoxSupplierName", true)[0].Text = supplierName.Name;
                this.Controls.Find("textBoxSupplierNumber", true)[0].Text = supplierName.Number;
            });
            formSelectSupplier.Show();
            
        }
        private void textBoxComponentName_Click(object sender, EventArgs e)
        {

            var formSelectComponent = new FormSelectComponen();
            formSelectComponent.SetSelectFinishCallback((selectedID) =>
            {
                WMSEntities wmsEntities = new WMSEntities();
                var componenName = (from s in wmsEntities.ComponentView
                                    where s.ID == selectedID
                                    select s).FirstOrDefault();
                if (componenName.Name == null)
                {
                    MessageBox.Show("选择零件失败，零件不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.supplierID = selectedID;
                this.Controls.Find("textBoxComponentName", true)[0].Text = componenName.Name;
            });
            formSelectComponent.Show();

        }

        
        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult MsgBoxResult = DialogResult.No;//设置对话框的返回值
            var textBoxSupplierName = this.Controls.Find("textBoxSupplierName", true)[0];
            var textBoxNo = this.Controls.Find("textBoxNo", true)[0];
            var textBoxComponentName = this.Controls.Find("textBoxComponentName", true)[0];

            //询问是否保留历史信息
            if (this.mode == FormMode.ALTER && this.history_save == 0)
            {


                MsgBoxResult = MessageBox.Show("是否要保留历史信息", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,

                MessageBoxDefaultButton.Button2);
            }
            if (textBoxNo.Text == string.Empty)
            {
                MessageBox.Show("零件代号不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxComponentName.Text == string.Empty)
            {
                MessageBox.Show("零件名称不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (textBoxSupplierName.Text == string.Empty)
            {
                MessageBox.Show("请选择供应商！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string supplierName = textBoxSupplierName.Text;
                try
                {
                    Supplier supplierID = (from s in this.wmsEntities.Supplier where s.Name == supplierName && s.IsHistory == 0 select s).Single();

                    this.supplierID = supplierID.ID;
                }
                catch
                {

                }
            }



            //if (this.supplierID == -1)
            //{
            //    MessageBox.Show("请输入正确的供应商名称！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            DataAccess.Supply supply = null;
            if (this.mode == FormMode.ALTER)
            {

                try
                {
                    supply = (from s in this.wmsEntities.Supply
                                       where s.ID == this.supplyID
                                       select s).Single();
                }
                catch
                {
                    MessageBox.Show("修改失败，请检查网络连接", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (supply == null)
                {
                    MessageBox.Show("历史零件信息不存在，请重新查询", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (MsgBoxResult == DialogResult.Yes)//如果对话框的返回值是YES（按"Y"按钮）
                {
                    //新建零件保留历史信息
                    this.wmsEntities.Supply.Add(supply);

                    try
                    {
                        supply.ID = -1;
                        supply.IsHistory = 1;
                        supply.NewestSupplyID = this.supplyID;
                        supply.LastUpdateUserID = this.userID;
                        supply.LastUpdateTime = DateTime.Now;
                        wmsEntities.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("操作失败，请检查网络连接", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var supplystorge = (from u in wmsEntities.Supply
                                          where u.NewestSupplyID == this.supplyID
                                          select u).ToArray();


                    if (supplystorge.Length > 0)
                    {


                                    MessageBox.Show("历史信息保留成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.history_save = 1;
                    }



                    try
                    {
                        supply = (from s in this.wmsEntities.Supply
                                    where s.ID == this.supplyID
                                    select s).Single();
                    }
                    catch
                    {
                        MessageBox.Show("修改失败，请检查网络连接", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (supply == null)
                    {
                        MessageBox.Show("零件信息不存在，请重新查询", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            else if (mode == FormMode.ADD)
            {
                supply = new DataAccess.Supply();
                this.wmsEntities.Supply.Add(supply);
                supply.CreateUserID = this.userID;
                supply.CreateTime = DateTime.Now;

            }
            supply.LastUpdateUserID = this.userID;
            supply.LastUpdateTime = DateTime.Now;
            supply.ProjectID = this.projectID;
            supply.WarehouseID = this.warehouseID;
            supply.SupplierID = this.supplierID;


            //开始数据库操作
            if (Utilities.CopyTextBoxTextsToProperties(this, supply, SupplyViewMetaData.supplykeyNames, out string errorMessage) == false)
            {
                MessageBox.Show(errorMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Utilities.CopyComboBoxsToProperties(this, supply, SupplyViewMetaData.KeyNames);
            }
            supply.IsHistory = 0;
            wmsEntities.SaveChanges();

            //调用回调函数
            if (this.mode == FormMode.ALTER && this.modifyFinishedCallback != null)
            {
                this.modifyFinishedCallback(supply.ID);
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if(this.mode == FormMode.ADD && this.addFinishedCallback != null)
            {
                this.addFinishedCallback(supply.ID);
                MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            
        }

        public void SetModifyFinishedCallback(Action<int> callback)
        {
            this.modifyFinishedCallback = callback;
        }

        public void SetAddFinishedCallback(Action<int> callback)
        {
            this.addFinishedCallback = callback;
        }

        public void SetMode(FormMode mode)
        {
            this.mode = mode;
            if(mode == FormMode.ALTER)
            {
                this.Text = "修改零件信息";
                this.groupBox1.Text = "修改零件信息";
                this.buttonOK.Text = "修改零件信息";
            }else if (mode == FormMode.ADD)
            {
                this.Text = "添加零件信息";
                this.groupBox1.Text = "添加零件信息";
                this.buttonOK.Text = "添加零件信息";
            }
        }

        private void buttonOK_MouseEnter(object sender, EventArgs e)
        {
            buttonOK.BackgroundImage = WMS.UI.Properties.Resources.bottonB2_s;
        }

        private void buttonOK_MouseLeave(object sender, EventArgs e)
        {
            buttonOK.BackgroundImage = WMS.UI.Properties.Resources.bottonB2_q;
        }

        private void buttonOK_MouseDown(object sender, MouseEventArgs e)
        {
            buttonOK.BackgroundImage = WMS.UI.Properties.Resources.bottonB3_q;
        }
    }
}
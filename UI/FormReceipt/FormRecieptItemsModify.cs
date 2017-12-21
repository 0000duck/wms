﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.DataAccess;
using WMS.UI.FormReceipt;

namespace WMS.UI
{
    public partial class FormReceiptItemsModify : Form
    {
        FormMode formMode;
        WMSEntities wmsEntities = new WMSEntities();
        int receiptTicketItemID;
        Action CallBack = null;
        private int componentID;
        int receiptTicketID;
        public FormReceiptItemsModify()
        {
            InitializeComponent();
        }
        public FormReceiptItemsModify(FormMode formMode, int receiptTicketItemsID, int receiptTicketID)
        {
            InitializeComponent();
            this.formMode = formMode;
            this.receiptTicketItemID = receiptTicketItemsID;
            this.receiptTicketID = receiptTicketID;
        }

        public void SetCallBack(Action action)
        {
            this.CallBack = action;
        }

        private void FormRecieptTicketItemsModify_Load(object sender, EventArgs e)
        {
            this.tableLayoutPanelTextBoxes.Controls.Clear();
            for (int i = 0; i < ReceiptMetaData.itemsKeyName.Length; i++)
            {
                KeyName curKeyName = ReceiptMetaData.itemsKeyName[i];
                if (curKeyName.Visible == false && curKeyName.Editable == false)
                {
                    continue;
                }
                Label label = new Label();
                label.Text = curKeyName.Name;
                this.tableLayoutPanelTextBoxes.Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Name = "textBox" + curKeyName.Key;
                if (this.formMode == FormMode.ALTER && curKeyName.Editable == false)
                {
                    textBox.Enabled = false;
                }
                //Console.WriteLine("{0}  {1}", label.Text, textBox.Name);

                this.tableLayoutPanelTextBoxes.Controls.Add(textBox);
            }
            if (this.formMode == FormMode.ALTER)
            {

                ReceiptTicketItemView receiptTicketItemView = (from s in this.wmsEntities.ReceiptTicketItemView
                                                               where s.ID == this.receiptTicketItemID
                                                               select s).Single();
                Utilities.CopyPropertiesToTextBoxes(receiptTicketItemView, this);

            }
            //this.Controls.Find("textBoxReceiptTicketID", true)[0].Enabled = false;
            //this.Controls.Find("textBoxReceiptTicketID", true)[0].Text = this.receiptTicketID.ToString();
            this.Controls.Find("textBoxComponentNo", true)[0].Click += textBoxComponentID_Click;
            this.Controls.Find("textBoxComponentName", true)[0].Enabled = false;
        }

        private void textBoxComponentID_Click(object sender, EventArgs e)
        {
            FormSearch formSearch = new FormSearch();
            formSearch.Show();
            formSearch.SetSelectFinishCallback(new Action<int>((int ID) =>
            {
                //Console.WriteLine(ID);
                WMS.DataAccess.Component component = (from c in wmsEntities.Component where c.ID == ID select c).FirstOrDefault();
                if (component != null)
                {
                    //this.Controls.Find("textBoxComponentID", true)[0].Text = ID.ToString();
                    this.Controls.Find("textBoxComponentName", true)[0].Text = component.Name;
                    this.Controls.Find("textBoxComponentNo", true)[0].Text = component.No;
                    this.componentID = ID;
                }
                else
                {
                    MessageBox.Show("找不到该零件");
                }
            }));
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.formMode == FormMode.ALTER)
            {
                ReceiptTicketItem receiptTicketItem = (from s in this.wmsEntities.ReceiptTicketItem
                                                       where s.ID == this.receiptTicketItemID
                                                       select s).Single();
                string errorInfo;
                if (Utilities.CopyTextBoxTextsToProperties(this, receiptTicketItem, ReceiptMetaData.itemsKeyName, out errorInfo) == true)
                {
                    wmsEntities.SaveChanges();
                    MessageBox.Show("Successful");
                    CallBack();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(errorInfo);
                    CallBack();
                }
            }
            else  if(this.formMode == FormMode.ADD)
            {
                //this.Controls.Find("textBoxReceiptTicketID", true)[0].Text = this.receiptTicketID.ToString();
                ReceiptTicketItem receiptTicketItem = new ReceiptTicketItem();
                string errorInfo;
                if(Utilities.CopyTextBoxTextsToProperties(this, receiptTicketItem, ReceiptMetaData.itemsKeyName, out errorInfo) == true)
                {
                    receiptTicketItem.ReceiptTicketID = this.receiptTicketID;
                    receiptTicketItem.ID = 0;
                    receiptTicketItem.ComponentID = this.componentID;
                    wmsEntities.ReceiptTicketItem.Add(receiptTicketItem);
                    wmsEntities.SaveChanges();
                    MessageBox.Show("Successful");
                    CallBack();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(errorInfo);
                    CallBack();
                }
            }
        }
    }
}

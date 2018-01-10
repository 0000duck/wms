﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.DataAccess;
using WMS.UI;
using unvell.ReoGrid;
using System.Threading;

namespace WMS.UI.FormReceipt
{
    public partial class FormSearch : Form
    {
        private WMSEntities wmsEntities = new WMSEntities();
        private int ComponentID = -1;
        private int supplierID = -1;
        //private Action CallBack = null;
        private Action<int> selectFinishCallback = null;
        public FormSearch()
        {
            InitializeComponent();
        }

        public FormSearch(int supplierID)
        {
            InitializeComponent();
            this.supplierID = supplierID;
        }

        public void SetSelectFinishCallback(Action<int> selectFinishedCallback)
        {
            this.selectFinishCallback = selectFinishedCallback;
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            InitComponent();
            WMSEntities wmsEntities = new WMSEntities();
            //this.textBoxSearchContition.Text = (from s in wmsEntities.Component where s.s select s.).FirstOrDefault();
            this.Search();
        }

        private void InitComponent()
        {
            this.comboBoxSearchCondition.SelectedIndex = 0;

            //初始化表格
            var worksheet = this.reoGridControlMain.Worksheets[0];
            worksheet.SelectionMode = WorksheetSelectionMode.Row;
            for (int i = 0; i < ReceiptMetaData.componentKeyName.Length; i++)
            {
                worksheet.ColumnHeaders[i].Text = ReceiptMetaData.componentKeyName[i].Name;
                worksheet.ColumnHeaders[i].IsVisible = ReceiptMetaData.componentKeyName[i].Visible;
            }
            worksheet.Columns = ReceiptMetaData.componentKeyName.Length; //限制表的长度
        }

        private void Search()
        {
            string value = this.textBoxSearchContition.Text;
            string key = this.comboBoxSearchCondition.SelectedItem.ToString();
            this.labelStatus.Text = "正在搜索...";
            new Thread(new ThreadStart(() =>
            {
                WMS.DataAccess.ComponentView[] componentView = null;
                if (key == "零件编号")
                {
                    componentView = (from s in this.wmsEntities.ComponentView
                                      where s.No == value
                                      select s).ToArray();
                }
                else if (key == "零件名称")
                {
                    componentView = (from s in this.wmsEntities.ComponentView
                                      where s.Name.Contains(value)
                                      select s).ToArray();
                }
                else
                {
                    MessageBox.Show("内部错误，无法识别查询条件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.Invoke(new Action(() =>
                {
                    var worksheet = this.reoGridControlMain.Worksheets[0];
                    worksheet.DeleteRangeData(RangePosition.EntireRange);
                    for (int i = 0; i < componentView.Length; i++)
                    {
                        WMS.DataAccess.ComponentView curComponent = componentView[i];
                        object[] columns = Utilities.GetValuesByPropertieNames(curComponent, (from kn in ReceiptMetaData.componentKeyName select kn.Key).ToArray());
                        for (int j = 0; j < worksheet.Columns; j++)
                        {
                            worksheet[i, j] = columns[j] == null ? "" : columns[j].ToString();
                        }
                    }
                    if (componentView.Length == 0)
                    {
                        worksheet[0, 2] = "没有查询到符合条件的记录";
                    }
                    this.labelStatus.Text = "搜索完成";
                }));
            })).Start();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            this.SelectItem();
        }

        private void SelectItem()
        {
            int[] ids = this.GetSelectedIDs();
            if (ids.Length != 1)
            {
                MessageBox.Show("请选择一项");
                return;
            }
            this.selectFinishCallback?.Invoke(ids[0]);
            this.Close();
        }

        private int[] GetSelectedIDs()
        {
            List<int> ids = new List<int>();
            var worksheet = this.reoGridControlMain.Worksheets[0];
            for (int row = worksheet.SelectionRange.Row; row <= worksheet.SelectionRange.EndRow; row++)
            {
                if (worksheet[row, 0] == null) continue;
                if (int.TryParse(worksheet[row, 0].ToString(), out int shipmentTicketID))
                {
                    ids.Add(shipmentTicketID);
                }
            }
            return ids.ToArray();
        }
    }


}
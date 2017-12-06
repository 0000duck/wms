﻿namespace WMS.UI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("用户管理");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("供应商");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("零件");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("仓库");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("项目");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("基本信息", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("到货管理");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("上架管理");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("收货管理", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("发货单管理");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("作业单管理");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("出库单管理");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("发货管理", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("库存信息");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("库存日志");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("库存汇总");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("库存信息", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16});
            this.panelTop = new System.Windows.Forms.Panel();
            this.tableLayoutBanner = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelAuth = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.comboBoxProject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelFill = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.treeViewLeft = new System.Windows.Forms.TreeView();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.tableLayoutBanner.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.tableLayoutBanner);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(762, 100);
            this.panelTop.TabIndex = 0;
            // 
            // tableLayoutBanner
            // 
            this.tableLayoutBanner.BackColor = System.Drawing.Color.RoyalBlue;
            this.tableLayoutBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutBanner.ColumnCount = 2;
            this.tableLayoutBanner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBanner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 467F));
            this.tableLayoutBanner.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutBanner.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutBanner.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBanner.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutBanner.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutBanner.Name = "tableLayoutBanner";
            this.tableLayoutBanner.RowCount = 2;
            this.tableLayoutBanner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBanner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutBanner.Size = new System.Drawing.Size(762, 100);
            this.tableLayoutBanner.TabIndex = 3;
            // 
            // panel3
            // 
            this.tableLayoutBanner.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(758, 52);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "安途丰达WMS物流管理系统";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.labelUsername);
            this.panel1.Controls.Add(this.labelAuth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 58);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 40);
            this.panel1.TabIndex = 3;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Location = new System.Drawing.Point(4, 1);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(61, 23);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "用户名";
            // 
            // labelAuth
            // 
            this.labelAuth.AutoSize = true;
            this.labelAuth.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelAuth.ForeColor = System.Drawing.Color.White;
            this.labelAuth.Location = new System.Drawing.Point(84, 1);
            this.labelAuth.Name = "labelAuth";
            this.labelAuth.Size = new System.Drawing.Size(44, 23);
            this.labelAuth.TabIndex = 2;
            this.labelAuth.Text = "权限";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(297, 58);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 40);
            this.panel2.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel2.Controls.Add(this.comboBoxWarehouse, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxProject, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(463, 40);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWarehouse.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(299, 3);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(161, 31);
            this.comboBoxWarehouse.TabIndex = 0;
            this.comboBoxWarehouse.SelectedIndexChanged += new System.EventHandler(this.comboBoxWarehouse_SelectedIndexChanged);
            // 
            // comboBoxProject
            // 
            this.comboBoxProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProject.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.comboBoxProject.FormattingEnabled = true;
            this.comboBoxProject.Location = new System.Drawing.Point(64, 2);
            this.comboBoxProject.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxProject.Name = "comboBoxProject";
            this.comboBoxProject.Size = new System.Drawing.Size(163, 31);
            this.comboBoxProject.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(231, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "仓库";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-3, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 40);
            this.label3.TabIndex = 3;
            this.label3.Text = "项目";
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.tableLayoutPanel1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 100);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(762, 439);
            this.panelFill.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelRight, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(762, 439);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.treeViewLeft);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(2, 2);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(263, 435);
            this.panelLeft.TabIndex = 0;
            // 
            // treeViewLeft
            // 
            this.treeViewLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewLeft.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.treeViewLeft.Location = new System.Drawing.Point(0, 0);
            this.treeViewLeft.Name = "treeViewLeft";
            treeNode1.Name = "节点11";
            treeNode1.Text = "用户管理";
            treeNode2.Name = "节点12";
            treeNode2.Text = "供应商";
            treeNode3.Name = "节点13";
            treeNode3.Text = "零件";
            treeNode4.Name = "节点14";
            treeNode4.Text = "仓库";
            treeNode5.Name = "节点0";
            treeNode5.Text = "项目";
            treeNode6.Name = "节点1";
            treeNode6.Text = "基本信息";
            treeNode7.Name = "节点21";
            treeNode7.Text = "到货管理";
            treeNode8.Name = "节点22";
            treeNode8.Text = "上架管理";
            treeNode9.Name = "节点2";
            treeNode9.Text = "收货管理";
            treeNode10.Name = "节点31";
            treeNode10.Text = "发货单管理";
            treeNode11.Name = "节点32";
            treeNode11.Text = "作业单管理";
            treeNode12.Name = "节点33";
            treeNode12.Text = "出库单管理";
            treeNode13.Name = "节点3";
            treeNode13.Text = "发货管理";
            treeNode14.Name = "节点41";
            treeNode14.Text = "库存信息";
            treeNode15.Name = "节点42";
            treeNode15.Text = "库存日志";
            treeNode16.Name = "节点43";
            treeNode16.Text = "库存汇总";
            treeNode17.Name = "节点4";
            treeNode17.Text = "库存信息";
            this.treeViewLeft.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode9,
            treeNode13,
            treeNode17});
            this.treeViewLeft.Size = new System.Drawing.Size(263, 435);
            this.treeViewLeft.TabIndex = 0;
            this.treeViewLeft.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewLeft_AfterSelect);
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(270, 3);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(489, 433);
            this.panelRight.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 539);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelTop);
            this.Name = "FormMain";
            this.Text = "安途丰达WMS物流管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelTop.ResumeLayout(false);
            this.tableLayoutBanner.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelFill.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.TreeView treeViewLeft;
        private System.Windows.Forms.ComboBox comboBoxWarehouse;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelAuth;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBanner;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.ComboBox comboBoxProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
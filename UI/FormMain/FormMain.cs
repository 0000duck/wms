using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

using System.Windows.Forms;
using WMS.UI.FormReceipt;
using WMS.UI.FormBase;
using WMS.DataAccess;

namespace WMS.UI
{
    public partial class FormMain : Form
    {
        private User user = null;
        private Project project = null;
        private Warehouse warehouse = null;
        private WMSEntities wmsEntities = new WMSEntities();
        private int supplierid=-1;
        private int setitem;
        string remindtext="";



        private Action formClosedCallback;

        public FormMain(int userID)
        {
            InitializeComponent();
            User user = (from u in this.wmsEntities.User
                         where u.ID == userID
                         select u).Single();
            this.user = user;
            if (user.SupplierID != null)
            {
                this.supplierid = Convert.ToInt32(user.SupplierID);
                remind();


            }
            else if (user.SupplierID == null)
            {
                supplierid = -1;
            }

            


        }





        private void remind()
        {

        WMSEntities wmsEntities = new WMSEntities();
        WMS.DataAccess.ComponentView component = null;
        DateTime contract_enddate;
            DateTime contract_startdate;

        int days;
            StringBuilder sb = new StringBuilder();

            //��ͬ����
            Supplier Supplier = new Supplier();
            try
            {

                Supplier = (from u in this.wmsEntities.Supplier
                            where u.ID == supplierid
                            select u).FirstOrDefault();

                contract_enddate = Convert.ToDateTime(Supplier.EndingTime);
                contract_startdate = Convert.ToDateTime(Supplier.StartingTime);
            }
            catch
            {

                MessageBox.Show("����ʧ�ܣ�������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            days = (contract_enddate-DateTime.Now  ).Days;
            
            //���
            int[] warringdays = { 3, 5, 10 };
            int reminedays;

            
            try
            {

                var ComponentName = (from u in wmsEntities.StockInfoView
                                     where u.ReceiptTicketSupplierID == supplierid
                                     select u.ComponentName).ToArray();


                var ShipmentAreaAmount = (from u in wmsEntities.StockInfoView
                                          where u.ReceiptTicketSupplierID ==
                                          this.supplierid
                                          select u.ShipmentAreaAmount).ToArray();



                var ReceiptTicketNo = (from u in wmsEntities.StockInfoView
                                       where u.ReceiptTicketSupplierID == supplierid
                                       select u.SupplyNumber).ToArray();





                int[] singlecaramount = new int[ComponentName.Length];

                int[] dailyproduction = new int[ComponentName.Length];

                for (int i = 0; i < ComponentName.Length; i++)

                {
                    
                    
                    string ComponentNamei = ComponentName[i];

                    if (ShipmentAreaAmount[i] == null)
                    {
                        continue;
                    }

                    if (ReceiptTicketNo[i] == null)

                    {
                        
                        continue;
                    }


                    try
                    {
                        component = (from u in wmsEntities.ComponentView
                                     where u.Name == ComponentNamei
                                     select u).FirstOrDefault();

                        if (component == null)
                        {
                            
                            continue;
                        }
                        if (component.SingleCarUsageAmount == null)
                        {
                            
                            continue;

                        }

                        singlecaramount[i] = Convert.ToInt32(component.SingleCarUsageAmount);

                        if (component.DailyProduction == null)
                        {
                            
                            continue;

                        }

                        dailyproduction[i] = Convert.ToInt32(component.DailyProduction);


                        reminedays = Convert.ToInt32(ShipmentAreaAmount[i]) / (singlecaramount[i] * dailyproduction[i]);

                        if (reminedays < 10)
                        {
                            if (reminedays == 0)
                            {
                                sb.Append("���ջ�����Ϊ" + ReceiptTicketNo[i] + "�����" + ComponentName[i] + "�Ѿ�����1���������" + "\r\n" + "\r\n");
                            }

                            else
                            {
                                sb.Append("���ջ�����Ϊ" + ReceiptTicketNo[i] + "�����" + ComponentName[i] + "��Լ��������" + reminedays + "��" + "\r\n" + "\r\n");
                            }
                        }

                    }
                    catch
                    {

                        MessageBox.Show("����ʧ�ܣ�������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
               }
                this.remindtext  = sb.ToString() ;


                




            }
            catch
            {

                MessageBox.Show("����ʧ�ܣ�������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if(days<10||remindtext !=""||(contract_enddate >DateTime.Now&&contract_startdate <DateTime.Now ))

            {
                int contract_effect = 0;
                if (contract_enddate > DateTime.Now && contract_startdate < DateTime.Now)
                {

                     contract_effect = 1;
                }
                FormSupplierRemind a1 = new FormSupplierRemind(days,this.remindtext,contract_effect  );

                a1.Show();




            }











        }






        public void SetFormClosedCallback(Action callback)
        {
            this.formClosedCallback = callback;
        }

        private void RefreshTreeView()
        {
            TreeNode[] treeNodes = new TreeNode[]
            {
                MakeTreeNode("������Ϣ",new TreeNode[]{
                    MakeTreeNode("�û�����"),
                    MakeTreeNode("��Ӧ�̹���"),
                    MakeTreeNode("��������"),
                    MakeTreeNode("�������"),
                    MakeTreeNode("��Ա����"),
                    MakeTreeNode("����")
                    }),
                MakeTreeNode("�ջ�����",new TreeNode[]{
                    MakeTreeNode("����������"),
                    MakeTreeNode("�ͼ쵥����"),
                    MakeTreeNode("�ϼܵ�����"),
                    MakeTreeNode("�ϼ��������"),
                    }),
                MakeTreeNode("��������",new TreeNode[]{
                    MakeTreeNode("����������"),
                    MakeTreeNode("��ҵ������"),
                    MakeTreeNode("���ⵥ����"),
                    }),
                MakeTreeNode("������",new TreeNode[]{
                    MakeTreeNode("�����Ϣ"),
                    MakeTreeNode("����̵�"),
                    }),
            };

            this.treeViewLeft.Nodes.Clear();
            TreeNode[] nodes = (from node in (from node in treeNodes
                                              where HasAuthority(node.Text)
                                              select GetAuthenticatedSubTreeNodes(node))
                                where node.Nodes.Count > 0
                                select node).ToArray();
            this.treeViewLeft.Nodes.AddRange(nodes);
        }

        //����û��Ƿ�����Ӧ���ܵ�Ȩ��
        private bool HasAuthority(string funcName)
        {
            var searchResult = (from fa in FormMainMetaData.FunctionAuthorities
                                where fa.FunctionName == funcName
                                select fa.Authorities).FirstOrDefault();
            if (searchResult == null) {
                return true;
            }
            Authority[] authorities = searchResult;
            foreach(Authority authority in authorities)
            {
                if(((int)authority & this.user.Authority) == (int)authority)
                {
                    return true;
                }
            }
            return false;
        }

        //��ȡ��Ȩ�޵������ӽڵ�
        private TreeNode GetAuthenticatedSubTreeNodes(TreeNode node)
        {
            if (HasAuthority(node.Text) == false)
            {
                return null;
            }

            TreeNode newNode = (TreeNode)node.Clone();
            newNode.Nodes.Clear();

            foreach (TreeNode curNode in node.Nodes)
            {
                if (HasAuthority(curNode.Text))
                {
                    newNode.Nodes.Add(GetAuthenticatedSubTreeNodes(curNode));
                }
            }
            return newNode;
        }

        private static TreeNode MakeTreeNode(string text, TreeNode[] subNodes = null)
        {
            TreeNode node = new TreeNode() { Text = text };
            if (subNodes == null)
            {
                return node;
            }
            foreach (TreeNode subNode in subNodes)
            {
                node.Nodes.Add(subNode);
            }
            return node;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //ˢ��������ο�
            this.RefreshTreeView();

            //ˢ�¶���
            this.labelUsername.Text = this.user.Username;
            this.labelAuth.Text = this.user.AuthorityName+" :";

            //�����С������ʾ���ı�
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Convert.ToInt32(DeskWidth * 0.8);
            this.Height = Convert.ToInt32(DeskHeight * 0.8);

            new Thread(()=>
            {
                //��������ʾ�ֿ�
                WMSEntities wms = new WMSEntities();
                var allWarehouses = (from s in wms.Warehouse select s).ToArray();
                var allProjects = (from s in wms.Project select s).ToArray();

                if (this.IsDisposed)
                {
                    return;
                }
                this.Invoke(new Action(()=>
                {
                    for (int i = 0; i < allWarehouses.Count(); i++)
                    {
                        Warehouse warehouse = allWarehouses[i];
                        comboBoxWarehouse.Items.Add(new ComboBoxItem(warehouse.Name, warehouse));
                    }
                    this.comboBoxWarehouse.SelectedIndex = 0;
                    this.warehouse = allWarehouses[0];

                    for (int i = 0; i < allProjects.Count(); i++)
                    {
                        Project project = allProjects[i];
                        comboBoxProject.Items.Add(new ComboBoxItem(project.Name, project));
                    }
                    this.comboBoxProject.SelectedIndex = 0;
                    this.project = allProjects[0];
                }));
            }).Start();

            //if (this.supplierid != -1)
            //{
              
            //    FormSupplierRemind a1 = new FormSupplierRemind(this.supplierid );
            //    a1.Show();
                

            //}




        }

        private void treeViewLeft_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewLeft.SelectedNode.Text == "�û�����")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                FormUser l = new FormUser(this.user.ID,this.project.ID,this.warehouse.ID);//ʵ�����Ӵ���
                l.TopLevel = false;
                l.Dock = DockStyle.Fill;//���ڴ�С
                l.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(l);
                l.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "��Ӧ�̹���")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                FormBaseSupplier l = new FormBaseSupplier(user.Authority,this.supplierid ,this.user.ID );//ʵ�����Ӵ���
                l.TopLevel = false;
                l.Dock = System.Windows.Forms.DockStyle.Fill;//���ڴ�С
                l.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(l);
                l.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "��������")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                FormBaseSupply l = new FormBaseSupply(user.Authority, this.supplierid, this.project.ID, this.warehouse.ID, this.user.ID);//ʵ�����Ӵ���
                l.TopLevel = false;
                l.Dock = System.Windows.Forms.DockStyle.Fill;//���ڴ�С
                l.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(l);
                l.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "�������")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                FormBaseComponent l = new FormBaseComponent(user.Authority, this.supplierid, this.project.ID, this.warehouse.ID, this.user.ID);//ʵ�����Ӵ���
                l.TopLevel = false;
                l.Dock = System.Windows.Forms.DockStyle.Fill;//���ڴ�С
                l.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(l);
                l.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "����")
            {
                this.setitem = 0;
                this.LoadSubWindow(new FormOtherInfo(this.setitem));
            }
            if (treeViewLeft.SelectedNode.Text == "��Ŀ����")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                this.setitem = 1;
                FormBaseProject l = new FormBaseProject();//ʵ�����Ӵ���
                l.TopLevel = false;
                l.Dock = System.Windows.Forms.DockStyle.Fill;//���ڴ�С
                l.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(l);
                l.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "��Ա����")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                FormBase.FormBasePerson l = new FormBase.FormBasePerson();//ʵ�����Ӵ���
                l.TopLevel = false;
                l.Dock = System.Windows.Forms.DockStyle.Fill;//���ڴ�С
                l.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(l);
                l.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "����������")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                FormReceiptArrival l = new FormReceiptArrival(this.project.ID, this.warehouse.ID, this.user.ID);//ʵ�����Ӵ���
                l.SetActionTo(0, new Action<string, string>((string key, string value) =>
                {
                    this.panelRight.Controls.Clear();
                    panelRight.Visible = true;
                    FormSubmissionManage s = new FormSubmissionManage(this.project.ID, this.warehouse.ID, this.user.ID, key, value);
                    s.TopLevel = false;
                    s.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.panelRight.Controls.Clear();//���
                    s.FormBorderStyle = FormBorderStyle.None;
                    this.panelRight.Controls.Add(s);
                    s.Show();
                    //treeViewLeft.SelectedNode = treeViewLeft.Nodes.Find("�ͼ쵥����", true)[0];
                    Utilities.SendMessage(this.panelRight.Handle, Utilities.WM_SETREDRAW, 1, 0);
                }));
                l.SetActionTo(1, new Action<string, string>((key, value) =>
                {
                    this.panelRight.Controls.Clear();
                    FormReceiptShelves s = new FormReceiptShelves(this.project.ID, this.warehouse.ID, this.user.ID, key, value);
                    s.TopLevel = false;
                    s.Dock = System.Windows.Forms.DockStyle.Fill;
                    s.FormBorderStyle = FormBorderStyle.None;
                    //s.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.panelRight.Controls.Add(s);
                    s.Show();
                    Utilities.SendMessage(this.panelRight.Handle, Utilities.WM_SETREDRAW, 1, 0);
                }));
                l.TopLevel = false;
                l.Dock = System.Windows.Forms.DockStyle.Fill;//���ڴ�С
                l.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(l);
                l.Show();
            }
          
            if (treeViewLeft.SelectedNode.Text == "�ϼܵ�����")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                FormReceiptShelves l = new FormReceiptShelves(this.project.ID, this.warehouse.ID, this.user.ID);//ʵ�����Ӵ���
                l.TopLevel = false;
                l.Dock = System.Windows.Forms.DockStyle.Fill;//���ڴ�С
                l.FormBorderStyle = FormBorderStyle.None;//û�б�����
                l.SetToPutaway(new Action<string, string>((key, value) =>
                {
                    this.panelRight.Controls.Clear();
                    FormShelvesItem s = new FormShelvesItem(this.project.ID, this.warehouse.ID, this.user.ID, key, value);
                    s.TopLevel = false;
                    s.Dock = System.Windows.Forms.DockStyle.Fill;
                    s.FormBorderStyle = FormBorderStyle.None;
                    //s.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.panelRight.Controls.Add(s);
                    s.Show();
                    //this.treeViewLeft.SelectedNode = treeViewLeft.Nodes.Find("�ϼ��������", true)[0];
                    Utilities.SendMessage(this.panelRight.Handle, Utilities.WM_SETREDRAW, 1, 0);
                }));
                this.panelRight.Controls.Add(l);
                l.Show();
            }

            if (treeViewLeft.SelectedNode.Text == "�ϼ��������")
            {
                this.panelRight.Controls.Clear();
                panelRight.Visible = true;
                FormShelvesItem l = new FormShelvesItem(this.project.ID, this.warehouse.ID, this.user.ID, null, null);
                l.TopLevel = false;
                l.Dock = System.Windows.Forms.DockStyle.Fill;
                l.FormBorderStyle = FormBorderStyle.None;
                this.panelRight.Controls.Add(l);
                l.Show();
            }

            if (treeViewLeft.SelectedNode.Text == "����������")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                FormShipmentTicket formShipmentTicket = new FormShipmentTicket(this.user.ID,this.project.ID,this.warehouse.ID);//ʵ�����Ӵ���
                formShipmentTicket.SetToJobTicketCallback(this.ToJobTicketCallback);
                formShipmentTicket.TopLevel = false;
                formShipmentTicket.Dock = System.Windows.Forms.DockStyle.Fill;//���ڴ�С
                formShipmentTicket.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(formShipmentTicket);
                formShipmentTicket.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "��ҵ������")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                FormJobTicket l = new FormJobTicket(this.user.ID,this.project.ID,this.warehouse.ID);//ʵ�����Ӵ���
                l.SetToPutOutStorageTicketCallback(this.ToPutOutStorageTicketCallback);
                l.TopLevel = false;
                l.Dock = System.Windows.Forms.DockStyle.Fill;//���ڴ�С
                l.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(l);
                l.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "���ⵥ����")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                FormPutOutStorageTicket l = new FormPutOutStorageTicket(this.user.ID,this.project.ID,this.warehouse.ID);//ʵ�����Ӵ���
                l.TopLevel = false;
                l.Dock = System.Windows.Forms.DockStyle.Fill;//���ڴ�С
                l.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(l);
                l.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "�����Ϣ")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                var formBaseStock = new FormStockInfo(this.user.ID,this.project.ID,this.warehouse.ID);//ʵ�����Ӵ���
                formBaseStock.TopLevel = false;
                formBaseStock.Dock = DockStyle.Fill;//���ڴ�С
                formBaseStock.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(formBaseStock);
                formBaseStock.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "����̵�")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                var formBaseStock = new FormStockInfoCheckTicket(this.project .ID ,this.warehouse .ID ,this.user.ID);//ʵ�����Ӵ���
                formBaseStock.TopLevel = false;
                formBaseStock.Dock = DockStyle.Fill;//���ڴ�С
                formBaseStock.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(formBaseStock);
                formBaseStock.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "�ͼ쵥����")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                var formSubmissionManage = new FormSubmissionManage(this.project.ID, this.warehouse.ID, this.user.ID);//ʵ�����Ӵ���
                formSubmissionManage.TopLevel = false;
                formSubmissionManage.Dock = DockStyle.Fill;//���ڴ�С
                formSubmissionManage.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(formSubmissionManage);
                formSubmissionManage.Show();
            }
        }

        private void ToJobTicketCallback(string shipmentTicketNo)
        {
            if (this.IsDisposed) return;
            this.Invoke(new Action(() =>
            {
                FormJobTicket formJobTicket = new FormJobTicket(this.user.ID, this.project.ID, this.warehouse.ID);//ʵ�����Ӵ���
                formJobTicket.SetToPutOutStorageTicketCallback(this.ToPutOutStorageTicketCallback);
                formJobTicket.SetSearchCondition("ShipmentTicketNo", shipmentTicketNo);
                this.LoadSubWindow(formJobTicket);
                this.SetTreeViewSelectedNodeByText("��ҵ������");
            }));
        }

        private void ToPutOutStorageTicketCallback(string condition,string jobTicketNo)
        {
            if (this.IsDisposed) return;
            this.Invoke(new Action(() =>
            {
                FormPutOutStorageTicket formPutOutStorageTicket = new FormPutOutStorageTicket(this.user.ID, this.project.ID, this.warehouse.ID);//ʵ�����Ӵ���
                formPutOutStorageTicket.SetSearchCondition(condition, jobTicketNo);
                this.LoadSubWindow(formPutOutStorageTicket);
                this.SetTreeViewSelectedNodeByText("���ⵥ����");
            }));
        }

        private void LoadSubWindow(Form form)
        {
            this.panelRight.Visible = false;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;//���ڴ�С
            form.FormBorderStyle = FormBorderStyle.None;//û�б�����
            this.panelRight.Controls.Clear();//���
            this.panelRight.Controls.Add(form);
            form.Show();
            this.panelRight.Visible = true;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.formClosedCallback?.Invoke();
        }

        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.project = ((ComboBoxItem)this.comboBoxProject.SelectedItem).Value as Project;
            this.panelRight.Controls.Clear();
            this.treeViewLeft.SelectedNode = null;
        }

        private void comboBoxWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.warehouse = ((ComboBoxItem)this.comboBoxWarehouse.SelectedItem).Value as Warehouse;
            this.panelRight.Controls.Clear();
            this.treeViewLeft.SelectedNode = null;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("ȷ���˳���", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void SetTreeViewSelectedNodeByText(string text)
        {
            TreeNode node = this.FindTreeNodeByText(this.treeViewLeft.Nodes,text);
            if(node == null)
            {
                throw new Exception("���ο��в������ڵ㣺" + text);
            }
            this.treeViewLeft.AfterSelect -= this.treeViewLeft_AfterSelect;
            this.treeViewLeft.SelectedNode = node;
            this.treeViewLeft.AfterSelect += this.treeViewLeft_AfterSelect;
        }

        private TreeNode FindTreeNodeByText(TreeNodeCollection nodes,string text)
        {
            if(nodes.Count == 0)
            {
                return null;
            }
            foreach (TreeNode curNode in nodes)
            {
                if(curNode.Text == text)
                {
                    return curNode;
                }
                TreeNode foundNode = FindTreeNodeByText(curNode.Nodes,text);
                if(foundNode != null)
                {
                    return foundNode;
                }
            }
            return null;
        }
    }
}

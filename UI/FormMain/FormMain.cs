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
        private int supplierid;
        private int setitem;



        private Action formClosedCallback;

        public FormMain(int userID)
        {
            InitializeComponent();
            User user = (from u in this.wmsEntities.User
                         where u.ID == userID
                         select u).Single();
            this.user = user;
            this.supplierid = Convert.ToInt32(user.SupplierID);
            if (this.supplierid != 0)
            {
                Supplier Supplier = (from u in this.wmsEntities.Supplier
                                     where u.ID == supplierid
                                     select u).Single();
                if (Convert.ToString(Supplier.EndingTime) != string.Empty)
                {
                    if (Supplier.EndingTime < DateTime.Now)
                    {
                        MessageBox.Show("��ͬ�Ѿ�����ֹ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                }

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
                    MakeTreeNode("�������"),
                    MakeTreeNode("��Ա����"),
                    MakeTreeNode("����")
                    }),
                MakeTreeNode("�ջ�����",new TreeNode[]{
                    MakeTreeNode("����������"),
                    MakeTreeNode("�ͼ쵥����"),
                    MakeTreeNode("�ϼܵ�����"),

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
                FormBaseSupplier l = new FormBaseSupplier(user.Authority,Convert.ToInt32(this.user.SupplierID),this.user.ID );//ʵ�����Ӵ���
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
                FormBaseComponent l = new FormBaseComponent(user.Authority, Convert.ToInt32(this.user.SupplierID), this.project.ID, this.warehouse.ID, this.user.ID);//ʵ�����Ӵ���
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

        private void ToPutOutStorageTicketCallback(string jobTicketNo)
        {
            if (this.IsDisposed) return;
            this.Invoke(new Action(() =>
            {
                FormPutOutStorageTicket formPutOutStorageTicket = new FormPutOutStorageTicket(this.user.ID, this.project.ID, this.warehouse.ID);//ʵ�����Ӵ���
                formPutOutStorageTicket.SetSearchCondition("JobTicketJobTicketNo", jobTicketNo);
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

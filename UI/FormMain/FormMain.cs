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

        private Action formClosedCallback;

        public FormMain(int userID)
        {
            InitializeComponent();
            User user = (from u in this.wmsEntities.User
                         where u.ID == userID
                         select u).Single();
            this.user = user;
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
                    MakeTreeNode("�ֿ����"),
                    MakeTreeNode("��Ŀ����"),
                    }),
                MakeTreeNode("�ջ�����",new TreeNode[]{
                    MakeTreeNode("��������"),
                    MakeTreeNode("�ͼ쵥����"),
                    MakeTreeNode("�ϼܹ���"),

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
                                select fa.Authority).ToArray();
            if (searchResult.Length == 0) {
                return true;
            }
            Authority authority = searchResult[0];
            if (((int)authority & this.user.Authority) > 0)
            {
                return true;
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


        private void treeViewLeft_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.ForeColor == SystemColors.Control)
                {
                    e.Cancel = true;  //����ѡ�н��ýڵ�
                }
            }
        }
        private void treeViewLeft_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.ForeColor == SystemColors.Control)
                {
                    e.Cancel = true; //����ѡ�н��ýڵ�

                }
            }
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
            Utilities.SendMessage(this.panelRight.Handle, Utilities.WM_SETREDRAW, 0, 0);
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
                FormBaseSupplier l = new FormBaseSupplier(user.Authority,Convert.ToInt32(this.user.SupplierID));//ʵ�����Ӵ���
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
                FormBaseComponent l = new FormBaseComponent(user.Authority, Convert.ToInt32(this.user.SupplierID), this.project.ID, this.warehouse.ID);//ʵ�����Ӵ���
                l.TopLevel = false;
                l.Dock = System.Windows.Forms.DockStyle.Fill;//���ڴ�С
                l.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(l);
                l.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "�ֿ����")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                FormBaseWarehouse l = new FormBaseWarehouse();//ʵ�����Ӵ���
                l.TopLevel = false;
                l.Dock = System.Windows.Forms.DockStyle.Fill;//���ڴ�С
                l.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(l);
                l.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "��Ŀ����")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                FormBase.FormBaseProject l = new FormBase.FormBaseProject();//ʵ�����Ӵ���
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
                FormReceiptArrival l = new FormReceiptArrival(this.project.ID, this.warehouse.ID, this.user.ID);//ʵ�����Ӵ���
                l.SetActionTo(0, new Action(() =>
                {
                    FormSubmissionManage s = new FormSubmissionManage();
                    s.TopLevel = false;
                    s.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.panelRight.Controls.Clear();//���
                    this.panelRight.Controls.Add(s);
                    s.Show();
                    Utilities.SendMessage(this.panelRight.Handle, Utilities.WM_SETREDRAW, 1, 0);
                }));
                l.SetActionTo(1, new Action(() =>
                {
                    FormReceiptShelves s = new FormReceiptShelves();
                    s.TopLevel = false;
                    s.Dock = System.Windows.Forms.DockStyle.Fill;
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
          
            if (treeViewLeft.SelectedNode.Text == "�ϼܹ���")
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
                FormShipmentTicket l = new FormShipmentTicket(this.user.ID,this.project.ID,this.warehouse.ID);//ʵ�����Ӵ���
                l.TopLevel = false;
                l.Dock = System.Windows.Forms.DockStyle.Fill;//���ڴ�С
                l.FormBorderStyle = FormBorderStyle.None;//û�б�����
                this.panelRight.Controls.Add(l);
                l.Show();
            }
            if (treeViewLeft.SelectedNode.Text == "��ҵ������")
            {
                this.panelRight.Controls.Clear();//���
                panelRight.Visible = true;
                FormJobTicket l = new FormJobTicket(this.user.ID,this.project.ID,this.warehouse.ID);//ʵ�����Ӵ���
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
            Utilities.SendMessage(this.panelRight.Handle, Utilities.WM_SETREDRAW, 1, 0);
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.UI.FormBase
{
    class BasePersonMetaData
    {

        private static KeyName[] keyNames = {
            new KeyName(){Key="ID",Name="ID",Visible=false,Editable=false},
            new KeyName(){Key="Name",Name="��Ա����",Visible=true,Editable=true},
            new KeyName(){Key="Position",Name="��λ",Editable=false,ComboBoxItems = new ComboBoxItem[]{
                new ComboBoxItem("�ջ�"),
                new ComboBoxItem("����"),
                new ComboBoxItem("������"),
                new ComboBoxItem("����"),
            } },

            new KeyName(){Key="ProjectName",Name="������Ŀ����",Visible=true,Editable=true,Save=false},
            new KeyName(){Key="WarehouseName",Name="���ڲֿ�����",Visible=true,Editable=true,Save=false},
        };
        public static KeyName[] KeyNames { get => keyNames; set => keyNames = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.UI.FormBase
{
    class BasePersonMetaData
    {
        private static int defaultPosition = -1;
        public static int DEFAULTPOSITION { get => defaultPosition; set => defaultPosition = value; }

        public enum POSITION
        {
            POSITION_RECEIPT =1,
            POSITION_SHIPMENT =2,
            POSITION_STOCKINFO =3,
            POSITION_SETTLEMENT =4,

        };

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


        private static KeyName[] positionKeyNames = {
            new KeyName(){Key="Receipt",Name="�ջ�"},
            new KeyName(){Key="Shipment",Name="����"},
            new KeyName(){Key="StockInfo",Name="������"},
            new KeyName(){Key="Settlement",Name= "����"},
        };
        public static KeyName[] PositionKeyNames { get => positionKeyNames; set => positionKeyNames = value; }
    }
}

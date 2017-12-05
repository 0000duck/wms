﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.UI
{
    public class KeyName
    {
        public string Key;
        public string Name;
        public bool Visible = true;
        public bool Editable = false;
    }

    public enum FormMode
    {
        ADD,ALTER
    }

    public enum Authority
    {
        SETTLEMENT = 16777216,
        SETTLEMENT_SUPPLIER_SELFONLY = 8388608,
        STOCK_CHECK = 4194304,
        STOCK_CHECK_SUPPLIER_SELFONLY = 2097152,
        STOCKINFO = 1048576,
        STOCKINFO_SUPPLIER_SELFONLY = 524288,
        DELIVERY_SEND = 262144,
        DELIVERY_SEND_SUPPLIER_SELFONLY = 131072,
        DELIVERY_OUTPUT = 65536,
        DELIVERY_OUTPUT_SUPPLIER_SELFONLY = 32768,
        DELIVERY_JOB = 16384,
        DELIVERY_JOB_SUPPLIER_SELFONLY = 8192,
        RECEIPT_SHELVES = 4096,
        RECEIPT_SHELVES_SUPPLIER_SELFONLY = 2048,
        RECEIPT_ARRIVAL = 1024,
        RECEIPT_ARRIVAL_SUPPLIER_SELFONLY = 512,
        BASE_USER = 256,
        BASE_USER_SUPPLIER_SELFONLY = 128,
        BASE_WAREHOUSE = 64,
        BASE_WAREHOUSE_SUPPLIER_SELFONLY = 32,
        BASE_PROJECT = 16,
        BASE_PROJECT_SUPPLIER_SELFONLY = 8,
        BASE_SUPPLIER = 4,
        BASE_SUPPLIER_SUPPLIER_SELFONLY = 2,
        BASE_COMPONENT = 1,
        BASE_COMPONENT_SUPPLIER_SELFONLY = 0,
    }
}
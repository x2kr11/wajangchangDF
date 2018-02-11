using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eHR.Framework.Enum;

namespace eHR.Framework.Control.ShRepeater
{
    public class RepeaterBody
    {
        public RepeaterBody() { }

        public RepeaterBody(string itemCtlId, string itemCssCalss, string itemStyle, string dataColumnName, EControlType ctlType) 
        {
            this.ItemCtlId = itemCtlId;
            this.ItemCssClass = itemCssCalss;
            this.ItemStyle = itemStyle;
            this.DataColumnName = dataColumnName;
            this.CtlType = ctlType;
        }
        private string _itemCtlId;
        private string _itemCssClass;
        private string _itemStyle;
        private string _dataColumnName;
        private EControlType _ctlType = EControlType.Label;

        public EControlType CtlType
        {
            get { return _ctlType; }
            set { _ctlType = value; }
        }

        public string DataColumnName
        {
            get { return _dataColumnName; }
            set { _dataColumnName = value; }
        }

        public string ItemCtlId
        {
            get { return _itemCtlId; }
            set { _itemCtlId = value; }
        }
        public string ItemCssClass
        {
            get { return _itemCssClass; }
            set { _itemCssClass = value; }
        }

        public string ItemStyle
        {
            get { return _itemStyle; }
            set { _itemStyle = value; }
        }

    }
}

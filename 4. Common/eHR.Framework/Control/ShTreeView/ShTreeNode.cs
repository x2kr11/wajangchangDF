//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace eHR.Framework.Control.ShTreeView
//{
//    class ShTreeViewcs
//    {
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;
using System.Web;

namespace eHR.Framework.Control
{
    public class ShTreeNode : TreeNode
    {
        public ShTreeNode()
            : base()
        {
        }


        public ShTreeNode(TreeView owner, bool isRoot)
            : base(owner, isRoot)
        {

        }

        protected override void LoadViewState(object state)
        {
            object[] arrState = state as object[];

            this.Tag = arrState[1];
            base.LoadViewState(arrState[0]);
        }


        protected override object SaveViewState()
        {
            object[] arrState = new object[2];
            arrState[0] = base.SaveViewState();
            arrState[1] = this.Tag;

            return arrState;
        }

        private object _tag;

        [
        Category("Sh TreeNode 속성"),
        Description("ShTreeVeiw에서 사용하는 클래스.")
        ]
        public object Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }
    }
}

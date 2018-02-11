//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace eHR.Framework.Control.ShTreeView
//{
//    class ShTreeView
//    {
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web;
using System.Drawing;
using System.Web.UI;
using System.Security.Permissions;
using System.Data;
using System.ComponentModel;

namespace eHR.Framework.Control
{
    /// <summary>
    /// Define a PermissionLevel and ToolBox 
    /// </summary>
    [
    AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal),
    AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal),
    ToolboxData("<{0}:ShTreeView runat=\"server\" ></{0}:ShTreeView>"),
    ToolboxBitmap(typeof(System.Web.UI.WebControls.TreeView)),
    ]
    public class ShTreeView : TreeView, IPostBackEventHandler
    {
        private string IMAGE_URL = "~/Images/Tree/MenuD2.gif";
        private string ROOT_IMAGE_URL = "~/Images/Tree/MenuHome.gif";
        private string SELECTED_IMAGE_URL = "~/Images/Tree/MenuD3.gif";

        /// <summary>
        /// 생성자 입니다.
        /// </summary>
        public ShTreeView() : base() { }

        protected override TreeNode CreateNode()
        {
            return new ShTreeNode(this, false);
        }

        /// <summary>
        /// 선택된 노드를 반환 합니다.
        /// </summary>
        [
        Category("Sh TreeView 속성"),
        Description("ShTreeView에서 사용하는 클래스.")
        ]
        public ShTreeNode ShSelectedNode
        {
            get
            {
                if (this.SelectedNode == null)
                    return null;
                else
                    return (ShTreeNode)this.SelectedNode;
            }
        }

        /// <summary>
        /// 데이타를 바인딩 합니다.
        /// </summary>
        /// <param name="dataSet">Dataset 개체 입니다. 이 DataSet개체의 첫번째 테이블에 데이타를 바인딩 합니다.</param>
        /// <param name="columnName">바인딩할 키 컬럼명을 정의 합니다.</param>
        /// <param name="parentColumnName">부모 컬럼명을 정의 합니다.</param>
        /// <param name="textColumnName">노드의 Text 값을 정의 합니다.</param>
        /// <param name="valueColumnName">노드의 Value값을 정의 합니다.</param>
        public void FillData(DataSet dataSet, string columnName, string parentColumnName, string textColumnName, string valueColumnName)
        {
            this.NodeStyle.ImageUrl = IMAGE_URL;

            this.SelectedNodeStyle.ImageUrl = SELECTED_IMAGE_URL;
            this.SelectedNodeStyle.ForeColor = Color.Red;
            this.RootNodeStyle.ImageUrl = ROOT_IMAGE_URL;

            TreeNodeBinding tnb = new TreeNodeBinding();
            tnb.DataMember = "System.Data.DataRowView";
            tnb.TextField = textColumnName;
            tnb.ValueField = valueColumnName;
            tnb.PopulateOnDemand = false;
            tnb.SelectAction = TreeNodeSelectAction.Select;
            this.DataBindings.Add(tnb);

            this.DataSource = new TreeHierarchicalDataSource(dataSet, columnName, parentColumnName);
            this.DataBind();

            //첫번째 노드 Select
            if (this.Nodes.Count > 0)
                this.Nodes[0].Selected = true;
        }

        /// <summary>
        /// 데이타를 바인딩 합니다.
        /// </summary>
        /// <param name="dataSet">Dataset 개체 입니다. 이 DataSet개체의 첫번째 테이블에 데이타를 바인딩 합니다.</param>
        /// <param name="columnName">바인딩할 키 컬럼명을 정의 합니다.</param>
        /// <param name="parentColumnName">부모 컬럼명을 정의 합니다.</param>
        /// <param name="textColumnName">노드의 Text 값을 정의 합니다.</param>
        /// <param name="valueColumnName">노드의 Value값을 정의 합니다.</param>
        public void FillData(DataSet dataSet, string columnName, string parentColumnName, string textColumnName, string valueColumnName, string urlName)
        {
            this.NodeStyle.ImageUrl = IMAGE_URL;

            this.SelectedNodeStyle.ImageUrl = SELECTED_IMAGE_URL;
            this.SelectedNodeStyle.ForeColor = Color.Red;
            this.RootNodeStyle.ImageUrl = ROOT_IMAGE_URL;

            TreeNodeBinding tnb = new TreeNodeBinding();
            tnb.DataMember = "System.Data.DataRowView";
            tnb.TextField = textColumnName;
            tnb.ValueField = valueColumnName;
            tnb.NavigateUrlField = urlName;
            tnb.ToolTipField = columnName;
            tnb.PopulateOnDemand = false;
            tnb.SelectAction = TreeNodeSelectAction.Select;

            this.DataBindings.Add(tnb);

            this.DataSource = new TreeHierarchicalDataSource(dataSet, columnName, parentColumnName);
            this.DataBind();

            //첫번째 노드 Select
            if (this.Nodes.Count > 0)
                this.Nodes[0].Selected = true;
        }

        ///<summary>
        ///노드의 선택이 변경 되면 발생 합니다.
        ///</summary>
        ///<param name="e"></param>
        protected override void OnSelectedNodeChanged(EventArgs e)
        {

            if (this.SelectedValue.Trim() == "")
            {
                return;
            }

            if (this.SelectedNode != null)
            {
                this.Attributes["PrevSelectedPath"] = this.Attributes["SelectedPath"];
                this.Attributes["SelectedPath"] = this.SelectedNode.ValuePath;

                TreeNode tNode = this.FindNode(this.Attributes["PrevSelectedPath"]);
                if (tNode != null)
                {
                    if (tNode.Parent == null)
                    {
                        tNode.ImageUrl = this.ROOT_IMAGE_URL;
                        tNode.Target = "";
                    }
                    else
                    {

                        tNode.Target = "";
                        tNode.ImageUrl = this.IMAGE_URL;
                    }
                }
                this.SelectedNode.ImageUrl = this.SELECTED_IMAGE_URL;
            }
            else
            {
                this.Attributes["SelectedPath"] = "";
            }

            base.OnSelectedNodeChanged(e);

        }
    }
}

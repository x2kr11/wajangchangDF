
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Data;
using System.Collections;

namespace eHR.Framework.Control
{
    public class TreeHierarchicalDataSource : IHierarchicalDataSource
    {
        DataSet _dataSet;
        string _idColumnName;
        string _parentIdColumnName;

        /// <summary>
        /// 생성자 입니다.
        /// </summary>
        /// <param name="dataSet">DataSet 소스 입니다.</param>
        /// <param name="idColumnName">Key 컬럼 이름 입니다.</param>
        /// <param name="parentidColumnName">부모 Key 컬럼 이름 입니다.</param>
        public TreeHierarchicalDataSource(DataSet dataSet, string idColumnName, string parentIdColumnName)
        {
            this._dataSet = dataSet;
            this._idColumnName = idColumnName;
            this._parentIdColumnName = parentIdColumnName;
        }

        public event EventHandler DataSourceChanged;

        public HierarchicalDataSourceView GetHierarchicalView(string viewPath)
        {
            return new DataSourceView(this, viewPath);
        }

        #region supporting methods
        DataRowView GetParentRow(DataRowView row)
        {
            _dataSet.Tables[0].DefaultView.RowFilter = String.Format("{0} = '{1}'", _idColumnName, row[_parentIdColumnName].ToString());
            DataRowView parentRow = _dataSet.Tables[0].DefaultView[0];
            _dataSet.Tables[0].DefaultView.RowFilter = "";
            return parentRow;
        }

        string GetChildrenViewPath(string viewPath, DataRowView row)
        {
            return viewPath + "\\" + row[_idColumnName].ToString();
        }

        bool HasChildren(DataRowView row)
        {
            _dataSet.Tables[0].DefaultView.RowFilter = String.Format("{0} = '{1}'", _parentIdColumnName, row[_idColumnName]);
            bool hasChildren = _dataSet.Tables[0].DefaultView.Count > 0;
            _dataSet.Tables[0].DefaultView.RowFilter = "";
            return hasChildren;
        }

        string GetParentViewPath(string viewPath)
        {
            return viewPath.Substring(0, viewPath.LastIndexOf("\\"));
        }
        #endregion

        #region private classes that implement further interfaces
        class DataSourceView : HierarchicalDataSourceView
        {
            TreeHierarchicalDataSource hDataSet;
            string viewPath;

            public DataSourceView(TreeHierarchicalDataSource hDataSet, string viewPath)
            {
                this.hDataSet = hDataSet;
                this.viewPath = viewPath;
            }

            public override IHierarchicalEnumerable Select()
            {
                return new HierarchicalEnumerable(hDataSet, viewPath);
            }
        }

        class HierarchicalEnumerable : IHierarchicalEnumerable
        {
            TreeHierarchicalDataSource hDataSet;
            string viewPath;

            public HierarchicalEnumerable(TreeHierarchicalDataSource hDataSet, string viewPath)
            {
                this.hDataSet = hDataSet;
                this.viewPath = viewPath;
            }

            public IHierarchyData GetHierarchyData(object enumeratedItem)
            {
                DataRowView row = (DataRowView)enumeratedItem;
                return new HierarchyData(hDataSet, viewPath, row);
            }

            public IEnumerator GetEnumerator()
            {
                if (viewPath == "")
                    hDataSet._dataSet.Tables[0].DefaultView.RowFilter = String.Format("{0} is null", hDataSet._parentIdColumnName);
                else
                {
                    string lastID = viewPath.Substring(viewPath.LastIndexOf("\\") + 1);
                    hDataSet._dataSet.Tables[0].DefaultView.RowFilter = String.Format("{0} = '{1}'", hDataSet._parentIdColumnName, lastID);
                }

                IEnumerator i = hDataSet._dataSet.Tables[0].DefaultView.GetEnumerator();
                hDataSet._dataSet.Tables[0].DefaultView.RowFilter = "";
                return i;
            }
        }

        class HierarchyData : IHierarchyData
        {
            TreeHierarchicalDataSource hDataSet;
            DataRowView row;
            string viewPath;

            public HierarchyData(TreeHierarchicalDataSource hDataSet, string viewPath, DataRowView row)
            {
                this.hDataSet = hDataSet;
                this.viewPath = viewPath;
                this.row = row;
            }

            public IHierarchicalEnumerable GetChildren()
            {
                return new HierarchicalEnumerable(hDataSet, hDataSet.GetChildrenViewPath(viewPath, row));
            }

            public IHierarchyData GetParent()
            {
                return new HierarchyData(hDataSet, hDataSet.GetParentViewPath(viewPath), hDataSet.GetParentRow(row));
            }

            public bool HasChildren
            {
                get
                {
                    return hDataSet.HasChildren(row);
                }
            }

            public object Item
            {
                get
                {
                    return row;
                }
            }

            public string Path
            {
                get
                {
                    return viewPath;
                }
            }

            public string Type
            {
                get
                {
                    return typeof(DataRowView).ToString();
                }
            }
        }
        #endregion
    }
}

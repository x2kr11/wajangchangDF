using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eHR.Framework.Enum;

namespace eHR.Framework.Control.ShRepeater
{
    public class DynamicTmp: ITemplate
    {
        ListItemType templateType;
        private ListItemType listItemType;
        private DataColumnCollection dataColumnCollection;
        private List<RepeaterHeader> lstHeader = new List<RepeaterHeader>();
        private List<RepeaterBody> lstBody = new List<RepeaterBody>();
        private List<RepeaterBody> lstFooter = new List<RepeaterBody>();
        private EControlType eCtlType = EControlType.Label;
        public DynamicTmp(ListItemType type)
        {
            templateType = type;
        }

        public DynamicTmp(ListItemType type, DataTableCollection tbl)
        {
            templateType = type;
            //  myTable = tbl;
        }

        public DynamicTmp(ListItemType listItemType, DataColumnCollection dataColumnCollection)
        {
            // TODO: Complete member initialization
            this.templateType = listItemType;
            this.dataColumnCollection = dataColumnCollection;
        }

        public DynamicTmp(ListItemType listItemType, List<RepeaterHeader> lst)
        {
            // TODO: Complete member initialization
            this.templateType = listItemType;
            this.lstHeader = lst;
        }

        public DynamicTmp(ListItemType listItemType, List<RepeaterBody> lst)
        {
            // TODO: Complete member initialization
            this.templateType = listItemType;
            this.lstBody = lst;
        }


        //public DynamicTmp(ListItemType listItemType, List<RepeaterBody> lst, List<RepeaterBody> lstF)
        //{
        //    // TODO: Complete member initialization
        //    this.templateType = listItemType;
        //    this.lstBody = lst;
        //    this.lstFooter = lstF;
        //}
        public void InstantiateIn(System.Web.UI.Control container)
        {
            PlaceHolder ph = new PlaceHolder();
            Label[] labelArray = null;
            if (lstBody != null)
            {
                int iColumnCnt = lstBody.Count;
                labelArray = new Label[iColumnCnt];
                for (int j = 0; j < iColumnCnt; j++)
                {
                    labelArray[j] = new Label();
                    labelArray[j].ID = lstBody[j].ItemCtlId;
                }
            }
            switch (templateType)
            {
                case ListItemType.Header:

                    string strControl = "";

                    strControl += "<thead><tr>";
                    if (lstHeader == null)
                    {
                        foreach (DataColumn item in dataColumnCollection)
                        {
                            strControl += "<th>" + item.ColumnName + "</th>";
                        }
                    }
                    else
                    {
                        foreach (RepeaterHeader rh in lstHeader)
                        {
                            //   string strTd = string.Format("<td width='{0}' class='{1}'>{2}</td>");
                            strControl = strControl + string.Format("<th width='{0}' class='{1}'>{2}</th>", rh.HeaderWidth, rh.HeaderCssClass, rh.HeaderName);
                        }
                    }
                    strControl += "</tr></thead>";
                    ph.Controls.Add(new LiteralControl(strControl));

                    break;
                case ListItemType.Item:

                    ph.Controls.Add(new LiteralControl("<tr>"));
                    for (int j = 0; j < lstBody.Count; j++)
                    {
                       ph.Controls.Add(new LiteralControl(string.Format("<td style='{0}' class='{1}'>", lstBody[j].ItemStyle, lstBody[j].ItemCssClass)));
                       if (lstBody[j].CtlType == EControlType.Label)
                        {
                        
                        Label lbl = new Label();
                        
                        lbl.ID = lstBody[j].ItemCtlId;
                        ph.Controls.Add(lbl);
                        }
                       else if (lstBody[j].CtlType == EControlType.LinkButton)
                        {

                            LinkButton lnk = new LinkButton();
                            lnk.ID = lstBody[j].ItemCtlId;
                            ph.Controls.Add(lnk);
                        }

                        ph.Controls.Add(new LiteralControl("</td>"));
                    }
                    ph.Controls.Add(new LiteralControl("</tr>"));
                    ph.DataBinding += new EventHandler(TemplateControlTC_DataBinding);
                    
                    break;
                case ListItemType.Footer:
                    ph.Controls.Add(new LiteralControl("<tr>"));
                    for (int j = 0; j < lstBody.Count; j++)
                    {
                        ph.Controls.Add(new LiteralControl(string.Format("<td style='{0}' class='{1}'>", lstBody[j].ItemStyle, lstBody[j].ItemCssClass)));
                        Label lbl = new Label();
                        lbl.ID = lstBody[j].ItemCtlId;
                        ph.Controls.Add(lbl);
                        ph.Controls.Add(new LiteralControl("</td>"));
                    }
                    ph.Controls.Add(new LiteralControl("</tr>"));
                    break;
            }
            container.Controls.Add(ph);
        }
        private void TemplateControlTC_DataBinding(object sender, System.EventArgs e)
        {
            PlaceHolder ph = (PlaceHolder)sender;
            RepeaterItem ri = (RepeaterItem)ph.NamingContainer;


            //String[] stringArray = new String[dataColumnCollection.Count];
            int i = 0;
            foreach (RepeaterBody strItem in lstBody)
            {
                String itemValue = (String)DataBinder.Eval(ri.DataItem, strItem.DataColumnName).ToString();
                int iCtlNum = i + 0;
                if (strItem.CtlType == EControlType.Label)
                {

                    ((Label)ph.FindControl(strItem.ItemCtlId)).Text = itemValue;
                }
                else if (strItem.CtlType == EControlType.LinkButton)
                {
                    ((LinkButton)ph.FindControl(strItem.ItemCtlId)).Text = itemValue;
                }
                i++;
            }
        }
    }
    /// <summary>
    /// 업로드된 파일 정보를 관리 합니다.
    /// </summary>
 

}

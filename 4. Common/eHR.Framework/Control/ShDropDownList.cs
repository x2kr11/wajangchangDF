//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace eHR.Framework.Control
//{
//    class ShDropDownList
//    {
//    }
//}
using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using System.Drawing;
using System.Security.Permissions;
using System.ComponentModel;
using System.Data;

[assembly: TagPrefix("eHR.Framework.Control", "aspx")]
namespace eHR.Framework.Control
{
    /// <summary>
    /// DropDownList Group
    /// </summary>
    //AspNetHostingPermission 권한의 Level이 적어도 Minimal인 상태에서 코드를 실행해야 합니다.
    // An interface that the transformer provides to the consumer.
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [ToolboxBitmap(typeof(System.Web.UI.WebControls.DropDownList))]
    [ToolboxData("<{0}:ShDropDownList runat=server></{0}:ShDropDownList>")]
    public class ShDropDownList : System.Web.UI.WebControls.DropDownList
    {

        /// <summary>
        /// 
        /// </summary>
        public ShDropDownList()
        {

        }

        #region ENUM 모음
        public enum AddingItemMode
        {
            /// <summary>
            /// 아무것도 추가하지 않습니다.
            /// </summary>
            None = -1,
            /// <summary>
            /// 전체선택 문자열을 첫번째 항목에 추가합니다.
            /// </summary>
            /// <remarks>기본값은 "전체선택" 이며 고객사에 따라 Message.xml의 값을 변경하여 텍스트를 변경할 수 있습니다.</remarks>
            All = 0,
            /// <summary>
            /// 선택하세요 문자열을 첫번째 항목에 추가합니다.
            /// </summary>
            /// <remarks>기본값은 "선택하세요" 이며 고객사에 따   라 Message.xml의 값을 변경하여 텍스트를 변경할 수 있습니다.</remarks>
            Select = 1,
            /// <summary>
            /// 빈문자열을 첫번째 항목에 추가합니다.
            /// </summary>
            Empty = 2
        } 
        #endregion

        #region 클래스변수 모음
        #endregion

        #region 프로퍼티 모음
        /// <summary>
        /// GroupName
        /// </summary>

        [Category("Sh DropdownList 속성")]
        [Description("Group 이름을 등록하고 Listitem의 Value값이 Group이름과 같을 때 구분자로 분류된다.")]

        public string GroupName
        {
             get
            {
                if (ViewState["__Sh_Res_Key__"] == null)
                {
                    return "GroupName";
                }
                else
                {
                    return (string)ViewState["__Sh_Res_Key__"];
                }
            }
            set
            {
                ViewState["__Sh_Res_Key__"] = value;
            }         
        }
        #endregion

        #region 메소드
        /// <summary>
        /// 지정된 작성기에 컨트롤의 내용을 렌더링합니다.
        /// </summary>
        /// <param name="writer">writer</param>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            // 렌더링 옵션 또는 OptionGroup
            OptionGroupRenderContents(writer);
        }

        /// <summary>
        /// 렌더링 옵션 또는 OptionGroup
        /// </summary>
        /// <param name="writer">writer</param>
        private void OptionGroupRenderContents(HtmlTextWriter writer)
        {
            //EndTag 초기화
            bool writerEndTag = false;

            foreach (ListItem li in this.Items)
            {
                // ListItem 값이 OptionGroupValue 가 아니때
                if (li.Value != this.GroupName)
                {
                    // 랜더링
                    RenderListItem(li, writer);
                }
                // ListItem 값이 OptionGroupValue 일때
                else
                {
                    if (writerEndTag)
                        // EndTag 랜더링
                        OptionGroupEndTag(writer);
                    else
                        writerEndTag = true;

                    // BeginTag 랜더링
                    OptionGroupBeginTag(li, writer);
                }
            }

            if (writerEndTag)
                // EndTag 랜더링
                OptionGroupEndTag(writer);
        }

        /// <summary>
        /// BeginTag 랜더링
        /// </summary>
        /// <param name="li">OptionGroup 값</param>
        /// <param name="writer">writer</param>
        private void OptionGroupBeginTag(ListItem li, HtmlTextWriter writer)
        {
            writer.WriteBeginTag("optgroup");

            // label 추가
            writer.WriteAttribute("label", li.Text);

            foreach (string key in li.Attributes.Keys)
            {
                writer.WriteAttribute(key, li.Attributes[key]);
            }

            writer.Write(HtmlTextWriter.TagRightChar);
            writer.WriteLine();
        }

        /// <summary>
        /// EndTag 랜더링
        /// </summary>
        /// <param name="writer">writer</param>
        private void OptionGroupEndTag(HtmlTextWriter writer)
        {
            writer.WriteEndTag("optgroup");
            writer.WriteLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="li">Option Item</param>
        /// <param name="writer">writer</param>
        private void RenderListItem(ListItem li, HtmlTextWriter writer)
        {
            writer.WriteBeginTag("option");

            // 옵션의 값을 기록합니다.
            writer.WriteAttribute("value", li.Value, true);

            if (li.Selected)
            {
                writer.WriteAttribute("selected", "selected", false);
            }

            foreach (string key in li.Attributes.Keys)
            {
                writer.WriteAttribute(key, li.Attributes[key]);
            }

            writer.Write(HtmlTextWriter.TagRightChar);

            HttpUtility.HtmlEncode(li.Text, writer);

            writer.WriteEndTag("option");
            writer.WriteLine();
        }


        /// <summary>
        /// Fill Data to DropDownList
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="addingItemMode"></param>
        public void FillData(DataTable dataSource, string displayMember, string valueMember, AddingItemMode addingItemMode)
        {
            if (dataSource == null) return;

            if (addingItemMode != AddingItemMode.None)
            {
                this.AddRowByAddingItemMode(dataSource, displayMember, valueMember, addingItemMode);
            }

            this.DataTextField = displayMember;
            this.DataValueField = valueMember;
            this.DataSource = dataSource;
            this.DataBind();

            if (dataSource != null && dataSource.Rows.Count > 0)
            {
                this.SelectedIndex = 0;
            }
        }

 
        private void AddRowByAddingItemMode(DataTable dataSource, string displayMember,
                                                string valueMember, AddingItemMode addingItemMode)
        {
            object strNewValueMember = string.Empty;
            string strNewDisplayMember = string.Empty;

            //다국어 지원 고려 되지 않은 상태 입니다.
            switch (addingItemMode)
            {
                case AddingItemMode.All:
                    strNewValueMember = "ALL";
                    strNewDisplayMember = "전체";
                    break;
                case AddingItemMode.Empty:
                    strNewValueMember = "EMPTY";
                    strNewDisplayMember = "";
                    break;
                case AddingItemMode.Select:
                    strNewValueMember = "SELECT";
                    strNewDisplayMember = "선택하십시오";
                    break;
                //case AddingItemMode.All:
                //    strNewValueMember = "IDEV_FRAMEWORK_ALL";
                //    strNewDisplayMember = "=== ALL ===";
                //    break;
                //case AddingItemMode.Empty:
                //    strNewValueMember = "IDEV_FRAMEWORK_EMPTY";
                //    strNewDisplayMember = "";
                //    break;
                //case AddingItemMode.Select:
                //    strNewValueMember = "IDEV_FRAMEWORK_SELECT";
                //    strNewDisplayMember = "=== Select ===";
                //    break;
            }

            if (dataSource.Columns[valueMember].DataType.Name.IndexOf("Int") >= 0)
            {
                strNewValueMember = 0;
            }

            DataRow row = dataSource.NewRow();
            row[valueMember] = strNewValueMember;
            row[displayMember] = strNewDisplayMember;
            dataSource.Rows.InsertAt(row, 0);
            dataSource.AcceptChanges();
        }
        #endregion
        
    }
}

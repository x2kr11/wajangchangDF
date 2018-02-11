using System;
using System.Drawing.Design;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;

[assembly: TagPrefix("eHR.Framework.Control", "SH")]
namespace eHR.Framework.Control
{
    /// <summary>
    /// PageNavigator에 대한 요약 설명입니다.
    /// </summary>
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [ToolboxData("<{0}:ShPageNavigatorNew runat=server></{0}:ShPageNavigatorNew>")]
  
    public class ShPageNavigatorNew : WebControl, INamingContainer
    {
        #region Field
        // Default 폰트명
        private string m_font_family = "tahoma";
        // Default 폰트크기
        private string m_font_size = "10";
        // Default First Image Path
        private string m_first_image_path = "~/Images/btn_prev2.gif";  
        // Default Prev Image Path
        private string m_prev_image_path = "~/Images/btn_prev.gif";
        // Default Next Image Path
        private string m_next_image_path = "~/Images/btn_next.gif";
        // Default Last Image Path
        private string m_last_image_path = "~/Images/btn_next2.gif";
        
        // Base Num
        private HtmlInputHidden txtBaseNum = null;
        // 현재 Page
        private HtmlInputHidden txtCurPage = null;
        // 총 리스트 건수
        private HtmlInputHidden txtTotListCount = null;

        // 페이지당 리스트 건수
        private HtmlInputHidden txtListPerPage = null;
        // 페이지당 리스트 건수
        //private int m_ListPerPage = 0;

        HtmlTableCell htcNum = null;

        // Total Count Label
        Label lblTotalCount = null;
        // 현재페이지 / 총 페이지
        Label lblTotalPage = null;
        // First Image Button
        ImageButton btnFirst = null;
        // Prev Image Button
        ImageButton btnPrev = null;
        // Next Image Button
        ImageButton btnNext = null;
        // Last Image Button
        ImageButton btnLast = null;

        // Event
        public event EventHandler Click;
        #endregion

        #region Constructor
        public ShPageNavigatorNew()
        {
            this.Click += Click;
        }
        #endregion

        #region Property
        [Bindable(true), Category("ShControl"), DefaultValue(""), Editor("System.Web.UI.Design.ImageUrlEditor, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), Description("Last Image Path")]
        public string ShLastImagePath
        {
            get
            {

                return m_last_image_path;
            }
            set
            {
                m_last_image_path = value;
            }
        }

        [Bindable(true), Category("ShControl"), DefaultValue(""), Editor("System.Web.UI.Design.ImageUrlEditor, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), Description("Previous Image Path")]
        public string ShPrevImagePath
        {
            get
            {
              
                return m_prev_image_path;
            }
            set
            {
                m_prev_image_path = value;
            }
        }

        [Bindable(true), Category("ShControl"), DefaultValue(""), Editor("System.Web.UI.Design.ImageUrlEditor, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), Description("Next Image Path")]
        public string ShNextImagePath
        {
            get
            {
              
                return m_next_image_path;
            }
            set
            {
                m_next_image_path = value;
            }
        }

        [Bindable(true), Category("ShControl"), DefaultValue(""), Editor("System.Web.UI.Design.ImageUrlEditor, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), Description("First Image Path")]
        public string ShFirstImagePath
        {
            get
            {
                return m_first_image_path;
            }
            set
            {
                m_first_image_path = value;
            }
        }

        [Bindable(true), Category("ShControl"), DefaultValue(""), Editor("System.Web.UI.Design.ImageUrlEditor, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), Description("List Count per Page")]
        public string ShListPerPage
        {
            get
            {
                EnsureChildControls();
                return txtListPerPage.Value;
            }
            set
            {
                EnsureChildControls();
                txtListPerPage.Value = value;
            }
        }

        [Description("현재페이지"), Category("ShControl")]
        public string ShCurrentPage
        {
            get
            {
                EnsureChildControls();
                return txtCurPage.Value;
            }
            set
            {
                EnsureChildControls();

                txtCurPage.Value = value;
                Reset();
            }
        }


        [Description("총 리스트 건수Visible"), Category("ShControl")]
        public bool ShTotalListCountVisible
        {
            get
            {
                return txtTotListCount.Visible;
            }
            set
            {
                txtTotListCount.Visible = value;
            }
        }

        
        [Description("총 리스트 건수"), Category("ShControl")]
        public string ShTotalListCount
        {
            get
            {
                EnsureChildControls();
                return txtTotListCount.Value;
            }
            set
            {
                EnsureChildControls();
                if (this.txtTotListCount == null)
                    this.txtTotListCount = new HtmlInputHidden();

                if (txtTotListCount.Value != value)
                {
                    Reset();
                }
                txtTotListCount.Value = value;
            }
        }

        [Description("폰트명"), Category("ShControl")]
        public string FontName
        {
            get
            {
                return m_font_family;
            }
            set
            {
                m_font_family = value;
            }
        }

        [Description("폰트크기"),Category("ShControl")]
        public string FontSize
        {
            get
            {
                return m_font_size;
            }
            set
            {
                m_font_size = value;
            }
        }


        private bool bLoadingVisiable = false;
        [Bindable(true),
        DefaultValue(false), Category("ShControl"),
        Description("클릭시 Loading 표시 여부")]
        public bool DisplayLoading
        {
            get
            {
                return this.bLoadingVisiable;
            }

            set
            {
                this.bLoadingVisiable = value;
            }
        }


		// 페이지 네비게이션 출력 상수 설정
		private int m_PageNavCount = 10;
		[Bindable(true),
		DefaultValue(false), Category("ShControl"),
		Description("페이지 버튼 개수")]
		public int PageNavCount
		{
			get
			{
				return this.m_PageNavCount;
			}

			set
			{
				this.m_PageNavCount = value;
			}
		}
        #endregion

        #region Reset
        public void Reset()
        {
            EnsureChildControls();

            if (txtCurPage.Value == "0")
            {
                txtBaseNum.Value = "0";
                txtCurPage.Value = "1";

                return;
            }

            // 1~10 까지는 BaseNum : 0, 11~20 : 10 이렇게 계산되어야 함.
            int nCurrentPage = Convert.ToInt32(txtCurPage.Value);
            nCurrentPage = (nCurrentPage - 1) / 10 * 10;

            txtBaseNum.Value = nCurrentPage.ToString();
        }
        #endregion

        #region OnClick
        protected virtual void OnClick(EventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
                //Page.ClientScript.GetPostBackEventReference(this, as,as);
                //string postback = Page.ClientScript.GetPostBackEventReference(this, "arg", true);
              //this.Attributes.Add("OnClick", postback); 
            }
        }

         
        #endregion

        #region CreateChildControls
        protected override void CreateChildControls()
        {
            // State Store
            // 1. Base Number
            txtBaseNum = new HtmlInputHidden();
            txtBaseNum.Value = "0";
            Controls.Add(txtBaseNum);

            // 2. Current Page
            txtCurPage = new HtmlInputHidden();
            txtCurPage.Value = "0";
            Controls.Add(txtCurPage);

            // 3. Total List Count
            txtTotListCount = new HtmlInputHidden();
            txtTotListCount.Value = "0";
            Controls.Add(txtTotListCount);

            // 4. List Per Page
            txtListPerPage = new HtmlInputHidden();
            txtListPerPage.Value = "0";
            Controls.Add(txtListPerPage);

            // # Table Add
            HtmlTable oTable = new HtmlTable();
            oTable.Width = "100%";
            
            oTable.Attributes.Add("class","Nnavi");

            HtmlTableRow oRow = new HtmlTableRow();
            HtmlTableCell oCell = new HtmlTableCell();
            //oCell.Width = "40%";
            //oCell.InnerHtml = "&nbsp;";
            //oRow.Cells.Add(oCell);

            //oCell = new HtmlTableCell();
            //oCell.Width = "60%";
            //oCell.Attributes.Add("class", "paging");

            htcNum = new HtmlTableCell();
            //htcNum.Align = "center";
            //htcNum.Width = "70%";
            //htcNum.Attributes.Add("class", "paging");
            //htcNum.Attributes.Add("style", "vertical-align:middle;");

            // 4. First Button
            btnFirst = new ImageButton();
            btnFirst.ImageUrl = this.ShFirstImagePath;
            btnFirst.AlternateText = "First";
            btnFirst.Attributes.Add("title", "First");
            btnFirst.Attributes.Add("class", "ico-b1");
            btnFirst.Attributes.Add("style", "float:left");

            btnFirst.OnClientClick = "";
            btnFirst.Click += new ImageClickEventHandler(btnFirst_Click);
            htcNum.Controls.Add(btnFirst);

            Label lblFirst = new Label();
            //lblFirst.Text = "&nbsp;";
            htcNum.Controls.Add(lblFirst);

            // 4. Prev Button
            btnPrev = new ImageButton();
            btnPrev.ImageUrl = this.ShPrevImagePath;
            btnPrev.AlternateText = "Prev";
            btnPrev.Attributes.Add("title", "Prev");
            btnPrev.Attributes.Add("class", "ico-b1");
            btnPrev.Attributes.Add("style", "float:left");
            btnPrev.OnClientClick = "";
            btnPrev.Click += new ImageClickEventHandler(btnPrev_Click);
            htcNum.Controls.Add(btnPrev);

            Label lblPrev = new Label();
            lblPrev.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            htcNum.Controls.Add(lblPrev);

            // 5. Num Button
			for (int i = 1; i <= PageNavCount; i++)
            {
                LinkButton btnNum = new LinkButton();
                btnNum.Text = string.Format("{0}", i.ToString());
                //btnNum.Style.Add("font-size", this.FontSize);
                //btnNum.Style.Add("font-family", this.FontName);
                btnNum.OnClientClick = "";
                
                btnNum.Click += new EventHandler(btnNum_Click);
                btnNum.Visible = false;
                htcNum.Controls.Add(btnNum);

                Label lblNum = new Label();
                lblNum.Text = "&nbsp;";
                htcNum.Controls.Add(lblNum);
            }

            Label lblNext = new Label();
            lblNext.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            htcNum.Controls.Add(lblNext);

            // 6. Next Button
            btnNext = new ImageButton();
            btnNext.ImageUrl = this.ShNextImagePath;
            btnNext.AlternateText = "Next";
            btnNext.Attributes.Add("title", "Next");
            btnNext.Attributes.Add("class", "ico-b2");

            btnNext.OnClientClick = "";               
            btnNext.Click += new ImageClickEventHandler(btnNext_Click);
            htcNum.Controls.Add(btnNext);

            Label lblLast = new Label();
            lblLast.Text = "&nbsp;";
            htcNum.Controls.Add(lblLast);

            // 6. Last Button
            btnLast = new ImageButton();
            btnLast.ImageUrl = this.ShLastImagePath;
            btnLast.AlternateText = "Last";
            btnLast.Attributes.Add("title", "btnLast");
            btnLast.Attributes.Add("class", "ico-b2");

            btnLast.OnClientClick = "";           
            btnLast.Click += new ImageClickEventHandler(btnLast_Click);
            htcNum.Controls.Add(btnLast);

            htcNum.Width = "20%";
            //oCell.Controls.Add(htcNum);
            oRow.Cells.Add(htcNum);

            // 전체 건수
            oCell = new HtmlTableCell();
            //oCell.Width = "20%";
            //oCell.Attributes.Add("class", "total alignRight");

            // Total List Count
            lblTotalCount = new Label();
            oCell.Controls.Add(lblTotalCount);
            oCell.Width = "80%";
            oCell.Align = "left";
            oRow.Cells.Add(oCell);

            /*
            // Total Page
            oCell = new HtmlTableCell();
            lblTotalPage = new Label();
            lblTotalPage.Style.Add("font-size", m_font_size);
            lblTotalPage.Style.Add("font-family", m_font_family);
            lblTotalPage.Text = " / page";
            oCell.Align = "right";
            oCell.Width = "120px";
            oCell.Controls.Add(lblTotalPage);
            oRow.Cells.Add(oCell);
            */

            oTable.Rows.Add(oRow);
            Controls.Add(oTable);
        }
        #endregion

        #region OnPreRender
        protected override void OnPreRender(EventArgs e)
        {
            int i = 1;
            foreach (System.Web.UI.Control oCtl in htcNum.Controls)
            {
                if (oCtl.GetType().ToString() == "System.Web.UI.WebControls.LinkButton")
                {
                    if (IsNumberString(((LinkButton)oCtl).Text))
                    {
                        ((LinkButton)oCtl).Text = string.Format("{0}", i + GetInt(((HtmlInputHidden)Controls[0]).Value));
                        i++;
                        
                    }
                }
            }
            
            // 변수 선언
            int iBaseNum = 0;
            int iTotListCount = 0;
            int iCurrentPage = 0;

            // 변수 설정
            iBaseNum = GetInt(txtBaseNum.Value);
            iCurrentPage = GetInt(txtCurPage.Value);
            iTotListCount = GetInt(txtTotListCount.Value);

            // 이미지 설정
            btnFirst.ImageUrl = this.ShFirstImagePath;// == "" ? Page.ClientScript.GetWebResourceUrl(this.GetType(), "Mosti.Web.Controls.Resources.arrfirst.png") : this.ShFirstImagePath;
            btnLast.ImageUrl = this.ShLastImagePath;// == "" ? Page.ClientScript.GetWebResourceUrl(this.GetType(), "Mosti.Web.Controls.Resources.arrend.png") : this.ShFirstImagePath;
            btnPrev.ImageUrl = this.ShPrevImagePath;// == "" ? Page.ClientScript.GetWebResourceUrl(this.GetType(), "Mosti.Web.Controls.Resources.arrprev.png") : this.ShFirstImagePath;
            btnNext.ImageUrl = this.ShNextImagePath;// == "" ? Page.ClientScript.GetWebResourceUrl(this.GetType(), "Mosti.Web.Controls.Resources.arrnext.png") : this.ShFirstImagePath;

            // 총 리스트 건수 보이기
            if (iTotListCount < 1)
            {
                lblTotalCount.Visible = false;
            }
            else
            {
                lblTotalCount.Text = string.Format("전체 <b>{0}</b> 건", iTotListCount);
                lblTotalCount.Visible = true;
            }

            /*
            // 페이지수 보이기
            if (iTotListCount < 1)
            {
                lblTotalPage.Visible = false;
            }
            else
            {
                lblTotalPage.Text = string.Format("{0} / {1} Page", iCurrentPage, (iTotListCount / GetInt(this.ListPerPage) + ((iTotListCount % GetInt(this.ListPerPage)) == 0 ? 0 : 1)));
                lblTotalPage.Visible = true;
            }
            */

            // 출력 설정
            // 1. Base Page가 0인 경우 Prev 버튼을 감춘다.
            if (iBaseNum == 0)
            {
                btnPrev.Visible = false;
                btnFirst.Visible = false;
            }
            else
            {
                btnPrev.Visible = true;
                btnFirst.Visible = true;
            }

            // 2. 총 리스트 개수보다 ( BaseNum * 페이지당 리스트 개수) + ( 페이지당 리스트 개수 * ( 네비게이션 출력개수 + 1) ) 가 작으면 Next 버튼을 감춘다.
			if (iTotListCount <= (iBaseNum * GetInt(this.ShListPerPage)) + (GetInt(this.ShListPerPage) * (PageNavCount)))
            {
                btnNext.Visible = false;
                btnLast.Visible = false;
            }
            else
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }

            // 3. 페이지 네비게이션 출력
            i = 1;

            // 페이지번호 감추기 및 강조
            foreach (System.Web.UI.Control oCtl in htcNum.Controls)
            {
                if (oCtl.GetType().ToString() == "System.Web.UI.WebControls.LinkButton")
                {

					//oCtl.Visible = false;

                    if (IsNumberString(((LinkButton)oCtl).Text))
                    {
                        // Hidden Or Visible
                        // total list count 가 0보다 클 경우 보여줄 페이지를 선택한다.
                        if ((GetInt(((LinkButton)oCtl).Text.Replace("[", "").Replace("]", "")) - 1) * GetInt(this.ShListPerPage) < iTotListCount && iTotListCount > 0)
                            oCtl.Visible = true;
                        else
                            oCtl.Visible = false;
                        // Set Strong
                        if (GetInt(((LinkButton)oCtl).Text.Replace("[", "").Replace("]", "")) == iCurrentPage)
                        {
                            ((LinkButton)oCtl).ControlStyle.Font.Bold = true;
                            ((LinkButton)oCtl).ControlStyle.ForeColor = System.Drawing.Color.Red;
                            ((LinkButton)oCtl).Text = string.Format("{0}", iCurrentPage);
                            
                        }
                        else
                        {
                            ((LinkButton)oCtl).ControlStyle.Font.Bold = false;
                            ((LinkButton)oCtl).ControlStyle.ForeColor = System.Drawing.Color.Black;
                        }
                        
                        i++;
                    }
                }
            }

            System.Web.UI.Control oLbl = null;
            for (int k = 0; k < htcNum.Controls.Count; k++)
            {
                oLbl = htcNum.Controls[k];
                if (oLbl.GetType().ToString() == "System.Web.UI.WebControls.LinkButton")
                {
                    if (oLbl.Visible == false)
                    {
                        htcNum.Controls[k + 1].Visible = false;
                    }
                    else
                    {
                        htcNum.Controls[k + 1].Visible = true;
                    }
                }
            }

            this.Attributes.Add("align", "center");
            this.CssClass = this.CssClass;
        }
        #endregion

        #region btnFirst_Click
        private void btnFirst_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (Int32.Parse(txtBaseNum.Value) >= 10)
            {
                txtCurPage.Value = Convert.ToString(1);
                txtBaseNum.Value = Convert.ToString(0);
                OnClick(new EventArgs());
            }
            else
            {
                txtBaseNum.Value = txtBaseNum.Value;
            }
        }
        #endregion

        #region btnPrev_Click
        private void btnPrev_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (Int32.Parse(txtBaseNum.Value) >= 10)
            {
                txtCurPage.Value = Convert.ToString(Int32.Parse(txtBaseNum.Value));
                txtBaseNum.Value = Convert.ToString(Int32.Parse(txtBaseNum.Value) - 10);
                OnClick(new EventArgs());
            }
            else
            {
                txtBaseNum.Value = txtBaseNum.Value;
            }
        }
        #endregion

        #region btnNum_Click
        private void btnNum_Click(object sender, EventArgs e)
        {
            txtBaseNum.Value = txtBaseNum.Value;
            txtCurPage.Value = ((LinkButton)sender).Text.Replace("[", "").Replace("]", "");
            OnClick(new EventArgs());

             


        }
        #endregion

        #region btnNext_Click
        private void btnNext_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            txtBaseNum.Value = Convert.ToString((GetInt(txtBaseNum.Value) + 10));
            txtCurPage.Value = Convert.ToString((GetInt(txtBaseNum.Value) + 1));
            OnClick(new EventArgs());
        }
        #endregion

        #region btnLast_Click
        private void btnLast_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            int iBaseNum = 0;
            int iTotListCount = 0;
            int iCurrentPage = 0;
            int iTmp = 0;

            iBaseNum = GetInt(txtBaseNum.Value);
            iCurrentPage = GetInt(txtCurPage.Value);
            iTotListCount = GetInt(txtTotListCount.Value);

            iTmp = (int)(iTotListCount / GetInt(this.ShListPerPage));

            if (iTmp - (iTmp % 10) == GetInt(txtTotListCount.Value))
                txtBaseNum.Value = Convert.ToString(iTmp - (iTmp % 10) - 10);
            else
                txtBaseNum.Value = Convert.ToString(iTmp - (iTmp % 10));
            txtCurPage.Value = Convert.ToString(iTotListCount / GetInt(this.ShListPerPage) + ((iTotListCount % GetInt(this.ShListPerPage)) == 0 ? 0 : 1));
            OnClick(new EventArgs());
        }
        #endregion

        #region IsNumberString
        private bool IsNumberString(string s)
        {
            bool bReturn = false;
            s = s.Replace("[", "").Replace("]", "");
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsNumber(s, i) != true)
                {
                    bReturn = false;
                    break;
                }
                else
                {
                    bReturn = true;
                }
            }
            return bReturn;
        }
        #endregion

        #region GetInt
        private int GetInt(object o)
        {
            string s = o.ToString();
            if (IsNumberString(s))
                return Int32.Parse(s);
            else
                return 0;
        }
        #endregion
    }
}

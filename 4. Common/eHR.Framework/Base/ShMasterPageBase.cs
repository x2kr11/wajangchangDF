using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace eHR.Framework.Base
{
    public class ShMasterPageBase : MasterPage
    {
        private readonly string _loadingImg = "/images/loading.gif";
        private readonly string _loadingClose = "MostiLoading.Fn_CloseLoading();";
        
        private string DIV { get; set; }

        public ShMasterPageBase()
        {
            this.SetCreateDivMessage();
        }
        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {  
            base.OnLoad(e);
        }

        private void SetCreateDivMessage()
        {
            //StringWriter _div = new StringWriter();
            
            ////_div.WriteLine("<div id=\"__BACKGROUND_ENABLE_FALSE\" style=\"z-index:99998; filter: Alpha(Opacity=60); opacity:0.6; -moz-opacity:0.6; position:absolute; background-color:#A1B2CB; visibility:hidden; vertical-align:middle\"/>");
            ////_div.WriteLine("<div id=\"__BACKGROUND_ENABLE_TABLE\" style=\"z-index:99999; filter: Alpha(Opacity=300); position:absolute; visibility:hidden;\">");
            ////_div.WriteLine("<table cellpadding=\"2\" cellspacing=\"2\">");
            ////_div.WriteLine("        <tr>");
            ////_div.WriteLine("            <td><img src=\"{0}\"  onclick=\"{1}\"/></td>", this._loadingImg, this._loadingClose);
            ////_div.WriteLine("            <td class=\"sk_text_gray_12 sk_text_bold\"><b>&nbsp;&nbsp;now loading, please wait.</b></td>");
            ////_div.WriteLine("        </tr>");
            ////_div.WriteLine("    </table>");
            ////_div.WriteLine(" </div>");
            
            //this.DIV = _div.ToString();
        }
    }
}

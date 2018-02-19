<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailList.aspx.cs" Inherits="WebApplication2.DetailList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="txt/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <link rel="stylesheet" type="text/css" href="/styles/css/common.css" />
    <link rel="stylesheet" type="text/css" href="/styles/css/layout.css" />
    <link rel="stylesheet" type="text/css" href="/styles/css/btn01.css" />
    <link rel="stylesheet" type="text/css" href="/styles/css/board01.css" />
    <link rel="stylesheet" type="text/css" href="/styles/css/table01.css" />
    <link rel="stylesheet" type="text/css" href="/styles/css/object.css" />
    <link rel="stylesheet" type="text/css" href="/styles/css/popup.css" />
    <link rel="stylesheet" type="text/css" href="/styles/css/main.css" />
    <link rel="icon" href="/styles/images/favicon.ico" type="image/x-icon" />
    <script type="text/javascript" src="/styles/js/css.browser.detect.js"></script>
    <script type="text/javascript" src="/styles/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="/styles/js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="/styles/js/jquery.form.js"></script>
    <script type="text/javascript" src="/styles/js/jquery.ui.js"></script>
    <script type="text/javascript" src="/styles/js/common.js"></script>
    <title></title>
    <script type="text/javascript">    
        //Cancel 버튼 클릭 시
        function btnCancel_OnClick() {
            parent.MostiPopup.HidePopup();
        }
        //모험단 변경 시
        function ddlLocation_change() {
             <%=GetPostBackEventReference(btnAdventure)%>
            return false;
        }
    </script>
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        .GridPager a, .GridPager span {
            display: block;
            height: 15px;
            width: 15px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
        }

        .GridPager a {
            background-color: #f5f5f5;
            color: #969696;
            border: 1px solid #969696;
        }

        .GridPager span {
            background-color: #A1DCF2;
            color: #000;
            border: 1px solid #3AC0F2;
        }
    </style>
</head>
<body style="min-width: 920px">
    <form id="form1" runat="server">
        <div id="lay_wrap" class="lay_expand">
            <div id="pop_layer2" class="pop_contents" style="display: block; top: 0;">
                <!--popup contents-->
                <div class="pop_con_fix pop_con_fix_scroll" style="overflow: hidden">
                    <div class="pop_con_area">
                        <div class="section_margin_s">
                            <!-- Horizontal Table -->
                            <div class="tbl_hori skin01">
                                <table class="tbl_hori_inside" summary="insert">
                                    <caption>Insert Table</caption>
                                    <colgroup>
                                        <col width="15%">
                                        <col width="35%">
                                        <col width="15%">
                                        <col width="">
                                    </colgroup>
                                    <tbody>
                                        <tr class="hori_t_row">
                                            <th scope="row" class="hori_t_head">모험단명</th>
                                            <td class="hori_t_data">
                                                <select class="jqForm pct" id="ddlGirin" runat="server" onchange="ddlLocation_change()">
                                                </select>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <!-- //Horizontal Table -->
                            <p style="margin: 15px 0;">
                                <div class="board_list">
                                    <asp:GridView ID="gvGirinList" runat="server" AutoGenerateColumns="false" CssClass="board_list_table" EmptyDataText='empty' ShowHeaderWhenEmpty="true" CellPadding="0" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvGirinList_PageIndexChanging" PageIndex="0">
                                        <HeaderStyle CssClass="board_list_row" />
                                        <RowStyle CssClass="board_list_row" />
                                        <EmptyDataRowStyle CssClass="empty" />
                                        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderStyle CssClass="board_list_head" Width="20%" />
                                                <HeaderTemplate>캐릭터명</HeaderTemplate>
                                                <ItemStyle CssClass="board_list_data align_center" />
                                                <ItemTemplate>
                                                    <%#Eval("characterName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderStyle CssClass="board_list_head" />
                                                <HeaderTemplate>획득한 아이템</HeaderTemplate>
                                                <ItemStyle CssClass="board_list_data align_left" />
                                                <ItemTemplate>
                                                    <%# Eval("itemName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderStyle CssClass="board_list_head" />
                                                <HeaderTemplate>날짜</HeaderTemplate>
                                                <ItemStyle CssClass="board_list_data align_left" />
                                                <ItemTemplate>
                                                    <%#Eval("date") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </p>
                            <!--Button Area-->
                            <div class="btn_section">
                                <div class="center_section">
                                    <a href="#" id="btnCancel" class="btn_txt btn_type_a btn_color_a" onclick="btnCancel_OnClick()">
                                        <span class="txt">Cancel</span>
                                        <!-- Cancel -->
                                    </a>
                                    <%-- <aspx:shlinkbutton id="btnLocation" runat="server" cssclass="btn_txt btn_srch btn_color_a" visible="false" onclick="btnLocation_Click">                           
                                            </aspx:shlinkbutton>--%>
                                    <asp:LinkButton ID="btnAdventure" runat="server" Visible="false" OnClick="btnAdventure_Click"></asp:LinkButton>
                                </div>
                                <div class="clearboth"></div>
                            </div>
                            <!--//Button Area-->
                        </div>
                    </div>
                </div>
                <!--//popup contents-->
            </div>
            <!-- //Contents Popup -->
        </div>
    </form>
</body>
</html>

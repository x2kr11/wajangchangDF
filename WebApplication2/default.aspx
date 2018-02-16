<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication2.WebForm1" %>

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
    <script type="text/javascript">
        function btnFlag_Click(Flag) {
            $("#<%= hidFlag.ClientID%>").val(Flag);
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="page_tit">
                <tr>
                    <td class="tit_area">                       
                        <div class="tit">획득 목록</div>                       
                    </td>
                    <td>
                          <a href="http://developers.neople.co.kr" target="_blank">
                            <img src="styles/images/loc_info/neopleAPI_Logo.png" alt="Neople 오픈 API" />
                        </a>
                    </td>
                    <td class="btn_area">
                        <!-- 버튼 추가!-->
                        <asp:LinkButton ID="btnSku" runat="server" OnClientClick="return btnFlag_Click('Sku')" OnClick="btnSearch_Click" CssClass="btn_txt btn_srch btn_color_a">
                        <span css="txt">skuSearch</span>
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnFiori" runat="server" OnClientClick="return btnFlag_Click('Fiori')" OnClick="btnSearch_Click" CssClass="btn_txt btn_srch btn_color_a">
                        <span css="txt">FioriSearch</span>
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnXian" runat="server" OnClientClick="return btnFlag_Click('Xian')" OnClick="btnSearch_Click" CssClass="btn_txt btn_srch btn_color_a">
                        <span css="txt">XianSearch</span>
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnLunch" runat="server" OnClientClick="return btnFlag_Click('Lunch')" OnClick="btnSearch_Click" CssClass="btn_txt btn_srch btn_color_a">
                        <span css="txt">LunchSearch</span>
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnInsert" runat="server" CssClass="btn_txt btn_srch btn_color_a" PostBackUrl="~/InsertID.aspx">
                        <span css="txt">캐릭터 등록</span>
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hidFlag" runat="server" />
            <!-- //Page Title -->
            <!-- Search-->
            <div class="srch_type01 skin01">
                <div class="condition_area">
                    <table class="condition_table" summary="Search Table">
                        <caption>Search Table</caption>
                        <tbody>
                            <tr>
                                <th scope="col" class="condition_t_head">Search Condition</th>
                                <td class="condition_t_data" style="width: 120px;">
                                    <select class="jqForm pct" id="ddlCondition" runat="server">
                                        <option value="cacNm">캐릭터 이름</option>
                                        <option value="adventureNM">모험단 검색</option>
                                    </select>
                                </td>
                                <td class="condition_t_data noborder_left">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="pct"></asp:TextBox></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="btn_area">
                    <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="btn_txt btn_srch btn_color_a">       
                            <span css="txt">Search</span>
                    </asp:LinkButton>
                </div>
            </div>
            <!--// Search-->
            <!-- Sub Title -->
            <div class="opt_tit">
                <div class="opt_tit_left">
                    <div class="elmt">
                        <span class="opt_tit_bu opt_tit_bu_01"></span>
                        <span class="txt">Search Result</span>
                    </div>
                </div>
                <div class="opt_tit_right">
                    <div class="elmt">
                        <span class="total">Total : <b>
                            <asp:Literal ID="gvCount" runat="server"></asp:Literal></b></span>
                    </div>
                </div>
            </div>
            <!-- //Sub Title -->
            <!-- Board List -->
            <div class="board_list" style="margin-bottom: 10px">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" CssClass="board_list_table" ShowHeaderWhenEmpty="True" CellPadding="0" AllowPaging="true" PageSize="10" OnDataBound="gvList_DataBound" OnPageIndexChanging="gvList_PageIndexChanging" PageIndex="1">
                    <HeaderStyle CssClass="board_list_row" />
                    <RowStyle CssClass="board_list_row" />
                    <EmptyDataRowStyle CssClass="empty" />
                    <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
                    <Columns>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                characterName
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("characterName") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                Item Name
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("itemName") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                Date
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("date") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                Channel
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("ChannelName") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                ChannelNO
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("channelNo") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                dungeonName
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("dungeonName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <!-- Sub Title -->
            <div class="opt_tit">
                <div class="opt_tit_left">
                    <div class="elmt">
                        <span class="opt_tit_bu opt_tit_bu_01"></span>
                        <span class="txt">Search Result 봉자! </span>
                    </div>
                </div>
                <div class="opt_tit_right">
                    <div class="elmt">
                        <span class="total">Total : <b>
                            <asp:Literal ID="gvCount2" runat="server"></asp:Literal></b></span>
                    </div>
                </div>
            </div>
            <!-- //Sub Title -->
            <!-- Board List -->
            <div class="board_list">
                <asp:GridView ID="gvList2" runat="server" AutoGenerateColumns="false" CssClass="board_list_table" ShowHeaderWhenEmpty="True" CellPadding="0" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvList2_PageIndexChanging" PageIndex="1">
                    <HeaderStyle CssClass="board_list_row" />
                    <RowStyle CssClass="board_list_row" />
                    <EmptyDataRowStyle CssClass="empty" />
                    <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                characterName
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("characterName") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                Name
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                Date
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("date") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                itemId
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("itemId") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                itemName
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("itemName") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                booster
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("booster") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>

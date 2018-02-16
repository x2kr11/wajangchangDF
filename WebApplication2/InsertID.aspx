<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertID.aspx.cs" Inherits="WebApplication2.InsertID" %>

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
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="page_tit">
                <tr>
                    <td class="tit_area">
                        <div class="tit">캐릭터 등록</div>
                    </td>
                    <td class="btn_area">
                        <!-- 버튼 추가!-->
                        <asp:LinkButton ID="btnList" runat="server" CssClass="btn_txt btn_srch btn_color_a" PostBackUrl="~/default.aspx">
                        <span css="txt">List</span>
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
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
                                        <option value="cacNm">추가할 캐릭터 이름</option>
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
            <div class="board_list" style="margin-bottom: 10px">
                <asp:GridView ID="gvCacList" runat="server" AutoGenerateColumns="false" CssClass="board_list_table" ShowHeaderWhenEmpty="True" CellPadding="0" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvCacList_PageIndexChanging" PageIndex="1">
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
                                <%# Eval("id") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                            <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                characterName
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("serverId") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                            <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                characterName
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("characterId") %>
                            </ItemTemplate>
                        </asp:TemplateField>

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
                                characterName
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("adventureName") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                            <asp:TemplateField>
                            <HeaderStyle CssClass="board_list_head" Width="5%" />
                            <HeaderTemplate>
                                characterName
                            </HeaderTemplate>
                            <ItemStyle CssClass="board_list_data align_center" />
                            <ItemTemplate>
                                <%# Eval("guildId") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>

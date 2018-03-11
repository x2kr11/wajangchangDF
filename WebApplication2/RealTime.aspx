<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RealTime.aspx.cs" Inherits="WebApplication2.RealTime" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

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
<body>
    <form id="form1" runat="server">
        <div>
            <table class="page_tit">
                <tr>
                    <td class="tit_area">
                        <div class="tit">오늘의 에픽(실시간 반영)</div>
                    </td>
                    <td>
                        <a href="http://developers.neople.co.kr" target="_blank">
                            <img src="styles/images/loc_info/neopleAPI_Logo.png" alt="Neople 오픈 API" />
                        </a>
                    </td>
                    <td class="btn_area"></td>
                </tr>
            </table>
            <asp:HiddenField ID="hidFlag" runat="server" />
            <!-- //Page Title -->
            <!-- Search-->
            <div class="srch_type01 skin01">
                <%--    <div class="condition_area">
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
                </div>--%>
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
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Timer ID="TodayEpicTimer" runat="server" Interval="60000" OnTick="Timer1_Tick"></asp:Timer>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="board_list" style="margin-bottom: 10px">
                        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" CssClass="board_list_table" ShowHeaderWhenEmpty="True" CellPadding="0" AllowPaging="true" PageSize="15" OnDataBound="gvList_DataBound" OnPageIndexChanging="gvList_PageIndexChanging" PageIndex="0">
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
                    <!-- //Board List-->
                    <asp:Chart ID="chartWajangchang" runat="server" DataSourceID="SqlDataSource1" Width="1024px">
                        <Series>
                            <asp:Series Name="Series1" XValueMember="adventureName" YValueMembers="epic"></asp:Series>
                        </Series>

                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>

                    </asp:Chart>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:wajangchangConnectionString %>" SelectCommand="SELECT B.adventureName
		  ,Count(*) AS epic
	FROM timeline_hell_epic A
	INNER JOIN character_info B ON A.characterId = B.characterId
	WHERE convert(int, convert(char(8), date , 112)) = convert(varchar(8), GetDate(), 112)
	GROUP BY B.adventureName
	ORDER BY epic DESC"></asp:SqlDataSource>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TodayEpicTimer" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
            <!-- Layer Popup -->
            <div id="mw">
                <div class="pop_bg"></div>
                <div id="__layer_pop" class="pop_layer_s">
                    <div class="pop_tit_wrap">
                        <h2 class="pop_tit" id="__layer_pop_title">Popup Title</h2>
                        <a href="javascript:;" class="close_area">
                            <span class="pop_layer_btn pop_layer_btn_close">
                                <span class="blind">팝업 닫기</span>
                            </span>
                        </a>
                    </div>
                    <div class="pop_con_fix" id="__layer_pop_content_body1">
                        <div class="pop_con_area" id="__layer_pop_content_body2">
                            <iframe id="__layer_pop_content_frame" name="__layer_pop_content_frame" style="width: 100%; border: 0px;"></iframe>
                        </div>
                    </div>
                </div>
            </div>
            <input type="hidden" id="hidMenuId" name="hidMenuId" value=" " />
            <!-- //Layer Popup -->
    </form>
</body>
</html>

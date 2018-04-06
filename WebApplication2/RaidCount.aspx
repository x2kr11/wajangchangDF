<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RaidCount.aspx.cs" Inherits="WebApplication2.RaidCount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
        $(document).ready(function () {
            $("#chkAll").click(function () {
                $("input:checkbox").not(this).prop("checked", this.checked);
            });

            $(".inp_date").MostiDatepicker();
        })



        function deleteLeaveRowList() {
            var checkedRow = $("input:checkbox:checked").not("#chkAll");
            checkedRow.each(function () {
                $(this).parent().parent().parent().remove();
            })
        }

        function addLeaveRowList() {
            var rowSeq = $("#tbRaidList tr").length;

            var tbodyObj = $("#tbRaidList");
            var trObj = $("<tr class='vert_t_row'></tr>");

            var tbchkObj = $("<td class='vert_t_data' style='text-align: center;'></td>");
            tbchkObj.append("<input type='checkbox' class='jqForm' name='chbox'/>");

            trObj.append(tbchkObj);

            var tdVacationTypeObj = $("<td class='vert_t_data'></td>");

            //그룹1
            var groupSelectObj = $("<select name='Raid_Group' class='jqForm' style='width:130px;'><select>");
            groupSelectObj.append("<option value='안톤' </option>");

            //그룹2
            var typeSelectObj = $("<select name='Raid_Type' class='jqForm' style='width:130px;'></select>");
            typeSelectObj.append("<option value='싱글'></option>'");

            tdVacationTypeObj.append(groupSelectObj);
            tdVacationTypeObj.append(" ");

            tdVacationTypeObj.append(typeSelectObj);
            trObj.append(tdVacationTypeObj);

            //날짜
            var tdFromObj = $("<td class='vert_t_data'></td>");
            var divStarObj = $("<div style='display:inline-block'></div>");
            tdFromObj.append("<input type='text' class='inp_date' name='Start_DT' readonly='true'/>");
            divStarObj.append("<span class='jqTransformRadioWrapper'><input type='radio' class='jqForm jqTransformHidden jqRadio' id='startAmPm01_" + rowSeq + "' name='Start_AM_PM[" + rowSeq + "]' value='AM' checked='checked' /><span class='jqTransformRadio'></span></span><label for='startAmPm01' style='cursor: pointer;'>오전</label>");
            divStarObj.append("<span class='jqTransformRadioWrapper'><input type='radio' class='jqForm jqTransformHidden jqRadio' id='startAmPm02_" + rowSeq + "' name='Start_AM_PM[" + rowSeq + "]' value='PM' /><span class='jqTransformRadio'></span></span><label for='startAmPm02' style='cursor: pointer;'>오후</label>");

            tdFromObj.append(divStarObj);
            trObj.append(tdFromObj);

            var tdNameObj = $("<td class='vert_t_data'><input type='text' class='pct' name='Remarks' maxlength=500'/>");
            trObj.append(tdNameObj);

            var tdPhaseObj = $("<td class='vert_t_data'><input type='text' class='pct' name='Phase' maxlenght=500/>");
            trObj.append(tdPhaseObj);

            trObj.find(".inp_date").MostiDatepicker();

            tbodyObj.append(trObj);
            tbodyObj.removeClass("jqtransformdone");
            tbodyObj.jqTransform();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Sub Title -->
        <div class="opt_tit mgT20">
            <div class="opt_tit_left">
                <div class="elmt">
                    <span class="opt_tit_bu opt_tit_bu_01"></span>
                    <span class="txt">Raid</span>
                </div>
            </div>
            <div class="opt_tit_right">
                <div class="elmt">
                    <a href="#" onclick="javascript:addLeaveRowList()" class="btn_txt btn_type_b btn_color_b">
                        <span class="txt">행 추가</span>
                    </a>
                    <a href="#" onclick="javascript:deleteLeaveRowList()" class="btn_txt btn_type_b btn_color_a">
                        <span class="txt">행 삭제</span>
                    </a>
                </div>
            </div>
        </div>
        <!-- //Sub Title -->
        <div class="tbl_vert skin01">
            <table id="tblLeaveList" class="tbl_vert_inside">
                <colgroup>
                    <%-- <col width="5%" />
                    <col width="360" />
                    <col width="18%" />
                    <col width="18%" />
                    <col width="10%" />
                    <col width="" />--%>
                </colgroup>
                <thead>
                    <tr class="vert_t_row">
                        <th class="vert_t_head" scope="col">
                            <input type="checkbox" class="jqForm" id="chkAll" />
                        </th>
                        <th class="vert_t_head" scope="col">
                            <img src="/styles/images/board01/icoStar.png" alt="필수입력" />Raid Name</th>
                        <th class="vert_t_head" scope="col">
                            <img src="/styles/images/board01/icoStar.png" alt="필수입력" />Raid Type</th>
                        <th class="vert_t_head" scope="col">
                            <img src="/styles/images/board01/icoStar.png" alt="필수입력" />Raid Date</th>
                        <th class="vert_t_head" scope="col">Phase Name</th>
                    </tr>
                </thead>
                <tbody id="tbRaidList">
                    <tr class="vert_t_row">
                        <td class="vert_t_data" style="text-align: center;">
                            <input type="checkbox" class="jqForm" name="chbox" />
                        </td>
                        <td class="vert_t_data">
                            <select name="Raid_NM" class="jqForm" style="width: 130px;">
                                <option value="루크">Luke</option>
                                <option value="안톤">Anthon</option>
                            </select>

                            <select name="Raid_TP" class="jqForm" style="width: 130px;">
                                <option value="싱글">Single</option>
                                <option value="파티">Party</option>
                            </select>
                        </td>
                        <td class="vert_t_data">
                            <input type="text" class="inp_date" name="Start_DT" readonly="true" />
                            <div style="display: inline-block">
                                <span class="jqTransformRadioWrapper">
                                    <input type="radio" class="jqForm jqTransformHidden jqRadio" id="startAmPm01_0" name="Start_AM_PM[0]" value="AM" checked="checked" /><span class="jqTransformRadio"></span></span><label for="startAmPm01_0" style="cursor: pointer;">오전<!-- 오전 --></label>
                                <span class="jqTransformRadioWrapper">
                                    <input type="radio" class="jqForm jqTransformHidden jqRadio" id="startAmPm02_0" name="Start_AM_PM[0]" value="PM" /><span class="jqTransformRadio"></span></span><label for="startAmPm02_0" style="cursor: pointer;">오후<!-- 오후 --></label>
                            </div>
                        </td>

                        <td class="vert_t_data">
                            <input type="text" class="pct" name="Name" value="" maxlength="500" />
                        </td>
                        <td class="vert_t_data">
                            <input type="text" class="pct" name="Phase" value="" maxlength="500" />
                        </td>
                    </tr>
                </tbody>

            </table>
        </div>
    </form>
</body>
</html>

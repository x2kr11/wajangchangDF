/*-----------------------------------
기능 : 메뉴가 고정되는 그리드뷰 Object 를 만든다.
-------------------------------------
objGridviewID   : 그리드뷰로 만들 Object ID
options   : width, height,scrollBarWidth, GridHeaderCelloffset
-----------------------------------*/
(function ($) {
    $.fn.Scrollable = function (options) {
        var defaults = {
            Width: 800,
            Height: 300,
            ScrollBarWidth: 0,
            GridHeaderCellOffset: 3
        };
        var options = $.extend(defaults, options);
        var gridScrollWidth = parseInt(options.Width) + parseInt(options.ScrollBarWidth);
     
        return this.each(function () {
            var grid = $(this).get(0);
            var headerCellWidths = new Array();
            for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
                headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
            }
            grid.parentNode.appendChild(document.createElement("div"));
            var gridRootDiv = grid.parentNode;
            gridRootDiv.id = grid.id + "_gridRootDiv";
            gridRootDiv.style.cssText = "background-color: whitesmoke; width:" + gridScrollWidth + "px";

            //기존 그리드뷰 위에 Group에 대한 내용을 보여줄 영역을 그려준다.
            var group = document.createElement("div");
            group.className = "group_team";
            group.innerText = options.GroupName;
            var group_span = document.createElement("span");
            group_span.className = "group_num";
           
            if (options.GroupNum != 0)
            {
                group_span.innerHTML = " Count [" + options.GroupNum + "]";               
                group.appendChild(group_span);
            }
            
            gridRootDiv.appendChild(group);           

            var gridHeaderTable = document.createElement("table");
            gridHeaderTable.id = grid.id + "_gridHeaderTable";
            for (i = 0; i < grid.attributes.length; i++) {
                if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                    gridHeaderTable.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
                }
            }
            gridHeaderTable.style.cssText = grid.style.cssText;
            gridHeaderTable.style.width = grid.offsetWidth + "px";
            gridHeaderTable.appendChild(document.createElement("thead"));
            
            gridHeaderTable.getElementsByTagName("thead")[0].appendChild(grid.getElementsByTagName("TR")[0]);
            gridHeaderTable.getElementsByTagName("TR")[0].className += "board_list_row";

            var gridHeaderCells = gridHeaderTable.getElementsByTagName("TH");
            var gridHeaderRow = grid.getElementsByTagName("TR")[0];

            gridRootDiv.removeChild(grid);

            var gridHeaderDiv = document.createElement("div");
            gridHeaderDiv.id = grid.id + "_gridHeaderDiv";
            gridHeaderDiv.style.cssText = "overflow:hidden; width:" + options.Width + "px";
            gridHeaderDiv.appendChild(gridHeaderTable);
            gridRootDiv.appendChild(gridHeaderDiv);

            var gridScrollDiv = document.createElement("div");
            gridScrollDiv.id = grid.id + "_gridScrollDiv";			
            gridScrollDiv.style.cssText = "overflow-y:auto; height:" + options.Height + "px; width:" + gridScrollWidth + "px";
            gridScrollDiv.appendChild(grid);
            gridRootDiv.appendChild(gridScrollDiv);

            $(gridScrollDiv).scroll(function () {                
                document.getElementById(gridHeaderDiv.id).scrollLeft =
                    document.getElementById(gridScrollDiv.id).scrollLeft;
            });
        });
    };
})(jQuery);

/*-----------------------------------
기능 : 그리드 뷰 안에 체크박스 전체선택/해제
-------------------------------------
objGridviewID   : 그리드뷰 헤더에 있는 checkBoxAll
-----------------------------------*/
function checkboxAll(obj) {
    var $obj = $(obj);
    $obj.click(function () {
        if ($obj.prop("checked")) {
            $("input[type=checkbox]").prop("checked", true);
        }
        else {
            $("input[type=checkbox]").prop("checked", false);
        }
    });
}
// 自动调整 datagrid
if (typeof bpm === "undefined") { bpm = {}; }
if (typeof bpm.page === "undefined") { bpm.page = {}; }
bpm.page = {
    windowShow: function (title, url, width, height) {
        if (top.bpm.main.windowShow) {
            top.bpm.main.windowShow(title, url, width, height);
        } else if (bpm.main.windowShow) {
            bpm.main.windowShow(title, url, width, height);
        }
    },
    windowClose: function () {
        if (parent.bpm.main.windowClose) {
            parent.bpm.main.windowClose();
        } else if (parent.parent && parent.parent.bpm.main.windowClose) {
            parent.parent.bpm.main.windowClose();
        } else if (bpm.main.windowClose) {
            bpm.main.windowClose();
        }
    },
    tip: function (message, icon) {
        if (parent.bpm.main.tip) {
            parent.bpm.main.tip(message, icon);
        } else if (parent.parent && parent.parent.bpm.main.tip) {
            parent.parent.bpm.main.tip(message, icon);
        } else if (bpm.main.tip) {
            bpm.main.tip(message, icon);
        }
    },
    alert: function (message, icon, func) {
        if (parent.bpm.main.alert) {
            parent.bpm.main.alert(message, icon, func);
        } else if (parent.parent && parent.parent.bpm.main.alert) {
            parent.parent.bpm.main.alert(message, icon, func);
        } else if (bpm.main.alert) {
            bpm.main.alert(message, icon, func);
        }
    },
    confirm: function (message, func) {
        if (parent.bpm.main.confirm) {
            parent.bpm.main.confirm(message, func);
        } else if (parent.parent && parent.parent.bpm.main.confirm) {
            parent.parent.bpm.main.confirm(message, func);
        } else if (bpm.main.confirm) {
            bpm.main.confirm(message, func);
        }
    },
    refreshDataGrid: function () {
        if (parent.bpm.main && parent.bpm.main.reloadDataGrid) {
            parent.bpm.main.reloadDataGrid();
        }
    }
};
$(function () {
    notificationPage();
});
function dynamicReloadGrid() {
    $(".easyui-datagrid").datagrid("reload");
};
function notificationPage() {
    var message = $("#action_message").val();
    if (typeof message == "undefined" || message == null || message == "") {
        return;
    }
    $("#action_message").val("");
    var autoClose = $("#action_message").attr("autoclose");
    bpm.page.alert(message, "info", function () {
        /* close window. */
        if (typeof autoClose != "undefined" && autoClose == "1") {
            bpm.page.refreshDataGrid();
            bpm.page.windowClose();
        }
    });
};
/* search condition. */
function getSearchParamItem(o) {
    if (!o) {
        return "";
    }
    itemName = $(o).attr("search");
    if (!itemName || itemName == "") {
        itemName = $(o).attr("name");
    }
    var value = $(o).val();
    if (typeof value == "undefined" || value == null || value == "") {
        return "";
    }
    return itemName + "=" + value + "&";
}
function getSearchParams(container) {
    container = (!container) ? "" : (container + " ");
    var result = document.URL;
    var urlIndex = result.indexOf('?');
    if (urlIndex > 1 && urlIndex + 1 < result.length) {
        result = result.substring(urlIndex + 1);
        result = (result == "#" ? "" : (result + "&"));
    } else {
        result = "";
    }
    $(container + "input[search]").each(function () {
        var inputType = $(this).attr("type");
        if (typeof inputType != "undefined" && inputType.toLowerCase() == "checkbox") {
            itemName = $(this).attr("search");
            if (!itemName || itemName == "") {
                itemName = $(this).attr("name");
            }
            result += (itemName + "=" + (typeof ($(this).attr("checked")) != "undefined") + "&");
        } else {
            result += getSearchParamItem(this);
        }
    });
    $(container + "select[search]").each(function () {
        if ($(this).hasClass("easyui-combotree")) {
            itemName = $(this).attr("search");
            if (!itemName || itemName == "") {
                itemName = $(this).attr("id");
            }
            itemValue = $("#" + itemName).combotree("getValue");
            if (typeof itemValue != undefined && itemValue != "") {
                result += (itemName + "=" + itemValue + "&");
            }
        } else {
            result += getSearchParamItem(this);
        }
    });
    if (result.length > 1) {
        result = result.substring(0, result.length - 1);
    }
    return result;
};
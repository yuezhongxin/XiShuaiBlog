if (typeof appPath === "undefined") { appPath = "/"; }
if (typeof appName === "undefined") { appName = "CMSExpress"; }
if (typeof bpm === "undefined") { bpm = {}; }
if (typeof bpm.main === "undefined") { bpm.main = {}; }
bpm.main = {
    windowShow: function (title, url, width, height) {
        var width = (typeof width == "undefined" || width == 0) ? 800 : width;
        var height = (typeof height == "undefined" || height == 0) ? 350 : height;

        $.jBox("iframe:" + appPath + url, {
            title: title,
            border: 1,
            width: width,
            height: height,
            buttons: { }
        });
    },
    windowClose: function () {
        $.jBox.close();
    },
    tip: function (message, icon) {
        if (!icon || icon == "") { icon = "info"; }
        $.jBox.tip(message, icon);
    },
    alert: function (message, icon, func) {
        if (!icon || icon == "") { icon = "info"; }
        $.jBox.prompt(message, "系统提示", icon, {
            top: "30%",
            submit: function () {
                if (func) { func(); }
            }
        });
    },
    confirm: function (message, func) {
        var submitHandler = function (v, h, f) {
            if (v == "ok" && func) {
                func();
            }
            return true;
        };
        $.jBox.confirm(message, "系统提示", submitHandler, { top: "30%" });
    },
    loadMenus: function (menuContainer, url, showAccordion) {
        if (!menuContainer || !url) {
            return false;
        }
        $(menuContainer).html("<a>Hello</a>");
    },
    bindTabs: function () { // init add tab event

    },
    addTabItem: function (title, url) {
        var header = title;
        if (header && header.length > 9) {
            header = header.substring(0, 8) + "..";
        }
        if (!$(".easyui-tabs").tabs("exists", header)) {
            $(".easyui-tabs").tabs("add", {
                title: header,
                content: '<iframe src="' + (appPath + url) + '" width="100%" height="99%" frameborder="0" scrolling="auto"></iframe>',
                iconCls: "",
                closable: true
            });
            $("span:contains('" + header + "')").parent().attr("title", title); //设置悬浮提示.
        } else {
            $(".easyui-tabs").tabs("select", header);
        };
        // 双击关闭TAB选项卡.
        $(".tabs-inner").dblclick(function () {
            var _title = $(this).children(".tabs-closable").text();
            $('.easyui-tabs').tabs('close', _title);
        });
    },
    reloadDataGrid: function () {
        var selectedTab = $(".easyui-tabs").tabs("getSelected");
        if (!selectedTab) {
            return false;
        }
        var src = $(selectedTab).attr("src");
        for (var i = 0; i < window.frames.length; i++) {
            if (window.frames[i].src == src) {
                window.frames[i].dynamicReloadGrid();
                break;
            }
        }
    }
};


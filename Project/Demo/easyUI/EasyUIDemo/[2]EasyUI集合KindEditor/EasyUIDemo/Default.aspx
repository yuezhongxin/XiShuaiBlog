<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EasyUIDemo._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="EasyUI/themes/default/easyui.css" rel="stylesheet" />
    <link href="EasyUI/themes/icon.css" rel="stylesheet" />
    <link href="css/admin.css" rel="stylesheet" />
    <script src="EasyUI/jquery.min.js"></script>
    <script src="EasyUI/jquery.easyui.min.js"></script>
    <script src="js/common.js"></script>
</head>
<body class="easyui-layout" data-options="fit:true,scroll:'no'">
    <div data-options="region:'north',border:false" style="height: 74px; background: #2596ea; padding: 10px">
        <img src="images/logo.png" />EasyUIDemo
    </div>
    <div data-options="region:'west',split:true,title:'导航菜单'" style="width: 170px;">
        <div class="easyui-accordion" data-options="fit:true,border:false">
            <div title="系统设置1" data-options="selected:true">
                <div style="margin: 5px">
                    <ul class="tree easyui-tree" data-options="animate:true,lines:true">
                        <li data-options="iconCls:'icon-group'">
                            <span>基本设置</span>
                            <ul>
                                <li data-options="iconCls:'icon-group_add'">
                                    <span>test1</span>
                                </li>
                                <li data-options="iconCls:'icon-group_delete'">
                                    <span>test2</span>
                                </li>
                                <li data-options="iconCls:'icon-group_edit'">
                                    <span>test3</span>
                                </li>
                            </ul>
                        </li>
                        <li data-options="state:'closed',iconCls:'icon-joystick'">
                            <span>系统设置</span>
                            <ul>
                                <li data-options="iconCls:'icon-joystick_add'">
                                    <span>test4</span>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
            <div title="系统设置2" style="padding: 10px;">
                content2
            </div>
            <div title="系统设置3" style="padding: 10px">
                content3
            </div>
        </div>
    </div>
    <div data-options="region:'south',border:false" style="height: 23px;">
        <div class="footer">EasyUIDemo</div>
    </div>
    <div data-options="region:'center'">
        <div id="tabs" class="easyui-tabs" data-options="tools:'#tab-tools',fit:true,border:false" >
            <div title="主页" data-options="iconCls:'icon-house'" style="padding: 10px;">
                <iframe scrolling="auto" frameborder="0"  src="form.html" style="width:100%;height:100%;"></iframe>
            </div>
        </div>
        <div id="tab-tools">
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add'" onclick="addTab()"></a>
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'" onclick="removeTab()"></a>
        </div>
    </div>
    <div id="mm" class="easyui-menu" style="width: 150px;">
        <div id="refresh" data-options="iconCls:'icon-arrow_refresh'">刷新</div>
        <div class="menu-sep"></div>
        <div id="close">关闭</div>
        <div id="closeall">全部关闭</div>
        <div id="closeother">除此之外全部关闭</div>
        <div class="menu-sep"></div>
        <div id="closeright">当前页右侧全部关闭</div>
        <div id="closeleft">当前页左侧全部关闭</div>
        <div class="menu-sep"></div>
        <div id="exit">退出</div>
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="XQH.EasyUi.Web.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    
    <title>JQuery EasyUi Frame</title>
    <link href="JQueryEasyUi/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="JQueryEasyUi/icon.css" rel="stylesheet" type="text/css" />

    <script src="JQueryEasyUi/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="JQueryEasyUi/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="JQueryEasyUi/Cookie.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(function() {
            //系统管理树
            $("#sysManageTree").tree({
                checkbox: false,
                url: 'Service/EasyUiService.ashx?Method=GetSysManageTree&RoleId=' + GetCookie("RoleInfo").substring(7,8),
                onClick: function(node) {
                    $(this).tree('toggle', node.target);

                    //$("#contentPage").attr("src", node.attributes);
                    loadFrame(node.attributes);
                }
//                onContextMenu: function(e, node) {
//                    e.preventDefault();
//                    $('#sysManageTree').tree('select', node.target);
//                    $('#treeMenu').menu('show', {
//                        left: e.pageX,
//                        top: e.pageY
//                    });
//                }
            });

            //工作树
            $("#workManageTree").tree({
                checkbox: false,
                url: 'Service/EasyUiService.ashx?Method=GetWorkManageTree&RoleId=' + GetCookie("RoleInfo").substring(7, 8),
                onClick: function(node) {
                    $(this).tree('toggle', node.target);

                    loadFrame(node.attributes);
                }
            });

            //日常管理树
            $("#dailyManageTree").tree({
                checkbox: false,
                url: 'Service/EasyUiService.ashx?Method=GetDailyManageTree&RoleId=' + GetCookie("RoleInfo").substring(7, 8),
                onClick: function(node) {
                    $(this).tree('toggle', node.target);

                    loadFrame(node.attributes);
                }
            });

            //其他事项树
            $("#otherTree").tree({
                checkbox: false,
                url: 'Service/EasyUiService.ashx?Method=GetOtherTree&RoleId=' + GetCookie("RoleInfo").substring(7, 8),
                onClick: function(node) {
                    $(this).tree('toggle', node.target);

                    loadFrame(node.attributes);
                }
            });
        });

        //加载页面
        function loadFrame(url) {
            $("#contentPage").attr("src",url);
        }
    </script>
</head>
<body class="easyui-layout">
<%--    <noscript>
        <div style="position: absolute; z-index: 100000; height: 2046px; top: 0px; left: 0px;
            width: 100%; background: white; text-align: center;">
            <img src="images/noscript.gif" alt='抱歉，请开启脚本支持！' />
        </div>
    </noscript>--%>
    <div region="north" border="false" style="height:70px;background:#3D3C7A">
        <h2 style=" padding:20px 0 0 20px; color:#fff;">JQueryEasyUi Frame</h2>
    </div>
    <div region="west" split="true" title="管理工具" style="width:200px;padding:0px;">
        <div class="easyui-accordion" fit="true" >
		    <div title="系统管理">
                <ul id="sysManageTree">
                </ul>
		    </div>
		    <div title="业务管理">
			    <ul id="workManageTree">
                </ul>
		    </div>
		    <div title="日常管理">
			    <ul id="dailyManageTree">
                </ul>
		    </div>
		    <div title="其他事项">
			    <ul id="otherTree">
                </ul>
		    </div>
	    </div>
    </div>
    <div region="center" title="内容区域" iconCls="icon-index">
		<div class="easyui-tabs" fit="true" border="false">
			<div title="主页" style="padding:0px;overflow:hidden;"> 
                <iframe id="contentPage" width="100%" height="100%" frameborder="0" marginheight="0" marginwidth = "0"></iframe>
			</div>
		</div>
    </div>
    <div region="south" style="height:30px;"></div>
    
    <div id="treeMenu" class="easyui-menu" style="width:120px;">
		<div onclick="append()" iconCls="icon-reload">刷新</div>
		<div class="menu-sep"></div>
		<div onclick="expand()">展开</div>
		<div onclick="collapse()">收缩</div>
	</div>
</body>
</html>

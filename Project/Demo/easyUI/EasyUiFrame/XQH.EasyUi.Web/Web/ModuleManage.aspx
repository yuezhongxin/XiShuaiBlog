<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleManage.aspx.cs" Inherits="XQH.EasyUi.Web.Web.ModuleManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    
    <link href="../JQueryEasyUi/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../JQueryEasyUi/icon.css" rel="stylesheet" type="text/css" />

    <script src="../JQueryEasyUi/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../JQueryEasyUi/jquery.easyui.min.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(function() {
            
            $('#moduleManageGrid').datagrid({
                title: '模块管理',
                //iconCls: 'icon-save',
                //width: 800,
                height: 562,
                collapsible: false,
                url: '../datagrid_data.aspx',
                frozenColumns: [[
                    { field: 'ck', checkbox: true },
                    { title: 'ID', field: 'code', width: 80, sortable: true }
				]],
                columns: [[
					{ field: 'code', title: 'Item ID', width: 80 },
					{ field: 'name', title: 'Product ID', width: 100 },
					{ field: 'addr', title: 'List Price', width: 80 },
					{ field: 'col4', title: 'Unit Cost', width: 80 }
				]],
                pagination: true,
                rownumbers: true,
                toolbar:
                [
                    {
                        id: 'btnAdd',
                        text: '添加模块',
                        iconCls: 'icon-add',
                        handler: function() {
                        }
                    },
                    '-',
                    {
                        id: 'btnEdit',
                        text: '编辑模块',
                        iconCls: 'icon-cut',
                        handler: function() {
                        }
                    },
                    '-',
                    {
                        id: 'btnDelete',
                        text: '删除模块',
                        disabled: true,
                        iconCls: 'icon-save',
                        handler: function() {
                        }
                    }
                ]
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style=" width:100%; height:100%;">
            <table id="moduleManageGrid"></table>
        </div>
    </form>
</body>
</html>

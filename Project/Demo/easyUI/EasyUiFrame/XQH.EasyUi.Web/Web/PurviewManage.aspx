<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurviewManage.aspx.cs" Inherits="XQH.EasyUi.Web.Web.PurviewManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../JQueryEasyUi/icon.css" rel="stylesheet" type="text/css" />
    <link href="../JQueryEasyUi/default/easyui.css" rel="stylesheet" type="text/css" />

    <script src="../JQueryEasyUi/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../JQueryEasyUi/jquery.easyui.min.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        //角色ID 全局变量
        var RoleId;

        $(function() {

            $('#roleManageGrid').datagrid({
                //title: '角色管理',
                //iconCls: 'icon-save',
                collapsible: false,
                fitColumns: true,
                singleSelect: true,
                remoteSort: false,
                sortName: 'RoleName',
                sortOrder: 'desc',
                nowrap: true,
                method: 'get',
                loadMsg: '正在加载数据...',
                url: '../Service/EasyUiService.ashx?Method=GetRoleInfo',
                frozenColumns: [[
                    { field: 'ck', checkbox: true }
			    ]],
                columns: [[
				    { field: 'RoleId', title: '角色ID', width: 80, sortable: true },
				    { field: 'RoleName', title: '角色名称', width: 100,sortable:true },
				    { field: 'RoleDes', title: '角色描述', width: 100 }
			    ]],
                pagination: true,
                pageNumber: 1,
                rownumbers: true,
                toolbar:
                [
                    {
                        id: 'btnAdd',
                        text: '添加角色',
                        iconCls: 'icon-add',
                        handler: function() {
                            $("#roleName").val("");
                            $("#roleDes").val("");
                            addRoleDialog();
                        }
                    },
                    '-',
                    {
                        id: 'btnEdit',
                        text: '编辑角色',
                        iconCls: 'icon-edit',
                        handler: function() {
                            var selected = $('#roleManageGrid').datagrid('getSelected');
                            if (selected) {
                                var roleId = selected.RoleId;
                                var roleName = selected.RoleName;
                                var roleDes = selected.RoleDes;
                                $("#roleName").val(roleName);
                                $("#roleDes").val(roleDes);
                                editRoleDialog();
                            }
                        }
                    },
                    '-',
                    {
                        id: 'btnDelete',
                        text: '删除角色',
                        disabled: true,
                        iconCls: 'icon-remove',
                        handler: function() {
                        }
                    }
                ],
                onLoadSuccess: function() {
                    //$("#roleManageGrid").datagrid('reload');
                },
                onClickRow: function(rowIndex, rowData) {
                    var roleId = rowData.RoleId;
                    loadTree(roleId);
                    RoleId = roleId;
                }
            });
        });

        //加载树
        function loadTree(roleId) {
            $("#permissionTree").tree({
                checkbox: true,
                onlyLeafCheck:true,
                url: '../Service/EasyUiService.ashx?Method=SetPermissionTree&RoleId=' + encodeURI(roleId),
                onClick: function(node) {
                    $(this).tree('toggle', node.target);
                },
                onCheck: function(node, checked) {
                    var checked = node.checked;
                    var roleId = RoleId;
                    var permissionId = node.id;
                    setPermission(checked, roleId, permissionId);
                    //alert(i);
                }
            });
        }
        
        //设置权限
        function setPermission(checked,roleId,permissionId) {
            $.ajax({
                type: "POST",
                dataType: "json",
                //cache:true,
                url: "../Service/EasyUiService.ashx?Method=SetPermission",
                data: { IsChecked: checked, RoleId: roleId,PermissionId:permissionId },
                success: function(json) {
                },
                error: function() {
                    $.messager.alert('错误', '设置权限失败...请联系管理员!', 'error');
                }
            });
        }

        //添加角色对话框
        function addRoleDialog() {
            $("#dialogAddRole").show();
            $("#dialogAddRole").attr("title", "添加角色");

            $("#dialogAddRole").dialog({
                width: 500,
                height: 200,
                draggable: true,
                resizable: false,
                modal: true,
                buttons:
                    [
                        {
                            text: '提交',
                            iconCls: 'icon-ok',
                            handler: function() {
                                
                            }
                        },
				        {
				            text: '取消',
				            handler: function() {
				                $('#dialogAddRole').dialog('close');
				            }
				        }
				    ]
            });
        }

        //编辑角色对话框
        function editRoleDialog() {
            $("#dialogAddRole").show();
            $("#dialogAddRole").attr("title", "编辑角色");

            $("#dialogAddRole").dialog({
                width: 500,
                height: 200,
                draggable: true,
                resizable: false,
                modal: true,
                buttons:
                    [
                        {
                            text: '提交',
                            iconCls: 'icon-ok',
                            handler: function() {

                            }
                        },
				        {
				            text: '取消',
				            handler: function() {
				                $('#dialogAddRole').dialog('close');
				            }
				        }
				    ]
            });
        }
    </script>
</head>
<body class="easyui-layout">
		<div region="west" split="true" title="权限树" style="width:200px;">
	        <ul id="permissionTree">
            </ul>
		</div>
		<div region="center" title="角色管理">
            <table id="roleManageGrid" fit="true"></table>
		</div>
		
	<div id="dialogAddRole" icon="icon-add" title="添加角色" style=" display:none;">
        <div style=" width:460px; height:100px; font-size:12px; color:Black;">
            <table style=" width:450px; height:100px; margin-left:20px; margin-top:15px;">
                <tr>
                    <td valign="middle" style=" width:100px">角色名称：</td>
                    <td valign="middle" style=" width:370px"><input id="roleName" type="text" style=" width:350px"/></td>
                </tr>
                <tr>
                    <td valign="top">角色描述：</td>
                    <td valign="middle" style=" width:370px"><textarea id="roleDes" rows="4" cols="10" style=" width:350px;"></textarea></td>
                </tr>
            </table>
        </div>
    </div>
</body>
</html>

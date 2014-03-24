<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EasyUIDemo._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="EasyUI/themes/default/easyui.css" rel="stylesheet" />
    <link href="EasyUI/themes/icon.css" rel="stylesheet" />
    <script src="EasyUI/jquery.min.js"></script>
    <script src="EasyUI/jquery.easyui.min.js"></script>
</head>
<body class="easyui-layout">
    <div data-options="region:'north',border:false" style="height: 60px; background: #B3DFDA; padding: 10px">north region</div>
    <div data-options="region:'west',split:true,title:'West'" style="width: 150px; ">
        <div class="easyui-accordion" data-options="fit:true,border:false">
            <div title="Title1" style="padding: 10px;">
                content1
            </div>
            <div title="Title2" data-options="selected:true" style="padding: 10px;">
                content2
            </div>
            <div title="Title3" style="padding: 10px">
                content3
            </div>
        </div>
    </div>
    <div data-options="region:'south',border:false" style="height: 50px; background: #A9FACD; padding: 10px;">south region</div>
    <div data-options="region:'center',title:'Center'"></div>
</body>
</html>

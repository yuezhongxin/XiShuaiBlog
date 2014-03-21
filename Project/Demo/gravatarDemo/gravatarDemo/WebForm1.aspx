<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="gravatarDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" /><br />
        <asp:Image ID="Image2" runat="server" ImageUrl="http://www.gravatar.com/avatar/aae1e25f99469f5c616f777e9d?d=wavatar&s=40" />url:http://www.gravatar.com/avatar/aae1e25f99469f5c616f777e9d?d=wavatar&s=40 <br />
        <asp:Image ID="Image3" runat="server" ImageUrl="http://www.gravatar.com/avatar/aae1e25f99469f5c616f7e9d?d=wavatar&s=40" />url:http://www.gravatar.com/avatar/aae1e25f99469f5c616f7e9d?d=wavatar&s=40 <br />
        <asp:Image ID="Image4" runat="server" ImageUrl="http://www.gravatar.com/avatar/aae1e25f99469f5c616f777d?d=wavatar&s=40" />url:http://www.gravatar.com/avatar/aae1e25f99469f5c616f777d?d=wavatar&s=40 <br />
        <asp:Image ID="Image5" runat="server" ImageUrl="http://www.gravatar.com/avatar/aae1e25f99469f5c616f777?d=wavatar&s=40" />url:http://www.gravatar.com/avatar/aae1e25f99469f5c616f777?d=wavatar&s=40 <br />
    </div>
    </form>
</body>
</html>

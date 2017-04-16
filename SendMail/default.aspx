<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SendMail.Web._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>测试邮件</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width: 300px; margin: 0 auto;">
            <div>
                <asp:TextBox ID="txtTo" runat="server" MaxLength="30" TextMode="Email" ToolTip="收件人" AutoCompleteType="Email"></asp:TextBox>
            </div>
            <div>
                <img alt="" src="/public/5a.jpg" width="200px" height="70px" />
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="发送" />
                <asp:Label ID="lbl1" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

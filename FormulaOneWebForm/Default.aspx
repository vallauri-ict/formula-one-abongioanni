<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOneWebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" Text="invia" />
            <br />
            <asp:Label runat="server" Text=" " />
            <br />
        </div>
        <div>
            <asp:ListBox ID="cmbCountries" runat="server"></asp:ListBox>
        </div>
    </form>
</body>
</html>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOneWebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList ID="cmb" runat="server" OnSelectedIndexChanged="cmbCountries_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList><br />
        <br />
        <br />
        <asp:GridView ID="content" runat="server"></asp:GridView>
    </form>
</body>
</html>

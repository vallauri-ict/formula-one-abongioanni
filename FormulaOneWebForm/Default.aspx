<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOneWebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="https://1000logos.net/wp-content/uploads/2020/02/F1-Logo.png" />
    <title>Formula 1</title>
    <link type="text/css" rel="stylesheet" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">

        <asp:ListBox ID="content" runat="server"></asp:ListBox>

        <span runat="server" class="no-results" id="noResults"></span>
    </form>
</body>
</html>

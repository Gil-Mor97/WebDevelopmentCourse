<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jscripts/jquery-1.12.0.min.js"></script>
    <script src="jscripts/myScript.js"></script>
</head>
<body dir="rtl">
    <form id="form1" runat="server">
    <div>

        <%-- הגדרת תיבת טקסט עם מאפיין item=0--%>
        <%-- בהתאם למיקום במערך להגדרת הגבלת התווים --%>
        <asp:TextBox ID="TextBox1" item="1" CharacterLimit="60" CssClass="CharacterCount"  runat="server"></asp:TextBox>
        <%-- לייבל שתמיד יקרא LabelCounter --%>
        <%-- ומספר התואם למספר תיבת הטקסט הקשורה אליו --%>
        <asp:Label ID="LabelCounter1" runat="server" Text="60"></asp:Label>   


        <%-- ראו דימיון ושינויים בין שתי תיבות הטקסט והלייבלים --%>
        <asp:TextBox ID="TextBox2" item="2" CharacterLimit="30" CssClass="CharacterCount" runat="server"></asp:TextBox>
        <asp:Label ID="LabelCounter2" runat="server" Text="30"></asp:Label>


    </div>
    </form>
</body>
</html>

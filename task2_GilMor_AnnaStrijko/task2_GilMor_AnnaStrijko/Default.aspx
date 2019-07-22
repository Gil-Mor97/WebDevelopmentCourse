<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>הוספת XML</title>
    <style>
        .labels {
            font-weight: 700;
        }
    </style>
</head>
<body dir="rtl">
    <form id="form1" runat="server">
        <h1>בניית XML למשחק HIT-the-DUCK</h1>
        <h2>הוספת משחק</h2>

        <div>
            <asp:Label ID="categoryLb" runat="server" Text="נושא המשחק" CssClass="labels"></asp:Label>
            <asp:TextBox ID="categoryTB" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="codeLb" runat="server" Text="קוד משחק" CssClass="labels"></asp:Label>
            <asp:TextBox ID="codeTB" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="qtnLb" runat="server" Text="שאלת המשחק" CssClass="labels"></asp:Label>
            <asp:TextBox ID="qtnTB" runat="server"></asp:TextBox>
            <br />
            <br />
            <h3>הוספת מסיח</h3>
            <asp:Label ID="typeLb" runat="server" Text="סוג המסיח" CssClass="labels"></asp:Label>
            <asp:RadioButtonList ID="typeRBL" runat="server">
                <asp:ListItem Value="txt">טקסט</asp:ListItem>
                <asp:ListItem Value="img">תמונה</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="correctLb" runat="server" Text="האם מסיח אמת או שקר" CssClass="labels"></asp:Label>
            <asp:RadioButtonList ID="correctRBL" runat="server">
                <asp:ListItem Value="true">מסיח נכון</asp:ListItem>
                <asp:ListItem Value="false">מסיח לא נכון</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="contentLb" runat="server" Text="תוכן המסיח" CssClass="labels"></asp:Label>
            <asp:TextBox ID="contentTB" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </div>
    </form>
</body>
</html>

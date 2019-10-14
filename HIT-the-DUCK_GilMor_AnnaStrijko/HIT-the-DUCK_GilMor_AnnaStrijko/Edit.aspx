<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HIT-the-DUCK - עריכת משחק</title>
    <script src="jscripts/jquery-1.12.0.min.js"></script>
    <script src="jscripts/myScript.js"></script>
    <style type="text/css">
        body {
            direction: rtl;
        }

        * {
            direction: rtl;
            text-align: right;
            padding: 0.1em;
        }

        h1 {
            text-align: center;
        }

        .countTooltip {
            text-align: left;
            float: left;
        }

        .btn, container {
            margin: 0 auto;
        }
    </style>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body dir="rtl">
    <h1>עריכת XML למשחק HIT-the-DUCK</h1>
    <div class="container col-sm-5">
        <h2>עריכת המשחק</h2>
        <div>
            <form id="form1" runat="server">
                <div class="form-group">
                    <div class="form-group row">
                        <div class="form-group" style="float: right">
                            <asp:Label ID="Label1" runat="server" Text="שם המשחק: (1-20 תווים)"></asp:Label><br />
                            <asp:TextBox ID="gamename" item="1" CharacterLimit="20" CssClass="CharacterCount" runat="server" value="test"></asp:TextBox><br />
                            <asp:Label ID="LabelCounter1" CssClass="countTooltip" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group" style="float: left">
                            <asp:Label ID="Label2" runat="server" Text="הנחייה לזיהוי: (1-30 תווים)"></asp:Label><br />
                            <asp:TextBox ID="instruction" item="2" CharacterLimit="30" CssClass="CharacterCount" runat="server" value="test"></asp:TextBox><br />
                            <asp:Label ID="LabelCounter2" CssClass="countTooltip" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RblChange">
                        </asp:RadioButtonList>
                    </div>
                    <div class="form-group row">
                        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                    </div>
                    <div class="form-group row">
                        <asp:Button ID="back" runat="server" Text="בחזרה לעמוד הראשי" OnClick="back_Click" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>

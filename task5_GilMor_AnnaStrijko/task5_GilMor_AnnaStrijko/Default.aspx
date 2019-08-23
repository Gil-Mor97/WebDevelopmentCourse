<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>הוספת XML</title>
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

        .btn, container {
            margin: 0 auto;
        }
    </style>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body dir="rtl">
    <h1>עריכת XML למשחק HIT-the-DUCK</h1>
    <div class="container col-sm-5">
        <h2>הוספת משחק</h2>
        <div class="container col-sm-12">
            <form id="form1" runat="server">

                <div class="form-group">
                    <div class="form-group row">
                        <asp:Label ID="Label6" runat="server" Text="בחירת קוד משחק" class="col-sm-4"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RblLoad"></asp:DropDownList>
                    </div>
                    <div class="form-group row">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RblChange">
                        </asp:RadioButtonList>
                    </div>
                    <div class="form-group row">
                        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>

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
        #Button2, container{
            margin: 0 auto;
        }
    </style>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body dir="rtl">
    <h1>בניית XML למשחק HIT-the-DUCK</h1>
    <div class="container col-sm-5">
        <h2>הוספת משחק</h2>
        <div class="container col-sm-12">
            <form id="form1" runat="server">
                <div class="form-group row">
                    <asp:Label ID="categoryLb" runat="server" Text="נושא המשחק" class="col-sm-3"></asp:Label>
                    <asp:TextBox ID="categoryTB" runat="server" class="form-control col-sm-6"></asp:TextBox>
                </div>
                <div class="form-group row">
                    <asp:Label ID="codeLb" runat="server" Text="קוד משחק" class="col-sm-3"></asp:Label>
                    <asp:TextBox ID="codeTB" runat="server" class="form-control col-sm-6"></asp:TextBox>
                </div>
                <div class="form-group row">
                    <asp:Label ID="qtnLb" runat="server" Text="שאלת המשחק" class="col-sm-3"></asp:Label>
                    <asp:TextBox ID="qtnTB" runat="server" class="form-control col-sm-6" TextMode="MultiLine"></asp:TextBox>
                </div>
                <br />

                <h3>הוספת מסיח</h3>
                <div class="form-group row">
                    <asp:Label ID="typeLb" runat="server" Text="סוג המסיח" class="col-sm-3"></asp:Label>
                    <asp:RadioButtonList ID="typeRBL" runat="server" class="form-control col-sm-6">
                        <asp:ListItem Value="txt">טקסט</asp:ListItem>
                        <asp:ListItem Value="img">תמונה</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-group row">
                    <asp:Label ID="correctLb" runat="server" Text="האם מסיח אמת או שקר" class="col-sm-3"></asp:Label>
                    <asp:RadioButtonList ID="correctRBL" runat="server" class="form-control col-sm-6">
                        <asp:ListItem Value="true">מסיח נכון</asp:ListItem>
                        <asp:ListItem Value="false">מסיח לא נכון</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-group row">
                    <asp:Label ID="contentLb" runat="server" Text="תוכן המסיח" class="col-sm-3"></asp:Label>
                    <asp:TextBox ID="contentTB" runat="server" class="form-control col-sm-6"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="* שם קובץ התמונה או טקסט" class="col-sm-12"></asp:Label>
                </div>
                <div class="form-group row">
                    <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="יצירת XML" class="btn col-md-4    " />
                </div>
            </form>
        </div>
    </div>
</body>
</html>

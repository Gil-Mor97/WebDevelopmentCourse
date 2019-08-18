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
    <h1>בניית XML למשחק HIT-the-DUCK</h1>
    <div class="container col-sm-5">
        <h2>הוספת משחק</h2>
        <div class="container col-sm-12">
            <form id="form1" runat="server">
                <div class="form-group">
                    <div class="form-group row">
                        <asp:Label ID="Label1" runat="server" Text="האם המשחק מפורסם בהתאם לקוד המשחק שהוזן" class="col-sm-3"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" class="form-control col-sm-6"></asp:TextBox>
                    </div>
                    <div class="form-group row">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="הצג" class="btn col-md-4" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="form-group row">
                        <asp:Label ID="Label2" runat="server" Text="שם המשחק בהתאם לקוד המשחק שהוזן" class="col-sm-3"></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" class="form-control col-sm-6"></asp:TextBox>
                    </div>
                    <div class="form-group row">
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="הצג" class="btn col-md-4" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="form-group row">
                        <asp:Label ID="Label3" runat="server" Text="כל השאלות בהתאם לקוד המשחק שהוזן " class="col-sm-3"></asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server" class="form-control col-sm-6"></asp:TextBox>
                    </div>
                    <div class="form-group row">
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="הצג" class="btn col-md-4" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="form-group row">
                        <asp:Label ID="Label4" runat="server" Text="סוג הפריט (טקסט או תמונה) של המסיח/הפריט הראשון של המשחק שהתאם לקוד המשחק שהוזן" class="col-sm-3"></asp:Label>
                        <asp:TextBox ID="TextBox4" runat="server" class="form-control col-sm-6"></asp:TextBox>
                    </div>
                    <div class="form-group row">
                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="הצג" class="btn col-md-4" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="form-group row">
                        <asp:Label ID="Label5" runat="server" Text="רשות: משחק למבוגרים בלבד שעולה 50.49" class="col-sm-3"></asp:Label>
                        <asp:TextBox ID="TextBox5" runat="server" class="form-control col-sm-6"></asp:TextBox>
                    </div>
                    <div class="form-group row">
                        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="הצג" class="btn col-md-4" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HIT-the-DUCK - עריכת משחק</title>
    <script src="jscripts/jquery-1.12.0.min.js"></script>
    <script src="jscripts/myScript.js"></script>

    <link href="styles/myStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.0/css/all.css" integrity="sha384-lZN37f5QGtY3VHgisS14W3ExzMWZxybE1SJSEsQp9S+oqd12jhcu+A56Ebc1zFSJ" crossorigin="anonymous">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body dir="rtl">
    <div class="container col-sm-12">
        <h1 runat="server" id="myH1">עריכת המשחק</h1>
        <div>
            <form id="form1" runat="server">
                <div class="container">
                    <div id="infospace" class="form-group row">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="שם המשחק: (1-20 תווים)"></asp:Label><br />
                            <asp:TextBox ID="gamename" placeholder="שם המשחק" item="1" MaxLength="20" CharacterLimit="20" CssClass="CharacterCount" runat="server" value="שם המשחק"></asp:TextBox><br />
                            <asp:Label ID="LabelCounter1" CssClass="countTooltip" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="הנחייה לזיהוי: (1-50 תווים)"></asp:Label><br />
                            <asp:TextBox ID="instructions" placeholder="הנחייה לזיהוי" item="2" MaxLength="50" CharacterLimit="50" CssClass="CharacterCount" runat="server" value="הנחיות למשחק"></asp:TextBox><br />
                            <asp:Label ID="LabelCounter2" CssClass="countTooltip" runat="server" Text=""></asp:Label>
                        </div>
                        <div id="updating">
                            <asp:Button ID="UpadeInfo" Text="עדכון שם והנחיות" CssClass="btn btn-primary" runat="server" OnClick="UpadeInfo_Click" UseSubmitBehavior="False" />
                        </div>
                        <div>
                            <asp:Button ID="back" runat="server" CssClass="btn btn-primary" Text="בחזרה לעמוד הראשי" Style="display: block; width: 100%;" OnClick="back_Click" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="form-group col-sm-5" style="float: right;">
                            <div class="checks">
                                <div><span id="overall-ok" class="fa fa-exclamation-circle"></span><span>לפחות 18 פריטים</span></div>
                                <div><span id="column-ok" class="fas fa-check-circle"></span><span>לפחות 9 פריטים בכל עמודה</span></div>
                                <div><span id="instuction-ok" class="fas fa-check-circle"></span><span>הנחייה לזיהוי</span></div>
                            </div>
                            <asp:FileUpload ID="FileUpload1" runat="server" />

                            <div id="uploading">
                                <asp:ImageButton ID="imgUpload" ImageUrl="~/images/uploadPhoto.png" runat="server" OnClick="imgUpload_Click" OnClientClick="openFileUploader1(); return false;" />
                                <asp:ImageButton ID="txtUpload" ImageUrl="~/images/uploadText.png" runat="server" OnClick="txtUpload_Click" />
                            </div>
                            <div id="ducky">
                                <div id="myEdit" style="float: right; direction: rtl">
                                    <asp:TextBox ID="itemTB" runat="server" Visible="false" placeholder="תוכן המסיח" Text="" item="3" MaxLength="40" TextMode="MultiLine" CharacterLimit="40" CssClass="CharacterCount"></asp:TextBox>
                                    <br />
                                    <asp:Label ID="LabelCounter3" Visible="false" CssClass="countTooltip" runat="server" Text=""></asp:Label>
                                    <asp:Image ID="itemIMG" Visible="true" runat="server" ImageUrl="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" />
                                    <%--</div>
                        <div class="form-group">--%>
                                    <br />
                                    <asp:RadioButtonList ID="ansRBL" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="נכון" Value="true"></asp:ListItem>
                                        <asp:ListItem Text="לא נכון" Value="false"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <div id="buttons">
                                        <asp:Button ID="itemUpdateButton" CssClass="btn btn-primary" Visible="false" runat="server" Text="עדכון מסיח" OnClick="itemUpdateButton_Click" />
                                        <asp:Button ID="itemCancelButton" CssClass="btn btn-danger" Visible="false" runat="server" Text="מחיקת מסיח" OnClick="itemCancelButton_Click" />
                                        <asp:Button ID="ItemAddButtonIMG" CssClass="btn btn-primary" runat="server" Text="הוספת מסיח" OnClick="ItemAddButton_Click" />
                                        <asp:Button ID="ItemAddButtonTXT" CssClass="btn btn-primary" runat="server" Text="הוספת מסיח" OnClick="ItemAddButton_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-sm-7" style="float: left; direction: rtl">
                            <div class="form-group row">
                                <asp:DataList ID="DataListCorrect" runat="server" DataSourceID="XmlDataSource_Correct" OnSelectedIndexChanged="ItemSelect">
                                    <HeaderTemplate>
                                        מסיחים נכונים
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkSelect" runat="server" theItemId='<%#XPathBinder.Eval(Container.DataItem,"@id")%>' CommandName="Select">
                                            <asp:Label ID="NameLabel" runat="server" Text='<%#XPath("text()")%>'></asp:Label>
                                            <asp:Image ID="ImageQR" Width="50px" runat="server" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Height="50px" Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="datalistItem" />
                                    <SelectedItemStyle BackColor="Yellow"></SelectedItemStyle>
                                </asp:DataList>
                                <asp:XmlDataSource ID="XmlDataSource_Correct" runat="server" DataFile="~/XMLFiles/games.xml"></asp:XmlDataSource>
                                <asp:DataList ID="DataListIncorrect" runat="server" DataSourceID="XmlDataSource_Incorrect" OnSelectedIndexChanged="ItemSelect">
                                    <HeaderTemplate>
                                        מסיחים לא נכונים
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkSelect" runat="server" theItemId='<%#XPathBinder.Eval(Container.DataItem,"@id")%>' CommandName="Select">
                                            <asp:Label ID="NameLabel" runat="server" Text='<%#XPath("text()")%>'></asp:Label>
                                            <asp:Image ID="ImageQR" Width="50px" runat="server" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Height="50px" Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="datalistItem" />
                                    <SelectedItemStyle BackColor="Yellow"></SelectedItemStyle>
                                </asp:DataList>
                                <asp:XmlDataSource ID="XmlDataSource_Incorrect" runat="server" DataFile="~/XMLFiles/games.xml"></asp:XmlDataSource>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>

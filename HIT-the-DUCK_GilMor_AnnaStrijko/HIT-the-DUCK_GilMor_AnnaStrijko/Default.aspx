<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HIT-the-DUCK - ניהול משחקים</title>
    <style>
        body {
            direction: rtl;
            font-family: Arial;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            שם המשחק <asp:TextBox ID="addNameTB" runat="server"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/add.png" OnClick="ImageButton1_Click" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="XmlDataSource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="שם המשחק">
                        <ItemTemplate>
                            <asp:Label ID="NameLabel" runat="server" Text='<%#Server.UrlDecode(XPathBinder.Eval(Container.DataItem, "@name").ToString())%>'> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="קוד משחק">
                        <ItemTemplate>
                            <asp:Label ID="idLabel" runat="server" Text='<%#XPathBinder.Eval(Container.DataItem, "@gamecode")%>'> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="עריכה">
                        <ItemTemplate>
                            <asp:ImageButton ID="editImageButton" CommandName="editRow" theItemId='<%#XPathBinder.Eval(Container.DataItem,"@id")%>' runat="server" ImageUrl="~/images/edit.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="מחיקה">
                        <ItemTemplate>
                            <asp:ImageButton ID="deleteImageButton" CommandName="deleteRow" theItemId='<%#XPathBinder.Eval(Container.DataItem,"@id")%>' runat="server" ImageUrl="~/images/delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="פרסום">
                        <ItemTemplate>
                            <asp:CheckBox ID="isPassCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged="isPassCheckBox_CheckedChanged" Checked='<%#Convert.ToBoolean(XPathBinder.Eval(Container.DataItem,"@isPublished"))%>' theItemId='<%#XPathBinder.Eval(Container.DataItem,"@id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>

            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/XMLFiles/games.xml" XPath="/HIT-the-Duck/game"></asp:XmlDataSource>
            <br />
        </div>
    </form>
</body>
</html>

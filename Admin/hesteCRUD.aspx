<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hesteCRUD.aspx.cs" Inherits="Admin_hesteCRUD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    
    div#liste, div#edit
    {
        float:left;
    }
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="liste">
            <asp:Button ID="ButtonNy" runat="server" onclick="ButtonNy_Click" 
                Text="Ny Hest" />
            <br />
            <asp:EntityDataSource ID="EntityDataSourceHeste" runat="server" 
                ConnectionString="name=RideklubbenContext" 
                DefaultContainerName="RideklubbenContext" EnableFlattening="False" 
                EntitySetName="Heste">
            </asp:EntityDataSource>
            <asp:Repeater ID="RepeaterHeste" runat="server" 
                DataSourceID="EntityDataSourceHeste" 
                onitemcommand="RepeaterHeste_ItemCommand">
                <ItemTemplate>
                    <div class="hest">
                        <asp:LinkButton ID="LinkButtonHest" runat="server" CommandName="hentHest" CommandArgument='<%# Eval("HesteId") %>'>
<%--                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "../" + Eval("BilledeSti") %>' Width="100" />--%>
                        <asp:Image ID="Image2" runat="server" ImageUrl='<%# "../images/hesteBillede.aspx?id=" + Eval("HesteId") + "&size=tiny" %>' />
                        
                        <span class="hesteNavn"><%# Eval("Navn") %></span>
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonSlet" runat="server" CommandName="sletHest" CommandArgument='<%# Eval("HesteId") %>'>Slet</asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div id="edit">
            <asp:Panel ID="PanelEdit" runat="server" Visible="false" >
                <asp:Image ID="ImageEdit" runat="server" ImageUrl='<%# "../images/hesteBillede.aspx?id=" + Eval("HesteId") + "&size=small" %>' style="float:right" />
                <asp:Label ID="LabelNavn" runat="server" BackColor="#F0F0F0" Text="Navn" 
                    Width="200px"></asp:Label>
                <asp:TextBox ID="TextBoxNavn" runat="server" Width="200px"></asp:TextBox>
                <br />
                <asp:Label ID="LabelVægt" runat="server" BackColor="#F0F0F0" Text="Vægt" 
                    Width="200px"></asp:Label>
                <asp:TextBox ID="TextBoxVægt" runat="server" Width="200px"></asp:TextBox>
                <br />
                <asp:Label ID="LabelHøjde" runat="server" BackColor="#F0F0F0" Text="Højde" 
                    Width="200px"></asp:Label>
                <asp:TextBox ID="TextBoxHøjde" runat="server" Width="200px"></asp:TextBox>
                <br />
                <asp:Label ID="LabelBillede" runat="server" BackColor="#f0f0f0" Text="Billede"
                    Width="200px"></asp:Label>
                <asp:FileUpload ID="FileUploadBillede" runat="server" />
                <br />

                <asp:Button ID="ButtonOpdater" runat="server" Text="Opdater" 
                    onclick="ButtonOpdater_Click" Visible="false" />
                <asp:Button ID="ButtonOpret" runat="server" Text="Opret" 
                    onclick="ButtonOpret_Click" Visible="false" />
                
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>

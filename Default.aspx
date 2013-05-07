<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RideKlubben</title>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

      <div class="container">
        <div class="topBar row">
            <asp:Repeater ID="RepeaterTopBar" runat="server" 
                OnItemCommand="RepeaterTopBar_ItemCommand">
                <HeaderTemplate>
                    <h2 class="span12">Heste</h2>
                    <div class="span12">
                </HeaderTemplate>
                <ItemTemplate>       
                        <div class="menuImage ">
                            <%--<img src="images/Dansk_Varmblod.jpg" />--%>
                            <asp:LinkButton ID="LinkButtonTopBar" runat="server" CommandArgument='<%# Eval("HesteId") %>' >
                                <asp:Image ID="ImageHest" runat="server" ImageUrl='<%# Eval("BilledeSti") %>'/></asp:LinkButton>
                           <%-- <asp:ImageButton ID="ImageTopBar" runat="server" 
                                ImageUrl='<%# Eval("BilledeSti") %>'  CommandArgument='<%# Eval("HesteId") %>' />--%>
                        </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
          
            
          <%--  
            <h2 class="span12">Heste</h2>
              <div class="span12">
            <div class="menuImage ">
                <img src="images/Dansk_Varmblod.jpg" />
            </div>
            <div class="menuImage">
                <img src="images/20db8b3f-bd3e-4186-8a60-72128fdbf694.jpg" />
            </div>
            <div class="menuImage ">
                <img src="images/Eva edit.jpg" />
            </div>
            <div class="menuImage valgt">
                <img src="images/Tarok på Grosbois 005.jpg" />
            </div>
            <div class="menuImage">
                <img src="images/Springhest.jpg" />
            </div>
            <div class="menuImage ">
                <img src="images/Dansk_Varmblod.jpg" />
            </div>
            <div class="menuImage">
                <img src="images/20db8b3f-bd3e-4186-8a60-72128fdbf694.jpg" />
            </div>
            <div class="menuImage ">
                <img src="images/Eva edit.jpg" />
            </div>
            <div class="menuImage">
                <img src="images/Resize.jpg" />
            </div>
            <div class="menuImage">
                <img src="images/Springhest.jpg" />
            </div>
            <div class="menuImage ">
                <img src="images/Dansk_Varmblod.jpg" />
            </div>
            <div class="menuImage">
                <img src="images/20db8b3f-bd3e-4186-8a60-72128fdbf694.jpg" />
            </div>
            <div class="menuImage ">
                <img src="images/Eva edit.jpg" />
            </div>
            <div class="menuImage">
                <img src="images/Resize.jpg" />
            </div>
            <div class="menuImage">
                <img src="images/Springhest.jpg" />
            </div>
        </div>--%></div>
        <div class="row">
            <div class="leftColumn span2">
                <asp:Repeater ID="RepeaterLeftColumn" runat="server" >
                    <HeaderTemplate>
                        <h2 class="">Ryttere</h2>
                    </HeaderTemplate>
                    <ItemTemplate>
                         <div class="menuImage">
                            <img src='<%# Eval("BilledeSti") %>' />
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>

                    </FooterTemplate>
                </asp:Repeater>
             <%--   <h2 class="">Ryttere</h2>
                <div class="menuImage">
                    <img src="images/ryttere/ALridsillustration.JPG" />
                </div>
                <div class="menuImage">
                    <img src="images/ryttere/16-2-1024x682.jpg" />
                </div>
                <div class="menuImage">
                    <img src="images/ryttere/Carola_002.jpg" />
                </div>--%>
            </div>
            <div class="centerColumn span8">
                <div class="centerImage">
                    <div class="imageInfo">
                        <h1><%--Tarok--%><asp:Literal ID="CenterImageNavn" runat="server"></asp:Literal></h1>
                        <h2><%--24 år--%><asp:Literal ID="CenterImageAlder" runat="server"></asp:Literal>, 
                            <%--Tudegårdens stutteri--%><asp:Literal ID="CenterIamgeOprindelse" runat="server"></asp:Literal></h2>
                    </div> 
                    <%--<img src="images/Tarok på Grosbois 005.jpg" />--%>
                    <asp:Image ID="CenterImageImg" runat="server" />
                </div>
                <div class="row">
                    <h2 class="span8">Forældre</h2>
                    <div class="forælder span4 menuImage">
                        <%--<img src="images/Eva edit.jpg" />--%>
                        <asp:Image ID="CenterImageFaderImg" runat="server" />
                    </div>
                    <div class="forælder span4 menuImage">
                        <%--<img src="images/Springhest.jpg" />--%>
                        <asp:Image ID="CenterImageModerImage" runat="server" />
                    </div>
                </div>
            </div>
            <div class="rightColumn span2">
                <asp:Repeater ID="RepeaterRightColumn" runat="server">
                    <HeaderTemplate>
                        <h2 class="">Ejere</h2>
                    </HeaderTemplate>
                    <ItemTemplate>
                         <div class="menuImage">
                    <img src="images/ryttere/ejere/DSC1819-1.jpg" />
                </div> 
                    </ItemTemplate>
                </asp:Repeater>
                <%--<h2 class="">Ejere</h2>
                 <div class="menuImage">
                    <img src="images/ryttere/ejere/DSC1819-1.jpg" />
                </div> 
                <div class="menuImage">
                    <img src="images/ryttere/ejere/adebf0b94a-images-SysHeaven.png" />
                </div>--%>
            </div>
        </div>
    </div>
    </form>
</body>
    <script type="text/javascript" src="http://code.jquery.com/jquery.js"></script>
    <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>
</html>

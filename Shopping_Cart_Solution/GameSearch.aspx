<%@ Page Title="" Language="C#" MasterPageFile="~/GameMaster.master" AutoEventWireup="true" CodeFile="GameSearch.aspx.cs" Inherits="GameSearch" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html>
    <html>
    <head>
        <title>Search</title>
        <link rel="stylesheet" type="text/css" href="assets/css/GameSearch.css" />
    </head>
    <body>
        <br />
        <div class="pagetitle">Search Result</div>
        <br />

        <div>
            <asp:TextBox ID="txtSearch2" Style="height: 0.1px; width: 0.1px; border: none" runat="server"></asp:TextBox>
        </div>

        <div class="sidecontainer">
            <div style="width: auto; height: auto; float: right">
               <a style="font-family: 'Oswald', sans-serif;">CUSTOMER FAVOURITES</a>
                    <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Spring Games</a>
                    <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">SB's Top 10 Weekly Games</a>
                    <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">New Releases</a>

                    <a style="font-family: 'Oswald', sans-serif;"></a>
                    <a style="font-family: 'Oswald', sans-serif;">BEST VALUE</a>
                    <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Call Of Duty special: 20% discount on all Call Of Duty games!</a>
                                        <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Call Of Duty franchaise collection: get all 40 games at 10% Off! </a>
                    <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Spring Game Deals</a>
                    <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">SB Game Classics: $6 Each</a>
                    <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">New Releases 15% Off</a>
                    <a style="font-family: 'Oswald', sans-serif;"></a>
                    <a style="font-family: 'Oswald', sans-serif;">CATEGORIES</a>
                    <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Action</a>
                    <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Indie</a>
                    <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">Open-world</a>
                    <a href="#" style="font-family: 'Oswald', sans-serif; color: #48C9B0; font-size: 12.5px">See All Categories</a>
            </div>
        </div>

        <div class="gamecontainer">
            <asp:Label ID="lblnoresult2" runat="server" Text="No results found." Font-Size="Larger" Visible="False"></asp:Label>
            <div class="gameshelf">
                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <div style="width: 146px;">
                            <asp:ImageButton PostBackUrl='<%# ResolveClientUrl("GameProductDetails.aspx?ProdID=" + Eval("ID") ) %>' class="gameimage" ID="imgGames" ImageUrl='<%#Eval("Image") %>' runat="server" />
                            <asp:Label class="gametitle" ID="lblGameTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label><br />
                            <asp:Label class="gamepublisher" ID="lblGamepublisher" runat="server" Text='<%#Eval("Publisher") %>' Style="color: #48C9B0"></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </body>
    </html>
</asp:Content>


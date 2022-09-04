<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Admin-GameBestseller.aspx.cs" Inherits="GameBestseller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!DOCTYPE html>
    <html>
        <head>
            <title>Best Sellers</title>
            <link rel="stylesheet" type="text/css" href="assets/css/GameBestseller.css" />
        </head>
        <body>
            <br />
            <div class="pagetitle">The Best Sellers</div>
            <br />

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
                <div class="containertitle">
                   CALL OF DUTY TITLES - 20% OFF
                    <asp:Button 
                    ID="btnCallOfDuty"
                    Style="font-size: 14px; padding: 8px; margin-bottom: 10px; margin-left: 10px; border: 0.5px solid" 
                    runat="server" 
                    Text="INSERT" OnClick="btnCallOfDuty_Click" />

                </div>

                <div class="gameshelf">
                    <asp:Repeater ID="CallOfDuty" runat="server">
                         <ItemTemplate>             
                             <div style="width: 146px">
                                <asp:ImageButton ID="imgGames"  CssClass="gameimage" ImageUrl='<%#Eval("GS_Image")%>' runat="server" />
                                <asp:TextBox ID="txtImage" Text='<%#Eval("GS_Image")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label CssClass="gametitle" ID="lblTitle"  runat="server" Text='<%#Eval("GS_Title")%>'></asp:Label>
                                <asp:TextBox ID="txtTitle" Text='<%#Eval("GS_Title")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label CssClass="gamepublisher" ID="lblPublisher" runat="server" Text='<%#Eval("GS_Publisher")%>' Style="color: #48C9B0"></asp:Label>
                                <asp:TextBox ID="txtDeveloper" Text='<%#Eval("GS_Publisher")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label ID="lblGameId" runat="server" Text='<%# Eval("GS_ID") %>' Visible="false"></asp:Label>
                                <br />

                                <asp:LinkButton ID="lnkEdit" Text="Edit |" runat="server" OnClick="OnEdit" Font-Size="X-Small" />
                                <asp:LinkButton ID="lnkUpdate" Text="Update |" runat="server" Visible="false" OnClick="OnUpdate"  Font-Size="X-Small" />
                                <asp:LinkButton ID="lnkCancel" Text="Cancel |" runat="server" Visible="false" OnClick="OnCancel" Font-Size="X-Small" />
                                <asp:LinkButton
                                ID="lnkDelete"
                                Text="Delete"
                                runat="server"
                                OnClick="OnDelete"
                                OnClientClick="return confirm('Are you sure you want to delete this?');"
                                Font-Size="X-Small" />
                             </div>              
                        </ItemTemplate>
                    </asp:Repeater>

                </div>

                <div class="containertitle">
                   ACTION TITLES
                    <asp:Button 
                    ID="btnAddAction"
                    Style="font-size: 14px; padding: 8px; margin-bottom: 10px; margin-left: 10px; border: 0.5px solid" 
                    runat="server" 
                    Text="INSERT" OnClick="btnAddAction_Click" />

                </div>

                <div class="gameshelf">
                    <asp:Repeater ID="Action" runat="server">
                         <ItemTemplate>             
                             <div style="width: 146px">
                                <asp:ImageButton ID="imgGames"  CssClass="gameimage" ImageUrl='<%#Eval("GS_Image")%>' runat="server" />
                                <asp:TextBox ID="txtImage" Text='<%#Eval("GS_Image")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label CssClass="gametitle" ID="lblTitle"  runat="server" Text='<%#Eval("GS_Title")%>'></asp:Label>
                                <asp:TextBox ID="txtTitle" Text='<%#Eval("GS_Title")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label CssClass="gamepublisher" ID="lblPublisher" runat="server" Text='<%#Eval("GS_Publisher")%>' Style="color: #48C9B0"></asp:Label>
                                <asp:TextBox ID="txtDeveloper" Text='<%#Eval("GS_Publisher")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label ID="lblGameId" runat="server" Text='<%# Eval("GS_ID") %>' Visible="false"></asp:Label>
                                <br />

                                <asp:LinkButton ID="lnkEdit" Text="Edit |" runat="server" OnClick="OnEdit" Font-Size="X-Small" />
                                <asp:LinkButton ID="lnkUpdate" Text="Update |" runat="server" Visible="false" OnClick="OnUpdate"  Font-Size="X-Small" />
                                <asp:LinkButton ID="lnkCancel" Text="Cancel |" runat="server" Visible="false" OnClick="OnCancel" Font-Size="X-Small" />
                                <asp:LinkButton
                                ID="lnkDelete"
                                Text="Delete"
                                runat="server"
                                OnClick="OnDelete"
                                OnClientClick="return confirm('Are you sure you want to delete this?');"
                                Font-Size="X-Small" />
                            </div>
               
                        </ItemTemplate>
                    </asp:Repeater>

                </div>

                <div class="containertitle">
                   CO-OP TITLES
                    <asp:Button 
                    ID="btnAddCoOp"
                    Style="font-size: 14px; padding: 8px; margin-bottom: 10px; margin-left: 10px; border: 0.5px solid" 
                    runat="server" 
                    Text="INSERT" OnClick="btnAddCoOp_Click" />
                </div>

                <div class="gameshelf">
                    <asp:Repeater ID="CoOp" runat="server">
                         <ItemTemplate>             
                             <div style="width: 146px">
                                <asp:ImageButton ID="imgGames"  CssClass="gameimage" ImageUrl='<%#Eval("GS_Image")%>' runat="server" />
                                <asp:TextBox ID="txtImage" Text='<%#Eval("GS_Image")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label CssClass="gametitle" ID="lblTitle"  runat="server" Text='<%#Eval("GS_Title")%>'></asp:Label>
                                <asp:TextBox ID="txtTitle" Text='<%#Eval("GS_Title")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label CssClass="gamepublisher" ID="lblPublisher" runat="server" Text='<%#Eval("GS_Publisher")%>' Style="color: #48C9B0"></asp:Label>
                                <asp:TextBox ID="txtDeveloper" Text='<%#Eval("GS_Publisher")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label ID="lblGameId" runat="server" Text='<%# Eval("GS_ID") %>' Visible="false"></asp:Label>
                                <br />

                                <asp:LinkButton ID="lnkEdit" Text="Edit |" runat="server" OnClick="OnEdit" Font-Size="X-Small" />
                                <asp:LinkButton ID="lnkUpdate" Text="Update |" runat="server" Visible="false" OnClick="OnUpdate"  Font-Size="X-Small" />
                                <asp:LinkButton ID="lnkCancel" Text="Cancel |" runat="server" Visible="false" OnClick="OnCancel" Font-Size="X-Small" />
                                <asp:LinkButton
                                ID="lnkDelete"
                                Text="Delete"
                                runat="server"
                                OnClick="OnDelete"
                                OnClientClick="return confirm('Are you sure you want to delete this?');"
                                Font-Size="X-Small" />
                            </div>
               
                        </ItemTemplate>
                    </asp:Repeater>

                </div>

                <div class="containertitle">
                   INDIE TITLES
                    <asp:Button 
                    ID="btnAddIndie"
                    Style="font-size: 14px; padding: 8px; margin-bottom: 10px; margin-left: 10px; border: 0.5px solid" 
                    runat="server" 
                    Text="INSERT" OnClick="btnAddIndie_Click" />
                </div>

                <div class="gameshelf">
                    <asp:Repeater ID="Indie" runat="server">
                         <ItemTemplate>             
                             <div style="width: 146px">
                               <asp:ImageButton ID="imgGames"  CssClass="gameimage" ImageUrl='<%#Eval("GS_Image")%>' runat="server" />
                                <asp:TextBox ID="txtImage" Text='<%#Eval("GS_Image")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label CssClass="gametitle" ID="lblTitle"  runat="server" Text='<%#Eval("GS_Title")%>'></asp:Label>
                                <asp:TextBox ID="txtTitle" Text='<%#Eval("GS_Title")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label CssClass="gamepublisher" ID="lblPublisher" runat="server" Text='<%#Eval("GS_Publisher")%>' Style="color: #48C9B0"></asp:Label>
                                <asp:TextBox ID="txtDeveloper" Text='<%#Eval("GS_Publisher")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label ID="lblGameId" runat="server" Text='<%# Eval("GS_ID") %>' Visible="false"></asp:Label>
                                <br />

                                <asp:LinkButton ID="lnkEdit" Text="Edit |" runat="server" OnClick="OnEdit" Font-Size="X-Small" />
                                <asp:LinkButton ID="lnkUpdate" Text="Update |" runat="server" Visible="false" OnClick="OnUpdate"  Font-Size="X-Small" />
                                <asp:LinkButton ID="lnkCancel" Text="Cancel |" runat="server" Visible="false" OnClick="OnCancel" Font-Size="X-Small" />
                                <asp:LinkButton
                                ID="lnkDelete"
                                Text="Delete"
                                runat="server"
                                OnClick="OnDelete"
                                OnClientClick="return confirm('Are you sure you want to delete this?');"
                                Font-Size="X-Small" />
                            </div>
               
                        </ItemTemplate>
                    </asp:Repeater>

                </div>

                <div class="containertitle">
                   OPEN WORLD TITLES
                    <asp:Button 
                    ID="btnAddOpenWorld"
                    Style="font-size: 14px; padding: 8px; margin-bottom: 10px; margin-left: 10px; border: 0.5px solid" 
                    runat="server" 
                    Text="INSERT" OnClick="btnAddOpenWorld_Click" />
                </div>

                <div class="gameshelf">
                    <asp:Repeater ID="OpenWorld" runat="server">
                         <ItemTemplate>             
                             <div style="width: 146px">
                               <asp:ImageButton ID="imgGames"  CssClass="gameimage" ImageUrl='<%#Eval("GS_Image")%>' runat="server" />
                                <asp:TextBox ID="txtImage" Text='<%#Eval("GS_Image")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label CssClass="gametitle" ID="lblTitle"  runat="server" Text='<%#Eval("GS_Title")%>'></asp:Label>
                                <asp:TextBox ID="txtTitle" Text='<%#Eval("GS_Title")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label CssClass="gamepublisher" ID="lblPublisher" runat="server" Text='<%#Eval("GS_Publisher")%>' Style="color: #48C9B0"></asp:Label>
                                <asp:TextBox ID="txtDeveloper" Text='<%#Eval("GS_Publisher")%>' runat="server" Visible="false"></asp:TextBox>
                                <br />

                                <asp:Label ID="lblGameId" runat="server" Text='<%# Eval("GS_ID") %>' Visible="false"></asp:Label>
                                <br />

                                <asp:LinkButton ID="lnkEdit" Text="Edit |" runat="server" OnClick="OnEdit" Font-Size="X-Small" />
                                <asp:LinkButton ID="lnkUpdate" Text="Update |" runat="server" Visible="false" OnClick="OnUpdate"  Font-Size="X-Small" />
                                <asp:LinkButton ID="lnkCancel" Text="Cancel |" runat="server" Visible="false" OnClick="OnCancel" Font-Size="X-Small" />
                                <asp:LinkButton
                                ID="lnkDelete"
                                Text="Delete"
                                runat="server"
                                OnClick="OnDelete"
                                OnClientClick="return confirm('Are you sure you want to delete this?');"
                                Font-Size="X-Small" />
                            </div>
               
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
        </body>
    </html>
</asp:Content>


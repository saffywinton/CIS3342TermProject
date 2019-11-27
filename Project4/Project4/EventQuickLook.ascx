<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventQuickLook.ascx.cs" Inherits="DoorGrubMate.EventQuickLook" %>

<div class="row">
    <div class="col fillBox">
        <asp:Image ID="imgThumbnail" runat="server" />
    </div>
</div>
<div class="row">
    <div class="col-9">
        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    </div>
    <div class="col-3 fillBox">
        <asp:Button ID="btn" runat="server" Text="Button" />
    </div>
</div>
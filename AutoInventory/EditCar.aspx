<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="EditCar.aspx.cs" Inherits="AutoInventory.EditCar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div>
        <div class="text-center"><h1>Edit Automobile</h1></div>
        <form runat="server" id="frm">
            <asp:Label runat="server" ID="lblManufacturer" AssociatedControlID="txtManufacturer" Text="Manufacturer"></asp:Label>
            <asp:TextBox runat="server" ID="txtManufacturer" MaxLength="100"></asp:TextBox>
            <br />
            <asp:Label runat="server" ID="lblMake" AssociatedControlID="txtMake" Text="Make"></asp:Label>
            <asp:TextBox runat="server" ID="txtMake" MaxLength="100"></asp:TextBox>
            <br />
            <asp:Label runat="server" ID="lblYear" AssociatedControlID="txtYear" Text="Year"></asp:Label>
            <asp:TextBox runat="server" ID="txtYear" MaxLength="4" TextMode="Number" min="1900"></asp:TextBox> (2015)
            <br />
            <asp:Label runat="server" ID="lblColour" AssociatedControlID="txtColour" Text="Colour"></asp:Label>
            <asp:TextBox runat="server" ID="txtColour" MaxLength="25" TextMode="Color"></asp:TextBox>
            <br />
            <asp:Label runat="server" ID="lblSeating" AssociatedControlID="txtSeating" Text="Seating"></asp:Label>
            <asp:TextBox runat="server" ID="txtSeating" MaxLength="4" TextMode="Number" min="1" max="8"></asp:TextBox> 
            <br />
            <br />
            <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" /> <asp:Button runat="server" OnClientClick="return window.confirm('Are You Sure?');" ID="btnDelete" Text="Delete" OnClick="btnDelete_Click" /> <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" /> 
        </form>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>

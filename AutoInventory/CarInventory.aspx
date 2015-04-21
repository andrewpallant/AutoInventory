<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="CarInventory.aspx.cs" Inherits="AutoInventory.CarInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div ng-app="autoInventory" ng-controller="AutomobileController">
    <div class="text-center"><h1>Auto Inventory Manager</h1></div>
    <form id="frmMain" runat="server">
        <div class="text-right"><asp:LinkButton runat="server" ID="lnkNew" OnClick="lnkNew_Click">New Car</asp:LinkButton></div>
        <table ng-table="tableParams" class="table">
            <tr ng-repeat="automobile in $data">
                <td data-title="'Manufacturer'" sortable="'Manufacturer'"><a href="EditCar.aspx?id={{automobile.ID}}">{{automobile.Manufacturer}}</a></td>
                <td data-title="'Make'" sortable="'Make'">{{automobile.Make}}</td>
                <td data-title="'Year'" sortable="'Year'">{{automobile.Year}}</td>
                <td data-title="'Colour'" sortable="'Colour'" style="text-align:center;"><div style="background:{{automobile.Colour}};width:100px;border:1px outset #555;">&nbsp;</div></td>
                <td data-title="'Seating'" sortable="'Seating'">{{automobile.Seating}}</td>
            </tr>
        </table>
    </form>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script src="/scripts/angular.js"></script>
    <script src="/scripts/ng-table.js"></script>
    <script src="/InventoryData.aspx" type="text/javascript"></script>

    <link href="css/ng-table.css" rel="stylesheet" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ThreeTier_MultiUser_AddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
            <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h1>Contact List</h1>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row text-center">
            <div class="col-md-12">
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
                <asp:Label runat="server" ID="label" EnableViewState="false"></asp:Label>
            </div>
        </div>
    </div>
    <asp:GridView runat="server" ID="gvContactList" CssClass="table table-hover table-responsive table-bordered" style="margin-top:20px;" AutoGenerateColumns="False" OnRowCommand="gvContactList_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="ContactID" HeaderText="ID"/>
            <asp:BoundField DataField="ContactName" HeaderText="Contact"/>
            <asp:BoundField DataField="CountryName" HeaderText="Country" />
            <asp:BoundField DataField="StateName" HeaderText="State" />
            <asp:BoundField DataField="CityName" HeaderText="City" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="ContactNo" HeaderText="Contact Number" />
            <asp:BoundField  DataField="BirthDate" HeaderText="BirthDate" />
            <asp:BoundField DataField="PhotoDetail" HeaderText="PhotoDetail" ApplyFormatInEditMode="True" />
            <asp:TemplateField HeaderText="Photo">
                <ItemTemplate>
                   <asp:Image runat="server" ID="imgContactPhotoPath" ImageUrl='<%# Eval("ContactPhotoPath") %>' Height="180px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="hlEdit"  NavigateUrl ='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID=" +Eval("ContactID").ToString().Trim()  %>'  Text="Edit" CssClass="btn btn-danger btn-sm" Style="background-color:yellowgreen;border-color:yellowgreen" CommandName="EditRecord"  />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>


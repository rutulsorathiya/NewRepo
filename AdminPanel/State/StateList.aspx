<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ThreeTier_MultiUser_AddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h1>State List</h1>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row text-center">
            <div class="col-md-12">
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
            </div>
        </div>
    </div>
    <asp:GridView runat="server" ID="gvStateList" CssClass="table table-hover table-responsive table-bordered" style="margin-top:20px;" AutoGenerateColumns="False" OnRowCommand="gvStateList_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField  DataField="StateID" HeaderText="ID"/>
            <asp:BoundField  DataField="CountryName" HeaderText="Country"/>
            <asp:BoundField  DataField="StateName" HeaderText="State"/>
            <asp:BoundField  DataField="StateCode" HeaderText="State Code" />
            <asp:TemplateField HeaderText="Delete" >
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="hlEdit"  NavigateUrl ='<%# "~/AdminPanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID").ToString().Trim() %>'  Text="Edit" CssClass="btn btn-danger btn-sm" Style="background-color:yellowgreen;border-color:yellowgreen" CommandName="EditRecord"  />
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


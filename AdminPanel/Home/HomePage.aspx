<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ThreeTier_MultiUser_AddressBook.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="AdminPanel_Home_HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
        <style>
        .Section{
            background-color:silver;
            margin:10px;
            border-radius:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:Label runat="server" Visible="false" ID="lblMessage"></asp:Label>
            </div>
        </div>
    </div>
    
    <section class="Section">
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h2>Country Table</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView runat="server" ID="gvCountryList" CssClass=" table  table-bordered table-hover table-responsive"> </asp:GridView>
            </div>
        </div>
    </div>
    </section>
    <section class="Section">
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h2>State Table</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView runat="server" ID="gvStateList" CssClass=" table table-bordered table-hover table-responsive"> </asp:GridView>
            </div>
        </div>
    </div>
    </section>
    <section class="Section">
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h2>City Table</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView runat="server" ID="gvCityList" CssClass=" table table-bordered table-hover table-responsive"> </asp:GridView>
            </div>
        </div>
    </div>
    </section>
    <section class="Section">
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h2>Contact Category Table</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView runat="server" ID="gvContactCategoryList" CssClass=" table table-bordered table-hover table-responsive"> </asp:GridView>
            </div>
        </div>
    </div>
    </section>
    <section class="Section">
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h2>Contact Table</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView runat="server" ID="gvContactList" CssClass=" table table-bordered table-hover table-responsive" > </asp:GridView>
            </div>
        </div>
    </div>
        </section>
</asp:Content>


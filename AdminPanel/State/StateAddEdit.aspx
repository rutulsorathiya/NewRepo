<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ThreeTier_MultiUser_AddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
        <script>
        setTimeout(function () {
            document.getElementById("<%= lblMessage.ClientID%>").style.display = "none";
        }, 1000);
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12" style="background-color: #f7f7f7; margin-top: 10px; padding-left: 50px; width: 500px; height: 80px; border-radius: 10px">
                <h2>State Add/Edit Page</h2>
            </div>
        </div>
        <hr style="border-color: #555" />
        <div class="row">
            <div class="col-md-12 " style="padding-left: 670px">
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
            </div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>Country Name <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>State Name <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtStateName" CssClass="form-control" placeholder="Enter State Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ControlToValidate="txtStateName" Display="Dynamic" ErrorMessage="Enter State Name" ForeColor="Red" Style="font-size: x-small" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>State Code <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtStateCode" CssClass="form-control" placeholder="Enter State Code"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvStateCode" runat="server" ControlToValidate="txtStateCode" Display="Dynamic" ErrorMessage="Enter State Code" ForeColor="Red" Style="font-size: x-small" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-12 text-center">
                <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" ValidationGroup="Save"/>
                <asp:Button runat="server" ID="btnCnacel" Text="Cancel" CssClass="btn btn-success" OnClick="btnCancel_Click" Style="background-color: #555; color: white; border-color: #555;" />
            </div>
        </div>
    </div>
</asp:Content>


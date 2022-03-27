<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ThreeTier_MultiUser_AddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

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
                <h2>City Add/Edit Page</h2>
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
                <span>State Name <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-control" placeholder="Enter State Name"></asp:DropDownList>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>City Name <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control" placeholder="Enter City Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ControlToValidate="txtCityName" Display="Dynamic" ErrorMessage="Enter City Name" ForeColor="Red" Style="font-size: x-small" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>Pin Code :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtPinCode" CssClass="form-control" placeholder="Enter PinCode"></asp:TextBox>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>STD Code :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtSTDCode" CssClass="form-control" placeholder="Enter STD Code"></asp:TextBox>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-12 text-center">
                <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"  ValidationGroup="Save"/>
                <asp:Button runat="server" ID="btnCnacel" Text="Cancel" CssClass="btn btn-success" OnClick="btnCancel_Click" Style="background-color: #555; color: white; border-color: #555;" />
            </div>
        </div>
    </div>
</asp:Content>


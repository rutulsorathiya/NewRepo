<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ThreeTier_MultiUser_AddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

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
                <h2>Contact Add/Edit Page</h2>
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
                <span>Contact Name <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtContactName" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContactName" runat="server" ControlToValidate="txtContactName" Display="Dynamic" ErrorMessage="Enter Contact Name" ForeColor="Red" Style="font-size:x-small" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>Country Name <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="ddlCountryID" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged">
                </asp:DropDownList>
                
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>State Name <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="ddlStateID" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged">
                    <asp:ListItem Value="-1">-- Select State --</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>City Name <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="ddlCityID" AutoPoastBack="True" CssClass="form-control">
                    <asp:ListItem Value="-1">-- Select City --</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>Contact Category Name <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:CheckBoxList runat="server" ID="cblContactCategoryID" >
                </asp:CheckBoxList>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>Contact Number <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtContactNumber" CssClass="form-control" placeholder="Enter Contact Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContactNumber" runat="server" ControlToValidate="txtContactNumber" Display="Dynamic" ErrorMessage="Enter Contact Number" ForeColor="Red" Style="font-size:x-small" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>WhatsApp Number :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtWhatsAppNumber" CssClass="form-control" placeholder="Enter WhatsApp Number"></asp:TextBox>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>BirthDate <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtBirthDate" CssClass="form-control" Type="date" placeholder="Enter BirthDate" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ControlToValidate="txtBirthDate" Display="Dynamic" ErrorMessage="Enter Birth Date" ForeColor="Red" Style="font-size:x-small" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>Email <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Email Address" ForeColor="Red" Style="font-size:x-small" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>Age :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtAge" CssClass="form-control" placeholder="Enter Age"></asp:TextBox>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>Address <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" placeholder="Enter Address"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Enter Address" ForeColor="Red" Style="font-size:x-small" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>Blood Group :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtBloodGroup" CssClass="form-control" placeholder="Enter Blood Group"></asp:TextBox>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>FaceBook ID :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtFaceBookID" CssClass="form-control" placeholder="Enter FacebookID"></asp:TextBox>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>LinkedIN ID :</span>
            </div>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtLinkedINID" CssClass="form-control" placeholder="Enter LinkIN_ID"></asp:TextBox>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="margin: 10px">
            <div class="col-md-5" style="text-align: right">
                <span>Upload Photo <span style="color: red">*</span> :</span>
            </div>
            <div class="col-md-3">
                <asp:FileUpload ID="fuContactPhotoPath" runat="server" />
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" ValidationGroup="Save" />
                <asp:Button runat="server" ID="btnCnacel" Text="Cancel" CssClass="btn btn-success" OnClick="btnCancel_Click" Style="background-color: #555; color: white; border-color: #555;" />
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" id="hfContactPhotoPath" />
    <asp:HiddenField runat="server" id="hfPhotoDetail" />
</asp:Content>


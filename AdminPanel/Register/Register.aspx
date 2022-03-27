<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="AdminPanel_Register_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Register Page</title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!--Made with love by Mutiullah Samim -->
   
	<!--Bootsrap 4 CDN-->
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    
    <!--Fontawesome CDN-->
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">

	<!--Custom styles-->
    <link href="Register.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="container-fluid">
            <div class="row">
                <div class="col-md-12 text-center">
                    <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
                </div>
            </div>
            <div class="d-flex justify-content-center h-100">
                <div class="card">
                    <div class="card-header">
                        <h3>Register</h3>
                        <div class="d-flex justify-content-end social_icon">
                            <span><i class="fab fa-facebook-square"></i></span>
                            <span><i class="fab fa-google-plus-square"></i></span>
                            <span><i class="fab fa-twitter-square"></i></span>
                        </div>
                    </div>
                    <div class="card-body">
                        
                        <div class="input-group form-group">                  
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="fas fa-user"></i></span>
                            </div>
                            <asp:TextBox runat="server" ID="txtUserName" type="text" class="form-control" placeholder="username" />
                        </div>
                        
                        <div class="input-group form-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="fas fa-key"></i></span>
                            </div>
                            <asp:TextBox runat="server" ID="txtPassword" type="password" class="form-control" placeholder="password" />
                        </div>

                        <div class="input-group form-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="fas fa-key"></i></span>
                            </div>
                            <asp:TextBox runat="server" ID="txtReEnterPassowrd" type="password" class="form-control" placeholder="Re-type password" />
                        </div>
                       
                        <div class="input-group form-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="fas fa-tv fa-fw" style="color: var(--fa-navy);"></i></span>
                            </div>
                            <asp:TextBox runat="server" ID="txtDisplayName"  class="form-control" placeholder="Display Name" />
                        </div>
                      
                        <div class="input-group form-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="fas fa-envelope fa-fw"></i></span>
                            </div>
                            <asp:TextBox runat="server" ID="txtEmail" class="form-control" placeholder="Email" />
                        </div>
                        
                        <div class="input-group form-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="fas fa-phone"></i></span>
                            </div>
                            <asp:TextBox runat="server" ID="txtContactNo"  class="form-control" placeholder="Contact Number" />
                        </div>
                        <div class="form-group">
                            <asp:LinkButton runat="server" ID="lbLogin" type="submit" Text="Register" class="btn float-right login_btn" OnClick="lbLogin_Click"></asp:LinkButton>
                        </div>

                    </div>
                    <div class="card-footer">
                        <div class="d-flex justify-content-center links">
                            <a href="../Login/Login.aspx">Login</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

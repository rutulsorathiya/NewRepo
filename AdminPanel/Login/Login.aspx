<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Login_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!--Made with love by Mutiullah Samim -->
   
	<!--Bootsrap 4 CDN-->
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    
    <!--Fontawesome CDN-->
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">

	<!--Custom styles-->
	<link rel="stylesheet" type="text/css" href="login.css">
    <style>
        #lblMessageUserName{
            font-size:small;
        }
        #lblMessagePassword{
            font-size:small;
           
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
                </div>
            </div>
            <div class="d-flex justify-content-center h-100">
                <div class="card">
                    <div class="card-header">
                        <h3>Sign In</h3>
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
                            <asp:TextBox runat="server" ID="txtUserName" type="text" class="form-control" placeholder="username"  />
                        </div>
                        <div>
                            <asp:Label runat="server" ID="lblMessageUserName" EnableViewState="false"></asp:Label>
                        </div>                
                        <div class="input-group form-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="fas fa-key"></i></span>
                            </div>
                            <asp:TextBox runat="server" ID="txtPassword" type="password" class="form-control" placeholder="password" />
                        </div>
                        <div>
                            <asp:Label runat="server" ID="lblMessagePassword" EnableViewState="false"></asp:Label>
                        </div>
                        <div class="row align-items-center remember">
                            <asp:TextBox runat="server" type="checkbox" />Remember Me
                        </div>
                        <div class="form-group">
                            <asp:LinkButton runat="server" ID="lbLogin" type="submit" Text="Login" class="btn float-right login_btn" OnClick="lbLogin_Click"></asp:LinkButton>
                        </div>

                    </div>
                    <div class="card-footer">
                        <div class="d-flex justify-content-center links">
                            Don't have an account?<a href="../Register/Register.aspx">Sign Up</a>
                        </div>
                        <div class="d-flex justify-content-center">
                            <a href="#">Forgot your password?</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

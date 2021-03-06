﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RedirectToPortal.aspx.cs" Inherits="RedirectToPortal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Redirecting to Portal</title>
</head>
<body>
    <form id="form1" runat="server">
    </form>
    <form name="LoginForm" method="post" id="LoginForm" action="RedirectToPortal.aspx">
        <input type="hidden" name="Token" id="Token" />
        
        <!--Once logged into Membersuite, jump to this URL-->
        <input type="hidden" name="NextUrl" id="NextUrl" />
    
        <!--In the MemberSuite Portal header, provide a return link to a custom URL-->
        <input type="hidden" name="ReturnUrl" id="ReturnUrl" />
        <input type="hidden" name="ReturnText" id="ReturnText" />
        
        <!--On logout from the MemberSuite Portal, redirect to this URL rather than the default login page-->
        <input type="hidden" name="LogoutUrl" id="LogoutUrl" />
    </form>
    <script type="text/javascript" language="javascript">
        var hfReturnUrl = document.getElementById("ReturnUrl");
        var hfNextUrl = document.getElementById("NextUrl");
        var hfToken = document.getElementById("Token");
        var loginForm = document.getElementById("LoginForm");

        hfReturnUrl.value = '<asp:Literal runat=server ID="litReturnUrl" />';
        hfToken.value = '<asp:Literal runat=server ID="litToken" />';
        hfNextUrl.value = '<asp:Literal runat=server ID="litNextUrl" />';

        loginForm.action = '<asp:Literal runat=server ID="litAction" />';
        loginForm.submit();
    </script>
</body>
</html>

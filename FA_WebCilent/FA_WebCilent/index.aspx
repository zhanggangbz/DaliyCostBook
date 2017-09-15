<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FA_WebCilent.index" Async="true" AsyncTimeout="3000"  %>

<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no">
		<meta name="description" content="我的账本登录">
		
		<link rel="stylesheet" href="weui/lib/weui.min.css">
		<link rel="stylesheet" href="weui/css/jquery-weui.css">
		<link rel="stylesheet" href="css/Gstyle.css">
		<title>登录-我的账本</title>
	</head>
	<body ontouchstart>
		<header class='login-header'>
			<h1 class="login-title">登陆</h1>
		</header>
		<form id="form1" runat="server">
		<div class="weui-cells weui-cells_form">
			<div class="weui-cell">
				<div class="weui-cell__hd"><label class="weui-label">账号</label></div>
				<div class="weui-cell__bd">
                    <asp:TextBox ID="TextName" runat="server" class="weui-input" type="text" placeholder="账号"></asp:TextBox>
				</div>
			</div>
			
			<div class="weui-cell">
				<div class="weui-cell__hd"><label class="weui-label">密码</label></div>
				<div class="weui-cell__bd">
                    <asp:TextBox ID="TextPass" runat="server" class="weui-input" type="password" placeholder="请输入密码"></asp:TextBox>
				</div>
			</div>
		</div>
		
		<div class="weui-btn-area">
            <asp:Button ID="ButtonSub" runat="server" Text="确定" class="weui-btn weui-btn_primary" OnClick="ButtonSub_Click"/>
		</div>
		</form>


		<script src="weui/lib/jquery-2.1.4.js"></script>
		<script src="weui/lib/fastclick.js"></script>
		<script>
		    $(function () {
		        FastClick.attach(document.body);
		    });

		    function aaa() {
		        $.showLoading("正在登陆");
		    }
		</script>
		<script src="weui/js/jquery-weui.js"></script>
		
	</body>
</html>


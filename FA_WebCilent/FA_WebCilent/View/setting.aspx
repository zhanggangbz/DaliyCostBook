<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setting.aspx.cs" Inherits="FA_WebCilent.View.setting" Async="true" AsyncTimeout="3000" %>

<!DOCTYPE html>

<html>
    <head runat="server">
		<meta charset="UTF-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no">
		<meta name="description" content="我的账本个人中心">
		
		<link rel="stylesheet" href="../weui/lib/weui.min.css">
		<link rel="stylesheet" href="../weui/css/jquery-weui.css">
		<link rel="stylesheet" href="../css/Gstyle.css">
		
		<title>个人中心-我的账本</title>
    </head>
	<body>

		<header class='login-header'>
            <div style="width:50px; height:50px; background-color:#9ED99D; border-radius:25px;margin: 0 auto;">
                <h1 class="login-title">
                    <span style="height:50px; line-height:50px; display:block; color:#FFF; text-align:center;">
                        <asp:Literal runat="server" ID="showname"></asp:Literal>
					</span>
                </h1>
            </div>
		</header>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
		<div class="weui-form-preview">
			<div class="weui-form-preview__hd">
				<div class="weui-form-preview__item">
					<label class="weui-form-preview__label" style="color: #EC8B89;">上周花费</label>
					<em class="weui-form-preview__value">¥<asp:Literal runat="server" ID="lastweekhf"></asp:Literal></em>
				</div>
			</div>
            <div class="weui-form-preview__hd">
				<div class="weui-form-preview__item">
					<label class="weui-form-preview__label" style="color: #10AEFF;">上周收入</label>
					<em class="weui-form-preview__value">¥<asp:Literal runat="server" ID="lastweeksr"></asp:Literal></em>
				</div>
			</div>
			
			<div class="weui-form-preview__hd">
				<div class="weui-form-preview__item">
					<label class="weui-form-preview__label" style="color: #EC8B89;">本周花费</label>
					<em class="weui-form-preview__value">¥<asp:Literal runat="server" ID="curweekhf"></asp:Literal></em>
				</div>
			</div>
            <div class="weui-form-preview__hd">
				<div class="weui-form-preview__item">
					<label class="weui-form-preview__label" style="color: #10AEFF;">本周收入</label>
					<em class="weui-form-preview__value">¥<asp:Literal runat="server" ID="curweeksr"></asp:Literal></em>
				</div>
			</div>
		</div>
		
		<div class="weui-footer weui-footer_fixed-bottom" style="margin-bottom:53px"> 
			<a href="javascript:;" class="weui-btn weui-btn_warn" style="color: #FFFFFF;">退出</a>
		</div>


        <script src="../weui/lib/jquery-2.1.4.js"></script>
        <script src="../weui/lib/fastclick.js"></script>
        <script>
			$(function() {
			    FastClick.attach(document.body);
			});

        </script>
        <script src="../weui/js/jquery-weui.js"></script>
        <script src="../js/viewindex.js"></script>

	</body>
</html>

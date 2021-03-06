﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addtype.aspx.cs" Inherits="FA_WebCilent.View.addtype"  Async="true" AsyncTimeout="3000" %>

<!DOCTYPE html>

<html>
	<head runat="server">
		<meta charset="UTF-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no">
		<meta name="description" content="我的账本增加消费类型">
		
		<link rel="stylesheet" href="../weui/lib/weui.min.css">
		<link rel="stylesheet" href="../weui/css/jquery-weui.css">
		<link rel="stylesheet" href="../css/Gstyle.css">
		
		<title>增加消费类型-我的账本</title>
	</head>
	<body>
		<h1 style="margin-left: 10px;margin-top: 10px;">增加消费类型</h1>

        <form id="form1" runat="server">

		<div class="weui-cells weui-cells_form">
			<div class="weui-cell">
				<div class="weui-cell__hd"><label class="weui-label">名称</label></div>
				<div class="weui-cell__bd">
					<input class="weui-input" type="text" placeholder="输入类型名称">
				</div>
			</div>

            <div class="weui-cell weui-cell_select weui-cell_select-after">
				<div class="weui-cell__hd">
					<label for="" class="weui-label">父类型</label>
				</div>
				<div class="weui-cell__bd">
                    <asp:DropDownList ID="DropDownList1" class="weui-select" runat="server"></asp:DropDownList>
				</div>
			</div>
		
			<div class="weui-cells_checkbox">
				<label class="weui-cell weui-check__label" for="s11">
					<div class="weui-cell__hd">
						<input type="checkbox" class="weui-check" name="checkbox1" id="s11">
						<i class="weui-icon-checked"></i>
					</div>
					<div class="weui-cell__bd">
						<p>是收入</p>
					</div>
				</label>
			</div>
			
		</div>
		
		<div class="weui-btn-area">
			<a class="weui-btn weui-btn_primary" href="javascript:" id="showTooltips">提交</a>
		</div>

		</form>

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

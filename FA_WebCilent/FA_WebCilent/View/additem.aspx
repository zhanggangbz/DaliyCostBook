<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="additem.aspx.cs" Inherits="FA_WebCilent.View.additem" Async="true" AsyncTimeout="3000"%>

<!DOCTYPE html>

<html>
    <head runat="server">
		<meta charset="UTF-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no">
		<meta name="description" content="我的账本增加消费记录">
		
		<link rel="stylesheet" href="../weui/lib/weui.min.css">
		<link rel="stylesheet" href="../weui/css/jquery-weui.css">
		<link rel="stylesheet" href="../css/Gstyle.css">
		
		<title>增加消费记录-我的账本</title>
    </head>
    <body>
        <h1 style="margin-left: 10px;margin-top: 10px;">增加消费记录</h1>

        <form id="form1" runat="server">
		
		<div class="weui-cells weui-cells_form">
			<div class="weui-cell">
				<div class="weui-cell__hd"><label class="weui-label">时间</label></div>
				<div class="weui-cell__bd">
                   <input id="costtime" runat="server" class="weui-input" type="text" readonly="readonly" value="">
				</div>
			</div>
			
			<div class="weui-cell">
				<div class="weui-cell__hd"><label class="weui-label">金额</label></div>
				<div class="weui-cell__bd">
                    <asp:TextBox ID="TextBox1" runat="server" class="weui-input" type="number" placeholder="消费金额" Text="0"></asp:TextBox>
				</div>
			</div>

			<div class="weui-cell">
				<div class="weui-cell__hd">
					<label for="" class="weui-label">类型</label>
				</div>
				<div class="weui-cell__bd">
                    <input class="weui-input" id="typevalue" type="text" value="午饭" onclick="showPicker()" readonly="readonly">
                    <input style="display:none" class="weui-input" id="typevalueid" runat="server" type="text" value="444deb215cd94e599b65e87524784735">
				</div>
			</div>

            <div style="height: 1px;border-top: 1px solid #D9D9D9;color: #D9D9D9;-webkit-transform-origin: 0 0;transform-origin: 0 0;-webkit-transform: scaleY(0.5);transform: scaleY(0.5);left: 15px;"></div>

			<div class="weui-cells__title before" style="color: #000000;font-size: 17px;display:-webkit-box;display:flex;-webkit-box-align:center;align-items:center;">备注</div>
			<div class="weui-cells weui-cells_form">
				<div class="weui-cell">
					<div class="weui-cell__bd">
                        <asp:TextBox ID="Text_Remark" runat="server" class="weui-textarea" placeholder="请输入备注信息" rows="3" TextMode="MultiLine"></asp:TextBox>
						<!--<div class="weui-textarea-counter"><span>0</span>/200</div>-->
					</div>
				</div>
			</div>
		</div>
		
		<div class="weui-btn-area">
            <asp:Button ID="Button1" runat="server" Text="提交" class="weui-btn weui-btn_primary" OnClick="Button1_Click" />
		</div>
        </form>


        		
		<script src="../weui/lib/jquery-2.1.4.js"></script>
		<script src="../weui/lib/fastclick.js"></script>
		<script>
			$(function() {
				FastClick.attach(document.body);
				var d = new Date();
				var str = d.getFullYear()+"-"+(d.getMonth()+1)+"-"+d.getDate() + " " + d.getHours() + ":" + d.getMinutes();
				$("#costtime").val(str);
			});
		</script>
		<script src="../weui/js/jquery-weui.js"></script>
		<script src="../js/viewindex.js"></script>
		<script>
		    $("#costtime").datetimePicker({
				title: '消费时间',
				min: "1990-12-12",
				max: "2100-12-12 12:12",
				onChange: function (picker, values, displayValues) {
				    console.log(values);
				}
			});
        </script>
        <script type="text/javascript" src="https://res.wx.qq.com/open/libs/weuijs/1.1.1/weui.min.js"></script>
        <script>
            function showPicker()
            {
                <asp:Literal runat="server" ID="lit_RegiterJS"></asp:Literal>   
            }
            function aaa() {
                $.showLoading("正在提交");
            }

            <asp:Literal runat="server" ID="lit_RegiterJS1"></asp:Literal>
        </script> 
    </body>
</html>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Manager.ascx.cs" Inherits="HNUE_THACSY.Manager" %>
<head>
    <title>Quản lý thạc sỹ</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <style type="text/css">
        table, th, td {
            border: 1px solid #868585;
        }

        table {
            border-collapse: collapse;
            width: 100%;
            overflow: scroll;
            border-collapse: collapse;
        }

        th, td {
            text-align: center;
            padding: 10px;
        }

        table tr:nth-child(odd) {
            background-color: #eee;
        }

        table tr:nth-child(even) {
            background-color: white;
        }

        table tr:nth-child(1) {
            background-color: deepskyblue;
            color: white;
        }

        .auto-style1 {
            width: 323px;
        }
    </style>
    <script type="text/javascript">
        function GetId() {
            return confirm("Bạn có muốn mở File đã chọn!");
        }
    </script>
</head>
<asp:Label ID="test" runat="server"></asp:Label>
<a href="<%= BuildUrl("Register") %>">
    <img src="<%= ControlPath %>Images/addnew.png" width="30px" /></a>

<br>
<nav>
    <ul>
        <li><a href="<%= BuildUrl("Register") %>" title="ADMIN">ADMIN</a></li>
    </ul>
</nav>
<table>
    <tr style="text-align: center">
        <td>Họ tên</td>
        <td>Giới tính</td>
        <td>Ngày sinh</td>
        <td>CMND</td>
        <td>Nơi sinh</td>
        <td>SĐT</td>
        <td>Email</td>
        <td>Ngành</td>
        <td>Địa chỉ</td>
        <td>Ưu tiên 1</td>
        <td>Ưu tiên 2</td>
        <td>Tổng tiền</td>
        <td>Phiếu đăng ký dự thi</td>
        <td>Đơn xin dự thi</td>
        <td>Bằng tốt nghiệp</td>
        <td>Bảng điểm</td>
        <td>Sơ yếu lý lịch</td>
        <td>Giấy sức khoẻ</td>
        <td>Avatar</td>
        <td>Giấy ưu tiên</td>
        <td>Giấy miễn ngoại ngữ</td>
        <td>Hợp đồng lao động</td>
        <td>Công văn dự thi</td>
        <td>Giấy nộp tiền</td>
        <td></td>
        <td></td>
    </tr>
    <asp:Repeater runat="server" ID="rptTuyensinh">
        <ItemTemplate>
            <tr>
                <td style="text-align: center"><%# Eval("hoten") %></td>
                <td style="text-align: center"><%# Eval("gioitinh") %></td>
                <td>
                    <%# Eval("ngaysinh","{0:dd-MM-yyyy}") %>
                </td>
                <td><%# Eval("cmnd") %></td>
                <td><%# Eval("noisinh") %></td>
                <td><%# Eval("sdt") %></td>
                <td><%# Eval("email") %></td>
                <td><%# Eval("nganh") %></td>
                <td><%# Eval("diachilienhe") %></td>
                <td><%# Eval("mienthingoaingu") %></td>
                <td><%# Eval("doituonguutien") %></td>
                <td><%# Eval("tongtien") %></td>
                <td>
                    <asp:LinkButton ID="data1" runat="server" CommandName="data1" CommandArgument='<%# Bind("Id") %>' OnClick="openfile"  Text='<%# Eval("phieudangkyduthi") %>' OnClientClick="return GetId()" /></td>
                <td><%# Eval("donxinduthi") %></td>
                <td><%# Eval("bangtotnghiep") %></td>
                <td><%# Eval("bangdiemdaihoc") %></td>
                <td><%# Eval("soyeulilich") %></td>
                <td><%# Eval("giaysuckhoe") %></td>
                <td><%# Eval("avatar") %></td>
                <td><%# Eval("giayuutien") %></td>
                <td><%# Eval("giaymienthingoaingu") %></td>
                <td><%# Eval("hopdonglaodong") %></td>
                <td><%# Eval("congvanduthi") %></td>
                <td><%# Eval("giaynoptien") %></td>
                <td><a href="<%# BuildUrl("Register","Id="+ Eval("Id")) %>">
                    <img src="<%= ControlPath %>Images/edit.png" width="20px" /></a>
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="btnDel" OnClick="Del" CommandArgument='<%# Bind("Id") %>' OnClientClick="return confirm('Bạn có chắc muốn xóa?')"><img src="<%= ControlPath %>Images/Del.png" width="20px"/></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>

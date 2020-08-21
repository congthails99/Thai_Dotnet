<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="HNUE_THACSY.Register" %>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <title>ĐĂNG KÝ TUYỂN SINH ĐẠI HỌC 2020 - TRƯỜNG ĐẠI HỌC SƯ PHẠM HÀ NỘI Trường Đại học Sư phạm Hà Nội</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.0/css/bootstrap-grid.min.css">
    <script src="https://www.google.com/recaptcha/api.js?render=6Lf6q74ZAAAAAKkVkPGP3hbqP3KiUYfC7SzrUcVu"></script>
    <style>
        #table1 {
            border: 2px dashed #c2c1c1;
        }
    </style>
</head>
<nav>
    <ul>
        <li><a href="<%= BuildUrl("Manager") %>" title="ADMIN">ADMIN</a></li>
    </ul>
</nav>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
    </ContentTemplate>
</asp:UpdatePanel>
<form id="formData" method="post" role="form" novalidate="novalidate">

    <div class="container hnue_form">
        <div class="text-center">
            <div class="g-recaptcha" data-sitekey="6Lf6q74ZAAAAALmDM5qMSaKeTSd38_9bGv6Fnz_z"></div>
            <h4>TRƯỜNG ĐẠI HỌC SƯ PHẠM HÀ NỘI</h4>
            <h5>NỘP HỒ SƠ ĐĂNG KÝ TUYỂN SINH THẠC SỸ QUA MẠNG</h5>
        </div>
        <div class="row" id="table1">
            <div class="col-12">
                <hr>
            </div>
            <div class="col-3 form-group">
                <label class="lbl-item">Họ và tên (∗)</label>
                <asp:TextBox class="form-control" ID="tbHoten" runat="server" name="hoten" type="text" value=""></asp:TextBox>
            </div>
            <div class="col-3 form-group">
                <label class="lbl-item">Số chứng minh thư/thẻ căn cước (∗)</label>
                <asp:TextBox class="form-control" ID="tbCmnd" runat="server" name="cmnd" type="text" required="" value=""></asp:TextBox>
            </div>
            <div class="col-3 form-group">
                <label class="lbl-item">Giới tính (∗)</label>
                <asp:DropDownList ID="drpGioiTinh" name="GioiTinh" runat="server" class="form-control">
                    <asp:ListItem>Nam</asp:ListItem>
                    <asp:ListItem>Nữ</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-3 form-group">
                <label class="lbl-item">Mã hồ sơ</label>
                <asp:TextBox runat="server" ReadOnly="true" class="form-control" ID="tbMahoso" name="Mahoso" type="text" value=""></asp:TextBox>
            </div>
            <div class="col-3 form-group">
                <label class="lbl-item">Ngày sinh (∗)</label>
                <asp:TextBox class="form-control datepicker" ID="Ngaysinh" name="NgaySinh" type="text" placeholder="__/__/____" value="" runat="server"></asp:TextBox>
            </div>
            <div class="col-3 form-group">
                <label class="lbl-item">Nơi sinh (∗)</label>
                <asp:DropDownList CssClass="form-control" ID="drpNoisinh1" runat="server" DataValueField="tentinh" DataTextField="tentinh"></asp:DropDownList>
            </div>
            <div class="col-3 form-group">
                <label class="lbl-item">Điện thoại (∗)</label>
                <asp:TextBox class="form-control" ID="tbSdt" name="sdt" type="text" value="" runat="server"></asp:TextBox>
            </div>
            <div class="col-3 form-group">
                <label class="lbl-item">Email (∗)</label>
                <asp:TextBox class="form-control" ID="tbEmail" name="Email" type="text" value="" runat="server"></asp:TextBox>
            </div>
            <div class="col-6">
                <label>Ngành (∗)</label>
                <asp:DropDownList ID="drpNganh" runat="server" CssClass="form-control" DataValueField="tennganh" DataTextField="tennganh"></asp:DropDownList>

            </div>
            <div class="col-6 form-group">
                <label class="lbl-item">Địa chỉ liên hệ (∗)</label>
                <asp:TextBox class="form-control" ID="tbDiachi" name="Diachi" type="text" value="" runat="server"></asp:TextBox>
            </div>
            <div class="col-3 form-group">
                Đối tượng miễn thi ngoại ngữ
                <asp:CheckBox ID="uutien1" runat="server" />
            </div>
            <div class="col-3 form-group">
                Đối tượng ưu tiên
                <asp:CheckBox ID="uutien2" runat="server" />
            </div>
            <div class="col-12 form-group">
                <label>Lệ phí</label>
            </div>
            <div class="col-3 form-group">
                <asp:CheckBox Checked="true" ID="lephithi" runat="server" />
                Xử lý hồ sơ lệ phí thi:460.000đ
            </div>
            <div class="col-9 form-group">
                <asp:CheckBox ID="ontap" runat="server" />
                Ôn tập môn cơ bản + Môn cơ sở:2.000.000đ
            </div>
            <div class="col-3 form-group">
                <asp:CheckBox ID="monngoaingu" runat="server" />
                Môn ngoại ngữ:1.000.000đ
            </div>
            <div class="col-9 form-group">
                Tổng tiền:
                <asp:Label ID="lbTongtien" runat="server"></asp:Label>
            </div>
            <div class="col-12">
                <hr>
            </div>
            <div class="col-12 form-group">
                (Phòng Sau đại học sẽ liên hệ với thí sinh thuộc diện phải học bổ sung kiến thức sau khi xử lý hồ sơ. Kinh phí 300.000đ/tín chỉ)
            </div>
            <div class="col-12 form-group">
                <asp:Label ForeColor="red" ID="Tb_Loi" runat="server"></asp:Label>
            </div>
            <div class="col-3 form-group">
                <asp:Button runat="server" ID="bt_Layma" Text="Lấy mã hồ sơ" class="btn btn-primary" OnClick="laymahoso_Click" /> &ensp;
                <asp:Button ID="bt_Update" Visible="false" class="btn btn-primary" runat="server" OnClick="Update_Click" Text="Cập nhật" /> &ensp;
                <asp:Button ID="bt_Search" runat="server" class="btn btn-primary" OnClick="Search_Click" Text="Tìm kiếm" />
            </div>
            <div class="col-6 form-group">
                
            </div>
            <br />
            <div class="col-9" id="content" style="opacity: 1">
                <div class="col-12">
                    <label>DANH MỤC HỒ SƠ DỰ THI CẦN NỘP</label><br />
                    (Ghi chú: Thi sinh chuyển định dạng file hồ sơ thành pdf và upload theo thứ tự sau)<br />
                    (Thí sinh có thể sử dụng công cụ https://tools.pdf24.org/en/ để chuyển định dạng file pdf<br />
                    <br />
                </div>
                <div class="col-12">
                    <label>1. Phiếu đăng ký dự thi (theo mẫu)</label>
                </div>
                <div class="col-12">
                    <asp:FileUpload ID="file_phieudangkyduthi" runat="server" />
                </div>
                <hr />
                <div class="col-12">
                    <label>2. Đơn xin dự thi (theo mẫu)</label>
                </div>
                <div class="col-12">
                    <asp:FileUpload ID="file_donxinduthi" runat="server" />
                </div>
                <hr />
                <div class="col-12">
                    <label>3. Bản sao có công chứng: Bằng tốt nghiệp đại học.</label><br />
                </div>
                <div class="col-12">
                    <asp:FileUpload ID="file_bangtotnghiep" runat="server" />
                </div>
                <hr />
                <div class="col-12">
                    <label>4. Bản sao có công chứng: Bảng điểm đại học.</label><br />
                </div>
                <div class="col-12">
                    <asp:FileUpload ID="file_bangdiemdaihoc" runat="server" />
                </div>
                <hr />
                <div class="col-12">
                    <label>5. Sơ yếu lý lịch có xác nhận của thủ trưởng cơ quan hoặc chính quyền địa phương nơi cư trú (theo mẫu).</label><br />
                </div>
                <div class="col-12">
                    <asp:FileUpload ID="file_soyeulilich" runat="server" />
                </div>
                <hr />
                <div class="col-12">
                    <label>6. Giấy chứng nhận đủ sức khoẻ để học tập của một bệnh viện đa khoa.</label><br />
                </div>
                <div class="col-12">
                    <asp:FileUpload ID="file_giaysuckhoe" runat="server" />
                </div>
                <hr />
                <div class="col-12">
                    <label>7. Ảnh 4x6 (chất lượng cao, định dạng *.pdf, *.jpg, *.png)</label><br />
                </div>
                <div class="col-12">
                    <asp:FileUpload ID="file_avatar" runat="server" />
                </div>
                <hr />
                <div class="col-12">
                    <label>8. Bản sao có công chứng giấy tờ hợp pháp về đối tượng ưu tiên (nếu có)</label><br />
                </div>
                <div class="col-12">
                    <asp:FileUpload ID="file_giayuutien" runat="server" />
                </div>
                <hr />
                <div class="col-12">
                    <label>9. Bản sao có công chứng văn bằng, chứng chỉ để miễn ngoại ngữ (nếu có).</label><br />
                </div>
                <div class="col-12">
                    <asp:FileUpload ID="file_giaymienthingoaingu" runat="server" />
                </div>
                <hr />
                <div class="col-12">
                    <label>10. Bản sao có công chứng các quyết định tuyển dụng, hợp đồng lao động, quyết định bổ nhiệm (nếu có).</label><br />
                </div>
                <div class="col-12">
                    <asp:FileUpload ID="file_hopdonglaodong" runat="server" />
                </div>
                <hr />
                <div class="col-12">
                    <label>11. Công văn cử đi dự thi của thủ trưởng cơ quan (nếu có).</label><br />
                </div>
                <div class="col-12">
                    <asp:FileUpload ID="file_congvanduthi" runat="server" />
                </div>
                <hr />
                <div class="col-12">
                    <label>12. Minh chứng nộp tiền lệ phí (nếu có).</label>
                </div>
                <div class="col-12">
                    <asp:FileUpload ID="file_giaynoptien" runat="server" />
                </div>

                <div class="col-12">
                    <hr>
                </div>
                <div class="text-center">
                    <br>
                    <asp:Button type="submit" runat="server" class="btn btn-primary" Text="Nộp hồ sơ" OnClick="dk_Click" />
                </div>
                <div class="text-center">
                    <asp:Label runat="server" ID="lbTb" ForeColor="Red"></asp:Label>
                </div>
                <div class="col-12">
                    <hr>
                </div>
            </div>
            <div class="col-12">
                <label>Ghi chú:</label><br />
                - Thí sinh nhập đầy đủ thông tin trên form đăng ký.<br />
                - Sau khi lấy mã hồ sơ, thí sinh hộp bản scan theo danh mục và chịu trách nhiệm với các thông tin đã nộp.<br />
                - Trường Đại học Sư phạm sẽ hậu kiểm sau khi thí sinh nhập học và thu hồ sơ gốc.<br />
                - Các thí sinh dự thi chuyên ngành Quản lý giáo dục hoặc được cơ quan cử đi học cần chuẩn bị các giấy tờ mục 10 và 11.<br />
                - Các thí sinh được ưu tiên theo khu vực (đang công tác 2 năm liên tục) phải có quyết định tiếp nhận công tác của cấp có thẩm
                quyền (bản sao); Thí sinh là người dân tộc thiểu số: nộp giấy khai sinh (bản sao).<br />
                <br />
                <label>Hình thức nộp:&ensp;</label>Thí sinh nộp tiền qua tài khoản ngân hàng<br />
                Tên tài khoản: Trường Đại học Sư phạm Hà Nội<br />
                Số tài khoản: 1507311001008<br />
                Tại Ngân hàng: Agribank Chi nhánh Cầu Giấy, Hà Nội<br />
                Nội dung: Mã hồ sơ - Họ và tên – K30 - Số điện thoại
            </div>

        </div>
    </div>
</form>

<body>
    <script>

        document.getElementById("btn1").onclick = function () {
            document.getElementById("content").style.opacity = 1;
        };

        document.getElementById("btn2").onclick = function () {
            document.getElementById("content").style.display = 'block';
        };

    </script>
</body>

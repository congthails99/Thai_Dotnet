using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;
using Hnue.Helper;
using HNUE_THACSY.DataAccess;

namespace HNUE_THACSY
{
    public partial class Register : BaseController
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var userId = Request.QueryString["id"].ToInt();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == userId) ?? new Tuyensinh();
            var nganh = new ThacSyDataContext().Nganhs;
            drpNganh.DataSource = nganh.Select(i => new { i.tennganh }).OrderBy(i => i.tennganh).ToList();
            drpNganh.DataBind();
            var tinh = new ThacSyDataContext().Tinhs;
            drpNoisinh1.DataSource = tinh.Select(i => new { i.tentinh }).OrderBy(i => i.tentinh).ToList();
            drpNoisinh1.DataBind();
            if (IsPostBack || Request.QueryString["id"] == null) return;
            tbHoten.Text = c.hoten;
            drpGioiTinh.Text = c.gioitinh;
            Ngaysinh.Text = c.ngaysinh.ParseDateTime("dd-MM-yyyy");
            tbCmnd.Text = c.cmnd;
            drpNoisinh1.Text = c.noisinh;
            tbSdt.Text = c.sdt;
            tbEmail.Text = c.email;
            drpNganh.Text = c.nganh;
            tbDiachi.Text = c.diachilienhe;
            tbMahoso.Text = c.Id.ToString();
            lbTongtien.Text = c.tongtien.ToString();
            if (c.mienthingoaingu == null)
            {
                uutien1.Checked = false;
            }
            if (c.mienthingoaingu != null)
            {
                uutien1.Checked = true;
            }
            if (c.doituonguutien == null)
            {
                uutien2.Checked = false;
            }
            if (c.doituonguutien != null)
            {
                uutien2.Checked = true;
            }
        }
        protected void laymahoso_Click(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var userId = Request.QueryString["id"].ToInt();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == userId) ?? new Tuyensinh();
            var d = datacontext.Tuyensinhs.Where(i => i.cmnd == tbCmnd.Text).Count();
            c.hoten = tbHoten.Text.Trim();
            c.gioitinh = drpGioiTinh.Text.Trim();
            c.ngaysinh = Ngaysinh.Text.ToDateTime("dd-MM-yyyy");
            c.cmnd = tbCmnd.Text;
            c.noisinh = drpNoisinh1.SelectedValue;
            c.sdt = tbSdt.Text;
            c.email = tbEmail.Text;
            c.nganh = drpNganh.SelectedValue;
            c.diachilienhe = tbDiachi.Text;
            if (uutien1.Checked)
            {
                c.mienthingoaingu = uutien1.Text + "Miễn thi ngoại ngữ";
            }
            if (uutien2.Checked)
            {
                c.doituonguutien = uutien2.Text + "Đối tượng ưu tiên";
            }
            if (lephithi.Checked)
            {
                c.tongtien = lbTongtien.ToDouble() + 460000;
                lbTongtien.Text = "460.000đ";
            }
            if (lephithi.Checked && ontap.Checked)
            {
                c.tongtien = lbTongtien.ToDouble() + 2460000;
                lbTongtien.Text = "2.460.000đ";
            }
            if (lephithi.Checked && ontap.Checked && monngoaingu.Checked)
            {
                c.tongtien = lbTongtien.ToDouble() + 3460000;
                lbTongtien.Text = "3.460.000đ";
            }
            if (lephithi.Checked && monngoaingu.Checked)
            {
                c.tongtien = lbTongtien.ToDouble() + 1460000;
                lbTongtien.Text = "1.460.000đ";
            }
            if (d != 0)
            {
                Tb_Loi.Text = "Chứng minh nhân dân hoặc căn cước công dân đã tồn tại, mời nhập lại";
            }
            if (c.Id == 0 && d == 0)
            {
                datacontext.Tuyensinhs.InsertOnSubmit(c);
                datacontext.SubmitChanges();
            }
            if (c.Id > 0 && d == 0)
            {
                tbHoten.Text = c.hoten;
                drpGioiTinh.Text = c.gioitinh;
                c.ngaysinh = Ngaysinh.Text.ToDateTime("dd-MM-yyyy");
                tbCmnd.Text = c.cmnd;
                drpNoisinh1.SelectedValue = c.noisinh;
                tbSdt.Text = c.sdt;
                tbEmail.Text = c.email;
                drpNganh.SelectedValue = c.nganh;
                tbDiachi.Text = c.diachilienhe;
                tbMahoso.Text = c.Id.ToString();
                lbTongtien.Text = c.tongtien.ToString();
                datacontext.SubmitChanges();
            }
            bt_Layma.Visible = false;
            bt_Update.Visible = true;

            if (d == 0)
            {
                string text = "Chào mừng thí sinh " +"<b>"+ tbHoten.Text +"</b>"+ " đã nộp hồ sơ đăng ký tuyển sinh trình độ thạc sỹ của Trường Đại học Sư phạm Hà Nội " +"<br/>"
                    + "Mã hồ sơ của ban là: "+"<b>"+tbMahoso.Text+"</b>"+"<br/>"
                    + "Dự tuyển vào ngành: "+"<b>"+drpNganh.Text+"</b>"+"<br/>"
                    + "Nếu thi sinh chưa nộp lệ phí, vui lòng nộp lệ phí theo hướng dẫn sau để được xử lý hồ sơ: "+"<br/>"+"<br/>"
                    + "<b>"+"Hình thức nộp:"+"</b>"+" Thí sinh nộp tiền qua tài khoản ngân hàng"+"<br/>"
                    + "Tên tài khoản: Trường Đại học Sư phạm Hà Nội"+"<br/>"
                    + "Số tài khoản: 1507311001008"+"<br/>"
                    + "Tại Ngân hàng: Agribank Chi nhánh Cầu Giấy, Hà Nội"+"<br/>"
                    + "Nội dung: Mã hồ sơ - Họ và tên – K30 - Số điện thoại";
                MailMessage mail = new MailMessage("truongcongthai199@gmail.com", tbEmail.Text, "Xác nhận nộp hồ sơ đăng ký online dự tuyển thạc sỹ vào Trường ĐHSP Hà Nội",
                    text); //
                mail.IsBodyHtml = true;
                //gửi tin nhắn
                SmtpClient smtp = new SmtpClient()
                {
                    //Máy chủ smtp
                    Host = "smtp.gmail.com",
                    //Cổng gửi thư
                    Port = 587,
                    //Tài khoản Gmail
                    Credentials = new NetworkCredential("truongcongthai199@gmail.com", "Thailinh99"),
                    EnableSsl = true
                };

                #region Gửi thư
                smtp.Send(mail);
                #endregion*/
            }
        }
        
        protected void Search_Click(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var userId = Request.QueryString["id"].ToInt();
            var a = tbCmnd.Text;
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.cmnd == a) ?? new Tuyensinh();
            tbHoten.Text = c.hoten;
            drpGioiTinh.Text = c.gioitinh;
            Ngaysinh.Text = c.ngaysinh.ParseDateTime("dd-MM-yyyy");
            tbCmnd.Text = c.cmnd;
            drpNoisinh1.Text = c.noisinh;
            tbSdt.Text = c.sdt;
            tbEmail.Text = c.email;
            drpNganh.Text = c.nganh;
            tbDiachi.Text = c.diachilienhe;
            tbMahoso.Text = c.Id.ToString();
            lbTongtien.Text = c.tongtien.ToString();
            bt_Layma.Visible = false;
            bt_Update.Visible = true;
            Tb_Loi.Text="";
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            ThacSyDataContext db = new ThacSyDataContext();
            var d = db.Tuyensinhs.Where(i => i.cmnd == tbCmnd.Text).Count();
            Tuyensinh c = db.Tuyensinhs.Single(i => i.Id.ToString()==tbMahoso.Text);
            c.hoten = tbHoten.Text.Trim();
            c.gioitinh = drpGioiTinh.Text.Trim();
            c.ngaysinh = Ngaysinh.Text.ToDateTime("dd-MM-yyyy");
            c.cmnd = tbCmnd.Text;
            c.noisinh = drpNoisinh1.SelectedValue;
            c.sdt = tbSdt.Text;
            c.email = tbEmail.Text;
            c.nganh = drpNganh.SelectedValue;
            c.diachilienhe = tbDiachi.Text;
            if (uutien1.Checked)
            {
                c.mienthingoaingu = uutien1.Text + "Miễn thi ngoại ngữ";
            }
            if (uutien2.Checked)
            {
                c.doituonguutien = uutien2.Text + "Đối tượng ưu tiên";
            }
            if (lephithi.Checked)
            {
                c.tongtien = lbTongtien.ToDouble() + 460000;
                lbTongtien.Text = "460.000đ";
            }
            if (lephithi.Checked && ontap.Checked)
            {
                c.tongtien = lbTongtien.ToDouble() + 2460000;
                lbTongtien.Text = "2.460.000đ";
            }
            if (lephithi.Checked && ontap.Checked && monngoaingu.Checked)
            {
                c.tongtien = lbTongtien.ToDouble() + 3460000;
                lbTongtien.Text = "3.460.000đ";
            }
            if (lephithi.Checked && monngoaingu.Checked)
            {
                c.tongtien = lbTongtien.ToDouble() + 1460000;
                lbTongtien.Text = "1.460.000đ";
            }
            if (c.Id == 0 )
            {
                db.Tuyensinhs.InsertOnSubmit(c);
                db.SubmitChanges();
            }
            if (c.Id > 0 && d!=0 )
            {
                tbHoten.Text = c.hoten;
                drpGioiTinh.Text = c.gioitinh;
                c.ngaysinh = Ngaysinh.Text.ToDateTime("dd-MM-yyyy");
                tbCmnd.Text = c.cmnd;
                drpNoisinh1.SelectedValue = c.noisinh;
                tbSdt.Text = c.sdt;
                tbEmail.Text = c.email;
                drpNganh.SelectedValue = c.nganh;
                tbDiachi.Text = c.diachilienhe;
                tbMahoso.Text = c.Id.ToString();
                lbTongtien.Text = c.tongtien.ToString();
                db.SubmitChanges();
                Tb_Loi.Text = "Bạn đã cập nhật thành công!";
            }
            if (d == 0)
            {
                Tb_Loi.Text = "Chứng minh nhân dân/Căn cước công dân chưa được đăng ký";
            }
        }
        protected void dk_Click(object sender, EventArgs e)
        {
            ThacSyDataContext db = new ThacSyDataContext();
            var d = db.Tuyensinhs.Where(i => i.cmnd == tbCmnd.Text).Count();
            if (d == 0)
            {
                Tb_Loi.Text = "Chứng minh nhân dân/Căn cước công dân chưa được đăng ký";
            }
            Tuyensinh c = db.Tuyensinhs.Single(i => i.Id.ToString() == tbMahoso.Text);
            if (file_phieudangkyduthi.HasFile && file_donxinduthi.HasFile && file_bangtotnghiep.HasFile && file_bangdiemdaihoc.HasFile && file_soyeulilich.HasFile && file_giaysuckhoe.HasFile && file_avatar.HasFile)
            {
                string extension = Path.GetExtension(file_phieudangkyduthi.FileName);
                string donxinduthi = Path.GetExtension(file_donxinduthi.FileName);
                string bangtotnghiep = Path.GetExtension(file_bangtotnghiep.FileName);
                string bangdiem = Path.GetExtension(file_bangdiemdaihoc.FileName);
                string soyeulilich = Path.GetExtension(file_soyeulilich.FileName);
                string giaysuckhoe = Path.GetExtension(file_giaysuckhoe.FileName);
                string avatar = Path.GetExtension(file_avatar.FileName);
                string giayuutien = Path.GetExtension(file_giayuutien.FileName);
                string giaymienthingoaingu = Path.GetExtension(file_giaymienthingoaingu.FileName);
                string hopdonglaodong = Path.GetExtension(file_hopdonglaodong.FileName);
                string congvanduthi = Path.GetExtension(file_congvanduthi.FileName);
                string giaynoptien = Path.GetExtension(file_giaynoptien.FileName);
                if (extension == ".pdf" && donxinduthi == ".pdf" && bangtotnghiep==".pdf" && bangdiem==".pdf" && soyeulilich==".pdf" && giaysuckhoe==".pdf")
                {
                    string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\" + c.cmnd);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file_phieudangkyduthi.SaveAs(path + "\\" + c.cmnd.Trim() + "_" + file_phieudangkyduthi.FileName);
                    file_donxinduthi.SaveAs(path + "\\" + c.cmnd.Trim() + "_" + file_donxinduthi.FileName);
                    file_bangtotnghiep.SaveAs(path + "\\" + c.cmnd.Trim() + "_" + file_bangtotnghiep.FileName);
                    file_bangdiemdaihoc.SaveAs(path + "\\" + c.cmnd.Trim() + "_" + file_bangdiemdaihoc.FileName);
                    file_soyeulilich.SaveAs(path + "\\" + c.cmnd.Trim() + "_" + file_soyeulilich.FileName);
                    file_giaysuckhoe.SaveAs(path + "\\" + c.cmnd.Trim() + "_" + file_giaysuckhoe.FileName);
                    file_avatar.SaveAs(path + "\\" + c.cmnd.Trim() + "_" + file_avatar.FileName);
                    c.phieudangkyduthi = c.cmnd.Trim() + "_" + file_phieudangkyduthi.FileName;
                    c.donxinduthi = c.cmnd.Trim() + "_" + file_donxinduthi.FileName;
                    c.bangtotnghiep = c.cmnd.Trim() + "_" + file_bangtotnghiep.FileName;
                    c.bangdiemdaihoc = c.cmnd.Trim() + "_" + file_bangdiemdaihoc.FileName;
                    c.soyeulilich = c.cmnd.Trim() + "_" + file_soyeulilich.FileName;
                    c.giaysuckhoe = c.cmnd.Trim() + "_" + file_giaysuckhoe.FileName;
                    c.avatar = c.cmnd.Trim() + "_" + file_avatar.FileName;
                    if (giayuutien == ".pdf")
                    {
                        file_giayuutien.SaveAs(path + "\\" + c.cmnd.Trim() + "_" + file_giayuutien.FileName);
                        c.giayuutien = c.cmnd.Trim() + "_" + file_giayuutien.FileName;
                    }
                    if (giaymienthingoaingu == ".pdf")
                    {
                        file_giaymienthingoaingu.SaveAs(path + "\\" + c.cmnd.Trim() + "_" + file_giaymienthingoaingu.FileName);
                        c.giaymienthingoaingu = c.cmnd.Trim() + "_" + file_giaymienthingoaingu.FileName;
                    }
                    if (hopdonglaodong == ".pdf")
                    {
                        file_hopdonglaodong.SaveAs(path + "\\" + c.cmnd.Trim() + "_" + file_hopdonglaodong.FileName);
                        c.hopdonglaodong = c.cmnd.Trim() + "_" + file_hopdonglaodong.FileName;
                    }
                    if (congvanduthi == ".pdf")
                    {
                        file_congvanduthi.SaveAs(path + "\\" + c.cmnd.Trim() + "_" + file_congvanduthi.FileName);
                        c.congvanduthi = c.cmnd.Trim() + "_" + file_congvanduthi.FileName;
                    }
                    if (giaynoptien == ".pdf")
                    {
                        file_giaynoptien.SaveAs(path + "\\" + c.cmnd.Trim() + "_" + file_giaynoptien.FileName);
                        c.giaynoptien = c.cmnd.Trim() + "_" + file_giaynoptien.FileName;
                    }
                }
                else if (extension != ".pdf" || donxinduthi != ".pdf" || bangtotnghiep != ".pdf" || bangdiem != ".pdf" || soyeulilich != ".pdf" || giaysuckhoe != ".pdf")
                {
                    lbTb.Text = "File không đúng định dạng PDF";
                }
            }
            else if (!file_phieudangkyduthi.HasFile || !file_donxinduthi.HasFile || !file_bangtotnghiep.HasFile || !file_bangdiemdaihoc.HasFile || !file_soyeulilich.HasFile || !file_giaysuckhoe.HasFile || !file_avatar.HasFile)
            {
                lbTb.Text = "Chưa điền đủ thông tin bắt buộc";
            }
            if (c.Id > 0 && d != 0)
            {
                db.SubmitChanges();
            }

        }
    }
}
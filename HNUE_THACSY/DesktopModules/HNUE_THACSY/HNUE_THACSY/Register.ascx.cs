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
            //c.ngaysinh = DateTime.Parse(Ngaysinh.Text);
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
                //  Response.Redirect(BuildUrl("Register"));
            }
            bt_Layma.Visible = false;
            bt_Update.Visible = true;

            if (d == 0)
            {
                MailMessage mail = new MailMessage("truongcongthai199@gmail.com", tbEmail.Text, "HNUE - Thông tin bạn đã đăng ký thạc sỹ", "Họ tên: " + tbHoten.Text + Ngaysinh.Text + "Nơi sinh: " + tbDiachi.Text); //
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
        protected void Email_click(object sender, EventArgs e)
        {

        }
        protected void dk_Click(object sender, EventArgs e)
        {
            ThacSyDataContext db = new ThacSyDataContext();
            var d = db.Tuyensinhs.Where(i => i.cmnd == tbCmnd.Text).Count();
            Tuyensinh c = db.Tuyensinhs.Single(i => i.Id.ToString() == tbMahoso.Text);
            if (file_phieudangkyduthi.HasFile)
            {
                /*string ex = Path.GetExtension(file_phieudangkyduthi.FileName);
                if (ex == ".pdf")
                {
                    filename = Path.GetFileName(file_phieudangkyduthi.FileName);
                    file_phieudangkyduthi.SaveAs(Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\"+c.cmnd) + filename);
                    c.phieudangkyduthi = c.cmnd+filename;
                }*/
                string extension = Path.GetExtension(file_phieudangkyduthi.FileName);
                if (extension == ".pdf")
                {
                    string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\"+c.cmnd);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file_phieudangkyduthi.SaveAs(path+"\\"+c.cmnd.Trim()+"_"+ file_phieudangkyduthi.FileName);
                    c.phieudangkyduthi = c.cmnd.Trim() + "_" + file_phieudangkyduthi.FileName;
                    lbTb.Text = path;
                    //Response.Redirect(BuildUrl("Success"));                 
                }
                if (extension != ".pdf")
                {
                    lbTb.Text = "File không đúng định dạng";
                }
            }
            if (c.Id == 0)
            {
                db.Tuyensinhs.InsertOnSubmit(c);
                db.SubmitChanges();
            }
            if (c.Id > 0 && d != 0)
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
            }
            if (d == 0)
            {
                Tb_Loi.Text = "Chứng minh nhân dân/Căn cước công dân chưa được đăng ký";
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
    }
}
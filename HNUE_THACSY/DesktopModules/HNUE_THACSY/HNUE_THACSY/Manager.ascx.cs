using System;
using System.Linq;
using System.Net;
using System.Web.UI.WebControls;
using Hnue.Helper;
using HNUE_THACSY.DataAccess;

namespace HNUE_THACSY
{
    public partial class Manager : BaseController
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new ThacSyDataContext();
            if (db.Tuyensinhs.Count() > 0)
            {
                rptTuyensinh.DataSource = db.Tuyensinhs.OrderBy(i => i.Id).ToList();
                rptTuyensinh.DataBind();
            }
            else
            {
                test.Text = "Không có bản ghi nào";
            }
        }
        protected void Del(object sender, EventArgs e)
        {
            var db = new ThacSyDataContext();
            db.Tuyensinhs.DeleteOnSubmit(db.Tuyensinhs.First(i => i.Id == ((LinkButton)sender).CommandArgument.ToInt()));
            db.SubmitChanges();
            Response.Redirect(Request.RawUrl);
        }
        protected void openfile(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == ((LinkButton)sender).CommandArgument.ToInt());
            string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\" + c.cmnd);
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path+"\\"+c.phieudangkyduthi);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
        protected void openfile_Donxinduthi(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == ((LinkButton)sender).CommandArgument.ToInt());
            string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\" + c.cmnd);
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path + "\\" + c.donxinduthi);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
        protected void openfile_Bangtotnghiep(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == ((LinkButton)sender).CommandArgument.ToInt());
            string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\" + c.cmnd);
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path + "\\" + c.bangtotnghiep);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
        protected void openfile_Bangdiem(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == ((LinkButton)sender).CommandArgument.ToInt());
            string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\" + c.cmnd);
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path + "\\" + c.bangdiemdaihoc);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
        protected void openfile_Soyeulilich(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == ((LinkButton)sender).CommandArgument.ToInt());
            string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\" + c.cmnd);
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path + "\\" + c.soyeulilich);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
        protected void openfile_Giaysuckhoe(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == ((LinkButton)sender).CommandArgument.ToInt());
            string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\" + c.cmnd);
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path + "\\" + c.giaysuckhoe);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
        protected void openfile_Avavar(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == ((LinkButton)sender).CommandArgument.ToInt());
            string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\" + c.cmnd);
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path + "\\" + c.avatar);
            if (buffer != null)
            {
                Response.ContentType = "application/png";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
        protected void openfile_Giayuutien(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == ((LinkButton)sender).CommandArgument.ToInt());
            string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\" + c.cmnd);
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path + "\\" + c.giayuutien);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
        protected void openfile_Giaymienngoaingu(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == ((LinkButton)sender).CommandArgument.ToInt());
            string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\" + c.cmnd);
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path + "\\" + c.giaymienthingoaingu);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
        protected void openfile_Hopdonglaodong(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == ((LinkButton)sender).CommandArgument.ToInt());
            string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\" + c.cmnd);
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path + "\\" + c.hopdonglaodong);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
        protected void openfile_Congvanduthi(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == ((LinkButton)sender).CommandArgument.ToInt());
            string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\" + c.cmnd);
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path + "\\" + c.congvanduthi);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
        protected void openfile_Giaynoptien(object sender, EventArgs e)
        {
            var datacontext = new ThacSyDataContext();
            var c = datacontext.Tuyensinhs.FirstOrDefault(i => i.Id == ((LinkButton)sender).CommandArgument.ToInt());
            string path = Server.MapPath("DesktopModules\\HNUE_THACSY\\HNUE_THACSY\\fileUpload\\" + c.cmnd);
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path + "\\" + c.giaynoptien);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
    }
}
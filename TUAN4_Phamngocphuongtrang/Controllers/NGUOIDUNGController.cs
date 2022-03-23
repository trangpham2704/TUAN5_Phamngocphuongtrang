using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TUAN4_Phamngocphuongtrang.Models;
namespace TUAN4_Phamngocphuongtrang.Controllers
{
    public class NGUOIDUNGController : Controller
    {
        // GET: NGUOIDUNG
        myDataDataContext data = new myDataDataContext();
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dangky(FormCollection collection, KhachHang Kh)
        {
            var hoten = collection["hoten"];
            var tendangnhap = collection["tendangnhap"];
            var matkhau = collection["matkhau"];
            var MatKhauXacNhan = collection["MatKhauXacNhan"];
            var email = collection["email"];
            var diachi = collection["diachi"];
            var dienthoai = collection["dienthoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["ngaysinh"]);
            if (String.IsNullOrEmpty(MatKhauXacNhan))
            {
                ViewData["NhapMKXN"] = "Phai nhap mk xac nhan!";
            }
            else
            {
                if (!matkhau.Equals(MatKhauXacNhan))
                {
                    ViewData["MatKhauGiongNhau"] = "Mat khau va mat khau xac nhan phai giong nhau";

                }
                else
                {
                    Kh.hoten = hoten;
                    Kh.tendangnhap = tendangnhap;
                    Kh.matkhau = matkhau;
                    Kh.email = email;
                    Kh.diachi = diachi;
                    Kh.dienthoai = dienthoai;
                    Kh.ngaysinh = DateTime.Parse(ngaysinh);
                    data.KhachHangs.InsertOnSubmit(Kh);
                    data.SubmitChanges();
                    return RedirectToAction("DangNhap");
                }
            }
            return this.Dangky();

        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
    
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendangnhap = collection["tendangnhap"];
            var matkhau = collection["matkhau"];
            KhachHang kh = data.KhachHangs.SingleOrDefault(n => n.tendangnhap == tendangnhap && n.matkhau == matkhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "chuc mung dang nhap thanh cong";
                Session["TaiKhoan"] = kh;
            }
            else
            {
                ViewBag.ThongBao = " dang nhap ko thanh cong";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
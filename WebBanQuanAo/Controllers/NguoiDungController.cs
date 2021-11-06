using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        BanQuanAoEntities2 db = new BanQuanAoEntities2();
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            if (String.IsNullOrEmpty(tendn))
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            else if(String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                KhachHang kh = db.KhachHangs.SingleOrDefault(n=>n.TaiKhoan==tendn && n.MatKhau==matkhau);
                if (kh != null)
                {
                    Session["KhachHang"] = kh;
                    return RedirectToAction("Index","Home");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KhachHang kh)
        {
            var tenkh = collection["TenKH"];
            var diachi = collection["DiaChi"];
            var email = collection["Email"];
            var sdt = collection["SDT"];
            var taikhoan = collection["TaiKhoan"];
            var matkhau = collection["MatKhau"];
            var xnmatkhau = collection["xnMatKhau"];
            if (String.IsNullOrEmpty(tenkh))
                ViewBag.Thongbao = "Tên không được để trống";
            else if (String.IsNullOrEmpty(diachi))
                ViewBag.Thongbao = "Địa chỉ không được để trống";
            else if (String.IsNullOrEmpty(email))
                ViewBag.Thongbao = "Email không được để trống";
            else if (String.IsNullOrEmpty(sdt))
                ViewBag.Thongbao = "Số điện thoại không được để trống";
            else if (String.IsNullOrEmpty(taikhoan))
                ViewBag.Thongbao = "Tài khoản không được để trống";
            else if (String.IsNullOrEmpty(matkhau))
                ViewBag.Thongbao = "Mật khẩu không được để trống";
            else if (String.IsNullOrEmpty(xnmatkhau))
                ViewBag.Thongbao = "Xác nhận mật khẩu không được để trống";
            else if(String.Compare(matkhau,xnmatkhau)!=0)
                ViewBag.Thongbao = "Xác nhận mật khẩu không đúng";
            else
            {
                kh.TenKhachHang = tenkh;
                kh.DiaChi = diachi;
                kh.Email = email;
                kh.SoDienThoai = sdt;
                kh.TaiKhoan = taikhoan;
                kh.MatKhau = matkhau;
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("DKTC");
            }
            return this.DangKy();
        }
        public ActionResult DKTC()
        {
            return View();
        }
    }
}
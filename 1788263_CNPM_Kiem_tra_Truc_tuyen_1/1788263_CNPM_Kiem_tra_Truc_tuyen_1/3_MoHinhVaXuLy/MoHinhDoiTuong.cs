using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class HocSinh
    {
        public string Ho_ten, Ma_so, CMND, Gioi_tinh, Dia_chi, Ten_Dang_nhap, Mat_khau;
        public DateTime Ngay_sinh;
        public Lop Lop = new Lop();
        public List<Danh_sach_Vang> Danh_sach_Vang = new List<Danh_sach_Vang>();
    }
    public class Lop
    {
        public string Ten, Ma_so;
        public Khoi Khoi = new Khoi();
    }
    public class Khoi
    {
        public string Ten, Ma_so;
    }
    public class Danh_sach_Vang
    {
        public DateTime Ngay;
        public string Ly_do;
    }
    public class GiamThi
    {
        public string Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau;
    }
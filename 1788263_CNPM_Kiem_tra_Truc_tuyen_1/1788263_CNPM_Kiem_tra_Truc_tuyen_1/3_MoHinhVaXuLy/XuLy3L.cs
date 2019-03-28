using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.IO;
using System.Web.Helpers;//Use Json.Decode and Json.Encode
using System.Web.Hosting;

public class XL_TheHien
{
    public static string DiaChiMedia = $"../Kiem_tra/Media";
    public static CultureInfo Dinh_dang_VN = CultureInfo.GetCultureInfo("vi-VN");

    public static string TaoChuoiHTMLThongTinHocSinh(HocSinh HS)
    {
        var ChuoiHinh = $"<img src='{DiaChiMedia}/{HS.Ma_so}.png' style='width:90px;height:90px;' />";
        var ChuoiThongTin = $"<div class='btn' style='text-align:left'> " +
                      $"Mã số {HS.Ma_so}" +
                      $"<br />Họ Tên {HS.Ho_ten}" +
                      $"<br />CMND {HS.CMND}" +
                      $"<br />Địa chỉ {HS.Dia_chi}" +
                      $"<br />Ngày sinh {HS.Ngay_sinh}" +
                      $"<br />{HS.Lop.Ten}" +
                      $"<br />Số ngày vắng {HS.Danh_sach_Vang.Count} ngày" +
                       $"<br />Chi tiết về các ngày vắng như sau: ";
        HS.Danh_sach_Vang.ForEach(x =>
        {
            ChuoiThongTin += $"<br /> Ngày {x.Ngay.ToString(Dinh_dang_VN)} " +
                                $"<br /> Lý do: {x.Ly_do}";
        });
        var ChuoiHTML = $"<div class='col-md-4' style='margin-bottom:10px' >" +
                           $"{ChuoiHinh}" + $"{ChuoiThongTin}" +
                         "</div>";
        return ChuoiHTML;
    }

    public static string TaoChuoiHTMLDSHocSinh(List<HocSinh> DanhSachHocSinh)
    {
        var ChuoiHTML = "<div class='row'>";
        DanhSachHocSinh.ForEach(HS =>
        {
            ChuoiHTML += TaoChuoiHTMLThongTinHocSinh(HS);
        });
        ChuoiHTML += "</div>";
        return ChuoiHTML;
    }
}
public class XL_NghiepVu
{

}
public class XL_LuuTru
{
    static DirectoryInfo Thu_muc_Project = new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath);
    static DirectoryInfo Thu_muc_Du_lieu = Thu_muc_Project.Parent.Parent.GetDirectories("Kiem_tra")[0];
    static DirectoryInfo ThuMucHocSinh = Thu_muc_Du_lieu.GetDirectories("Hoc_sinh")[0];
    
    public static List<HocSinh> DocDanhSachHocSinh()
    {
        var DanhSach = new List<HocSinh>();
        var DanhSachTapTin = ThuMucHocSinh.GetFiles("*.json").ToList();
        DanhSachTapTin.ForEach(TapTin =>
        {
            var DuongDan = TapTin.FullName;
            var ChuoiJSon = File.ReadAllText(DuongDan);
            var HocSinh = Json.Decode<HocSinh>(ChuoiJSon);
            DanhSach.Add(HocSinh);
        });
        return DanhSach;
    }    
}
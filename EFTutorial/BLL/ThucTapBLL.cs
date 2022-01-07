using EFTutorial.DAL;
using EFTutorial.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTutorial.BLL
{
    public enum KETQUA3
    {
        ThanhCong, TenTrung
    }
    internal class ThucTapBLL
    {
        public static List<ThucTap> GetList(long idlop)
        {
            QLThucTapModel model = new QLThucTapModel();
            return model.ThucTaps.Where(e => e.IDNganh == idlop).ToList();
            //return model.SinhViens.ToList();
        }
        public static List<ThucTapVM> GetListVM()
        {
            QLThucTapModel model = new QLThucTapModel();
            var ls = model.ThucTaps.Select(e => new ThucTapVM
            {
                ID = e.ID,
                IDStudent = e.IDStudent,
                FullName = e.FullName,
                DOB = e.DOB,
                POB = e.POB,
                IDNganh = e.IDNganh,
                Name=e.Name,
                CTyThucTap=e.CTyThucTap
            }).ToList();
            return ls;
        }
        public static void Delete(long idsinhvien)
        {
            QLThucTapModel model = new QLThucTapModel();
            var sinhvien = model.ThucTaps.Where(e => e.ID == idsinhvien).FirstOrDefault();
            if (sinhvien != null)
                model.ThucTaps.Remove(sinhvien);
            else
                throw new Exception("Sinh vien ko ton tai");
            model.SaveChanges();
        }
        public static KETQUA3 Add(ThucTapVM sinhVienVM)
        {
            QLThucTapModel model = new QLThucTapModel();
            var sinhvien = model.ThucTaps.Where(e => e.IDStudent == sinhVienVM.IDStudent).FirstOrDefault();
            if (sinhvien != null)
            {
                return KETQUA3.TenTrung;
            }
            else
            {
                sinhvien = new ThucTap
                {
                    IDStudent = sinhVienVM.IDStudent,
                    FullName = sinhVienVM.FullName,
                    POB = sinhVienVM.POB,
                    DOB = sinhVienVM.DOB,
                    IDNganh = sinhVienVM.IDNganh,
                    Name=sinhVienVM.Name,
                    CTyThucTap=sinhVienVM.CTyThucTap

                };
                model.ThucTaps.Add(sinhvien);
                model.SaveChanges();
                return KETQUA3.ThanhCong;
            }
        }
        public static KETQUA3 Update(ThucTapVM sinhVienVM)
        {
            QLThucTapModel model = new QLThucTapModel();
            var sinhvien = model.ThucTaps.Where(e =>
            e.ID != sinhVienVM.ID && e.IDStudent == sinhVienVM.IDStudent).FirstOrDefault();
            if (sinhvien != null)
            {
                return KETQUA3.TenTrung;
            }
            else
            {
                sinhvien = model.ThucTaps.Where(e => e.ID == sinhVienVM.ID).FirstOrDefault();
                //lop.Name = lopHocVM.Name;
                sinhvien.IDStudent = sinhVienVM.IDStudent;
                sinhvien.FullName = sinhVienVM.FullName;
                sinhvien.POB = sinhVienVM.POB;
                sinhvien.DOB = sinhVienVM.DOB;
                sinhvien.IDNganh = sinhVienVM.IDNganh;
                sinhvien.Name = sinhVienVM.Name;
                sinhvien.CTyThucTap = sinhVienVM.CTyThucTap;
                model.SaveChanges();
                return KETQUA3.ThanhCong;
            }
        }
    }
}

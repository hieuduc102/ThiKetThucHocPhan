using EFTutorial.DAL;
using EFTutorial.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTutorial.BLL
{
    public enum KETQUA1
    {
        ThanhCong, TenTrung
    }
    internal class SinhVienBLL
    {
       
        public static List<SinhVien> GetList(long idlop)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            return model.SinhViens.Where(e => e.IDLop == idlop).ToList();
            //return model.SinhViens.ToList();
        }
        public static List<SinhVienVM> GetListVM()
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var ls = model.SinhViens.Select(e => new SinhVienVM
            {
                ID = e.ID,
                IDStudent = e.IDStudent,
                FirstName = e.FirstName,
                LastName = e.LastName,
                DOB = e.DOB,
                POB = e.POB,
                IDLop=e.IDLop
            }).ToList();
            return ls;
        }
        public static void Delete(long idsinhvien)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var sinhvien = model.SinhViens.Where(e => e.ID == idsinhvien).FirstOrDefault();
            if (sinhvien != null)
                    model.SinhViens.Remove(sinhvien);
            else
                throw new Exception("Sinh vien ko ton tai");
            model.SaveChanges();
        }
        public static KETQUA1 Add(SinhVienVM sinhVienVM)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var sinhvien = model.SinhViens.Where(e => e.IDStudent == sinhVienVM.IDStudent).FirstOrDefault();
            if (sinhvien != null)
            {
                return KETQUA1.TenTrung;
            }
            else
            {
                sinhvien = new SinhVien
                {
                    IDStudent = sinhVienVM.IDStudent,
                    FirstName = sinhVienVM.FirstName,
                    LastName = sinhVienVM.LastName,
                    POB = sinhVienVM.POB,
                    DOB = sinhVienVM.DOB,
                    IDLop=sinhVienVM.IDLop
                    
                };
                model.SinhViens.Add(sinhvien);
                model.SaveChanges();
                return KETQUA1.ThanhCong;
            }
        }
        public static KETQUA1 Update(SinhVienVM sinhVienVM)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var sinhvien = model.SinhViens.Where(e =>
            e.ID != sinhVienVM.ID && e.IDStudent == sinhVienVM.IDStudent).FirstOrDefault();
            if (sinhvien != null)
            {
                return KETQUA1.TenTrung;
            }
            else
            {
                sinhvien = model.SinhViens.Where(e => e.ID == sinhVienVM.ID).FirstOrDefault();
                //lop.Name = lopHocVM.Name;
                sinhvien.IDStudent = sinhVienVM.IDStudent;
                sinhvien.FirstName = sinhVienVM.FirstName;
                sinhvien.LastName = sinhVienVM.LastName;
                sinhvien.POB = sinhVienVM.POB;
                sinhvien.DOB = sinhVienVM.DOB;
                sinhvien.IDLop = sinhVienVM.IDLop;
                model.SaveChanges();
                return KETQUA1.ThanhCong;
            }
        }
    }
}

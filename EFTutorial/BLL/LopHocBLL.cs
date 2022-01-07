using EFTutorial.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTutorial.ViewModel;

namespace EFTutorial.BLL
{
    public enum KETQUA
    {
        ThanhCong,TenTrung
    }
    internal class LopHocBLL
    {
        public static List<LopHoc> GetList()
        {
            QLSinhVienModel model = new QLSinhVienModel();
            return model.LopHocs.OrderByDescending(e => e.Name).ToList();
        }
        public static List<LopHocVM> GetListVM()
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var ls = model.LopHocs.Select(e => new LopHocVM
            {
                ID = e.ID,
                Name = e.Name,
                TotalStudent = e.SinhViens.Count()
            }).ToList();
            return ls;
        }
        public static void Delete(long idLop)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var lop = model.LopHocs.Where(e => e.ID == idLop).FirstOrDefault();
            if (lop != null)
                if (lop.SinhViens.Count()!=0)
                    throw new Exception("Lop hoc co sinh vien ko the xoa");
                else
                    model.LopHocs.Remove(lop);
            else
                throw new Exception("Lop hoc ko ton tai");
            model.SaveChanges();
        }
        public static KETQUA Add(LopHocVM lopHocVM)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var lop = model.LopHocs.Where(e => e.Name == lopHocVM.Name).FirstOrDefault();
            if (lop != null)
            {
                return KETQUA.TenTrung;
            }
            else
            {
                lop = new LopHoc
                {
                    Name = lopHocVM.Name
                };
                model.LopHocs.Add(lop);
                model.SaveChanges();
                return KETQUA.ThanhCong;
            }
        }
        public static KETQUA Update(LopHocVM lopHocVM)
        {
            QLSinhVienModel model = new QLSinhVienModel();
            var lop = model.LopHocs.Where(e => 
            e.ID!=lopHocVM.ID && e.Name == lopHocVM.Name).FirstOrDefault();
            if (lop != null)
            {
                return KETQUA.TenTrung;
            }
            else
            {
                lop = model.LopHocs.Where(e => e.ID == lopHocVM.ID).FirstOrDefault();
                lop.Name = lopHocVM.Name;
                model.SaveChanges();
                return KETQUA.ThanhCong;
            }
        }
    }
}

using EFTutorial.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTutorial.ViewModel;

namespace EFTutorial.BLL
{
    public enum KETQUA2
    {
        ThanhCong, TenTrung
    }
    internal class NganhBLL
    {
        public static List<Nganh> GetList()
        {
            QLThucTapModel model = new QLThucTapModel();
            return model.Nganhs.OrderByDescending(e => e.TenNganh).ToList();
        }
        public static void Delete(long idNganh)
        {
            QLThucTapModel model = new QLThucTapModel();
            var lop = model.Nganhs.Where(e => e.IDNganh == idNganh).FirstOrDefault();
            if (lop != null)
                if (lop.ThucTaps.Count() != 0)
                    throw new Exception("Lop hoc co sinh vien ko the xoa");
                else
                    model.Nganhs.Remove(lop);
            else
                throw new Exception("Lop hoc ko ton tai");
            model.SaveChanges();
        }
        public static KETQUA2 Add(NganhVM lopHocVM)
        {
            QLThucTapModel model = new QLThucTapModel();
            var lop = model.Nganhs.Where(e => e.TenNganh == lopHocVM.TenNganh).FirstOrDefault();
            if (lop != null)
            {
                return KETQUA2.TenTrung;
            }
            else
            {
                lop = new Nganh
                {
                    TenNganh = lopHocVM.TenNganh
                };
                model.Nganhs.Add(lop);
                model.SaveChanges();
                return KETQUA2.ThanhCong;
            }
        }
        public static KETQUA2 Update(NganhVM lopHocVM)
        {
            QLThucTapModel model = new QLThucTapModel();
            var lop = model.Nganhs.Where(e =>
            e.IDNganh != lopHocVM.IDNganh && e.TenNganh == lopHocVM.TenNganh).FirstOrDefault();
            if (lop != null)
            {
                return KETQUA2.TenTrung;
            }
            else
            {
                lop = model.Nganhs.Where(e => e.IDNganh == lopHocVM.IDNganh).FirstOrDefault();
                lop.TenNganh = lopHocVM.TenNganh;
                model.SaveChanges();
                return KETQUA2.ThanhCong;
            }
        }
    }
}

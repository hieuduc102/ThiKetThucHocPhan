using EFTutorial.BLL;
using EFTutorial.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFTutorial
{
    public partial class frmThucTapChiTiet : Form
    {
        ThucTapVM sinhVienVM;
        public frmThucTapChiTiet(ThucTapVM sinhVienVM = null)
        {
            InitializeComponent();
            this.sinhVienVM = sinhVienVM;

            if (sinhVienVM == null)
            {
                this.Text = "Them moi sinh vien";
            }
            else
            {
                this.Text = "Cap nhat du lieu sinh vien";
                txtmsv.Text = sinhVienVM.IDStudent;
                txthoten.Text = sinhVienVM.FullName;
                txtqq.Text = sinhVienVM.POB;
                dtns.Value = (DateTime)sinhVienVM.DOB;
                txtnganh.Text = sinhVienVM.IDNganh.ToString();
                txtcty.Text = sinhVienVM.CTyThucTap;
                txtname.Text = sinhVienVM.Name;
            }
        }

        private void btndongy_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var msv = txtmsv.Text;
            var ho = txthoten.Text;
            var qq = txtqq.Text;
            var date = dtns.Value;
            var name = txtname.Text;
            var cty = txtcty.Text;
            long lop = long.Parse(txtnganh.Text);
            if ((string.IsNullOrEmpty(msv)) || (string.IsNullOrEmpty(ho)) || (string.IsNullOrEmpty(name)) || (string.IsNullOrEmpty(qq)) || (string.IsNullOrEmpty(txtnganh.Text)) || (string.IsNullOrEmpty(txtcty.Text)))
            {
                errorProvider1.SetError(txtmsv, "Ma sinh vien khong duoc de trong");
                errorProvider1.SetError(txthoten, "Ho ten sinh vien khong duoc de trong");
                errorProvider1.SetError(txtname, "Ten nganh khong duoc de trong");
                errorProvider1.SetError(txtqq, "Que quan sinh vien khong duoc de trong");
                errorProvider1.SetError(txtnganh, "Lop ko duoc bo trong");
                errorProvider1.SetError(txtcty, "Tên công ty không được để trống");
                return;
            }
            var rs = KETQUA3.ThanhCong;
            if (sinhVienVM == null)
            {
                //them
                rs = ThucTapBLL.Add(new ThucTapVM { IDStudent = msv, FullName = ho, Name = name, POB = qq, DOB = date, IDNganh = lop,CTyThucTap=cty });
            }
            else
            {
                //cap nhat
                sinhVienVM.IDStudent = msv;
                sinhVienVM.FullName = ho;
                sinhVienVM.Name = name;
                sinhVienVM.POB = qq;
                sinhVienVM.DOB = date;
                sinhVienVM.IDNganh = lop;
                sinhVienVM.CTyThucTap = cty;
                rs = ThucTapBLL.Update(sinhVienVM);
            }
            if (rs == KETQUA3.ThanhCong)
            {
                DialogResult = DialogResult.OK;
            }
            else if (rs == KETQUA3.TenTrung)
            {
                MessageBox.Show("Ma sinh vien khong duoc trung", "Thong bao");
            }
        }
    }
}

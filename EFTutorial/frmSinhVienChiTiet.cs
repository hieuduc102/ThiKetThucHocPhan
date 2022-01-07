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
    public partial class frmSinhVienChiTiet : Form
    {
        SinhVienVM sinhVienVM;
        //LopHocVM lopHocVM;
        public frmSinhVienChiTiet(SinhVienVM sinhVienVM=null)
        {
            InitializeComponent();
            this.sinhVienVM = sinhVienVM;
            //this.lopHocVM = lopHocVM;
            
            if (sinhVienVM == null)
            {
                this.Text = "Them moi sinh vien";
            }
            else
            {
                this.Text = "Cap nhat du lieu sinh vien";
                txtmsv.Text =sinhVienVM.IDStudent;
                txtho.Text =sinhVienVM.FirstName;
                txtten.Text = sinhVienVM.LastName;
                txtqq.Text = sinhVienVM.POB;
                dtns.Value = (DateTime)sinhVienVM.DOB;
                txtlop.Text = sinhVienVM.IDLop.ToString();
            }
        }

        private void btndongy_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var msv = txtmsv.Text;
            var ho=txtho.Text;
            var ten = txtten.Text;
            var qq=txtqq.Text;
            var date=dtns.Value;
            long lop = long.Parse(txtlop.Text);
            if ((string.IsNullOrEmpty(msv)) || (string.IsNullOrEmpty(ho)) || (string.IsNullOrEmpty(ten)) || (string.IsNullOrEmpty(qq)) || (string.IsNullOrEmpty(txtlop.Text)))
            {
                errorProvider1.SetError(txtmsv, "Ma sinh vien khong duoc de trong");
                errorProvider1.SetError(txtho, "Ho sinh vien khong duoc de trong");
                errorProvider1.SetError(txtten, "Ten sinh vien khong duoc de trong");
                errorProvider1.SetError(txtqq, "Que quan sinh vien khong duoc de trong");
                errorProvider1.SetError(txtlop, "Lop ko duoc bo trong");
                return;
            }
            var rs = KETQUA1.ThanhCong;
            if (sinhVienVM == null)
            {
                //them
                rs = SinhVienBLL.Add(new SinhVienVM { IDStudent = msv,FirstName=ho,LastName=ten,POB=qq,DOB=date,IDLop=lop });
            }
            else
            {
                //cap nhat
                sinhVienVM.IDStudent = msv;
                sinhVienVM.FirstName = ho;
                sinhVienVM.LastName = ten;
                sinhVienVM.POB = qq;
                sinhVienVM.DOB = date;
                sinhVienVM.IDLop = lop;
                rs = SinhVienBLL.Update(sinhVienVM);
            }
            if (rs == KETQUA1.ThanhCong)
            {
                DialogResult = DialogResult.OK;
            }
            else if (rs == KETQUA1.TenTrung)
            {
                MessageBox.Show("Ma sinh vien khong duoc trung", "Thong bao");
            }
        }
    }
}

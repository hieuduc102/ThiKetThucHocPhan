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
    public partial class frmLopChiTiet : Form
    {
        LopHocVM lopHocVM;
        public frmLopChiTiet(LopHocVM lopHocVM=null)
        {
            InitializeComponent();
            this.lopHocVM = lopHocVM;
            if(lopHocVM==null)
            {
                this.Text = "Them moi lop hoc";
            }
            else
            {
                this.Text = "Cap nhat du lieu lop hoc";
                txttenlop.Text = lopHocVM.Name;
            }
        }

        private void btndongy_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var tenlop = txttenlop.Text;
            if (string.IsNullOrEmpty(tenlop))
            {
                errorProvider1.SetError(txttenlop, "Lop hoc khoong duoc de trong");
                return;
            }
            var rs = KETQUA.ThanhCong;
            if (lopHocVM == null)
            {
                //them
                rs= LopHocBLL.Add(new LopHocVM { Name = tenlop });              
            }
            else
            {
                //cap nhat
                lopHocVM.Name = tenlop;
                rs = LopHocBLL.Update(lopHocVM);
            }
            if (rs == KETQUA.ThanhCong)
            {
                DialogResult = DialogResult.OK;
            }
            else if (rs == KETQUA.TenTrung)
            {
                MessageBox.Show("Ten lop khong duoc trung", "Thong bao");
            }
        }
    }
}

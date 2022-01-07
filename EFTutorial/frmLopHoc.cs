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
    public partial class frmLopHoc : Form
    {
        public frmLopHoc()
        {
            InitializeComponent();
            NapLopHoc();
        }
        void NapLopHoc()
        {
            var ls = LopHocBLL.GetListVM();
            lopHocVMBindingSource.DataSource = ls;
            dataGridView1.DataSource = lopHocVMBindingSource;
        }
        public LopHocVM selectLopHoc{
            get
            {
                return lopHocVMBindingSource.Current as LopHocVM;
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectLopHoc != null)
            {
                if (MessageBox.Show(
                    "Ban co thuc su muon xoa", 
                    "Chu y", 
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    LopHocBLL.Delete(selectLopHoc.ID);
                    lopHocVMBindingSource.RemoveCurrent();
                    MessageBox.Show("Da xoa thanh cong");
                }
                
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var f = new frmLopChiTiet();
            var rs=f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                NapLopHoc();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectLopHoc != null)
            {
                var f = new frmLopChiTiet(selectLopHoc);
                var rs = f.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    NapLopHoc();
                }
            } 
        }
    }
}

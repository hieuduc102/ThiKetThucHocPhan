using EFTutorial.BLL;
using EFTutorial.DAL;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var ls = LopHocBLL.GetList();
            comboBox1.DataSource = ls;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            NapSinhVien();
        }
        void NapSinhVien()
        {
            var ls = SinhVienBLL.GetListVM();
            sinhVienBindingSource.DataSource = ls;
            dataGridView1.DataSource = sinhVienBindingSource;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lopHoc = comboBox1.SelectedItem as LopHoc;
            if (lopHoc != null)
            {
                var ls = SinhVienBLL.GetList(lopHoc.ID);
                sinhVienBindingSource.DataSource = ls;
                dataGridView1.DataSource = sinhVienBindingSource;
            }
        }
        public SinhVienVM selectSinhVien
        {
            get
            {
                return sinhVienBindingSource.Current as SinhVienVM;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectSinhVien != null)
            {
                if (MessageBox.Show(
                    "Ban co thuc su muon xoa",
                    "Chu y",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SinhVienBLL.Delete(selectSinhVien.ID);
                    sinhVienBindingSource.RemoveCurrent();
                    MessageBox.Show("Da xoa thanh cong");
                }

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var f = new frmSinhVienChiTiet();
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                NapSinhVien();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectSinhVien != null)
            {
                var f = new frmSinhVienChiTiet(selectSinhVien);
                var rs = f.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    NapSinhVien();
                }
            }
        }
    }
}

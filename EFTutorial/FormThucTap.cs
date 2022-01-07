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
    public partial class FormThucTap : Form
    {
        public FormThucTap()
        {
            InitializeComponent();
            var ls = NganhBLL.GetList();
            comboBox1.DataSource = ls;
            comboBox1.DisplayMember = "TenNganh";
            comboBox1.ValueMember = "IDNganh";
            NapSinhVien();
        }
        void NapSinhVien()
        {
            var ls = ThucTapBLL.GetListVM();
            thucTapBindingSource.DataSource = ls;
            dataGridView1.DataSource = thucTapBindingSource;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lopHoc = comboBox1.SelectedItem as Nganh;
            if (lopHoc != null)
            {
                var ls = ThucTapBLL.GetList(lopHoc.IDNganh);
                thucTapBindingSource.DataSource = ls;
                dataGridView1.DataSource = thucTapBindingSource;
            }
        }
        public ThucTapVM selectThucTap
        {
            get
            {
                return thucTapBindingSource.Current as ThucTapVM;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectThucTap != null)
            {
                if (MessageBox.Show(
                    "Ban co thuc su muon xoa",
                    "Chu y",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ThucTapBLL.Delete(selectThucTap.ID);
                    thucTapBindingSource.RemoveCurrent();
                    MessageBox.Show("Da xoa thanh cong");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var f = new frmThucTapChiTiet();
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                NapSinhVien();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectThucTap != null)
            {
                var f = new frmThucTapChiTiet(selectThucTap);
                var rs = f.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    NapSinhVien();
                }
            }
        }
    }
}

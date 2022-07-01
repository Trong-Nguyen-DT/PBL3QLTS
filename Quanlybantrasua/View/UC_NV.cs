using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quanlybantrasua.BLL;
using Quanlybantrasua.DTO;

namespace Quanlybantrasua.View
{
    public partial class UC_NV : UserControl
    {
        public UC_NV()
        {
            InitializeComponent();
            GUI();
            dataGridViewNV.Columns[0].HeaderText = "Mã nhân viên";
            dataGridViewNV.Columns[1].HeaderText = "Tên nhân viên";
            dataGridViewNV.Columns[2].HeaderText = "Giới tính";
            dataGridViewNV.Columns[3].HeaderText = "Số điện thoại";
            dataGridViewNV.Columns[4].HeaderText = "Quản lý";
            dataGridViewNV.Columns[5].HeaderText = "Mật khẩu";
        }
        public void GUI()
        {
            dataGridViewNV.DataSource = BLLQLTS.Instance.GetAllNV();
            dataGridViewNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            string s = txtTimkiem.Text.ToString();
            dataGridViewNV.DataSource = BLLQLTS.Instance.GetNV_ViewByTenNV(s);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemNV f = new ThemNV(0);
            f.ShowDialog();
            GUI();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int ID_NV = 0;
            if (dataGridViewNV.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow row in dataGridViewNV.SelectedRows)
                {
                    ID_NV = Convert.ToInt32(row.Cells[0].Value);
                }
                ThemNV f = new ThemNV(ID_NV);
                f.ShowDialog();
                GUI();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            UC_NV x = new UC_NV();
            if (dataGridViewNV.SelectedRows.Count > 0)
            {
                Controls.Remove(x);
            }
            else
            {
                MessageBox.Show("Lựa chọn không hợp lệ");
            }
        }
    }
}

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
    }
}

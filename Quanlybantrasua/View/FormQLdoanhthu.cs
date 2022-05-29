using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Quanlybantrasua.BLL;
using Quanlybantrasua.DTO;

namespace Quanlybantrasua
{
    public partial class Doanhthu : Form
    {
        public int IDHD { get; set; }
        public Doanhthu(int iDHD)
        {
            InitializeComponent();
            IDHD = iDHD;
            load(BLLQLTS.Instance.GetCTDT(IDHD));
            dgv_ctdt.DataSource = BLLQLTS.Instance.GetCTDT(IDHD);
            dgv_ctdt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ctdt.Columns[0].HeaderText = "Tên hàng hóa";
            dgv_ctdt.Columns[1].HeaderText = "S? l??ng";
            dgv_ctdt.Columns[2].HeaderText = "Giá ti?n";
            GUI();
        }
        public void GUI()
        {
            foreach (HOA_DON i in BLLQLTS.Instance.GetAllHD())
            {
                if (i.ID_HD == IDHD)
                {
                    
                    txtTenNV.Text = i.NHANVIEN.Ten_NV.ToString();
                    

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }
        private void load(List<CTDTView> item)
        {
            dgv_ctdt.DataSource = item;
          
            lb_ctdt.Text = BLLQLTS.Instance.tongtien(item).ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
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
    public partial class UC_doanhthu : UserControl
    {
        public UC_doanhthu()
        {
            InitializeComponent();
            GUI();
            dgv_dt.Columns[0].HeaderText = "Mã hóa đơn";
            dgv_dt.Columns[1].HeaderText = "Số bàn";
            dgv_dt.Columns[2].HeaderText = "Tên Nhân viên";
            dgv_dt.Columns[3].HeaderText = "Số điện thoại";
            dgv_dt.Columns[4].HeaderText = "Giờ đến";
            dgv_dt.Columns[5].HeaderText = "Giờ đi";
            dgv_dt.Columns[6].HeaderText = "Tồng tiền";
            dgv_dt.Columns[7].HeaderText = "Khuyến mãi";
            dgv_dt.Columns[8].HeaderText = "Tên khách hàng";
            dgv_dt.Columns[9].HeaderText = "Thanh toán";
        }
        public void GUI()
        {
            dgv_dt.DataSource = BLLQLTS.Instance.GetAllHDView();
            dgv_dt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            load(BLLQLTS.Instance.GetAllHDView());
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            string s = tb_timkiemdt.Text.ToString();
            load(BLL.BLLQLTS.Instance.TimKiem_hoadon(s));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Hoadon_View> listHoaDon = new List<Hoadon_View>();
            DateTime bdau1 = bdau.Value;
            DateTime kthuc1 = kthuc.Value;
            load(BLLQLTS.Instance.GetListHDByTG(bdau1, kthuc1));
        }
        private void load(List<Hoadon_View> item)
        {
            dgv_dt.DataSource = item;
            lb_shd.Text = item.Count().ToString();
            lb_doanhthu.Text = BLLQLTS.Instance.tongdoanhthu(item).ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgv_dt.SelectedRows.Count == 1)
            {
                int ID_HD = 0;
                foreach (DataGridViewRow row in dgv_dt.SelectedRows)
                {
                    ID_HD = Convert.ToInt32(row.Cells[0].Value);
                }
                Doanhthu dt = new Doanhthu(ID_HD);
                dt.ShowDialog();

            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

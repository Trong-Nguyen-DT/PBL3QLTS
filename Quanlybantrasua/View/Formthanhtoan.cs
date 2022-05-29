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

namespace Quanlybantrasua
{
    public partial class xemdon : Form
    {
        public int ID_HD { get; set; }
        public xemdon(int IDHD)
        {
            InitializeComponent();
            ID_HD = IDHD;
            GUI();
        }
        public void GUI()
        {
            dataGridView1.DataSource = BLLQLTS.Instance.GetDetailBill(ID_HD);
            dataGridView1.Columns[0].HeaderText = "Tên hàng hóa";
            dataGridView1.Columns[1].HeaderText = "Số lượng";
            dataGridView1.Columns[2].HeaderText = "Giá";
            foreach (HOA_DON i in BLLQLTS.Instance.GetAllHD())
            {
                if (i.ID_HD == ID_HD)
                {
                    txtBan.Text = i.BAN.Tenban.ToString();
                    txtIDHD.Text = i.ID_HD.ToString();
                    txtTenNV.Text = i.NHANVIEN.Ten_NV.ToString();
                    txtTongtien.Text = i.Tongtien.ToString();
                    txtKM.Text = i.discount.ToString();

                }
            }
        }



    }
}

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
    public partial class Formdoimatkhau : Form
    {
        public string Tennhanvien { get; set; }
        public Formdoimatkhau(string Ten)
        {
            Tennhanvien = Ten;
            InitializeComponent();
            GUI();
        }
        public void GUI()
        {
            txtName.Text = Tennhanvien;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            NHANVIEN s = new NHANVIEN();
            foreach (NHANVIEN i in BLLQLTS.Instance.GetAllNV())
            {
                if (i.Ten_NV == Tennhanvien)
                {
                    s.ID_NV = i.ID_NV;
                    break;
                }
            }
            s.password = txtPass.Text.ToString();
            BLLQLTS.Instance.UpdatePass(s);
            MessageBox.Show("Đổi mật khẩu thành công");
            this.Close();
        }
    }
}

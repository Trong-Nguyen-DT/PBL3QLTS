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
    public partial class Formdangnhap : Form
    {
        public Formdangnhap()
        {
            InitializeComponent();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text.ToString();
            string pass = txtPass.Text.ToString();
            if (BLLQLTS.Instance.CheckAccount(Name, pass))
            {
                if (BLLQLTS.Instance.CheckPhanquyen(Name))
                {
                    GUI f = new GUI();
                    f.Show();
                }
                else
                {
                    Quanlyhanghoa f = new Quanlyhanghoa();
                    f.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Tên tài khoản và mật khẩu không đúng");
            }
        }

        private void btNguon_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

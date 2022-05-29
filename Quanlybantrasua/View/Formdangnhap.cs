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
            string chucvu = "";
            if (BLLQLTS.Instance.CheckAccount(Name, pass))
            {
                if (BLLQLTS.Instance.CheckPhanquyen(Name))
                {
                    GUI f = new GUI(Name);
                    f.ShowDialog();
                }
                else
                {
                    chucvu = "Quản lý";
                    Quanlyhanghoa f = new Quanlyhanghoa(Name,chucvu);
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
        int i = 0;
        private void hienmk_Click(object sender, EventArgs e)
        {
            i++;
            if (i % 2 == 0)
            {
                txtPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtPass.UseSystemPasswordChar = false;
            }

        }
    }
}

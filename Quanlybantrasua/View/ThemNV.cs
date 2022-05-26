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

namespace Quanlybantrasua.View
{
    public partial class ThemNV : Form
    {
        public int ID_NV { get; set; }
        public ThemNV(int IDNV)
        {
            ID_NV = IDNV;
            InitializeComponent();
            GUI(ID_NV);
        }
        public void GUI(int ID_NV)
        {
            NHANVIEN s = BLLQLTS.Instance.GetNVByID(ID_NV);
            if (ID_NV != 0)
            {
                txtName.Text = s.Ten_NV;
                txtPhone.Text = s.PhoneNumber.ToString();
                txtPass.Text = s.password;
                if (s.Gender == true)
                {
                    Rboy.Checked = true;
                }
                else
                {
                    Rgirl.Checked = true;
                }
                if (s.Phanquyen == true)
                {
                    RQL.Checked = true;
                }
                else
                {
                    RNV.Checked = true;
                }
            }
        }
        public ThemNV()
        {
            InitializeComponent();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (ID_NV == 0)
            {
                NHANVIEN s = new NHANVIEN
                {
                    ID_NV = BLLQLTS.Instance.GetAllNV().Count + 1,
                    Ten_NV = txtName.Text.ToString(),
                    PhoneNumber = Convert.ToInt32(txtPhone.Text.ToString()),
                    password = txtPass.Text.ToString(),

                };
                if (Rboy.Checked == true)
                {
                    s.Gender = true;
                }
                else
                {
                    s.Gender = false;
                }
                if (RNV.Checked == true)
                {
                    s.Phanquyen = true;
                }
                else
                {
                    s.Phanquyen = false;
                }
                BLLQLTS.Instance.AddUpdateNV(s);
            }
            else
            {
                NHANVIEN s = new NHANVIEN
                {
                    ID_NV = ID_NV,
                    Ten_NV = txtName.Text.ToString(),
                    PhoneNumber = Convert.ToInt32(txtPhone.Text.ToString()),
                    password = txtPass.Text.ToString(),

                };
                if (Rboy.Checked == true)
                {
                    s.Gender = true;
                }
                else
                {
                    s.Gender = false;
                }
                if (RNV.Checked == true)
                {
                    s.Phanquyen = true;
                }
                else
                {
                    s.Phanquyen = false;
                }
                BLLQLTS.Instance.AddUpdateNV(s);
            }

            this.Close();
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

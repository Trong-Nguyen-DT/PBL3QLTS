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
using Quanlybantrasua.View;

namespace Quanlybantrasua
{
    public partial class Quanlyhanghoa : Form
    {
        public string NameNhanvien { get; set; }
        public string Chucvu { get; set; }
        public Quanlyhanghoa(string Name,string CV)
        {
            NameNhanvien = Name;
            InitializeComponent();
            NameNV.Text = Name;
            UC_Hanghoa uchh = new UC_Hanghoa();
            AddControls(uchh);
            Timer.Start();
        }
        private void Thanhlucchon(Control tlc)
        {
            TLC.Top = tlc.Top;
            TLC.Height = tlc.Height;
        }
        private void AddControls(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelHH.Controls.Clear();
            panelHH.Controls.Add(c);
        }
        private void btHH_Click(object sender, EventArgs e)
        {
            Thanhlucchon(btHH);
            UC_Hanghoa uchh = new UC_Hanghoa();
            AddControls(uchh);
        }

        private void btNV_Click(object sender, EventArgs e)
        {
            Thanhlucchon(btNV);
            UC_NV ucnv = new UC_NV();
            AddControls(ucnv);
        }

        private void btDT_Click(object sender, EventArgs e)
        {
            Thanhlucchon(btDT);
            UC_doanhthu ucdt = new UC_doanhthu();
            AddControls(ucdt);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            TG.Text = dt.ToString("HH:mm:ss");
        }

        private void btDangxuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btKH_Click(object sender, EventArgs e)
        {
            Thanhlucchon(btKH);
            UC_Khachhang uckh = new UC_Khachhang();
            AddControls(uckh);
        }

        private void btDMK_Click(object sender, EventArgs e)
        {
            Formdoimatkhau s = new Formdoimatkhau("");
            s.ShowDialog();
        }
    }
}

﻿using System;
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
        public Quanlyhanghoa()
        {
            InitializeComponent();
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
        }

        private void btDT_Click(object sender, EventArgs e)
        {
            Thanhlucchon(btDT);
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
    }
}
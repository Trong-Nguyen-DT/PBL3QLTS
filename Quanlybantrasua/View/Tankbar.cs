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
    public partial class Tankbar : UserControl
    {
        public Tankbar()
        {
            InitializeComponent();
            GUI();
        }
        public void GUI()
        {
            danhsachhanghoa.DataSource = BLLQLTS.Instance.GetAllHHTinhtrang();
            danhsachhanghoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Them_Click(object sender, EventArgs e)
        {
            Themmon tm = new Themmon();
            tm.ShowDialog();
        }
    }
}

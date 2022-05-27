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
    public partial class UC_doanhthu : UserControl
    {
        public UC_doanhthu()
        {
            InitializeComponent();
            GUI();
        }
        public void GUI()
        {
            dataGridView1.DataSource = BLLQLTS.Instance.GetAllHD();
        }
    }
}

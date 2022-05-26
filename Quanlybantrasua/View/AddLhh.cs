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
    public partial class AddLhh : Form
    {
        
        public AddLhh()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool CheckDuplicate(Loai_HANGHOA lhh)
        {
            foreach (string i in BLLQLTS.Instance.GetAllTenLHH())
            {
                if (i == lhh.Ten_LHH)
                {
                    return true;
                }
            }
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Loai_HANGHOA lhh = new Loai_HANGHOA()
            {
                ID_LHH = BLLQLTS.Instance.GetAllLhh().Count + 1,
                Ten_LHH = txtTlhh.Text.ToString()
            };
            if (CheckDuplicate(lhh))
            {
                MessageBox.Show("Cu oi trung r");
            }
            else
            {
                BLLQLTS.Instance.AddLhh(lhh);
                this.Close();
            }

        }
    }
}

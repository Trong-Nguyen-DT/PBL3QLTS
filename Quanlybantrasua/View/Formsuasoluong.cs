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
    public partial class Formsuasoluong : Form
    {
        public int IDHH { get; set; }
      // public string Name { get; set; }
        public Formsuasoluong(int ID_HH,string Tenban)
        {
            InitializeComponent();
            IDHH = ID_HH;
            Name = Tenban;
            foreach (HANGHOA i in BLLQLTS.Instance.GetAllHH())
            {
                if (i.ID_HH == IDHH)
                {
                    txtNameHH.Text = i.Ten_HH.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (HOA_DON i in BLLQLTS.Instance.GetAllHD())
            {
                if (i.BAN.Tenban == Name && i.Thanhtoan == false)
                {
                    foreach (CHI_TIET_HOA_DON j in BLLQLTS.Instance.GetAllCTHD())
                    {
                        if (j.ID_HD == i.ID_HD && j.ID_HH == IDHH)
                        {
                            BLLQLTS.Instance.DelUpCTHD(j.ID_CTHD,Convert.ToInt32(txtsoluong.Text.ToString()));
                            Close();
                        }
                    }
                }
            }
        }
    }
}

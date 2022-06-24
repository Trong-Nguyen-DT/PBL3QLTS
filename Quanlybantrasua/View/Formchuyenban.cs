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
    public partial class Formchuyenban : Form
    {
        public int ID_HD { get; set; }
        public Formchuyenban(int IDHD)
        {
            ID_HD = IDHD;
            InitializeComponent();
            Getstate();
        }
        string Tenban = "";
        public void Getstate()
        {
            foreach (BAN i in BLLQLTS.Instance.GetState())
            {
                if (i.Tinhtrang == true)
                {
                    foreach (var button in this.groupBox1.Controls.OfType<Button>())
                    {
                        if (button.Name == i.Tenban)
                        {
                            button.BackColor = Color.Red;
                        }
                    }
                }
                else
                {
                    foreach (var button in this.groupBox1.Controls.OfType<Button>())
                    {
                        if (button.Name == i.Tenban)
                        {
                            button.BackColor = Color.DeepSkyBlue;
                        }
                    }
                }
            }
        }
        public new void Click(object sender, EventArgs e)
        {
            Tenban = ((Button)sender).Name.ToString();
        }
        private void button21_Click(object sender, EventArgs e)
        {
            HOA_DON s = new HOA_DON();
            s.ID_HD = ID_HD;
            foreach(BAN i in BLLQLTS.Instance.GetAllBan())
            {
                if (i.Tenban == Tenban)
                {
                    s.ID_BAN = i.ID_BAN;
                }
            }
            BLLQLTS.Instance.UpdateBan(s);
            this.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

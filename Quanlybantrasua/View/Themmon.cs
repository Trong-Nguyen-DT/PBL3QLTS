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
using Quanlybantrasua.DTO;
using Quanlybantrasua.View;

namespace Quanlybantrasua
{
    public partial class Themmon : Form
    {
        public Themmon()
        {
            InitializeComponent();
            Tenloaihanghoa.Items.AddRange(BLLQLTS.Instance.GetCbbLHH().ToArray());
        }
        public void ReloadCBB()
        {
            Tenloaihanghoa.Items.Clear();
            foreach (CbbLHH i in BLLQLTS.Instance.GetCbbLHH())
            {
                if (!Tenloaihanghoa.Items.Equals(i))
                {
                    Tenloaihanghoa.Items.Add(new CbbLHH { ID_LHH=i.ID_LHH,Ten_LHH=i.Ten_LHH});
                }
            }
        }
        public void AddCBBLHH(Loai_HANGHOA s)
        {
            Tenloaihanghoa.Items.Add(s);
        }
        private void tm_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tm_luu_Click(object sender, EventArgs e)
        {
            HANGHOA h = new HANGHOA
            {

                ID_HH = BLLQLTS.Instance.GetAllHH().Count + 1,
                ID_LHH = Convert.ToInt32(((CbbLHH)Tenloaihanghoa.SelectedItem).ID_LHH.ToString()),
                Ten_HH = txttenhh.Text.ToString(),
                Gia = Convert.ToInt32(txtGia.Text.ToString()),
                tinhTrang = true

            };
            BLLQLTS.Instance.addhh(h);
            this.Close();


        }

        private void butAddLHH_Click(object sender, EventArgs e)
        {
            AddLhh f = new AddLhh();
            f.ShowDialog();
            ReloadCBB();
        }
    }
}

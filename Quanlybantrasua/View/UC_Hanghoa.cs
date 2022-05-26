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

namespace Quanlybantrasua.View
{
    public partial class UC_Hanghoa : UserControl
    {
        public UC_Hanghoa()
        {
            InitializeComponent();
            comboxloc.Items.AddRange(BLLQLTS.Instance.GetCbbLHH().ToArray());
            GUI();
        }
        public void GUI()
        {
            danhsachhanghoa.DataSource = BLLQLTS.Instance.GetAllHHTinhtrang();
            danhsachhanghoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void AddCBBLHH(Loai_HANGHOA s)
        {
            comboxloc.Items.Add(s);
        }

        private void Them_Click(object sender, EventArgs e)
        {
            Themmon tm = new Themmon();
            tm.ShowDialog();
            GUI();
        }

        private void comboxloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID_HH = ((CbbLHH)comboxloc.SelectedItem).ID_LHH;
            if (ID_HH == 0)
            {
                danhsachhanghoa.DataSource = BLLQLTS.Instance.GetAllHH_View();
            }
            else
            {
                danhsachhanghoa.DataSource = BLLQLTS.Instance.GetHH_ViewbyIDLHH(ID_HH);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string s = txtTimkiemTenHH.Text.ToString();
            danhsachhanghoa.DataSource = BLLQLTS.Instance.GetHH_ViewByTenHH(s); n
        }

        private void btTN_Click(object sender, EventArgs e)
        {
            if (danhsachhanghoa.SelectedRows.Count > 0)
            {
                List<string> ID_LHH = new List<string>(); 
                foreach (DataGridViewRow i in danhsachhanghoa.SelectedRows)
                {
                    BLLQLTS.Instance.UpdateTinhtrang(Convert.ToInt32(i.Cells["ID_HH"].Value), Convert.ToBoolean(i.Cells["Tinhtrang"].Value));
                }
                GUI();
            }
            else
            {
                MessageBox.Show("Lựa chọn không hợp lệ");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (danhsachhanghoa.SelectedRows.Count == 1)
            {
                List<string> ID_LHH = new List<string>();
                foreach (DataGridViewRow i in danhsachhanghoa.SelectedRows)
                {
                    BLLQLTS.Instance.UpdateGia(Convert.ToInt32(i.Cells["ID_HH"].Value), Convert.ToInt32(i.Cells["Gia"].Value));
                    
                }
                GUI();
            }
            else
            {
                MessageBox.Show("Lựa chọn không hợp lệ");
            }
            
        }
    }
}

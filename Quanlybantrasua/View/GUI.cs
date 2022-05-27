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

namespace Quanlybantrasua
{
    public partial class GUI : Form
    {
        DateTime date = DateTime.Now;
        public GUI()
        {
            InitializeComponent();
            ShowCBBItems();
            ShowDGVOrder();
            ShowstatTable();
        }
        Boolean Checkclick = false;
        String Tenban = "";
        int tongtien;
        public void Tongtien(int ID_HD)
        {
            tongtien = 0;
            foreach(CHI_TIET_HOA_DON i in BLLQLTS.Instance.GetAllCTHD())
            {
                if(i.ID_HD == ID_HD)
                {
                    foreach(HANGHOA j in BLLQLTS.Instance.GetAllHH())
                    {
                        if (j.ID_HH == i.ID_HH)
                        {
                            tongtien +=Convert.ToInt32(i.soluong * j.Gia);
                        }
                    }
                }
            }
            txtTT.Text = tongtien.ToString();
        }
        public void GetTT()
        {
            foreach(HOA_DON i in BLLQLTS.Instance.GetAllHD())
            {
                if (i.BAN.Tenban == Tenban)
                {
                    txtPhone.Text = i.PhoneNumber.ToString();
                }
            }
        }
        public void ShowstatTable()
        {
            foreach(BAN i in BLLQLTS.Instance.GetState())
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
        public void ShowCBBItems()
        {
            cbbLHH.Items.Add(new CbbItems { IDLHH = 0, TenLHH = "Tất cả" });
            cbbLHH.Items.AddRange(BLLQLTS.Instance.GetCBB().ToArray());
            cbbLKH.Items.AddRange(BLLQLTS.Instance.GetCBBLKH().ToArray());
        }
    
        public void ShowDGVOrder()
        {
            cbbLHH.SelectedIndex = 0;
            DGVOrder.DataSource = BLLQLTS.Instance.GetAllHH_View();
            DGVOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public new void Click(object sender, EventArgs e)
        {
            Checkclick = true;
            Tenban = ((Button)sender).Name.ToString();
            GetTT();
            int ID_HD=0;
            foreach (HOA_DON j in BLLQLTS.Instance.GetAllHD())
            {
                if (j.BAN.Tenban==Tenban && j.Thanhtoan==false)
                {
                    ID_HD = j.ID_HD;
                }
            }
            Tongtien(ID_HD);
            DGVFood.DataSource = BLLQLTS.Instance.GetDetailBill(ID_HD);
            DGVFood.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;

            /*int ID_BAN = Convert.ToInt32(((Button)sender).Text.ToString());
            BLLQLTS.Instance.GetDetailBill(ID_BAN);*/
            
        }

        private void cbbLHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID_HH = ((CbbItems)cbbLHH.SelectedItem).IDLHH;
            if (ID_HH == 0)
            {
                DGVOrder.DataSource = BLLQLTS.Instance.GetAllHH_View();
            }
            else
            {
                DGVOrder.DataSource = BLLQLTS.Instance.GetHH_ViewbyIDLHH(ID_HH);
            }
        }

        private void butSearch(object sender, EventArgs e)
        {
            string s = txtSearchTenHH.Text.ToString();
            DGVOrder.DataSource = BLLQLTS.Instance.GetHH_ViewByTenHH(s);
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (DGVOrder.SelectedRows.Count > 0)
            {
                if (Checkclick)
                {
                    if (lbSoluong.SelectedIndex > -1)
                    {
                        foreach (DataGridViewRow i in DGVOrder.SelectedRows)
                        {
                            CHI_TIET_HOA_DON b = new CHI_TIET_HOA_DON();
                            b.ID_CTHD= BLLQLTS.Instance.GetAllCTHD().Count+1;
                            foreach (BAN j in BLLQLTS.Instance.GetAllBan())
                            {
                                if (j.Tenban == Tenban)
                                {
                                    foreach(HOA_DON k in BLLQLTS.Instance.GetAllHD())
                                    {
                                        if (k.ID_BAN == j.ID_BAN && k.Thanhtoan == false)
                                        {
                                            b.ID_HD = k.ID_HD;
                                        }
                                    }
                                }
                            };
                            b.ID_HH = Convert.ToInt32(i.Cells["ID_HH"].Value.ToString());
                            b.soluong = lbSoluong.SelectedIndex + 1 ;
                            BLLQLTS.Instance.AddUpDetailBill(b);
                            Tongtien(b.ID_HD);
                            DGVFood.DataSource = BLLQLTS.Instance.GetDetailBill((int)b.ID_HD);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn số lượng");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn bàn!!!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đồ uống!!!");
            }
        }

        private void butKH_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên");
            }
            else
            {
                if (Checkclick)
                {
                    KHACHHANG k = new KHACHHANG
                    {
                        PhoneNumber = Convert.ToInt32(txtPhone.Text.ToString()),
                        Ten_KH = txtNameKH.Text.ToString()
                    };
                    BLLQLTS.Instance.AddUpdateKH(k);
                    LOAI_KHACH_HANG l = BLLQLTS.Instance.GetLKHByPhone(k.PhoneNumber);
                    foreach (CbbLKH i in BLLQLTS.Instance.GetCBBLKH())
                    {
                        if (i.ID_LKH == l.ID_LKH)
                        {
                            cbbLKH.SelectedIndex = i.ID_LKH - 1;
                            break;
                        }
                    }
                    HOA_DON h = new HOA_DON();
                    foreach (BAN i in BLLQLTS.Instance.GetAllBan())
                    {
                        if (i.Tenban == Tenban)
                        {
                            h.ID_BAN = i.ID_BAN;
                            h.ID_HD = BLLQLTS.Instance.GetAllHD().Count+1;
                        }
                    };
                    h.PhoneNumber = Convert.ToInt32(txtPhone.Text);
                    h.Gio_den = date;
                    h.Thanhtoan = false;
                    BLLQLTS.Instance.AddUpHD(h);
                    DGVFood.DataSource = BLLQLTS.Instance.GetDetailBill((int)h.ID_HD);
                    ShowstatTable();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn bàn");
                }
            }
        }

        private void cbbLKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbGG.SelectedIndex = Convert.ToInt32(cbbLKH.SelectedIndex.ToString());
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            if (DGVFood.SelectedRows.Count > 0)
            {
                MessageBox.Show("Bạn có muốn xóa không ?");
                CHI_TIET_HOA_DON b = new CHI_TIET_HOA_DON();
                b.ID_CTHD = BLLQLTS.Instance.GetAllCTHD().Count + 1;
                foreach (BAN j in BLLQLTS.Instance.GetAllBan())
                {
                    if (j.Tenban == Tenban)
                    {
                        foreach (HOA_DON k in BLLQLTS.Instance.GetAllHD())
                        {
                            if (k.ID_BAN == j.ID_BAN && k.Thanhtoan == false)
                            {
                                b.ID_HD = k.ID_HD;
                                Tongtien(b.ID_HD);
                            }
                        }
                    }
                };

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Formdoimatkhau f = new Formdoimatkhau();
            f.ShowDialog();
        }
    }
}

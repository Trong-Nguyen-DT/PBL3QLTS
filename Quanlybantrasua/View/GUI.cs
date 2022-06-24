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
    public partial class GUI : Form
    {
        DateTime date = DateTime.Now;
        public string Tennhanvien { get; set; }
        public GUI(string NameNV)
        {
            InitializeComponent();
            Tennhanvien = NameNV;
            ShowCBBItems();
            ShowDGVOrder();
            ShowstatTable();
            lbNameNV.Text = Tennhanvien;
        }
        Boolean Checkclick = false;
        String Tenban = "";
        int tongtien;
        public void Tongtien(int ID_HD)
        {
            tongtien = 0;
            foreach (CHI_TIET_HOA_DON i in BLLQLTS.Instance.GetAllCTHD())
            {
                if (i.ID_HD == ID_HD)
                {
                    foreach (HANGHOA j in BLLQLTS.Instance.GetAllHH())
                    {
                        if (j.ID_HH == i.ID_HH)
                        {
                            tongtien += Convert.ToInt32(i.soluong * j.Gia);
                        }
                    }
                }
            }
            txtTT.Text = tongtien.ToString();
        }
        public void GetTT(int ID_HD)
        {
            foreach (HOA_DON i in BLLQLTS.Instance.GetAllHD())
            {
                if (i.ID_HD == ID_HD)
                {
                    txtPhone.Text = i.PhoneNumber.ToString();
                    txtNameKH.Text = i.KHACHHANG.Ten_KH.ToString();
                    cbbLKH.SelectedIndex = i.KHACHHANG.ID_LKH.Value - 1;
                    break;
                }
                else
                {
                    txtPhone.Text = "";
                    txtNameKH.Text = "";
                    cbbLKH.SelectedIndex = -1;
                }
            }
        }
        public void ShowstatTable()
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
            DGVOrder.Columns[0].HeaderText = "Mã hàng hóa";
            DGVOrder.Columns[1].HeaderText = "Tên hàng hóa";
            DGVOrder.Columns[2].HeaderText = "Giá";
            DGVOrder.Columns[3].HeaderText = "Tình trạng";
        }
        public new void Click(object sender, EventArgs e)
        {
            Checkclick = true;
            Tenban = ((Button)sender).Name.ToString();
            butThucdon.Text = "Thực đơn " + ((Button)sender).Text;
            int ID_HD = 0;
            foreach (HOA_DON j in BLLQLTS.Instance.GetAllHD())
            {
                if (j.BAN.Tenban == Tenban && j.Thanhtoan == false)
                {
                    ID_HD = j.ID_HD;
                }
            }
            GetTT(ID_HD);
            Tongtien(ID_HD);
            DGVFood.DataSource = BLLQLTS.Instance.GetDetailBill(ID_HD);
            DGVFood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVFood.Columns[0].HeaderText = "Mã hàng hóa";
            DGVFood.Columns[1].HeaderText = "Tên hàng hóa";
            DGVFood.Columns[2].HeaderText = "Số lượng";

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
                if (Checkclick == true && txtPhone.Text != "")
                {
                    if (lbSoluong.SelectedIndex > -1)
                    {
                        foreach (DataGridViewRow i in DGVOrder.SelectedRows)
                        {
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
                                        }
                                    }
                                }
                            };
                            b.ID_HH = Convert.ToInt32(i.Cells["ID_HH"].Value.ToString());
                            b.soluong = lbSoluong.SelectedIndex + 1;
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
                            h.ID_HD = BLLQLTS.Instance.GetAllHD().Count + 1;
                        }
                    };
                    foreach (NHANVIEN i in BLLQLTS.Instance.GetAllNV())
                    {
                        if (i.Ten_NV == Tennhanvien)
                        {
                            h.ID_NV = i.ID_NV;
                        }
                    }
                    h.PhoneNumber = Convert.ToInt32(txtPhone.Text);
                    h.Gio_den = date;
                    h.Thanhtoan = false;
                    h.Diem_TL = 0;
                    BLLQLTS.Instance.AddUpHD(h);
                    DGVFood.DataSource = BLLQLTS.Instance.GetDetailBill(h.ID_HD);
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
            int ID_HH = 0;
            if (DGVFood.SelectedRows.Count > 0)
            {

                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa không?", "Xóa món", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow k in DGVFood.SelectedRows)
                    {
                        ID_HH = Convert.ToInt32(k.Cells["ID_HH"].Value.ToString());

                    }
                    foreach (HOA_DON i in BLLQLTS.Instance.GetAllHD())
                    {
                        if (i.BAN.Tenban == Tenban && i.Thanhtoan == false)
                        {
                            foreach (CHI_TIET_HOA_DON j in BLLQLTS.Instance.GetAllCTHD())
                            {
                                if (j.ID_HD == i.ID_HD && j.ID_HH == ID_HH)
                                {
                                    BLLQLTS.Instance.DelUpCTHD(j.ID_CTHD, 0);
                                    DGVFood.DataSource = BLLQLTS.Instance.GetDetailBill(i.ID_HD);
                                    Tongtien(j.ID_HD);
                                }
                            }
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }


            }
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            if (DGVFood.SelectedRows.Count == 1)
            {
                int ID_HH = 0;
                foreach (DataGridViewRow k in DGVFood.SelectedRows)
                {
                    ID_HH = Convert.ToInt32(k.Cells["ID_HH"].Value.ToString());

                }
                Formsuasoluong f = new Formsuasoluong(ID_HH, Tenban);
                f.ShowDialog();
                foreach (HOA_DON i in BLLQLTS.Instance.GetAllHD())
                {
                    if (i.BAN.Tenban == Tenban && i.Thanhtoan == false)
                    {
                        foreach (CHI_TIET_HOA_DON j in BLLQLTS.Instance.GetAllCTHD())
                        {
                            if (j.ID_HD == i.ID_HD && j.ID_HH == ID_HH)
                            {
                                DGVFood.DataSource = BLLQLTS.Instance.GetDetailBill(i.ID_HD);
                                Tongtien(j.ID_HD);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm muốn sửa");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thanh toán không?", "Thanh toán", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                HOA_DON s = new HOA_DON();
                foreach (HOA_DON i in BLLQLTS.Instance.GetAllHD())
                {
                    if (i.BAN.Tenban == Tenban && i.Thanhtoan == false)
                    {
                        s.ID_HD = i.ID_HD;
                    }
                }
                s.Gio_di = date;
                s.Tongtien = Convert.ToInt32(txtthanhtien.Text.ToString());
                s.discount = Convert.ToInt32(cbbGG.Text.ToString());
                s.Diem_TL = Convert.ToInt32(txtTT.Text.ToString()) / 1000;
                s.Thanhtoan = true;
                BLLQLTS.Instance.Thanhtoan(s);
                xemdon f = new xemdon(s.ID_HD);
                f.ShowDialog();
                DGVFood.DataSource = null;
                ShowstatTable();
                GetTT(s.ID_HD);
                txtTT.Text = "";

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Formdoimatkhau f = new Formdoimatkhau(Tennhanvien);
            f.ShowDialog();
        }

        private void txtTT_TextChanged(object sender, EventArgs e)
        {
            if (txtTT.Text != "" && cbbGG.SelectedIndex != -1)
            {
                txtthanhtien.Text = (Convert.ToInt32(txtTT.Text) * (100 - Convert.ToInt32(cbbGG.Text)) / 100).ToString();
            }
            else
            {
                txtthanhtien.Text = "";
            }
        }

        private void cbbGG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTT.Text != "" && cbbGG.SelectedIndex != -1)
            {
                txtthanhtien.Text = (Convert.ToInt32(txtTT.Text) * (100 - Convert.ToInt32(cbbGG.Text)) / 100).ToString();
            }
            else
            {
                txtthanhtien.Text = "";
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            foreach (HOA_DON i in BLLQLTS.Instance.GetAllHD())
            {
                if (i.BAN.Tenban == Tenban && i.Thanhtoan == false)
                {
                    Formchuyenban f = new Formchuyenban(i.ID_HD);
                    f.ShowDialog();
                }
            }
            BLLQLTS.Instance.GetState();
            ShowstatTable();


        }
    }
}

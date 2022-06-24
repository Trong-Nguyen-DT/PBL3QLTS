using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlybantrasua.DTO;

namespace Quanlybantrasua.BLL
{
    public class BLLQLTS
    {
        QUANLYBANTRASUAEntities1 db = new QUANLYBANTRASUAEntities1();
        private static BLLQLTS _Instance;
        public static BLLQLTS Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLLQLTS();
                }
                return _Instance;
            }
            private set { }
        }
        private BLLQLTS()
        {
           
        }
        public List<CbbLHH> GetCbbLHH()
        {
            List<CbbLHH> data = new List<CbbLHH>();
            foreach (Loai_HANGHOA i in db.Loai_HANGHOA)
            {
                data.Add(new CbbLHH
                {
                    ID_LHH = i.ID_LHH,
                    Ten_LHH = i.Ten_LHH
                });
            }
            return data;
        }
        public List<CbbLKH> GetCBBLKH()
        {
            List<CbbLKH> data = new List<CbbLKH>();
            foreach (LOAI_KHACH_HANG i in db.LOAI_KHACH_HANG)
            {
                data.Add(new CbbLKH
                {
                    ID_LKH = i.ID_LKH,
                    Ten_KH = i.Ten_LKH


                });
            }
            return data;
        }
        public List<CbbItems> GetCBB()
        {
            List<CbbItems> data = new List<CbbItems>();
            foreach (Loai_HANGHOA i in db.Loai_HANGHOA)
            {
                data.Add(new CbbItems
                {
                    IDLHH = i.ID_LHH,
                    TenLHH = i.Ten_LHH

                });
            }
            return data;
        }
        public List<HANGHOA> GetAllHH()
        {
            List<HANGHOA> data = new List<HANGHOA>();
            data = db.HANGHOAs.ToList();
            return data;
        }
        public List<Hanghoa_View> GetAllHH_View()
        {
            List<Hanghoa_View> data = new List<Hanghoa_View>();
            data = db.HANGHOAs.Where(p=>p.tinhTrang==true).Select(p => new Hanghoa_View { ID_HH = p.ID_HH,Ten_HH = p.Ten_HH,Gia=(int)p.Gia,tinhtrang = (Boolean)p.tinhTrang}).ToList();

            return data;
        }
        public List<Hanghoastate> GetAllHHTinhtrang()
        {
            List<Hanghoastate> data = new List<Hanghoastate>();
            data = db.HANGHOAs.Select(p => new Hanghoastate { ID_HH = p.ID_HH, Ten_HH = p.Ten_HH, Gia = (int)p.Gia,Tinhtrang=(bool)p.tinhTrang }).ToList();

            return data;
        }
        public List<Hanghoa_View> GetHH_ViewbyIDLHH(int ID_LHH)
        {
            List<Hanghoa_View> data = new List<Hanghoa_View>();
            foreach(HANGHOA i in GetAllHH())
            {
                if (i.ID_LHH == ID_LHH)
                {
                    data.Add(new Hanghoa_View
                    {
                        ID_HH= i.ID_HH,
                        Ten_HH=i.Ten_HH,
                        Gia = (int)i.Gia,
                        tinhtrang = (bool)i.tinhTrang
                    }
                    );
                }
            }
            return data;
        }
        public List<Hanghoa_View> GetHH_ViewByTenHH(string TenHH)
        {
            List<Hanghoa_View> data = new List<Hanghoa_View>();
            foreach(HANGHOA i in GetAllHH())
            {
                if (i.Ten_HH.Contains(TenHH))
                {
                    data.Add(new Hanghoa_View
                    {
                        ID_HH = i.ID_HH,
                        Ten_HH = i.Ten_HH,
                        Gia = (int)i.Gia,
                        tinhtrang = (bool)i.tinhTrang
                    });
                }
            }
            return data;
        }
        public void AddUpDetailBill(CHI_TIET_HOA_DON b)
        {
            if (CheckCTHD((int)b.ID_HD,(int)b.ID_HH))
            {
                db.CHI_TIET_HOA_DON.Add(b);
            }
            else
            {
                CHI_TIET_HOA_DON s = db.CHI_TIET_HOA_DON.Where(p => p.ID_HH == b.ID_HH && p.ID_HD==b.ID_HD).FirstOrDefault();
                s.soluong += b.soluong.Value;
            }
            db.SaveChanges();
        }
        public bool CheckCTHD(int ID_HD, int ID_HH)
        {
            //true->add,false->update
            foreach(CHI_TIET_HOA_DON i in db.CHI_TIET_HOA_DON)
            {
                if (i.ID_HD == ID_HD & i.ID_HH==ID_HH)
                {
                    return false;
                }
            }
            return true;
            
        }
        public List<ThanhtoanView> GetDetailBill(int IDHD)
        {
            List<ThanhtoanView> data = new List<ThanhtoanView>();
            data = db.CHI_TIET_HOA_DON.Where(p=>p.HOA_DON.ID_HD==IDHD&&p.soluong>0).Select(p => new ThanhtoanView { TenHH = p.HANGHOA.Ten_HH, Soluong = (int)p.soluong,Dongia=(int)p.HANGHOA.Gia, Gia=(int)(p.soluong*p.HANGHOA.Gia)}).ToList();
            return data;
        }
        public bool CheckKH(int PhoneNB)
        {
            //true->add;false->up
            foreach(KHACHHANG i in db.KHACHHANGs)
            {
                if (i.PhoneNumber == PhoneNB)
                {
                    return false;
                }
            }
            return true;
        }
        public void AddUpdateKH(KHACHHANG k)
        {
            if (CheckKH(k.PhoneNumber))
            {
                k.ID_LKH = 2;
                k.Diemtichluy = 0;
                db.KHACHHANGs.Add(k);
            }
            else
            {
                KHACHHANG s = db.KHACHHANGs.Where(p => p.PhoneNumber == k.PhoneNumber).FirstOrDefault();
                s.Ten_KH = k.Ten_KH;
                s.Diemtichluy += k.Diemtichluy;
                if (s.Diemtichluy > 500)
                {
                    s.ID_LKH = 2;
                }
            }
            db.SaveChanges();
        }
        public List<BAN> GetState()
        {
            List<BAN> data = new List<BAN>();
            foreach(HOA_DON i in db.HOA_DON) 
            {
                if (i.Thanhtoan != false)
                {
                    BAN s = db.BANs.Where(p => p.ID_BAN == i.ID_BAN).FirstOrDefault();
                    s.Tinhtrang = false;
                }
                else
                {
                    BAN s = db.BANs.Where(p => p.ID_BAN == i.ID_BAN).FirstOrDefault();
                    s.Tinhtrang = true;
                }

            }
            db.SaveChanges();
            data = db.BANs.ToList();
            return data;
        }
        public LOAI_KHACH_HANG GetLKHByPhone(int Phone)
        {
            LOAI_KHACH_HANG data = new LOAI_KHACH_HANG();
            KHACHHANG s = db.KHACHHANGs.Where(p => p.PhoneNumber == Phone).Select(p => p).FirstOrDefault();
            data = db.LOAI_KHACH_HANG.Where(p => p.ID_LKH == s.ID_LKH).Select(p => p).FirstOrDefault();
            return data;
        }
        public List<BAN> GetAllBan()
        {
            List<BAN> data = new List<BAN>();
            data = db.BANs.ToList();
            return data;
        }
        public bool CheckHoadon(HOA_DON b)
        {
           
            foreach (HOA_DON i in db.HOA_DON)
            {
                if (i.ID_BAN == b.ID_BAN&&i.Thanhtoan==false)
                {
                    return false;
                }
            }
            return true;
        }
        public void AddUpHD(HOA_DON  b)
        {
            if (CheckHoadon(b))
            {
                db.HOA_DON.Add(b);
            }
            else
            {
                HOA_DON s = db.HOA_DON.Where(p => p.ID_BAN == b.ID_BAN).Select(p => p).FirstOrDefault();
                s.PhoneNumber = b.PhoneNumber;
            }
            //db.HOA_DON.Add(b);
            db.SaveChanges();
        }
        public List<HOA_DON> GetAllHD()
        {
            List<HOA_DON> data = new List<HOA_DON>();
            data = db.HOA_DON.ToList();
            return data;
        }
        public List<CHI_TIET_HOA_DON> GetAllCTHD()
        {
            List<CHI_TIET_HOA_DON> data = new List<CHI_TIET_HOA_DON>();
            data = db.CHI_TIET_HOA_DON.ToList();
            return data;
        }
        public bool CheckAccount(string Name,string pass)
        {
            foreach(NHANVIEN i in db.NHANVIENs)
            {
                if(i.Ten_NV==Name && i.password == pass)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckPhanquyen(string Name)
        {
            foreach (NHANVIEN i in db.NHANVIENs)
            {
                if (i.Ten_NV == Name &&i.Phanquyen==true)
                {
                    return true;
                }
            }
            return false;
        }
       
        public void addhh(HANGHOA h)
        { 
            db.HANGHOAs.Add(h);
            db.SaveChanges();
        }
        public List<Loai_HANGHOA> GetAllLhh()
        {
            List<Loai_HANGHOA> data = new List<Loai_HANGHOA> ();
            data = db.Loai_HANGHOA.ToList();
            return data;
        }
        public void AddLhh(Loai_HANGHOA s)
        {
            db.Loai_HANGHOA.Add(s);
            db.SaveChanges ();
        }
        public List<string> GetAllTenLHH()
        {
            List<string> data = new List<string>();
            foreach(Loai_HANGHOA i in db.Loai_HANGHOA)
            {
                data.Add(i.Ten_LHH);
            }
            return data;
        }
        public void UpdateTinhtrang (int ID, bool TT)
        {
            if (TT == true)
            {
                HANGHOA s = db.HANGHOAs.Where(p => p.ID_HH == ID).FirstOrDefault();
                s.tinhTrang = false;
            }
            else
            {
                HANGHOA s = db.HANGHOAs.Where(p => p.ID_HH == ID).FirstOrDefault();
                s.tinhTrang = true;
            }
            db.SaveChanges();
        }
        public void UpdateGia(int ID, int Gia)
        {
            HANGHOA s = db.HANGHOAs.Where(p => p.ID_HH == ID).FirstOrDefault();
            s.Gia = Gia;
            db.SaveChanges();
        }
        public List<NHANVIEN> GetAllNV()
        {
            List<NHANVIEN> data = new List<NHANVIEN>();
            data = db.NHANVIENs.ToList();
            return data;
        }
        public void AddNV(NHANVIEN s)
        {
            db.NHANVIENs.Add(s);
            db.SaveChanges();
        }
        public void UpdateNV(NHANVIEN s)
        {
            NHANVIEN n = db.NHANVIENs.Find(s.ID_NV);
            n.Ten_NV = s.Ten_NV;
            n.PhoneNumber = s.PhoneNumber;
            n.Gender = s.Gender;
            n.Phanquyen = s.Phanquyen;
            n.password = s.password;
            db.SaveChanges();
        }
        public NHANVIEN GetNVByID(int ID_NV)
        {
            NHANVIEN s = db.NHANVIENs.Find(ID_NV);
            return s;
        }
        public bool CheckAddNV(NHANVIEN s)
        {
            //true->Add,false->Update
            foreach (NHANVIEN i in db.NHANVIENs)
            {
                if (i.ID_NV == s.ID_NV)
                {
                    return false;
                }
            }
            return true;
        }
        public void AddUpdateNV(NHANVIEN s)
        {
            if (CheckAddNV(s) == true)
            {
                AddNV(s);
            }
            else
            {
                UpdateNV(s);
            }
        }
        public List<Nhanvien_View> GetNV_ViewByTenNV(string TenNV)
        {
            List<Nhanvien_View> data = new List<Nhanvien_View>();
            foreach (NHANVIEN i in GetAllNV())
            {
                if (i.Ten_NV.Contains(TenNV))
                {
                    data.Add(new Nhanvien_View
                    {
                        ID_NV = i.ID_NV,
                        Name = i.Ten_NV,
                        Gender = i.Gender,
                        PhoneNumber = i.PhoneNumber,
                        Phanquyen = i.Phanquyen,
                        password = i.password
                    });
                }
            }
            return data;
        }
        public void DelUpCTHD(int ID_CTHD,int soluong)
        {
            CHI_TIET_HOA_DON s = db.CHI_TIET_HOA_DON.Find(ID_CTHD);
            s.soluong = soluong;
            db.SaveChanges();
        }
        public void Thanhtoan(HOA_DON s)
        {
            HOA_DON data = db.HOA_DON.Find(s.ID_HD);
            data.Gio_di = s.Gio_di;
            data.discount = s.discount;
            data.Tongtien = s.Tongtien;
            data.Thanhtoan = s.Thanhtoan;
            data.Diem_TL = s.Diem_TL;
            db.SaveChanges();
            KHACHHANG k = db.KHACHHANGs.Find(data.PhoneNumber);
            k.Diemtichluy += s.Diem_TL;
            db.SaveChanges();


        }
        public List<Hoadon_View> TimKiem_hoadon(String TenKhachHang)
        {
            List<Hoadon_View> data = new List<Hoadon_View>();
            foreach (HOA_DON i in GetAllHD())
            {
                if (i.KHACHHANG.Ten_KH.ToString().Contains(TenKhachHang))
                {
                    data.Add(new Hoadon_View
                    {
                        ID_HD = i.ID_HD,
                        ID_BAN = (int)i.ID_BAN,
                        TenNV = i.NHANVIEN.Ten_NV,
                        PhoneNumber = (int)i.PhoneNumber,
                        Gio_den = (DateTime)i.Gio_den,
                        Gio_di = (DateTime)i.Gio_di,
                        Tongtien = (int)i.Tongtien,
                        discount = (int)i.discount,
                        Tenkhachhang = i.KHACHHANG.Ten_KH,
                        Thanhtoan = (bool)i.Thanhtoan

                    });
                }
            }
            return data;

        }
        public List<Hoadon_View> GetListHDByTG(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            List<Hoadon_View> listHoaDon = new List<Hoadon_View>();
            listHoaDon = db.HOA_DON.Where(p => p.Gio_di >= ngayBatDau && p.Gio_di <= ngayKetThuc).Select(p => new Hoadon_View { ID_HD = p.ID_HD, ID_BAN = (int)p.ID_BAN, TenNV = p.NHANVIEN.Ten_NV, PhoneNumber = (int)p.PhoneNumber, Gio_den = (DateTime)p.Gio_den, Gio_di = (DateTime)p.Gio_di, discount = (int)p.discount, Tongtien = (int)p.Tongtien, Tenkhachhang = p.KHACHHANG.Ten_KH, Thanhtoan = (bool)p.Thanhtoan }).ToList().ToList();
            return listHoaDon;
        }
        public double tongdoanhthu(List<Hoadon_View> doanhthu)
        {

            double result = 0;
            foreach (Hoadon_View i in doanhthu)
            {
                result += i.Tongtien;
            }
            return result;
        }
        public List<CTDTView> GetCTDT(int IDHD)
        {
            List<CTDTView> data = new List<CTDTView>();
            data = db.CHI_TIET_HOA_DON.Where(p => p.ID_HD == IDHD&&p.soluong>0).Select(p => new CTDTView { TenHH = p.HANGHOA.Ten_HH, Soluong = (int)p.soluong, Gia = (int)p.HANGHOA.Gia }).ToList();
            return data;
        }
        public List<Hoadon_View> GetAllHDView()
        {
            List<Hoadon_View> data = new List<Hoadon_View>();
            data = db.HOA_DON.Where(p => p.Thanhtoan == true).Select(p => new Hoadon_View { ID_HD = p.ID_HD, ID_BAN = (int)p.ID_BAN, TenNV = p.NHANVIEN.Ten_NV, PhoneNumber = (int)p.PhoneNumber, Gio_den = (DateTime)p.Gio_den, Gio_di = (DateTime)p.Gio_di, discount = (int)p.discount, Tongtien = (int)p.Tongtien, Tenkhachhang = p.KHACHHANG.Ten_KH, Thanhtoan = (bool)p.Thanhtoan }).ToList();
            return data;
        }
        public double tongtien(List<CTDTView> chitiet)
        {

            double result = 0;
            foreach (CTDTView i in chitiet)
            {
                result += i.Soluong*i.Gia;
            }
            return result;
        }
        public void UpdateBan(HOA_DON s)
        {
            HOA_DON data = db.HOA_DON.Find(s.ID_HD);
            data.ID_BAN = s.ID_BAN;
            db.SaveChanges();
        }
        public void UpdatePass(NHANVIEN s)
        {
            NHANVIEN data = db.NHANVIENs.Find(s.ID_NV);
            data.password = s.password;
            db.SaveChanges();
        }
    }
}

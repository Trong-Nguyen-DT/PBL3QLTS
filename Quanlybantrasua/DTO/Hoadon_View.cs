using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlybantrasua.DTO
{
    public class Hoadon_View
    {
        public int ID_HD { get; set; }
        public int ID_BAN { get; set; }
        public string TenNV { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Gio_den { get; set; }
        public DateTime Gio_di { get; set; }
        public int Tongtien { get; set; }
        public int discount { get; set; }
        public string Tenkhachhang { get; set; }
        public bool Thanhtoan { get; set; }
    }
}

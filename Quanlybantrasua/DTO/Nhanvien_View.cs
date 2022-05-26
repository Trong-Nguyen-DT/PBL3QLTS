using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlybantrasua.DTO
{
    public class Nhanvien_View
    {
        public int ID_NV { get; set; }
        public string Name { get; set; }

        public Nullable<bool> Gender { get; set; }
        public Nullable<int> PhoneNumber { get; set; }
        public Nullable<bool> Phanquyen { get; set; }
        public string password { get; set; }
    }
}

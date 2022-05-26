using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlybantrasua.DTO
{
    public class CbbLKH
    {
        public int ID_LKH { get; set; }
        public string Ten_KH { get; set; } 
        public override string ToString()
        {
            return Ten_KH;
        }
    }
}

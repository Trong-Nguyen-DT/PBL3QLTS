using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlybantrasua.DTO
{
    public class CbbItems
    {
        public int IDLHH { get; set; }
        public string TenLHH { get; set; }
        public override string ToString()
        {
            return TenLHH;
        }
    }
}

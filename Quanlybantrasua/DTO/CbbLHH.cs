using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlybantrasua.DTO
{
    public class CbbLHH
    {
        public int ID_LHH { get; set; }
        public string Ten_LHH { get; set; }
        public override string ToString()
        {
            return Ten_LHH;
        }

    }
}

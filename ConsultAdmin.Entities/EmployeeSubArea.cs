using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdmin.Entities
{
    public class EmployeeSubArea
    {
        public int SubAreaId { get; set; }
        public int AreaId { get; set; }
        public string SubArea { get; set; }
        public bool IsSubArea { get; set; }
        //public List<EmployeeSkill> Skills { get; set; }

        public bool SubAreaTextVisible { get; set; }
        public bool SubAreaImgDown { get; set; }
        public bool SubAreaImgUp { get; set; }
    }
}

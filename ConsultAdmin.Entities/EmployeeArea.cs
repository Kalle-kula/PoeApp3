using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdmin.Entities
{
    public class EmployeeArea
    {
        public int AreaId { get; set; }
        public string Area { get; set; }
        public bool IsArea { get; set; }

        public bool AreaImgDownClicked { get; set; }
        public bool AreaImgUpClicked { get; set; }
        public bool SubAreaTextVisible { get; set; }
        public bool SubAreaImgDown { get; set; }
        public bool SubAreaImgUp { get; set; }
        public bool SkillTextVisible { get; set; }

        //public List<EmployeeSubArea> SubAreas { get; set; }


    }
}

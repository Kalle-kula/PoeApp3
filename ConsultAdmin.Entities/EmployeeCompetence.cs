using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdmin.Entities
{
    public class EmployeeCompetence : BaseModel
    {
        public EmployeeCompetence()
        {
            EmployeeAreas = new EmployeeArea();
            EmployeeSubAreas = new EmployeeSubArea();
            EmployeeSkills = new EmployeeSkills();
        }

        public EmployeeCompetence(EmployeeArea area)
        {
            EmployeeAreas = area;
            IsArea = true;
            EmployeeSubAreas = new EmployeeSubArea();
            EmployeeSkills = new EmployeeSkills();
        }
        //private List<EmployeeArea> _employeeAreas;
        public EmployeeArea EmployeeAreas { get; set; }
        public EmployeeSubArea EmployeeSubAreas { get; set; }
        public EmployeeSkills EmployeeSkills { get; set; }

        public bool IsArea { get; set; }
        public bool IsSubArea { get; set; }
        public bool IsSkill { get; set; }
    }
}

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
            EmployeeAreas = new EmployeeAreas();
            EmployeeTypes = new EmployeeTypes();
            EmployeeSkills = new EmployeeSkills();
        }

        public EmployeeCompetence(EmployeeAreas area)
        {
            
            EmployeeAreas = area;

            EmployeeTypes = new EmployeeTypes();

            foreach (var type in area.EmployeeTypes)
            {
                EmployeeTypes = type;
            }
            EmployeeSkills = new EmployeeSkills();

            foreach (var skills in EmployeeTypes.EmployeeSkills)
            {
                EmployeeSkills = skills;
            }


        }
        public EmployeeAreas EmployeeAreas { get; set; }
        public EmployeeTypes EmployeeTypes { get; set; }
        public EmployeeSkills EmployeeSkills { get; set; }
        //private List<EmployeeArea> _employeeAreas;
        //public EmployeeAreas EmployeeAreas { get; set; }
        //public EmployeeSubArea EmployeeSubAreas { get; set; }
        //public EmployeeSkills EmployeeSkills { get; set; }

        //public bool IsArea { get; set; }
        //public bool IsSubArea { get; set; }
        //public bool IsSkill { get; set; }
    }
}

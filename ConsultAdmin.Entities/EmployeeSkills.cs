using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdmin.Entities
{
    public class EmployeeSkills
    {

        public int SkillId { get; set; }
        public bool IsSkill { get; set; }
        public int AreaId { get; set; }
        public int SubAreaId { get; set; }
        public string Skill { get; set; }
        public int SkillGrade { get; set; }
    }
}

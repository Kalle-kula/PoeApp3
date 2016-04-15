using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdmin.Entities
{
    public class EmployeeSkills
    {
        //public List<EmployeeSkills> EmployeeSkillsList { get; set; }

        public int AreaId { get; set; }
        public string Area { get; set; }
        public List<EmployeeSubArea> SubAreas { get; set; }
        //public class EmployeeArea
        //{
            
        //}

        public class EmployeeSubArea
        {
            public int SubAreaId { get; set; }
            public int AreaId { get; set; }
            public string SubArea { get; set; }
            public List<EmployeeSkill> Skills { get; set; }
        }

        public class EmployeeSkill
        {
            public int SkillId { get; set; }
            public int AreaId { get; set; }
            public int SubAreaId { get; set; }
            public string Skill { get; set; }
            public int SkillGrade { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdmin.Entities
{
    public class Skill
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int Level { get; set; }


        public string Description { get; set; }

        public DateTime LastUpdate { get; set; }

        public List<EmployeeSkill> SkillEmployees { get; set; }
    }
}

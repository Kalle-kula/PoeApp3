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
        public int AreaId { get; set; }
        public int TypeId { get; set; }
        public string SkillName { get; set; }
        public int Level { get; set; }
    }
}

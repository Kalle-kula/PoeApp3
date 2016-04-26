using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdmin.Entities
{
    public class EmployeeSkill
    {
        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int TypeId { get; set; }
        public string Typename { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int Level { get; set; }
        public string Comment { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}

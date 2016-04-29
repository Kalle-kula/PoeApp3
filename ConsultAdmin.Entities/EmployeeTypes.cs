using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdmin.Entities
{
    public class EmployeeTypes
    {
        public int AreaId { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public List<EmployeeSkills> EmployeeSkills { get; set; }
    }
}

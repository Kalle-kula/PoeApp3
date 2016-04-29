using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdmin.Entities
{
    public class EmployeeAreas
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }

        public List<EmployeeTypes> EmployeeTypes { get; set; }
    }
}

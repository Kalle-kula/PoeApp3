using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdmin.Entities
{
    public class EmployeeDetail : Employee
    {
        public int FTEPercentage { get; set; }


        public List<VirtualAddress> EmployeeVirtualAddresses { get; set; } = new List<VirtualAddress>();
        public List<PhysicalAddress> EmployeePhysicalAddresses { get; set; } = new List<PhysicalAddress>();

        public List<EmployeeContract> EmployeeContracts { get; set; } = new List<EmployeeContract>();

    }
}

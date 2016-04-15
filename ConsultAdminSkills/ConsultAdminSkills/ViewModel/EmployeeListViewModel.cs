using ConsultAdmin.Entities;
using ConsultAdminSkills.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdminSkills.ViewModel
{
    public class EmployeeListViewModel : BaseViewModel
    {
        public ObservableCollection<Employee> EmployeesCollection { get; set; }
        private readonly EmployeeManager _employeeManager;
        public EmployeeListViewModel()
        {
            EmployeesCollection = new ObservableCollection<Employee>();
            _employeeManager = new EmployeeManager();
        }

        public async Task FillEmployeeList()
        {
            
            var employees = await _employeeManager.GetAllEmployees() as List<Employee>;

            if (employees != null)
            {
                EmployeesCollection.Clear();
                foreach (var employee in employees)
                {
                    EmployeesCollection.Add(employee);
                }
                
            }
            
        }

    }
}

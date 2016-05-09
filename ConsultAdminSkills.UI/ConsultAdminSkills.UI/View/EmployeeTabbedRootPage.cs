using ConsultAdminSkills.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConsultAdminSkills.UI.View
{
    public class EmployeeTabbedRootPage : TabbedPage
    {
        public EmployeeTabbedRootPage(EmployeeViewModel employeeViewModel)
        {
            Children.Add(new NavigationPage(new EmployeeGeneralPage(employeeViewModel)) { Title = "General" });
            Children.Add(new NavigationPage(new EmployeeSkillsPage(employeeViewModel)) { Title = "Skills" });
            Children.Add(new NavigationPage(new EmployeeProjectsPage()) { Title = "Project" });
            Children.Add(new NavigationPage(new EmployeeInfoPage()) { Title = "Info" });
        }
    }
}

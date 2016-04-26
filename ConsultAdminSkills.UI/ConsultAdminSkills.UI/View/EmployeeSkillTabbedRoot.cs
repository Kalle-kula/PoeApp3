using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConsultAdminSkills.UI.View
{
    public class EmployeeSkillTabbedRoot : TabbedPage
    {
        public EmployeeSkillTabbedRoot()
        {
            Children.Add(new NavigationPage(new EmployeeSkillDescriptionPage()) { Title = "Description" });
            Children.Add(new NavigationPage(new EmployeeSkillLevelListPage()) { Title = "Employees" });
        }
    }
}

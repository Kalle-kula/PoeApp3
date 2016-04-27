using ConsultAdminSkills.ViewModel;
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
        
        public EmployeeSkillTabbedRoot(int skillId)
        {
            Children.Add(new NavigationPage(new EmployeeSkillDescriptionPage(skillId)) { Title = "Description" });
            Children.Add(new NavigationPage(new EmployeeSkillLevelListPage(skillId)) { Title = "Employees" });
        }
    }
}

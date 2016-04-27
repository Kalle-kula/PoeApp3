using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultAdminSkills.ViewModel;

using Xamarin.Forms;

namespace ConsultAdminSkills.UI.View
{

    public partial class EmployeeSkillLevelListPage : ContentPage
    {
        private EmployeeCompetenceViewModel _employeeCompetenceViewModel;
        private int skillId;

        public EmployeeSkillLevelListPage(int skillId)
        {
            InitializeComponent();
            _employeeCompetenceViewModel = new EmployeeCompetenceViewModel();
            BindingContext = _employeeCompetenceViewModel;

            this.skillId = skillId;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _employeeCompetenceViewModel.SetSkillDescription(skillId);
        }
    }
}

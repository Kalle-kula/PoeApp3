using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultAdminSkills.ViewModel;

using Xamarin.Forms;

namespace ConsultAdminSkills.UI.View
{
    public partial class EmployeeSkillDescriptionPage : ContentPage
    {
        //private EmployeeSkillViewModel _employeeSkillViewModel;
        private EmployeeCompetenceViewModel _employeeCompetenceViewModel;
        private int skillId;
        public EmployeeSkillDescriptionPage(int skillId)
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

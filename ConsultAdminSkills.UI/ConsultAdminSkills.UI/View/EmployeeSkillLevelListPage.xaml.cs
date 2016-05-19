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
        private int _skillId;

        public EmployeeSkillLevelListPage(int skillId)
        {
            InitializeComponent();
            _employeeCompetenceViewModel = new EmployeeCompetenceViewModel();
            BindingContext = _employeeCompetenceViewModel;

            this._skillId = skillId;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _employeeCompetenceViewModel.SetSkillDescription(_skillId);
        }

        //private async void AddTapped(object sender, EventArgs e)
        //{
        //    var eventArgsConvert = (TappedEventArgs)e;
        //    var addSkillClicked = eventArgsConvert.Parameter;
        //}

        //private async void EditTapped(object sender, EventArgs e)
        //{
        //    var eventArgsConvert = (TappedEventArgs)e;
        //    var dateClicked = eventArgsConvert.Parameter;
        //}

        //private async void DeleteTapped(object sender, EventArgs e)
        //{
        //    var eventArgsConvert = (TappedEventArgs)e;
        //    var dateClicked = eventArgsConvert.Parameter;
        //}

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultAdminSkills.ViewModel;
using XLabs;
using Xamarin.Forms;

namespace ConsultAdminSkills.UI.View
{
    public partial class AddCompetencePage : ContentPage
    {
        private EmployeeSkillViewModel _employeeSkillViewModel;
        private int EmployeeId;
        public AddCompetencePage()
        //int id
        {
            InitializeComponent();
            EmployeeId = 3;
            BindingContext = _employeeSkillViewModel;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _employeeSkillViewModel = new EmployeeSkillViewModel();
            await _employeeSkillViewModel.SetEmployeeSkillLists(EmployeeId);
            //    //_employeeSkillViewModel.VerfifyUser(employeeId);
            //    //await _employeeSkillViewModel.SetEmployeeSkillLists(employeeId);
            }
        }
}

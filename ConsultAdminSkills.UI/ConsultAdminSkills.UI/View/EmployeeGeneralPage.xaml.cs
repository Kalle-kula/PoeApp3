using ConsultAdminSkills.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ConsultAdminSkills.UI.View
{
    public partial class EmployeeGeneralPage : ContentPage
    {
        private readonly EmployeeViewModel _employeeViewModel;

        public EmployeeGeneralPage(EmployeeViewModel employeeViewModel)
        {
            if (employeeViewModel != null)
            {
                _employeeViewModel = employeeViewModel;
            }
            InitializeComponent();
            //_employeeViewModel = new EmployeeViewModel();
            BindingContext = _employeeViewModel;
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await _employeeViewModel.GetExtendedEmployee();
        //}


        private async void HomeAddressTapped(object sender, EventArgs e)
        {
            if (_employeeViewModel.HasHomeAddress)
            {
                await _employeeViewModel.NavigateToClickedHomeAddress();
            }
        }

        private async void WorkAddressTapped(object sender, EventArgs e)
        {
            if (_employeeViewModel.HasWorkAddress)
            {
                await _employeeViewModel.NavigateToClickedWorkAddress();
            }
        }

    }
}

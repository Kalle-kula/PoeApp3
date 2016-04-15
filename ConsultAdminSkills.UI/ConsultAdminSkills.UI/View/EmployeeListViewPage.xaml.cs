using ConsultAdminSkills.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ConsultAdminSkills.UI.View
{
    public partial class EmployeeListViewPage : ContentPage
    {
        private EmployeeListViewModel _employeeListViewModel;

        public EmployeeListViewPage()
        {
            InitializeComponent();
            _employeeListViewModel = new EmployeeListViewModel();
            BindingContext = _employeeListViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _employeeListViewModel.FillEmployeeList();
        }

        private async void EmployeeListViewItems_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return;
            var employeeClicked = e.Item;
            EmployeeViewModel employeeViewModel = new EmployeeViewModel(employeeClicked);
            await employeeViewModel.GetExtendedEmployee();

            await Navigation.PushModalAsync(new EmployeeTabbedRootPage(employeeViewModel));
        }
    }
}

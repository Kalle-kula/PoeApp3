using ConsultAdminSkills.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLabs;
using Xamarin.Forms;

namespace ConsultAdminSkills.UI.View
{
    public partial class EmployeeSkillsPage : ContentPage
    {
        //private EmployeeViewModel _employeeViewModel;
        private EmployeeSkillViewModel _employeeSkillViewModel;
        public EmployeeSkillsPage()
        {

            InitializeComponent();


            _employeeSkillViewModel = new EmployeeSkillViewModel();
            
                //if (employeeViewModel != null)
                //{
                //    _employeeViewModel = employeeViewModel;
                //}
                BindingContext = _employeeSkillViewModel;
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _employeeSkillViewModel.SetTextVisibleFalse();
        }

        private void EmployeeSkillList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return;
            var itemClicked = e.Item;
            

        }

        private void ToolbarItem_Edit(object sender, EventArgs e)
        {
            //Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(new EmployeeGeneralEditPage(_Navigation)));
        }
        private void AreaImgDownTapped(object sender, EventArgs e)
        {
            _employeeSkillViewModel.AreaImgUpClicked = true;
            _employeeSkillViewModel.AreaImgDownClicked = false;
            _employeeSkillViewModel.SubAreaTextVisible = true;
            _employeeSkillViewModel.SubAreaImgDown = true;

        }
        private void AreaImgUpTapped(object sender, EventArgs e)
        {
           _employeeSkillViewModel.SetTextVisibleFalse();
        }
        private void SubAreaImgDownTapped(object sender, EventArgs e)
        {
            _employeeSkillViewModel.SubAreaImgDown = false;
            _employeeSkillViewModel.SkillTextVisible = true;
            _employeeSkillViewModel.SubAreaImgUp = true;

        }
        private void SubAreaImgUpTapped(object sender, EventArgs e)
        {
            _employeeSkillViewModel.SubAreaImgDown = true;
            _employeeSkillViewModel.SkillTextVisible = false;
            _employeeSkillViewModel.SubAreaImgUp = false;
        }
    }
}

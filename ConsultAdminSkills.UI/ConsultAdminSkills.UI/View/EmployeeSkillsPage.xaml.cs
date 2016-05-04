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
            BindingContext = _employeeSkillViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _employeeSkillViewModel.SetSkillLists();
        }

        //private void EmployeeSkillList_OnItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    if (e == null) return;
        //    var itemClicked = e.Item;
        //}

        private void ToolbarItem_Edit(object sender, EventArgs e)
        {
            //Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(new EmployeeGeneralEditPage(_Navigation)));
        }
        private void AreaImgDownTapped(object sender, EventArgs e)
        {
            var eventArgsConvert = (TappedEventArgs)e;
            var imgClicked = eventArgsConvert.Parameter;
            _employeeSkillViewModel.OpenTypeName(imgClicked);

        }
        //private void AreaImgUpTapped(object sender, EventArgs e)
        //{
        //    var eventArgsConvert = (TappedEventArgs)e;
        //    var imgClicked = eventArgsConvert.Parameter;
        //    _employeeSkillViewModel.CloseTypeName(imgClicked);
        //}
        private void TypeNameImgDownTapped(object sender, EventArgs e)
        {
            var eventArgsConvert = (TappedEventArgs)e;
            var imgClicked = eventArgsConvert.Parameter;
            _employeeSkillViewModel.OpenSkillName(imgClicked);
        }
        //private void TypeNameImgUpTapped(object sender, EventArgs e)
        //{
        //    var eventArgsConvert = (TappedEventArgs)e;
        //    var imgClicked = eventArgsConvert.Parameter;
        //    _employeeSkillViewModel.CloseSkillName(imgClicked);
        //}
        private void SkillTapped(object sender, EventArgs e)
        {
            
            var eventArgsConvert = (TappedEventArgs)e;
            var skillClicked = eventArgsConvert.Parameter;
            int skillId = _employeeSkillViewModel.GetSkillId(skillClicked);
            Navigation.PushModalAsync(new EmployeeSkillTabbedRoot(skillId));
        }

        //public void DoStuff()
        //{
        //    int i = 2;
        //    int secoundInt =  GiveMeAValue(out i);
        //}
        //public int GiveMeAValue(out int i)
        //{
        //    i = 8;
        //    return 7;
        //}
    }
}

using ConsultAdminSkills.Interface;
using ConsultAdminSkills.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ConsultAdminSkills.UI.View
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }
        private void Emp_OnClicked(object sender, EventArgs e)
        {
            AppUI.MasterDetailPage.Detail = new NavigationPage(new EmployeeListViewPage());
            AppUI.MasterDetailPage.IsPresented = false;
        }
        private void Comp_OnClicked(object sender, EventArgs e)
        {
            AppUI.MasterDetailPage.Detail = new NavigationPage(new SkillsListPage());
            AppUI.MasterDetailPage.IsPresented = false;
        }
        private async void MenuLogout_OnClicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Close the application", "Do you also want to logout from the application?", "Yes", "No");
            if (response == true)
            {
                LocalStorageManager localStorage = new LocalStorageManager();
                localStorage.ClearUseridAndPassword();
            }
            DependencyService.Get<IApplicationUtilities>().CloseApp();
        }
        //private void MenuLatest_OnClicked(object sender, EventArgs e)
        //{
        //    AppUI.MasterDetailPage.Detail = new NavigationPage(new AddCompetencePage());
        //    AppUI.MasterDetailPage.IsPresented = false;
        //}
        
    }
}

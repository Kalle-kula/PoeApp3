using ConsultAdminSkills.Service;
using ConsultAdminSkills.UI.View;
using ConsultAdminSkills.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConsultAdminSkills.UI
{
    public class AppUI : Application
    {
        //EmployeeViewModel _employeeViewModel = new EmployeeViewModel();

        // public AppUI()
        //{
        //    // The root page of your application

        //    //MainPage = new EmployeeSkillsPage();

        //    MainPage = new EmployeeListViewPage();

        //    //MainPage = new SkillsListPage();

        //}
        public interface IAuthenticate
        {
            Task<bool> Authenticate();
        };

        public static MasterDetailPage MasterDetailPage;

        public AppUI()
        {
            var loginViewModel = new LoginViewModel();
            loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;

            //MainPage = new LoginPage(loginViewModel);   //<-- Enabla sen

            MainPage = new AddCompetencePage();  //<--Ta bort sen

        }

        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        void LoginViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var vm = sender as LoginViewModel;
            switch (e.PropertyName)
            {
                case "LoginRequired":
                    {
                        if (vm != null && vm.LoginRequired)
                        {
                            if (!(MainPage is LoginPage))
                            {
                                MainPage = new LoginPage(vm);
                            }
                        }
                        else
                        {

                            MasterDetailPage = new MasterDetailPage
                            {
                                Master = new MenuPage(),
                                Detail = new NavigationPage(new EmployeeListViewPage())
                            };
                            MainPage = MasterDetailPage;
                        }
                        break;
                    }
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

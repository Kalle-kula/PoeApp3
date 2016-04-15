using ConsultAdminSkills.Service;
using ConsultAdminSkills.UI.View;
using ConsultAdminSkills.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ConsultAdminSkills.UI
{
    public class AppUI : Application
    {
        //EmployeeViewModel _employeeViewModel = new EmployeeViewModel();

         public AppUI()
        {
            // The root page of your application
            MainPage = new EmployeeSkillsPage();
            //MainPage = new EmployeeTabbedRootPage();

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

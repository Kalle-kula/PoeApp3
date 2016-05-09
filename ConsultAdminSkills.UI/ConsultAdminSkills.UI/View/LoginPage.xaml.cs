using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultAdminSkills.ViewModel;

using Xamarin.Forms;
using XLabs;

namespace ConsultAdminSkills.UI.View
{
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel _loginViewModel;

        public LoginPage(LoginViewModel loginViewModel)
        {
            BindingContext = _loginViewModel = loginViewModel;

            InitializeComponent();
        }
        private void Login_OnClicked(object sender, EventArgs e)
        {
            string userName = EntryUsername.Text.Trim().ToLower();
            string password = EntryPassword.Text.Trim();
            bool rememberMe = CBRemember.Checked;
            if ((userName != null) && password != null)
            {
                _loginViewModel.Login(userName, password, rememberMe);
            }
        }

        private void Cb_CheckedChanged(object sender, EventArgs<bool> e)
        {

        }

        private void EntryInput_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string userName = EntryUsername.Text;
            string password = EntryPassword.Text;
            if ((userName != null) && password != null)
            {
                LoginButton.IsEnabled = true;
            }
            else
            {
                LoginButton.IsEnabled = false;
            }
        }
    }
}

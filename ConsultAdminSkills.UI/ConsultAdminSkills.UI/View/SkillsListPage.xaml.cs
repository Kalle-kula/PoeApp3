using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultAdminSkills.ViewModel;

using Xamarin.Forms;

namespace ConsultAdminSkills.UI.View
{
    public partial class SkillsListPage : ContentPage
    {
        private SkillViewModel _skillViewModel;

        public SkillsListPage()
        {
            InitializeComponent();
            _skillViewModel = new SkillViewModel();
            BindingContext = _skillViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _skillViewModel.SetSkillLists();
        }

        private void AreaImgDownTapped(object sender, EventArgs e)
        {
            var eventArgsConvert = (TappedEventArgs)e;
            var imgClicked = eventArgsConvert.Parameter;
            _skillViewModel.OpenTypeName(imgClicked);

        }
        private void TypeNameImgDownTapped(object sender, EventArgs e)
        {
            var eventArgsConvert = (TappedEventArgs)e;
            var imgClicked = eventArgsConvert.Parameter;
            _skillViewModel.OpenSkillName(imgClicked);
        }
        private void SkillTapped(object sender, EventArgs e)
        {
            var eventArgsConvert = (TappedEventArgs)e;
            var skillClicked = eventArgsConvert.Parameter;
            int skillId = _skillViewModel.GetSkillId(skillClicked);
            Navigation.PushModalAsync(new EmployeeSkillTabbedRoot(skillId));
        }
    }
}

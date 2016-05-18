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
            _employeeSkillViewModel = new EmployeeSkillViewModel();
            CreateAreaNameList();

            
            BindingContext = _employeeSkillViewModel;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetAreaPicker();
            //await SetAreaPicker();
            //_employeeSkillViewModel = new EmployeeSkillViewModel();
            //await _employeeSkillViewModel.SetEmployeeSkillLists(EmployeeId);
            //    //_employeeSkillViewModel.VerfifyUser(employeeId);
            //    //await _employeeSkillViewModel.SetEmployeeSkillLists(employeeId);
        }

        private async void CreateAreaNameList()
        {
            await _employeeSkillViewModel.LoadSkills();

            foreach (var areaName in _employeeSkillViewModel.AreaNameList)
            {
                AreaPicker.Items.Add(areaName);
            }

            foreach (var typeName in _employeeSkillViewModel.TypeNameList)
            {
                TypePicker.Items.Add(typeName);
            }

            foreach (var skillName in _employeeSkillViewModel.SkillNameList)
            {
                SkillPicker.Items.Add(skillName);
            }

            AreaPicker.SelectedIndex = 0;
        }

        private void SetAreaPicker()
        {
            AreaPicker.SelectedIndexChanged += (sender, args) =>
            {
                _employeeSkillViewModel.AreaIndexChanged(AreaPicker.SelectedIndex);

                TypePicker.Items.Clear();

                foreach (var typeName in _employeeSkillViewModel.TypeNameList)
                {
                    TypePicker.Items.Add(typeName);
                }

                if (TypePicker.Items.Any())
                {
                    TypePicker.SelectedIndex = 0;
                    SetSkillPicker();
                }
            };
        }

        private void SetSkillPicker()
        {
            TypePicker.SelectedIndexChanged += (sender, args) =>
            {
                _employeeSkillViewModel.TypeIndexChanged(TypePicker.SelectedIndex);

                SkillPicker.Items.Clear();
                foreach (var skillName in _employeeSkillViewModel.SkillNameList)
                {
                    SkillPicker.Items.Add(skillName);
                }
                if (SkillPicker.Items.Any())
                {
                    SkillPicker.SelectedIndex = 0;
                }
            };
        }
    }
}

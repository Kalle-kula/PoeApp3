using ConsultAdmin.Entities;
using ConsultAdminSkills.Fake;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdminSkills.ViewModel
{
    public class EmployeeSkillViewModel : BaseViewModel
    {

        public ObservableCollection<EmployeeSkills> EmployeeSkillsCollection { get; set; }
        public ObservableCollection<EmployeeSkills.EmployeeSubArea> SubAreaCollection { get; set; }
        public ObservableCollection<EmployeeSkills.EmployeeSkill> SkillCollection { get; set; }
        private EmployeeSkillFake _employeeSkillFake;
        //public List<EmployeeSkills> Area { get; set; }
        public List<EmployeeSkills.EmployeeSubArea> SubArea = new List<EmployeeSkills.EmployeeSubArea>();
        public List<EmployeeSkills.EmployeeSkill> Skill = new List<EmployeeSkills.EmployeeSkill>();
        List<EmployeeSkills> EmployeeSkillsList = new List<EmployeeSkills>();

        public EmployeeSkillViewModel()
        {
            SkillCollection = new ObservableCollection<EmployeeSkills.EmployeeSkill>();
            SubAreaCollection = new ObservableCollection<EmployeeSkills.EmployeeSubArea>();
            EmployeeSkillsCollection = new ObservableCollection<EmployeeSkills>();
            _employeeSkillFake = new EmployeeSkillFake();

            for (int i = 0; i < _employeeSkillFake.SkillId.Count; i++)
            {
                _employeeSkillFake.Skills.Add(new EmployeeSkills.EmployeeSkill()
                {
                    SkillId = _employeeSkillFake.SkillId[i],
                    Skill = _employeeSkillFake.Skill[i],
                    SkillGrade = _employeeSkillFake.SkillGrade[i],
                    //AreaId = _employeeSkillFake.AreaId[i],
                    //SubAreaId = _employeeSkillFake.SubAreaId[i]

                });
            }
            //SkillCollection.Clear();
            //foreach (var item in Skill)
            //{
            //    SkillCollection.Add(item);
            //}

            for (int i = 0; i < _employeeSkillFake.SubAreaId.Count; i++)
            {
                _employeeSkillFake.SubAreas.Add(new EmployeeSkills.EmployeeSubArea()
                {
                    SubAreaId = _employeeSkillFake.SubAreaId[i],
                    SubArea = _employeeSkillFake.SubArea[i],
                    Skills = _employeeSkillFake.Skills,
                    //AreaId = _employeeSkillFake.AreaId[i]

                });
            }
            //SubAreaCollection.Clear();
            //foreach (var subArea in SubArea)
            //{
            //    SubAreaCollection.Add(subArea);
            //}

            for (int i = 0; i < _employeeSkillFake.AreaId.Count; i++)
            {
                EmployeeSkillsList.Add(new EmployeeSkills()
                {
                    AreaId = _employeeSkillFake.AreaId[i],
                    Area = _employeeSkillFake.Area[i],
                    SubAreas = _employeeSkillFake.SubAreas
                });
            }
            EmployeeSkillsCollection.Clear();
            foreach (var skill in EmployeeSkillsList)
            {
                EmployeeSkillsCollection.Add(skill);
            }
            //var kolla = EmployeeSkillsCollection.FirstOrDefault(x => x.SubAreas)
    }

        public void AreaClicked()
        {

        }

        private bool _areaImgDownClicked;
        private bool _areaImgUpClicked;
        private bool _subAreaTextVisible;
        private bool _subAreaImgDown;
        private bool _subAreaImgUp;
        private bool _skillTextVisible;

        //public bool AreaImgDownClicked { get; set; }


        public bool AreaImgDownClicked
        {
            get { return _areaImgDownClicked; }
            set
            {
                if (_areaImgDownClicked != value)
                {
                    SetPropertyField(nameof(AreaImgDownClicked), ref _areaImgDownClicked, value);
                }
            }
        }

        public bool AreaImgUpClicked
        {
            get { return _areaImgUpClicked; }
            set
            {
                if (_areaImgUpClicked != value)
                {
                    SetPropertyField(nameof(AreaImgUpClicked), ref _areaImgUpClicked, value);
                }
            }
        }

        public bool SubAreaTextVisible
        {
            get { return _subAreaTextVisible; }
            set
            {
                if (_subAreaTextVisible != value)
                {
                    SetPropertyField(nameof(SubAreaTextVisible), ref _subAreaTextVisible, value);
                }
            }
        }

        public bool SubAreaImgDown
        {
            get { return _subAreaImgDown; }
            set
            {
                if (_subAreaImgDown != value)
                {
                    SetPropertyField(nameof(SubAreaImgDown), ref _subAreaImgDown, value);
                }
            }
        }

        public bool SubAreaImgUp
        {
            get { return _subAreaImgUp; }
            set
            {
                if (_subAreaImgUp != value)
                {
                    SetPropertyField(nameof(SubAreaImgUp), ref _subAreaImgUp, value);
                }
            }
        }

        public bool SkillTextVisible
        {
            get { return _skillTextVisible; }
            set
            {
                if (_skillTextVisible != value)
                {
                    SetPropertyField(nameof(SkillTextVisible), ref _skillTextVisible, value);
                }
            }
        }
        public void SetTextVisibleFalse()
        {
            AreaImgDownClicked = true;
            SubAreaTextVisible = false;
            AreaImgUpClicked = false;
            SubAreaImgDown = false;
            SubAreaImgUp = false;
            SkillTextVisible = false;
        }
    }
}

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
        //public int AreaId { get; set; }

        private EmployeeSkillFake _employeeSkillFake;
        private EmployeeCompetence _employeeCompetence;
        public int AreaId { get; set; }
        public string Area { get; set; }
        //public List<EmployeeSubArea> SubAreas { get; set; }


        public void SetSkillLists()
        {
            //Fyller på alla modeller(EmployeeArea/SubArea/Skill) från fejken(EmployeeSkillFake)

            _employeeSkillFake = new EmployeeSkillFake();

            for (int i = 0; i < _employeeSkillFake.SkillIds.Count; i++)
            {
                _employeeSkillFake.Skills.Add(new EmployeeSkills()
                {
                    SkillId = _employeeSkillFake.SkillIds[i],
                    Skill = _employeeSkillFake.Skill[i],
                    SkillGrade = _employeeSkillFake.SkillGrade[i],

                });
            }

            for (int i = 0; i < _employeeSkillFake.SubAreaId.Count; i++)
            {
                _employeeSkillFake.SubAreas.Add(new EmployeeSubArea()
                //EmployeeSubAreaList.Add(new EmployeeSkills.EmployeeSubArea()

                {
                    SubAreaId = _employeeSkillFake.SubAreaId[i],
                    SubArea = _employeeSkillFake.SubArea[i],
                    //Skills = _employeeSkillFake.Skills,
                    //AreaId = _employeeSkillFake.AreaId[i]


                });
                //EmployeeSubAreaList = _employeeSkillFake.SubAreas;
            }

            for (int i = 0; i < _employeeSkillFake.AreaIds.Count; i++)
            {
                _employeeSkillFake.EmployeeAreaList.Add(new EmployeeArea()
                {
                    Area = _employeeSkillFake.Area[i],
                    //SubAreas = _employeeSkillFake.SubAreas,
                    AreaImgDownClicked = true,
                    SubAreaTextVisible = false,
                    AreaImgUpClicked = false,
                    SubAreaImgDown = false,
                    SubAreaImgUp = false,
                    SkillTextVisible = false
                });
            }

            var list = new List<EmployeeCompetence>();
            foreach (var item in _employeeSkillFake.EmployeeAreaList)
            {
                var competence = new EmployeeCompetence(item);
                //var employeeCompetence = new EmployeeCompetence();
                //employeeCompetence.EmployeeAreas = item;
                //employeeCompetence.IsArea = true;
                list.Add(competence);
            }

            //Fyller på EmployeeCompetence modellen
            //_employeeCompetence = new EmployeeCompetence();

            //_employeeCompetence.EmployeeAreas = _employeeSkillFake.EmployeeAreaList;
            //_employeeCompetence.EmployeeSubAreas = _employeeSkillFake.SubAreas;
            //_employeeCompetence.EmployeeSkills = _employeeSkillFake.Skills;

            //Fyller EmployeeCompetenceCollection
            EmployeeCompetenceCollection = new ObservableCollection<EmployeeCompetence>();
            EmployeeCompetenceCollection.Clear();
            EmployeeCompetenceCollection.Add(_employeeCompetence);

            string s = "";
        }

        public void SetSubAreaList(object param)
        {
            var imgClicked = param as EmployeeArea;
            if (imgClicked == null) return;

            AreaId = imgClicked.AreaId;
            Area = imgClicked.Area;
            //här ska kolla ursprungliga listan ändras .where(x => x.areaId == areaId) på den arean där man klickade

            //foreach (var item in EmployeeCompetenceList.Where(x => x.EmployeeAreas.AreaId == AreaId))
            
            //foreach (var list in EmployeeCompetenceCollection)
            //{
            //    foreach (var item in list.EmployeeAreas.Where(x => x.AreaId == AreaId))
            //    {
            //        item.AreaImgDownClicked = false;
            //        item.AreaImgUpClicked = true;
            //    }
                
            //}

            //AreaImgDownClicked = false;
            //AreaImgUpClicked = true;

            //EmployeeSkills.
            // Här måste ny SubAreaLista skapas och sättas

            //EmployeeSubAreaList = new List<EmployeeSubArea>();
            //Kollar vilken area som blivit klickad på genom att jämföra med ursprungliga listan och tar bort den inte klickade arean till ny lista (clickedArea)


            //foreach (var subArea in SubAreas)
            //{
            //    EmployeeSubAreaList.Add(subArea);
            //}


            //foreach (var item in EmployeeSubAreaList.Where(x => !x.SubAreaImgDown))
            //{
            //    item.SubAreaImgDown = true;
            //}

            string s = "";
        }
        public void CloseSubArea(object param)
        {
            var imgClicked = param as EmployeeCompetence;
            if (imgClicked == null) return;
            //AreaId = imgClicked.EmployeeAreas.AreaId;
            //Area = imgClicked.EmployeeAreas.Area;
            //SubAreas = imgClicked.EmployeeAreas.SubAreas;

            //foreach (var item in EmployeeCompetenceList.Where(x => x.EmployeeAreas.AreaId == AreaId))
            //{
            //    item.EmployeeAreas.AreaImgDownClicked = true;
            //    item.EmployeeAreas.AreaImgUpClicked = false;
            //}
        }

        private bool _areaImgDownClicked;
        private bool _areaImgUpClicked;
        private bool _subAreaImgDown;
        private bool _subAreaImgUp;
        private bool _skillTextVisible;
        private ObservableCollection<EmployeeCompetence> _employeeCompetenceCollection;

        public ObservableCollection<EmployeeCompetence> EmployeeCompetenceCollection
        {
            get { return _employeeCompetenceCollection; }
            set
            {
                if (_employeeCompetenceCollection != value)
                {
                    SetPropertyField(nameof(EmployeeCompetenceCollection), ref _employeeCompetenceCollection, value);
                }
            }
        }

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

    }
}

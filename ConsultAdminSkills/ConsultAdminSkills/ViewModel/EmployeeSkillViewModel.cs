using ConsultAdmin.Entities;
using ConsultAdminSkills.Fake;
using ConsultAdminSkills.Model;
using ConsultAdminSkills.Service;
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

        //private EmployeeSkillFake _employeeSkillFake;
        private SkillManager _skillManager;
        private Skill _skill;
        public int AreaId { get; set; }
        public string Area { get; set; }
        public int SkillId { get; set; }
        private SkillTreeModel _skillTreeModel;
        private EmployeeSkill _employeeSkill;
        private EmployeeSkillManager _employeeSkillManager;
        //int employeeId = 3; //fake för inloggad person


        public void VerfifyUser(int employeeId)
        {
            //Här kollas om den klickade employeen är samma som den inloggade (visar CRUD-funktioner i toolbaren)
            if (employeeId == CurrentUser.EmployeeId)
            {
                IsSameUser = true;
            }
            else
            {
                IsSameUser = false;
            }
        }

        public async Task SetEmployeeSkillLists(int employeeId)
        {
            EmployeeSkillsList = new List<EmployeeSkill>();
            _skillManager = new SkillManager();
            EmployeeSkillsList = await _skillManager.GetAllEmployeeSkills(employeeId);

            CreateHierarchyList();
            CreateFlatList();
        }

        public void CreateHierarchyList()
        {
            if (EmployeeSkillsList == null) return;

            AllSkills = new List<EmployeeAreas>();

            int typeId = 0;
            int areaId = 0;
            foreach (var skill in EmployeeSkillsList)
            {
                if (areaId != skill.AreaId)
                {
                    areaId = skill.AreaId;
                    var area = WrapToEmployeeArea(skill);
                    foreach (var innerSkill in EmployeeSkillsList.Where(x => x.AreaId == areaId))
                    {
                        if (typeId != innerSkill.TypeId)
                        {
                            typeId = innerSkill.TypeId;
                            EmployeeTypes typeSkill = WrapToEmployeeTypes(innerSkill);

                            foreach (var finalSkill in EmployeeSkillsList.Where(x => x.AreaId == areaId && x.TypeId == typeId))
                            {
                                typeSkill.EmployeeSkills.Add(WrapToEmployeeSkill(finalSkill));
                            }
                            area.EmployeeTypes.Add(typeSkill);
                        }
                    }
                    AllSkills.Add(area);
                }
            }

        }

        #region Wrapper
        private EmployeeAreas WrapToEmployeeArea(EmployeeSkill skill)
        {
            return new EmployeeAreas()
            {
                AreaName = skill.AreaName,
                AreaId = skill.AreaId,
                EmployeeTypes = new List<EmployeeTypes>()
            };
        }

        private EmployeeTypes WrapToEmployeeTypes(EmployeeSkill innerSkill)
        {
            return new EmployeeTypes()
            {
                TypeName = innerSkill.TypeName,
                TypeId = innerSkill.TypeId,
                AreaId = innerSkill.AreaId,
                EmployeeSkills = new List<EmployeeSkills>()
            };
        }

        public EmployeeSkills WrapToEmployeeSkill(EmployeeSkill finalSkill)
        {
            return new EmployeeSkills()
            {
                SkillName = finalSkill.SkillName,
                SkillId = finalSkill.SkillId,
                Level = finalSkill.Level,
                TypeId = finalSkill.TypeId
            };
        }
        #endregion

        private void CreateFlatList()
        {
            SkillTreeList = new List<SkillTreeModel>();
            if (AllSkills == null) return;
            foreach (var area in AllSkills)
            {
                SkillTreeList.Add(new SkillTreeModel()
                {
                    AreaId = area.AreaId,
                    AreaName = area.AreaName,
                    Description = area.AreaName,
                    IsArea = true,
                    IsVisible = true,
                    IsExpanded = false,
                });
                foreach (var type in area.EmployeeTypes)
                {
                    SkillTreeList.Add(new SkillTreeModel()
                    {
                        AreaId = type.AreaId,
                        TypeId = type.TypeId,
                        TypeName = type.TypeName,
                        Description = type.TypeName,
                        IsType = true,

                    });
                    foreach (var skill in type.EmployeeSkills)
                    {
                        SkillTreeList.Add(new SkillTreeModel()
                        {
                            AreaId = type.AreaId,
                            TypeId = skill.TypeId,
                            SkillId = skill.SkillId,
                            SkillName = skill.SkillName,
                            Description = skill.SkillName,
                            Level = skill.Level,
                            IsSkill = true
                        });
                    }
                }
            }
            string y = "";
        }

        public void ClickAreaEvent(int id)
        {
            //SkillTreeList = new SkillTreeModel();
            // Vi kan kolla vad som finns i modellobjektet
            var list = SkillTreeList.FirstOrDefault(x => x.AreaId == id);

            // Är den expanderad sätter vi det till det motsatta värdet
            list.IsExpanded = !list.IsExpanded;
            list.AreaImgDownClicked = !list.IsExpanded;

            // Hämtar ut alla undertyper och sätter visible till true.
            foreach (var type in SkillTreeList.Where(x => x.AreaId == id && x.IsType))
            {
                // Visa eller dölj underobjekten. (types
                type.IsVisible = list.IsExpanded;
                type.IsAreaClicked = list.IsExpanded;

                // Visa bara underobjekten (Skills) om både area och type är expanderade
                var isVisible = type.IsExpanded && type.IsVisible;
                foreach (var skill in SkillTreeList.Where(x => x.AreaId == id && x.TypeId == type.TypeId && x.IsSkill))
                {
                    skill.IsVisible = isVisible;
                }
            }

        }

        public void ClickTypeEvent(int id)
        {
            // Vi kan kolla vad som finns i modellobjektet
            var model = SkillTreeList.FirstOrDefault(x => x.TypeId == id);
            // Sätter om Expanderadvärdet
            model.IsExpanded = !model.IsExpanded;


            foreach (var skill in SkillTreeList.Where(x => x.AreaId == model.AreaId && model.TypeId == id && x.IsSkill))
            {
                skill.IsVisible = model.IsExpanded;
                skill.IsTypeClicked = model.IsExpanded;
            }
        }
        public void OpenTypeName(object param)
        {
            var imgClicked = param as SkillTreeModel;
            if (imgClicked == null) return;
            ClickAreaEvent(imgClicked.AreaId);
        }

        public void OpenSkillName(object param)
        {
            var imgClicked = param as SkillTreeModel;
            if (imgClicked == null) return;
            ClickTypeEvent(imgClicked.TypeId);
        }

        public int GetSkillId(object param)
        {
            var skillClicked = param as SkillTreeModel;
            int skillId = skillClicked.SkillId;
            return skillId;
        }

        private bool _isSameUser;
        public bool IsSameUser
        {
            get { return _isSameUser; }
            set
            {
                if (_isSameUser != value)
                {
                    SetPropertyField(nameof(IsSameUser), ref _isSameUser, value);
                }
            }
        }

        private List<SkillTreeModel> _skillTreeList;
        public List<SkillTreeModel> SkillTreeList
        {
            get { return _skillTreeList; }
            set
            {
                if (_skillTreeList != value)
                {
                    SetPropertyField(nameof(SkillTreeList), ref _skillTreeList, value);
                }
            }
        }

        private List<EmployeeSkill> _employeeSkillsList;
        public List<EmployeeSkill> EmployeeSkillsList
        {
            get { return _employeeSkillsList; }
            set
            {
                if (_employeeSkillsList != value)
                {
                    SetPropertyField(nameof(EmployeeSkillsList), ref _employeeSkillsList, value);
                }
            }
        }

        private List<EmployeeAreas> _allSkills;
        public List<EmployeeAreas> AllSkills
        {
            get { return _allSkills; }
            set
            {
                if (_allSkills != value)
                {
                    SetPropertyField(nameof(AllSkills), ref _allSkills, value);
                }
            }
        }

        private List<Skill> _skillsList;
        public List<Skill> AllSkillsList
        {
            get { return _skillsList; }
            set
            {
                if (_skillsList != value)
                {
                    SetPropertyField(nameof(AllSkillsList), ref _skillsList, value);
                }
            }
        }

        //AddCompetencePage

        public List<string> AreaNameList { get; set; }
        public List<string> TypeNameList { get; set; }
        public List<string> SkillNameList { get; set; }
        public async Task LoadSkills()
        {
            _skillManager = new SkillManager();
            AllSkillsList = new List<Skill>();
            AllSkillsList = await _skillManager.GetAllSkills();

            AreaNameList = new List<string>();

            if (AllSkillsList != null && AllSkillsList.Count > 0)
            {
                AreaNameList.AddRange(AllSkillsList.Select(x => x.AreaName).Distinct());
                var areaList = AllSkillsList.FirstOrDefault();

                List<string> TypeList = new List<string>();

                if (areaList != null)
                {
                    foreach (var areaName in AllSkillsList)
                    {
                        if (areaName.AreaName == areaList.AreaName)
                            TypeList.Add(areaName.AreaName);
                    }
                }
                TypeList.AddRange(AllSkillsList.Where(x => x.AreaName == AllSkillsList.FirstOrDefault().AreaName).Select(x => x.TypeName));

                var firstType = TypeList.FirstOrDefault();
                var matchingTypes = AllSkillsList.Where(x => x.AreaName == firstType).ToList();
                var type = matchingTypes.Select(x => x.TypeName).Distinct();

                TypeNameList = new List<string>();
                List<string> SkillList = new List<string>();

                foreach (var typeName in type)
                {
                    TypeNameList.Add(typeName);
                    SkillList.Add(typeName);
                }

                SkillList.AddRange(AllSkillsList.Where(x => x.TypeName == AllSkillsList.FirstOrDefault().TypeName).Select(x => x.TypeName));
                var firstSkill = SkillList.FirstOrDefault();
                var matchingSkills = AllSkillsList.Where(x => x.TypeName == firstSkill).ToList();
                var skill = matchingSkills.Select(x => x.SkillName).Distinct();

                SkillNameList = new List<string>();
                foreach (var skillName in skill)
                {
                    SkillNameList.Add(skillName);
                }
            }
        }

        private int _areaIndex;
        public int AreaIndex
        {
            get { return _areaIndex; }
            set
            {
                if (_areaIndex != value)
                    SetPropertyField(nameof(AreaIndex), ref _areaIndex, value);
            }
        }

        private int _typeIndex;
        public int TypeIndex
        {
            get { return _typeIndex; }
            set
            {
                if (_typeIndex != value)
                    SetPropertyField(nameof(TypeIndex), ref _typeIndex, value);
            }
        }

        private int _skillIndex;
        public int SkillIndex
        {
            get { return _skillIndex; }
            set
            {
                if (_skillIndex != value)
                    SetPropertyField(nameof(SkillIndex), ref _skillIndex, value);
                SkillIndexChanged(SkillIndex);
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                    SetPropertyField(nameof(Description), ref _description, value);
            }
        }

        private int _skillLevelIndex;
        public int SkillLevelIndex
        {
            get { return _skillLevelIndex; }
            set
            {
                if (_skillLevelIndex != value)
                    SetPropertyField(nameof(SkillLevelIndex), ref _skillLevelIndex, value);
            }
        }


        public void AreaIndexChanged(int index)
        {
            if (AllSkillsList.Count < index) return;
            var selectedArea = AreaNameList[index];
            var matchingArea = AllSkillsList.Where(x => x.AreaName == selectedArea).ToList();
            var type = matchingArea.Select(x => x.TypeName).Distinct();
            TypeNameList.Clear();

            TypeNameList = new List<string>();

            if (type == null) return;
            {
                foreach (var typeName in type)
                {
                    TypeNameList.Add(typeName);
                }
            }
        }

        public void TypeIndexChanged(int index)
        {
            if (TypeNameList.Count < index || index == -1) return;
            var selectedType = TypeNameList[index];
            var matchingType = AllSkillsList.Where(x => x.TypeName == selectedType).ToList();
            var skill = matchingType.Select(x => x.SkillName).Distinct();

            SkillNameList.Clear();

            SkillNameList = new List<string>();

            if (skill == null) return;
            {
                foreach (var skillName in skill)
                {
                    SkillNameList.Add(skillName);
                }
            }
        }

        public void SkillIndexChanged(int index)
        {
            if (SkillNameList.Count < index || index == -1) return;
            var selectedSkill = SkillNameList[index];
            var matchingSkill = AllSkillsList.FirstOrDefault(x => x.SkillName == selectedSkill);
            var description = matchingSkill.Description.ToString();
            Description = description;
        }

        public void SkillLevelIndexChanged(int index)
        {

        }

        public async void SaveAndEditCompetence()
        {
            var selectedSkill = SkillNameList[SkillIndex];
            var matchingSkill = AllSkillsList.FirstOrDefault(x => x.SkillName == selectedSkill);

            _employeeSkill = new EmployeeSkill()
            {
                EmployeeId = CurrentUser.EmployeeId, //92,//
                EmployeeFullName = CurrentUser.FullName, //"Kalle Hallert", //
                SkillId = matchingSkill.SkillId,
                SkillName = matchingSkill.SkillName,
                TypeId = matchingSkill.TypeId,
                TypeName = matchingSkill.TypeName,
                AreaId = matchingSkill.AreaId,
                AreaName = matchingSkill.AreaName,
                Level = SkillLevelIndex,
                Comment = string.Empty,
                LastUpdate = DateTime.Now
            };
        }

        public async Task AddCompetence()
        {
            SaveAndEditCompetence();
            _employeeSkillManager = new EmployeeSkillManager();
            await _employeeSkillManager.SaveSkill(_employeeSkill);

        }
    }
}

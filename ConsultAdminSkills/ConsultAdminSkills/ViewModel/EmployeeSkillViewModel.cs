using ConsultAdmin.Entities;
using ConsultAdminSkills.Fake;
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
        public int AreaId { get; set; }
        public string Area { get; set; }
        public int SkillId { get; set; }


        int employeeId = 3;
        //public EmployeeSkillViewModel()
        //{

        //}

        public async Task SetSkillLists()
        {
            EmployeeSkillsList = new List<EmployeeSkill>();
            _skillManager = new SkillManager();
            //EmployeeSkillsList.Clear();
            EmployeeSkillsList = await _skillManager.GetAllEmployeeSkills(employeeId);

            if (EmployeeSkillsList == null) return;

            List<EmployeeAreas> allSkills = new List<EmployeeAreas>();

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
                    allSkills.Add(area);
                }
            }

            //List<string> list = new List<string>();

            //foreach (var area in allSkills)
            //{
            //    list.Add(area.AreaName);
            //    foreach (var item in area.EmployeeTypes)
            //    {
            //        list.Add(item.TypeName);
            //        foreach (var item2 in item.EmployeeSkills)
            //        {
            //            list.Add(item2.SkillName);
            //        }
            //    }
            //}

            var plattLista = new List<EmployeeCompetence>();
            foreach (var item in allSkills)
            {
                var competence = new EmployeeCompetence(item);
                plattLista.Add(competence);
            }

            string t = "";

            foreach (var employeeSkill in EmployeeSkillsList)
            {
                employeeSkill.EmployeeId = employeeId;
                employeeSkill.AreaImgDownClicked = true;
            }
            string s = "";
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
        public void OpenTypeName(object param)
        {
            var imgClicked = param as EmployeeSkill;
            if (imgClicked == null) return;

            AreaId = imgClicked.AreaId;
            Area = imgClicked.AreaName;
            //här ska kolla ursprungliga listan ändras .where(x => x.areaId == areaId) på den arean där man klickade

            //foreach (var item in EmployeeCompetenceList.Where(x => x.EmployeeAreas.AreaId == AreaId))

            //foreach (var list in EmployeeSkillsList)
            //{
            foreach (var item in EmployeeSkillsList.Where(x => x.AreaId == AreaId))
            {
                item.AreaImgDownClicked = false;
                item.AreaImgUpClicked = true;
                item.TypeNameImgDown = true;
            }
            //}

            string s = "";
        }
        public void CloseTypeName(object param)
        {
            var imgClicked = param as EmployeeSkill;
            if (imgClicked == null) return;
            AreaId = imgClicked.AreaId;
            Area = imgClicked.AreaName;
            //SubAreas = imgClicked.EmployeeAreas.SubAreas;

            foreach (var item in EmployeeSkillsList.Where(x => x.AreaId == AreaId))
            {
                item.AreaImgDownClicked = true;
                item.AreaImgUpClicked = false;
                item.TypeNameImgUp = false;
            }
        }

        public void OpenSkillName(object param)
        {
            var imgClicked = param as EmployeeSkill;
            if (imgClicked == null) return;
            AreaId = imgClicked.AreaId;
            Area = imgClicked.AreaName;

            foreach (var item in EmployeeSkillsList.Where(x => x.AreaId == AreaId))
            {
                item.TypeNameImgDown = false;
                item.TypeNameImgUp = true;
            }
        }

        public void CloseSkillName(object param)
        {
            var imgClicked = param as EmployeeSkill;
            if (imgClicked == null) return;
            AreaId = imgClicked.AreaId;
            Area = imgClicked.AreaName;

            foreach (var item in EmployeeSkillsList.Where(x => x.AreaId == AreaId))
            {
                item.TypeNameImgDown = true;
                item.TypeNameImgUp = false;
            }
        }

        public int GetSkillId(object param)
        {
            var skillClicked = param as EmployeeSkill;
            int skillId = skillClicked.SkillId;
            return skillId;
        }

        //public void SetSkillDescription()
        //{
        //    SetSkillLists();

        //    foreach (var skill in EmployeeSkillsList.Where(x => x.SkillId == SkillId))
        //    {
        //        SkillName = skill.SkillName;
        //        Comment = skill.Comment;
        //    }
        //}

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


    }
}

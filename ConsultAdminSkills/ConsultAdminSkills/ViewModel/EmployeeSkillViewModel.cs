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
            //Fyller på modellen(EmployeeSkill) från fejken(EmployeeSkillFake)

            //_employeeSkillFake = new EmployeeSkillFake();
            //_employeeSkillFake.EmployeeSkills.Add(new EmployeeSkill()
            //{
            //    EmployeeId = _employeeSkillFake.EmployeeId,
            //    EmployeeFullName = _employeeSkillFake.EmployeeFullName,
            //    SkillId = _employeeSkillFake.SkillId,
            //    SkillName = _employeeSkillFake.SkillName,
            //    TypeId = _employeeSkillFake.TypeId,
            //    TypeName = _employeeSkillFake.TypeName,
            //    AreaId = _employeeSkillFake.AreaId,
            //    AreaName = _employeeSkillFake.AreaName,
            //    Level = _employeeSkillFake.Level,
            //    Comment = _employeeSkillFake.Comment,
            //    LastUpdate = _employeeSkillFake.LastUpdate
            //});

            //var list = new List<EmployeeCompetence>(); <---EmployeeSkillsList
            //foreach (var item in _employeeSkillFake.EmployeeAreaList)
            //{
            //    var competence = new EmployeeCompetence(item);
            //    //var employeeCompetence = new EmployeeCompetence();
            //    //employeeCompetence.EmployeeAreas = item;
            //    //employeeCompetence.IsArea = true;
            //    list.Add(competence);
            //}

            EmployeeSkillsList = new List<EmployeeSkill>();
            _skillManager = new SkillManager();
            //EmployeeSkillsList.Clear();
            EmployeeSkillsList = await _skillManager.GetAllEmployeeSkills(employeeId);

            
            
            if (EmployeeSkillsList == null) return;
            foreach (var employeeSkill in EmployeeSkillsList)
            {
                employeeSkill.EmployeeId = employeeId;
                employeeSkill.AreaImgDownClicked = true;
                
            }
            //Här:

            //Fyller EmployeeSkillCollection
            //EmployeeSkillsList = new List<EmployeeSkill>();
            //EmployeeSkillsList.Clear();

            //foreach (var skill in _employeeSkillFake.EmployeeSkills)
            //{
            //    EmployeeSkillsList.Add(skill);
            //    skill.AreaImgDownClicked = true;
            //    skill.AreaImgUpClicked = false;
            //    skill.TypeNameImgDown = false;
            //    skill.TypeNameImgUp = false;
            //}
            string s = "";
        }

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

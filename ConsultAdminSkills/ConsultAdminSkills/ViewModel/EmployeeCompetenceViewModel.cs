using ConsultAdmin.Entities;
using ConsultAdminSkills.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsultAdminSkills.ViewModel
{

    public class EmployeeCompetenceViewModel : BaseViewModel
    {
        private EmployeeSkillViewModel _employeeSkillViewModel;
        private SkillManager _skillManager;
        public int SkillId { get; set; }
        private string _skillName;
        private string _description;
        private List<EmployeeSkill> _employeeSkill;
        public string SkillName
        {
            get { return _skillName; }
            set
            {
                if (_skillName != value)
                {
                    SetPropertyField(nameof(SkillName), ref _skillName, value);
                }
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    SetPropertyField(nameof(Description), ref _description, value);
                }
            }
        }
        public List<EmployeeSkill> SkillEmployees
        {
            get { return _employeeSkill; }
            set
            {
                if (_employeeSkill != value)
                {
                    SetPropertyField(nameof(SkillEmployees), ref _employeeSkill, value);
                }
            }
        }

        public async Task SetSkillDescription(int skillId)
        {
            _skillManager = new SkillManager();
            Skill skill = await _skillManager.GetSkill(skillId);
            if (skill == null) return;
            SkillName = skill.SkillName;
            Description = skill.Description;

            //SkillEmployees = skill.SkillEmployees;
            //var list = new List<>

            //foreach (var list in SkillEmployees)
            //{
            //    foreach (var name in list.EmployeeFullName)
            //    {
            //        //SkillEmployees.Add(name);
            //    }
            //}

            //var list = new List<EmployeeCompetence>();
            //foreach (var item in _employeeSkillFake.EmployeeAreaList)
            //{
            //    var competence = new EmployeeCompetence(item);
            //    //var employeeCompetence = new EmployeeCompetence();
            //    //employeeCompetence.EmployeeAreas = item;
            //    //employeeCompetence.IsArea = true;
            //    list.Add(competence);
            //}
        }
    }
}

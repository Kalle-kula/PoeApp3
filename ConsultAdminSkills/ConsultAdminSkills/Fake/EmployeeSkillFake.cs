using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultAdmin.Entities;

namespace ConsultAdminSkills.Fake
{
    public class EmployeeSkillFake
    {
        //public List<EmployeeArea> EmployeeAreaList = new List<EmployeeArea>();
        //public List<EmployeeSubArea> SubAreas = new List<EmployeeSubArea>();
        //public List<EmployeeSkills> Skills = new List<EmployeeSkills>();

        //public List<int> AreaIds = new List<int>() { 3, 6 };
        //public List<string> Area = new List<string>() { "Development", "Plattforms" };

        //public List<int> SubAreaId = new List<int>() { 1, 2 };
        //public List<string> SubArea = new List<string>() { "Language", ".NET" };

        //public List<int> SkillIds = new List<int>() { 1, 2, 3 };
        //public List<string> Skill = new List<string>() { "C#", "Xaml", "Java" };
        //public List<int> SkillGrade = new List<int>() { 8, 5, 1 };
        public List<EmployeeSkill> EmployeeSkills = new List<EmployeeSkill>();

        public int EmployeeId = 82;
        public string EmployeeFullName = "Kalle Hallert";
        public int SkillId = 2;
        public string SkillName = "C#";
        public int TypeId = 3;
        public string TypeName = "Language";
        public int AreaId = 4;
        public string AreaName = "Development";
        public int Level = 6;
        public string Comment = "I'm ok";
        public DateTime LastUpdate = DateTime.Now;


    }
}

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
        List<EmployeeSkills> EmployeeSkillsList = new List<EmployeeSkills>();

        public List<int> AreaId = new List<int>() { 3, 6 };
        public List<string> Area = new List<string>() { "Development", "Plattforms" };
        public List<EmployeeSkills.EmployeeSubArea> SubAreas = new List<EmployeeSkills.EmployeeSubArea>();

        public List<int> SubAreaId = new List<int>() { 1, 2 };
        public List<string> SubArea = new List<string>() { "Language", ".NET" };
        public List<EmployeeSkills.EmployeeSkill> Skills = new List<EmployeeSkills.EmployeeSkill>();

        public List<int> SkillId = new List<int>() { 1, 2, 3 };
        public List<string> Skill = new List<string>() { "C#", "Xaml", "Java" };
        public List<int> SkillGrade = new List<int>() { 8, 5, 1 };

        
        
        
    }
}

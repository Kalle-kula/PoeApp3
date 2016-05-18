using ConsultAdmin.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdminSkills.Service
{
     public class EmployeeSkillManager
    {
        public async Task SaveSkill(EmployeeSkill employeeSkill)
        {
            string uri = $"http://consultadminwebserver.azurewebsites.net/api/EmployeeSkill/";
            //{employeeSkill.SkillId}

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var requestJSON = JsonConvert.SerializeObject(employeeSkill);
                await httpClient.PostAsync(uri,
                new StringContent(requestJSON.ToString(), Encoding.UTF8, "application/json"));
            }
            catch (Exception ex)
            {

            }

            return;
        }
    }
}

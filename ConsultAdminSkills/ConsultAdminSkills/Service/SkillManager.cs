﻿using ConsultAdmin.Entities;
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
    public class SkillManager
    {
        private const string Url = "http://consultadminwebserver.azurewebsites.net/api/skill/";

        public async Task<Skill> GetSkill(int id)
        {
            Skill skill = new Skill();

            //var handle = Insights.TrackTime("Time_GetOneEmployee");
            //handle.Start();

            try
            {
                HttpClient client = new HttpClient();

                // Set pref result as JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Call the API with id as request args
                Task<string> contentsTask = client.GetStringAsync(Url + id.ToString());

                // await! control returns to the caller and the task continues to run on another thread
                string contents = await contentsTask.ConfigureAwait(false);

                // Deserialize the JSON data into Contact
                skill = JsonConvert.DeserializeObject<Skill>(contents);
            }
            catch (Exception ex)
            {
                //    Dictionary<string, string> myDictionary = new Dictionary<string, string>
                //    {
                //        {"Function", "EmployeeManager.GetEmployee"},
                //        {"Key", id.ToString()}
                //};
                //    _logger.LoggError(ex, myDictionary, (Xamarin.Insights.Severity.Error));
            }
            finally
            {
                // Stop the GetContact-timer
                //handle.Stop();
            }
            return skill;
        }
    }
}

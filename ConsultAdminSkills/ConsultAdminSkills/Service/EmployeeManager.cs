using ConsultAdmin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsultAdminSkills.Service
{
    public class EmployeeManager
    {
        //Todo: Read the correct URL from config
        private const string Url = "http://consultadminwebserver.azurewebsites.net/api/employee/";

        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            //var handle = Insights.TrackTime("Time_GetAllEmployees");
            //handle.Start();

            try
            {
                HttpClient client = new HttpClient();

                // Set pref result as JSON
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                // Call the API for contacts
                Task<string> contentsTask = client.GetStringAsync(Url);

                // await! control returns to the caller and the task continues to run on another thread
                string contents = await contentsTask.ConfigureAwait(false);

                // Deserialize the JSON data into ContactManager (List of contacts)
                employees = JsonConvert.DeserializeObject<List<Employee>>(contents);
            }
            catch (Exception ex)
            {
                //Dictionary<string, string> myDictionary = new Dictionary<string, string>
                //{
                //    {"Function", "EmployeeManager.GetAllEmployees"}
                //};
                //_logger.LoggError(ex, myDictionary, (Xamarin.Insights.Severity.Error));
            }
            finally
            {
                // Stop the GetAllEmployees-timer
                //handle.Stop();
            }

            return employees;
        }

        public async Task<EmployeeDetail> GetEmployee(int id)
        {
            EmployeeDetail employee = new EmployeeDetail();

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
                employee = JsonConvert.DeserializeObject<EmployeeDetail>(contents);
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
            return employee;
        }

        //public async Task<EmployeeSkills> FakeGetEmployeeSkills()
        //{
        //    EmployeeSkills employeeSkills = new EmployeeDetail();

        //    //var handle = Insights.TrackTime("Time_GetOneEmployee");
        //    //handle.Start();

        //    try
        //    {
        //        HttpClient client = new HttpClient();

        //        // Set pref result as JSON
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        // Call the API with id as request args
        //        Task<string> contentsTask = client.GetStringAsync(Url + id.ToString());

        //        // await! control returns to the caller and the task continues to run on another thread
        //        //string contents = "{\"AreaId\":3,\"Area\

        //        // Deserialize the JSON data into Contact
        //        employeeSkills = JsonConvert.DeserializeObject<EmployeeSkills>(contents);
        //    }
        //    catch (Exception ex)
        //    {
        //        //    Dictionary<string, string> myDictionary = new Dictionary<string, string>
        //        //    {
        //        //        {"Function", "EmployeeManager.GetEmployee"},
        //        //        {"Key", id.ToString()}
        //        //};
        //        //    _logger.LoggError(ex, myDictionary, (Xamarin.Insights.Severity.Error));
        //    }
        //    finally
        //    {
        //        // Stop the GetContact-timer
        //        //handle.Stop();
        //    }
        //    return employee;
        //}

    }
}

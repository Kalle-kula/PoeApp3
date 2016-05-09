using ConsultAdminSkills.Interface;
using ConsultAdminSkills.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConsultAdminSkills.Service
{
    public class LocalStorageManager
    {
        //private readonly ILogger _logger = new PCLLogger();
        private SQLiteConnection database;
        static object locker = new object();

        public string UserId { get; set; }
        public string Password { get; set; }

        public LocalStorageManager()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<SavedUser>();
            //database.Dispose();
        }

        public void SaveUseridAndPassword(string userid, string password)
        {
            lock (locker)
            {
                SavedUser savedUser = new SavedUser
                {
                    Id = 1,
                    UserId = userid,
                    Password = password
                };
                int no = database.InsertOrReplace(savedUser);
                //_logger.LoggText($"SaveUseridAndPassword affected {no.ToString()} rows when set {userid}");
            }
        }

        public void GetUseridAndPassword()
        {
            lock (locker)
            {
                SavedUser savedUser = database.Table<SavedUser>().FirstOrDefault(c => c.Id == 1);
                if (savedUser != null)
                {
                    this.UserId = savedUser.UserId;
                    this.Password = savedUser.Password;
                }
                else
                {
                    this.UserId = "";
                    this.Password = "";
                }
            }
        }

        public void ClearUseridAndPassword()
        {
            lock (locker)
            {
                database.Delete<SavedUser>(1);
                //_logger.LoggText("ClearUseridAndPassword");
            }
        }
    }
}

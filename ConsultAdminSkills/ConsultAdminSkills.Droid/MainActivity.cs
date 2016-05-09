using System;
using ConsultAdminSkills.UI;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin;
using Android.Graphics.Drawables;

namespace ConsultAdminSkills.Droid
{
    [Activity(Label = "ConsultAdminSkills", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            Insights.HasPendingCrashReport += (sender, isStartupCrash) =>
            {
                if (isStartupCrash)
                {
                    Insights.PurgePendingCrashReports().Wait();
                }
            };

            Insights.Initialize("07569bfb8266df4c285c645c5a28ebf2bb40db03", ApplicationContext);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //tar bort xamarinloggan
            ActionBar.SetIcon(new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent)));

            LoadApplication(new AppUI());
        }

        private void CreateAndShowDialog(String message, String title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }
    }
}


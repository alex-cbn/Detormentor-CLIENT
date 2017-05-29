using Detormentor_CLIENT.Models;
using Detormentor_CLIENT.Services;
using Detormentor_CLIENT.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using static Detormentor_CLIENT.Services.DBAccess;

namespace Detormentor_CLIENT
{
    public partial class App : Application
    {
        static DBAccess database;
        async void GetUpdate(List<VoterItem> lista)
        {
            lista = await Database.GetAllVotersAsync();
        }
        public App()
        {
            
            InitializeComponent();
            var items = new List<VoterItem>();
            items.Add(new VoterItem { ID = 1, Departament = "IT", Nume = "Ruski" });
            items.Add(new VoterItem { ID = 2, Departament = "IT", Nume = "30fps" });
            items.Add(new VoterItem { ID = 3, Departament = "AIMBOT", Nume = "Spinbot" });
            items.Add(new VoterItem { ID = 4, Departament = "WH", Nume = "Profil Privat" });
            items.Add(new VoterItem { ID = 5, Departament = "WH", Nume = "Hackusator" });
            items.Add(new VoterItem { ID = 6, Departament = "IT", Nume = "DINOSWOWER" });
            items.Add(new VoterItem { ID = 7, Departament = "Networking", Nume = "400 ping" });
            items.Add(new VoterItem { ID = 8, Departament = "Networking", Nume = "Glont prin el" });
            items.Add(new VoterItem { ID = 9, Departament = "TELEPORTING", Nume = "CS:GO" });
            Database.UpdateAsync(items);
            List<VoterItem> circlejrk = new List<VoterItem>();
            GetUpdate(circlejrk);
            MainPage = new AddVoters(items);
            //SelectMultipleBasePage<CheckItem> multiPage;
            // MainPage = new HomePage();
            ////var items = new List<PollOption>();
            ////items.Add(new PollOption { OptionString = "Papaly"});
            ////items.Add(new PollOption { OptionString = "Suki"});
            ////items.Add(new PollOption { OptionString = "Ruski"});
            ////items.Add(new PollOption { OptionString = "Patzalyyyy"});
            ////MainPage = new ViewPoll(items, "Presedintele Rusei", "Gaben approves the new president of RuskiLand");
            //var ServerFind = new ServerIPInput();
            //ServerFind.ValidServer += HandleValidServer;
            //MainPage = new Detormentor_CLIENT.MainPage();
        }

        public static DBAccess Database
        {
            get
            {
                if (database == null)
                {
                    database = new DBAccess(DependencyService.Get<IFileHelper>().GetLocalFilePath("VotersCache.db3"));
                }
                return database;
            }
        }

        private void HandleValidServer(object sender, EventArgs e)
        {
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
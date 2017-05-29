using Detormentor_CLIENT.DataServices;
using Detormentor_CLIENT.Models;
using Detormentor_CLIENT.Services;
using Detormentor_CLIENT.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using static Detormentor_CLIENT.Services.VotersDB;

namespace Detormentor_CLIENT
{
    public partial class App : Application
    {
        static UserWrapper.UserWrapp userwrapper;
        static VotersDB database_voters;
        static PollsDB database_poll;
        async void GetUpdate(List<VoterItem> lista)
        {
            lista = await VotersDatabase.GetAllVotersAsync();
        }
        public App()
        {
            
            InitializeComponent();
            //////var items = new List<VoterItem>();
            //////items.Add(new VoterItem { ID = 1, Departament = "IT", Nume = "Ruski" });
            //////items.Add(new VoterItem { ID = 2, Departament = "IT", Nume = "30fps" });
            //////items.Add(new VoterItem { ID = 3, Departament = "AIMBOT", Nume = "Spinbot" });
            //////items.Add(new VoterItem { ID = 4, Departament = "WH", Nume = "Profil Privat" });
            //////items.Add(new VoterItem { ID = 5, Departament = "WH", Nume = "Hackusator" });
            //////items.Add(new VoterItem { ID = 6, Departament = "IT", Nume = "DINOSWOWER" });
            //////items.Add(new VoterItem { ID = 7, Departament = "Networking", Nume = "400 ping" });
            //////items.Add(new VoterItem { ID = 8, Departament = "Networking", Nume = "Glont prin el" });
            //////items.Add(new VoterItem { ID = 9, Departament = "TELEPORTING", Nume = "CS:GO" });
            ////var items = new List<PollOption>();
            ////items.Add(new PollOption { OptionString = "Papaly"});
            ////items.Add(new PollOption { OptionString = "Suki"});
            ////items.Add(new PollOption { OptionString = "Ruski"});
            ////items.Add(new PollOption { OptionString = "Patzalyyyy"});
            ////MainPage = new ViewPoll(items, "Presedintele Rusiei", "Gaben approves the new president of RuskiLand");
            var ServerFind = new ServerIPInput();
            ServerFind.ValidServer += HandleValidServer;
            MainPage = ServerFind;
            //MainPage = new Detormentor_CLIENT.MainPage();
        }

        public static UserWrapper.UserWrapp UW
        {
            get
            {
                if(userwrapper == null)
                {
                    userwrapper = new UserWrapper.UserWrapp();
                }
                return userwrapper;
            }
        }

        public static PollsDB PollDatabase
        {
            get
            {
                if(database_poll == null)
                {
                    database_poll = new PollsDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("PollCache.db3"));
                }
                return database_poll;
            }
        }

        public static VotersDB VotersDatabase
        {
            get
            {
                if (database_voters == null)
                {
                    database_voters = new VotersDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("VotersCache.db3"));
                }
                return database_voters;
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
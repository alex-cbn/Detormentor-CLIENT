using Detormentor_CLIENT.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Detormentor_CLIENT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //SelectMultipleBasePage<CheckItem> multiPage;
            // MainPage = new HomePage();
            var items = new List<PollOption>();
            items.Add(new PollOption { OptionString = "Papaly"});
            items.Add(new PollOption { OptionString = "Suki"});
            items.Add(new PollOption { OptionString = "Ruski"});
            items.Add(new PollOption { OptionString = "Patzalyyyy"});
            MainPage = new ViewPoll(items, "Presedintele Rusei", "Gaben approves the new president of RuskiLand");
            //var ServerFind = new ServerIPInput();
            //ServerFind.ValidServer += HandleValidServer;
            //MainPage = new Detormentor_CLIENT.MainPage();
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

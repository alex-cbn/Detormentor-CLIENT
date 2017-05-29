using Detormentor_CLIENT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Detormentor_CLIENT
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PollListPage : ContentPage
    {
        public class PollTypeGroup : List<PollDescription>
        {
            public string Title { get; set; }
            public string ShorT { get; set; }
            public PollTypeGroup(string title, string shorT)
            {
                Title = title;
                ShorT = shorT;
            }
            public static IList<PollDescription> All { set; get; }
        }
        public class PollListCell : ViewCell
        {
            public PollListCell() : base()
            {
                Label demo = new Label();
                demo.SetBinding(Label.TextProperty, new Binding("title"));
                StackLayout mainstack = new StackLayout();
                mainstack.Children.Add(demo);
                View = mainstack;
            }
        }
        public PollListPage()
        {
            InitializeComponent();
            List<PollTypeGroup> Groups = new List<PollTypeGroup>
            {
                new PollTypeGroup("Active", "A")
                {
                    new PollDescription
                    {
                        ID=1,
                        description="Votare Presedinte",
                        title = "Prezidentiala",
                        winner = ""
                    },
                },
                new PollTypeGroup("Inactive", "I")
                {
                    new PollDescription
                    {
                        ID=1,
                        description="Ce mancam diseara",
                        title = "Prezidentiala",
                        winner = "Bataie"
                    },
                    new PollDescription
                    {
                        ID=2,
                        description="Cine duce lada",
                        title = "Baietii cu lada",
                        winner = "Ultimii fraieri"
                    },
                }
            };
            ListView thelist = new ListView
            {
                BindingContext = Groups,
                IsGroupingEnabled = true,
                GroupDisplayBinding = new Binding("Title"),
                GroupShortNameBinding = new Binding("ShorT"),
                ItemsSource = Groups,
                ItemTemplate = new DataTemplate(typeof(PollListCell)),
                GroupHeaderTemplate = null,
            };
            mainstack.Children.Add(thelist);
        }
    }
}

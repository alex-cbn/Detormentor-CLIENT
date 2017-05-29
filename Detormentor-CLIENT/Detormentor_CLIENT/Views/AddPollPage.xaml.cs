using Detormentor_CLIENT.Models;
using Detormentor_CLIENT.Views;
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
    public partial class AddPollPage : ContentPage
    {
        public List<VoterItem> listafinala;
        public List<VoterItem> lista;
        protected AddVoters voterpage;
        protected string makecommandstring()
        {
            string auxiliar;
            string result ="m:";
            result += numelabel.Text;
            result += ":";
            result += descriereeditor.Text;
            result += ":";
            auxiliar = optiuni.Text;
            int count_aux = auxiliar.Split('\n').Length - 1;
            auxiliar = auxiliar.Replace('\n', ':');
            result += "no_rules:";
            result += count_aux;
            result += ":";
            result += auxiliar;
            result += listafinala.Count;
            result += ":";
            foreach (var votant in listafinala)
            {
                result += votant.ID;
                result += ":";
                result += votant.Nume;
                result += ":";
            }
            result += auxiliar;
            result += ":";
            //result += App.UW.get_time_in_gtm(datalabel.Text);
            return result;
        }
        public AddPollPage()
        {
            InitializeComponent();
            optiuni.Focused += (sender, e) =>
            {
                if(optiuni.Text == "Exemplu:\n1:Azi\n2:Maine\n3:Poimaine")
                {
                    optiuni.Text = "";
                }
            };
            selectallbutton.Clicked += async (sender, e) =>
             {
                 await App.VotersDatabase.GetAllVotersAsync();
             };
            selectvotersbutton.Clicked += async (sender, e) =>
             {
                 lista = await App.VotersDatabase.GetAllVotersAsync();
                 lista.Add(new VoterItem { ID = 1, Departament = "IT", Nume = "Ruski" });
                 lista.Add(new VoterItem { ID = 2, Departament = "IT", Nume = "30fps" });
                 lista.Add(new VoterItem { ID = 3, Departament = "AIMBOT", Nume = "Spinbot" });
                 lista.Add(new VoterItem { ID = 4, Departament = "WH", Nume = "Profil Privat" });
                 lista.Add(new VoterItem { ID = 5, Departament = "WH", Nume = "Hackusator" });
                 lista.Add(new VoterItem { ID = 6, Departament = "IT", Nume = "DINOSWOWER" });
                 lista.Add(new VoterItem { ID = 7, Departament = "Networking", Nume = "400 ping" });
                 lista.Add(new VoterItem { ID = 8, Departament = "Networking", Nume = "Glont prin el" });
                 lista.Add(new VoterItem { ID = 9, Departament = "TELEPORTING", Nume = "CS:GO" });

                 voterpage = new AddVoters(lista);
                 await Navigation.PushModalAsync(voterpage);
             };
            donbutton.Clicked +=  (sender, e) =>
            {
                makecommandstring();
                //TODO send comand
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (voterpage != null)
            {
                listafinala = voterpage.advm.GetSelection();
            }
        }
    }

    //class AddPollPageViewModel : INotifyPropertyChanged
    //{

    //    public AddPollPageViewModel()
    //    {
    //        IncreaseCountCommand = new Command(IncreaseCount);
    //    }

    //    int count;

    //    string countDisplay = "You clicked 0 times.";
    //    public string CountDisplay
    //    {
    //        get { return countDisplay; }
    //        set { countDisplay = value; OnPropertyChanged(); }
    //    }

    //    public ICommand IncreaseCountCommand { get; }

    //    void IncreaseCount() =>
    //        CountDisplay = $"You clicked {++count} times";


    //    public event PropertyChangedEventHandler PropertyChanged;
    //    void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    //}
    
}

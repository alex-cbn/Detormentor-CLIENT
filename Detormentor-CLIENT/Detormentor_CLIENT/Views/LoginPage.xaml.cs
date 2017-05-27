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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //BindingContext = new ContentPageViewModel();
        }

        public void selectserverbuttonCLICK(object sender, EventArgs args)
        {
            ServerIPInput svinput = new ServerIPInput();
            svinput.ValidServer += HandleValidServer;
            Navigation.PushModalAsync(svinput);
        }

        public void loginBUTTONclick(object sender, EventArgs args)
        {
            serverlabel.Text = "Conectat";
        }

        public void HandleValidServer(object sender, EventArgs e)
        {
            ServerIPInput x = (ServerIPInput)sender;
            serverlabel.Text = x.m_IP;
        }

    }

    

    //class LoginPageViewModel : INotifyPropertyChanged
    //{

    //    public LoginPageViewModel()
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

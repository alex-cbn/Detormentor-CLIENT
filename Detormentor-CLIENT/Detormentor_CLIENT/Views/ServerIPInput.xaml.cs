using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Detormentor_CLIENT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServerIPInput : ContentPage
    {
        public String m_IP;
        public event EventHandler ValidServer;
        public event EventHandler InvalidServer;
        public void OnValidServer()
        {
            if(ValidServer !=null)
            {
                ValidServer(this, EventArgs.Empty);
            }
        }
        public void OnInvalidServer()
        {
            if (InvalidServer != null)
            {
                InvalidServer(this, EventArgs.Empty);
            }
        }
        public void loginBUTTONclick(object sender, EventArgs args)
        {
            //listen();
            //if (reply == "connect_ to_port")
            //{
                ValidServer(this, args);
            //}
        }
        public ServerIPInput()
        {
            InitializeComponent();
        }
        public void submitIP(object sender, EventArgs args)
        {
        //    m_IP = IPstring.Text;
        //    //try to connect
        //    if(success)
        //    {
                loginBUTTON.IsEnabled = true;
        //    }
        }
    }
}
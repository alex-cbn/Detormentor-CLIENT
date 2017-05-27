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
        public ServerIPInput()
        {
            InitializeComponent();
        }
        public void submitIP(object sender, EventArgs args)
        {
            if(/*IPstring.Text=="127.0.0.1"*/true)
            {
                m_IP = IPstring.Text;
                ValidServer(this, args);
            }
        }
    }
}

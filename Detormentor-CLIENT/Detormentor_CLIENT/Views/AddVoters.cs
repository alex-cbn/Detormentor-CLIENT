using Detormentor_CLIENT.Models;
using Detormentor_CLIENT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Detormentor_CLIENT.Views
{
    public class AddVoters : ContentPage
    {
        public List<VoterItem> takeme;
        public AddVotersViewModel advm;
        public AddVoters(List<VoterItem> items)
        {
            takeme = new List<VoterItem>();
            advm = new AddVotersViewModel(items);
            StackLayout mainstack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
            };
            ListView mainList = new ListView()
            {
                ItemsSource = advm.WrappedItems,
                ItemTemplate = new DataTemplate(typeof(VotersSelectionTemplate)),
            };
            mainList.ItemTapped += (sender, e) => {
                if (e.Item == null) return;
                var o = (WrappedSelection<VoterItem>)e.Item;
                o.IsSelected = !o.IsSelected;
                ((ListView)sender).SelectedItem = null; //de-select
            };
            Button DoneButton = new Button
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Text = "Done"
            };

            mainstack.Children.Add(mainList);
            mainstack.Children.Add(DoneButton);
            Content = mainstack;
            DoneButton.Clicked += (sender, e) =>
            {
                Navigation.PopModalAsync();
            };
            this.Appearing += async (sender, e) =>
            {
                await App.VotersDatabase.CleanAsync();
                App.VotersDatabase.MakeTable();
                await App.VotersDatabase.UpdateAsync(items);
                takeme = await App.VotersDatabase.GetAllVotersAsync();
                //mainList.BindingContextChanged;
            };
        }
    }
}

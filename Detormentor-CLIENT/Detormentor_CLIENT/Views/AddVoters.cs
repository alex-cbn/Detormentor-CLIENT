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
        public AddVoters(List<VoterItem> items)
        {
            List<VoterItem> takeme = new List<VoterItem>();
            AddVotersViewModel advm = new AddVotersViewModel(items);
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
            this.Appearing += async (sender, e) =>
            {
                await App.Database.CleanAsync();
                App.Database.MakeTable();
                await App.Database.UpdateAsync(items);
                takeme = await App.Database.GetAllVotersAsync();
                //mainList.BindingContextChanged;
            };
        }
    }
}

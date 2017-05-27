using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Detormentor_CLIENT.Views
{
    public class SelectMultipleBasePage<T> : ContentPage
    {
        public class WrappedSelection<T> : INotifyPropertyChanged
        {
            public T Item { get; set; }
            bool isSelected = false;
            public bool IsSelected
            {
                get
                {
                    return isSelected;
                }
                set
                {
                    if (isSelected != value)
                    {
                        isSelected = value;
                        PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
                        //						PropertyChanged (this, new PropertyChangedEventArgs (nameof (IsSelected))); // C# 6
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
        }
        public class WrappedItemSelectionTemplate : ViewCell
        {

            public WrappedItemSelectionTemplate() : base()
            {
                Label name = new Label();
                name.SetBinding(Label.TextProperty, new Binding("Item.OptionString"));
                Switch mainSwitch = new Switch();
                mainSwitch.SetBinding(Switch.IsToggledProperty, new Binding("IsSelected"));
                RelativeLayout layout = new RelativeLayout();
                layout.Children.Add(name,
                    Constraint.Constant(5),
                    Constraint.Constant(5),
                    Constraint.RelativeToParent(p => p.Width - 60),
                    Constraint.RelativeToParent(p => p.Height - 10)
                );
                layout.Children.Add(mainSwitch,
                    Constraint.RelativeToParent(p => p.Width - 55),
                    Constraint.Constant(5),
                    Constraint.Constant(50),
                    Constraint.RelativeToParent(p => p.Height - 10)
                );
                View = layout;
            }
        }
        public List<WrappedSelection<T>> WrappedItems = new List<WrappedSelection<T>>();
        public class DummyClass : INotifyPropertyChanged
        {
            public string uranus { get; set; }
            public string trex { get; set;}
            public DummyClass()
            {
                uranus = "as";
                trex = "TREK";
                PropertyChanged(this, new PropertyChangedEventArgs("trex"));
                PropertyChanged(this, new PropertyChangedEventArgs("uranus"));
            }

            public event PropertyChangedEventHandler PropertyChanged = delegate 
            {
                
            };

        }
        public SelectMultipleBasePage(List<T> items)
        {
            DummyClass dc = new DummyClass();

            WrappedItems = items.Select(item => new WrappedSelection<T>() { Item = item, IsSelected = false }).ToList();
            StackLayout mainstack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding=5
            };
            Label Title = new Label();
            Title.BindingContext = dc;
            Title.SetBinding(Label.TextProperty, new Binding("trex"));
            mainstack.Children.Add(Title);
            Label Description = new Label();
            Description.BindingContext = dc;
            Description.SetBinding(Label.TextProperty, new Binding("uranus"));
            mainstack.Children.Add(Description);
            ListView mainList = new ListView()
            {
                ItemsSource = WrappedItems,
                ItemTemplate = new DataTemplate(typeof(WrappedItemSelectionTemplate)),
            };
            mainList.ItemTapped += (sender, e) => {
                if (e.Item == null) return;
                var o = (WrappedSelection<T>)e.Item;
                o.IsSelected = !o.IsSelected;
                ((ListView)sender).SelectedItem = null; //de-select
            };
            mainstack.Children.Add(mainList);
            StackLayout ButtonStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HeightRequest = 80,
                MinimumHeightRequest = 80
            };
            Button SendButton = new Button
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Text="Send Vote"
            };
            ButtonStack.Children.Add(SendButton);
            mainstack.Children.Add(ButtonStack);
            Content = mainstack;
        } // Actual constructor
        void SelectAll()
        {
            foreach (var wi in WrappedItems)
            {
                wi.IsSelected = true;
            }
        }
        void SelectNone()
        {
            foreach (var wi in WrappedItems)
            {
                wi.IsSelected = false;
            }
        }
        public List<T> GetSelection()
        {
            return WrappedItems.Where(item => item.IsSelected).Select(wrappedItem => wrappedItem.Item).ToList();
        }
    }
    public class PollDisplay
    {

    }
}

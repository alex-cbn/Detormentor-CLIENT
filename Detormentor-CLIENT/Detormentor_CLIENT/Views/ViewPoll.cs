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
            public event EventHandler updatedbutton;
            public void Onupdatedbutton()
            {
                if (updatedbutton != null)
                {
                    updatedbutton(this, new EventArgs());
                }
            }
            public T Item { get; set; }
            bool isSelected = false;
            //public class DecentString
            //{
            //    public DecentString(string thestring)
            //    {
            //        _string = thestring;
            //    }
            //    public string _string;
            //    public string get()
            //    {
            //        return _string;
            //    }
            //    public void set(string newstring)
            //    {
            //        if(newstring!=_string)
            //        {
            //            _string = newstring;
            //            PropertyChangedEventArgs("")
            //        }
            //    }
            //}
            public string pemata
            {
                get
                {
                    if (!isSelected)
                    {
                        return "ic_check_box_outline_blank_black_24dp.png";
                    }
                    else
                    {
                        return "ic_check_box_black_24dp.png";
                    }
                }
                set
                {
                    if (pemata != value)
                    {
                        if(pemata != "ic_check_box_outline_blank_black_24dp.png")
                        {
                            isSelected = false;
                        }
                        else
                        {
                            isSelected = true;
                        }
                        PropertyChanged(this, new PropertyChangedEventArgs("pemata"));
                        //						PropertyChanged (this, new PropertyChangedEventArgs (nameof (IsSelected))); // C# 6
                    }
                }
            }
            public bool IsSelected
            {
                get
                {
                    return isSelected;
                }
                set
                {
                    pemata = "whatever";
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
                Image name = new Image();
                name.SetBinding(Image.SourceProperty, new Binding("pemata"));
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
        public SelectMultipleBasePage(List<T> items)
        {
            WrappedItems = items.Select(item => new WrappedSelection<T>() { Item = item, IsSelected = false }).ToList();
            ListView mainList = new ListView()
            {
                ItemsSource = WrappedItems,
                ItemTemplate = new DataTemplate(typeof(WrappedItemSelectionTemplate)),
            };
            mainList.ItemTapped += (sender, e) => {
                if (e.Item == null) return;
                var o = (WrappedSelection<T>)e.Item;
                o.IsSelected = !o.IsSelected;
                o.pemata = "muie";
                ((ListView)sender).SelectedItem = null; //de-select
            };
            Content = mainList;
        }
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
}

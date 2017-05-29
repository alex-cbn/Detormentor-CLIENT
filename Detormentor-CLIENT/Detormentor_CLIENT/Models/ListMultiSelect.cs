using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Detormentor_CLIENT.Models
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
    public class PollOptionSelectionTemplate : ViewCell
    {
        public PollOptionSelectionTemplate() : base()
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
    public class VotersSelectionTemplate : ViewCell
    {
        public VotersSelectionTemplate() : base()
        {
            Label name = new Label();
            name.SetBinding(Label.TextProperty, new Binding("Item.Nume"));
            Label dept = new Label();
            dept.SetBinding(Label.TextProperty, new Binding("Item.Departament"));
            Switch mainSwitch = new Switch()
            {
                VerticalOptions=LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            mainSwitch.SetBinding(Switch.IsToggledProperty, new Binding("IsSelected"));
            StackLayout mainstack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions= LayoutOptions.CenterAndExpand
            };
            StackLayout layout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
            };
            StackLayout switchwrap = new StackLayout()
            {

            };
            layout.Children.Add(name);
            layout.Children.Add(dept);
            switchwrap.Children.Add(mainSwitch);
            mainstack.Children.Add(switchwrap);
            mainstack.Children.Add(layout);
            View = mainstack;
        }
    }
}

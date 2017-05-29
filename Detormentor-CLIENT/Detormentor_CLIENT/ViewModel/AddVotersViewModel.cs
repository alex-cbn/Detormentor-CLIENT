using Detormentor_CLIENT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detormentor_CLIENT.ViewModel
{
    public class AddVotersViewModel
    {
        public List<WrappedSelection<VoterItem>> WrappedItems = new List<WrappedSelection<VoterItem>>();
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
        public List<VoterItem> GetSelection()
        {
            return WrappedItems.Where(item => item.IsSelected).Select(wrappedItem => wrappedItem.Item).ToList();
        }
        public AddVotersViewModel(List<VoterItem> items)
        {
            WrappedItems = items.Select(item => new WrappedSelection<VoterItem>() { Item = item, IsSelected = false }).ToList();
        }
    }
}

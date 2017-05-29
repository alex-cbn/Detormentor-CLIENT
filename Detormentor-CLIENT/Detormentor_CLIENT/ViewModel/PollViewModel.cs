using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detormentor_CLIENT.Models;

namespace Detormentor_CLIENT.ViewModel
{
    class PollViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<WrappedSelection<PollOption>> WrappedItems = new List<WrappedSelection<PollOption>>();
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
        public List<PollOption> GetSelection()
        {
            return WrappedItems.Where(item => item.IsSelected).Select(wrappedItem => wrappedItem.Item).ToList();
        }
        public PollViewModel(List<PollOption> items, string title, string description)
        {
            Title = title;
            Description = description;
            WrappedItems = items.Select(item => new WrappedSelection<PollOption>() { Item = item, IsSelected = false }).ToList();
        }
}
}

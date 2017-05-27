using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detormentor_CLIENT
{
    public class PollOptionService
    {
        public List<PollOption> GetOptions()
        {
            var list = new List<PollOption>
            {
                new PollOption
                {
                    OptionString = "Papaly",
                    ImageSource = "ic_add_box_black_24dp.png"
                },
                new PollOption
                {
                    OptionString = "Suki",
                    ImageSource = "ic_add_box_black_24dp.png"
                },
                new PollOption
                {
                    OptionString = "Ruski",
                    ImageSource = "ic_add_box_black_24dp.png"
                },
                new PollOption
                {
                    OptionString = "Payuba",
                    ImageSource = "ic_add_box_black_24dp.png"
                }
            };
            return list;
        }
    }
}

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
                },
                new PollOption
                {
                    OptionString = "Suki",
                },
                new PollOption
                {
                    OptionString = "Ruski",
                },
                new PollOption
                {
                    OptionString = "Payuba",
                }
            };
            return list;
        }
    }
}

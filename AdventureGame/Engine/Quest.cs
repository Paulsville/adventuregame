using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Quest
    {
        public IQuest Details { get; set; }
        public bool Completed { get; set; }

        public Quest(IQuest details, bool completed)
        {
            Details = details;
            Completed = completed;
        }
    }
}

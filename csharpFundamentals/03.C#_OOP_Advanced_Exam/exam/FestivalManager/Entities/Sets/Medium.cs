using System;

namespace FestivalManager.Entities.Sets
{
    public class Medium : Set
    {
        public Medium(string name)
            : base(name, new TimeSpan(0, 40, 0))
        {
        }
    }
}

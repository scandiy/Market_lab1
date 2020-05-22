using System;
using System.Collections.Generic;

namespace market
{
    public partial class Departments
    {
        public Departments()
        {
            Workers = new HashSet<Workers>();
        }

        public int Id { get; set; }
        public int MarketId { get; set; }

        public virtual Markets Market { get; set; }
        public virtual ICollection<Workers> Workers { get; set; }
    }
}

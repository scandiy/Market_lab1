using System;
using System.Collections.Generic;

namespace market
{
    public partial class OwnerMarket
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int MarketId { get; set; }

        public virtual Markets Market { get; set; }
        public virtual Owners Owner { get; set; }
    }
}

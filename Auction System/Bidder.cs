using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_System
{
    public class Bidder
    {
        public string bidderName { get; set; }
        public long startingBid { get; set; }
        public long maxBid { get; set; }
        public long currentBid { get; set; }
        public long autoIncrement { get; set; }

    }
}

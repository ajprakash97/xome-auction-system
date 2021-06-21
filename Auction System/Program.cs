using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_System
{
    class Program
    {
        public static long currMaximum = 0;
        static void Main(string[] args)
        {

            BiddingEvent newEvent = new BiddingEvent();
            newEvent.GetInputs();           
           
            newEvent.DisplayData();
            List<Bidder> biddersList = newEvent.GetBiddersDetails();

            Bidding newBid = new Bidding();
            currMaximum = newBid.startBidding(newEvent.maxBidders, biddersList, currMaximum,newEvent.eventStartTime,newEvent.eventEndTime);

            Console.WriteLine("Winning Bid: ${0}", currMaximum);
            Console.ReadLine();

        }
    }

    class BiddingEvent
    {
        public string eventName;
        public string itemName;
        public int basePrice;
        public int autoIncrementLimit;
        public int maxBidders;
        public DateTime eventStartTime;
        public DateTime eventEndTime;
        public CultureInfo provider = CultureInfo.InvariantCulture;
        public void GetInputs()
        {
            Console.Write("Please enter the Event Name: ");
            eventName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Please enter the Item Name: ");
            itemName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Please enter the Base Price: $");
            basePrice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Please enter the Auto Increament Limit: $");
            autoIncrementLimit = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Please enter the Max number of Bidders: ");
            maxBidders = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Enter the Event Start Time (hh:mm tt): ");
            eventStartTime = DateTime.ParseExact(Console.ReadLine(), "h:mm tt", provider);
            Console.WriteLine();
            Console.Write("Enter the Event End Time (hh:mm tt): ");
            eventEndTime = DateTime.ParseExact(Console.ReadLine(), "h:mm tt", provider);
        }

        public void DisplayData()
        {
            Console.WriteLine("-------------------------{0}-------------------------", this.eventName);
            Console.WriteLine("Event: {0}", this.eventName);
            Console.WriteLine("Seller: Item {0} | Base Price: {1}$", this.itemName, this.basePrice);
            Console.WriteLine("Auto Increament Limit: max of {0}", this.autoIncrementLimit);
            Console.WriteLine("Max Bidders: {0}", this.maxBidders);
            Console.WriteLine("Event Start Time: {0}, End Time: {1}", this.eventStartTime.ToString("h:mm tt"), this.eventEndTime.ToString("h:mm tt"));

            Console.WriteLine();

        }

        public List<Bidder> GetBiddersDetails()
        {
            List<Bidder> biddersList = new List<Bidder>();
            long currMaximum = 0;
            bool inputVal = true;
            for (int i = 0; i < this.maxBidders; i++)
            {
                Bidder newBidder = new Bidder();
                Console.WriteLine("----------Buyer {0}----------", i + 1);
                int buyer = i + 1;
                newBidder.bidderName = "Buyer " + buyer;
                Console.Write("Starting Bid: $");
                newBidder.startingBid = int.Parse(Console.ReadLine());
                if(newBidder.startingBid<this.basePrice)
                {
                    inputVal = false;
                }
                while(!inputVal)
                {
                    Console.WriteLine("Starting Bid should be higher than ${0}", this.basePrice);
                    newBidder.startingBid = int.Parse(Console.ReadLine());
                    if (newBidder.startingBid >= this.basePrice)
                    {
                        inputVal = true;
                    }
                }
                newBidder.currentBid = newBidder.startingBid;
                Console.Write("Max Bid: $");
                newBidder.maxBid = int.Parse(Console.ReadLine());
                Console.Write("Auto Increment Amount: $");
                newBidder.autoIncrement = int.Parse(Console.ReadLine());
                if (newBidder.autoIncrement > this.autoIncrementLimit)
                {
                    inputVal = false;
                }
                while (!inputVal)
                {
                    Console.WriteLine("Auto Increment Limit exceeded");
                    Console.WriteLine("Max limit is ${0}", this.autoIncrementLimit);
                    newBidder.autoIncrement = int.Parse(Console.ReadLine());
                    if (newBidder.autoIncrement <= this.autoIncrementLimit)
                    {
                        inputVal = true;
                    }
                }
                if (newBidder.startingBid > currMaximum)
                {
                    currMaximum = newBidder.startingBid;
                }

                biddersList.Add(newBidder);
            }
            return biddersList;
        }
    }

    class Bidding
    {
        public long startBidding(int maxBidders, List<Bidder> biddersList,long currMaximum, DateTime startTime, DateTime endTime)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            TimeSpan span = endTime.Subtract(startTime);
            Console.WriteLine("-------------------------Auction Started-------------------------");
            Console.WriteLine("-------------------------{0}-------------------------", startTime);
            while (maxBidders > 1 && sw.Elapsed < TimeSpan.FromMinutes(span.TotalMinutes))
            {
                for (int i = 0; i < biddersList.Count; i++)
                {
                    if (biddersList[i].maxBid >= biddersList[i].currentBid + biddersList[i].autoIncrement)
                    {
                        if (biddersList[i].currentBid <currMaximum)
                        {
                            biddersList[i].currentBid = biddersList[i].currentBid + biddersList[i].autoIncrement;
                        }
                        else
                        {
                            if(biddersList.Where(x=>x.currentBid == currMaximum).ToList().Count>1)
                            {
                                biddersList[i].currentBid = biddersList[i].currentBid + biddersList[i].autoIncrement;
                            }
                        }

                        if (biddersList[i].currentBid > currMaximum)
                        {
                            currMaximum = biddersList[i].currentBid;
                        }
                    }
                    else
                    {
                        biddersList.RemoveAt(i);
                        maxBidders--;
                    }

                }
            }
            Console.WriteLine("-------------------------{0}-------------------------",endTime);
            Console.WriteLine("-------------------------Auction Ended-------------------------");

            return currMaximum;

        }
    }
}

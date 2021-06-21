# xome-auction-system
Problem statement:
      Consider we are building a new auction application where a seller can offer an item up for sale and people can bid against each other to buy the item. We need to come up with the algorithm to automatically determine the winning bid after all bidders have entered their information on the site. The site will allow each bidder to enter three parameters: Starting bid - The first and lowest bid the buyer is willing to offer for the item. Max bid - This maximum amount the bidder is willing to pay for the item. Auto-increment amount - A dollar amount that the computer algorithm will add to the bidder's current bid each time the bidder is in a losing position relative to the other bidders. The algorithm should never let the current bid exceed the Max bid. The algorithm should only allow increments of the exact auto-increment amount.

Sample Input/Output:

Please enter the Event Name: California Event

Please enter the Item Name: Property 123

Please enter the Base Price: $50000

Please enter the Auto Increament Limit: $5000

Please enter the Max number of Bidders: 5

Enter the Event Start Time (hh:mm tt): 10:00 am

Enter the Event End Time (hh:mm tt): 10:01 am
-------------------------California Event-------------------------
Event: California Event
Seller: Item Property 123 | Base Price: 50000$
Auto Increament Limit: max of 5000
Max Bidders: 5
Event Start Time: 10:00 AM, End Time: 10:01 AM

----------Buyer 1----------
Starting Bid: $60000
Max Bid: $90000
Auto Increment Amount: $2000
----------Buyer 2----------
Starting Bid: $55000
Max Bid: $95000
Auto Increment Amount: $1000
----------Buyer 3----------
Starting Bid: $52000
Max Bid: $125000
Auto Increment Amount: $5000
----------Buyer 4----------
Starting Bid: $51000
Max Bid: $100000
Auto Increment Amount: $2000
----------Buyer 5----------
Starting Bid: $52000
Max Bid: $110000
Auto Increment Amount: $4000
-------------------------Auction Started-------------------------
-------------------------21-06-2021 10:00:00-------------------------
-------------------------21-06-2021 10:01:00-------------------------
-------------------------Auction Ended-------------------------
Winning Bid: $112000

class Reservation 
{
    constructor(confirmationNum, client, room, dateCreated, checkIn, checkOut, receipt, AddOn)
    {
        this.confirmationNum = confirmationNum;
        this.client = client;
        this.room = new Room();
        this.dateCreated = dateCreated;
        this.checkIn = checkIn;
        this.checkOut = checkOut;
        this.receipt = new Receipt();
        this.addOns = new Set([AddOn]);
    }  
}

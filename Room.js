class Room
{
    constructor(roomNum,reservation,isClean,isVacant) 
    {
        this.roomNum = roonNum;
        this.reservation = reservation;
        this.isClean = isClean;
        this.isVacant = isVacant;
    }

    isAvailable()
    {
        return isVacant && isClean;
    }

//     cleanRoom()
//     {
//         this.isClean = false;
//         // Set the service.
//     }
}

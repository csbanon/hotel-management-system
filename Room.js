class Room  {
    constructor(roomNum,reservation,isClean,isVacant) 
    {
        this.roomNum = roonNum;
        this.reservation = reservation;
        this.isClean = isClean;
        this.isVacant = isVacant;
    }

    _isAvailable()
    {
        return isVacant;
    }

    cleanRoom() // ask about possible implementation
    {
        this.isClean = false;

    }

    _description()
    {   
        console.log(this.roomNum);
        console.log("\n");
        console.log(this.reservation);
        console.log("\n");
        if(this.isClean == true)
        {
            console.log("Room is clean\n");
        }
        else
        {
            console.log("Room is dirty\n");
        }
        if(this.isVacant == true)
        {
            console.log()
        }
        else
        {
            console.log("Room is occupied\n");
        }
    }


}
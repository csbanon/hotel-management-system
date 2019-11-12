class Client
{
   constructor(firstName, lastName, userName, password, email, phone, reservation, card, isCheckedIn)
   {
       this.firstName = firstName;
       this.lastName = lastName;
       this.userName = userName;
       this.password = password;
       this.email = email;
       this.phone = phone;
       this.reservation = new Reservation ();
       this.card = new Card();
       this.isCheckedIn = isCheckedIn;
   }

   checkIn(room) // returns boolean
   {
       this.room = room;
       if(this.isCheckedIn == true)
       {
           this.room.isAvailable = false;
           return true;
       }
       else
       {
           return false;
       }
   }

   checkOut()    // returns boolean
   {
    //    this.reservation.receipt.printReceipt();
    //    this.reservation.room.isClean = false;
    //    this.reservation.room.cleanRoom();
    //    return true;
   }

   description() // void
   {
        //TODO
   }

   toString() //returns String
   {
        //TODO
   }

}
//for testing
// var  a = new Client(null,null,false,"Jane","Doe","jd333","pwd","jd@mail.com",407123456);
// console.log(a);

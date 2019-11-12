class Receipt {
    constructor(client, room, nights) {
        this.clent = client;
        this.room = room;
        this.nights = nights;
        this.addOns = [];
        this.addOnsP = [];
    }

    printRecipt() {
        console.log("Name: " + this.client.name);
        console.log("Room: " + this.room.number);
        console.log("");
        console.log("PRICES");
        console.log("-------------------------------------");
        console.log("Stay: Room" + room.price + " * " + this.nights + "Nights");
        if (this.addOns)
            for (let i = 0; i < this.addOns.length; i++) {
                console.log(this.addOns[i] + ": " + this.addOnsP[i]);
    }

    addAddOns(addon) {
        this.addOns.push(addon.name);
        this.addOnsP.push(addon.price);
    }
}
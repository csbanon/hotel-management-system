const fs = require('fs');

class Room {
  constructor(roomNum, reservation, isClean, isVacant) {
    this.roomNum = roonNum;
    this.reservation = reservation;
    this.isClean = isClean;
    this.isVacant = isVacant;
  }

  isAvailable() {
    return isVacant && isClean;
  }

  //     cleanRoom()
  //     {
  //         this.isClean = false;
  //         // Set the service.
  //     }

  read() {
    let rawdata = fs.readFileSync(this.path + this.roomNum + '.json');
    let temp = JSON.parse(rawdata);
    this.roomNum = temp.roonNum;
    this.reservation = temp.reservation;
    this.isClean = temp.isClean;
    this.isVacant = temp.isVacant;
  }

  store() {
    let data = JSON.stringify(this);
    fs.writeFileSync(this.path + this.roomNum + ".json", data);
  }
}

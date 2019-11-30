const fs = require('fs');

class User
{
  constructor(firstName, lastName, userName, password, email, phone)
  {
    this.name = { this.firstName = firstName, this.lastName = lastName };
    this.userName = userName;
    this.password = password;
    this.email = email;
    this.phone = phone;
  }
  
  deleteUser()
  {
    // Delete jSON file. Look up how to delete a jSON file from here.
  }

  //   validateUserData() {}  
  //   encryptUserData() {}
  
  // Look up as part of the UI.
  //   login() {}
  //   logout() {}

  read() {
    let rawdata = fs.readFileSync(this.path + this.name + '.json');
    let temp = JSON.parse(rawdata);
    this.id = temp.id;
    this.status = temp.status;
    this.name = temp.name;
    this.info = temp.info;
  }

  store() {
    let data = JSON.stringify(this);
    fs.writeFileSync(this.path + this.name.last + ", " + this.name.first + ".json", data);
  }
}
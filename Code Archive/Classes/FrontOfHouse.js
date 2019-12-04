class FrontOfHouse {
    constructor(firstName,lastName,userName,passWord,email,phone) 
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.userName = userName;
        this.passWord = passWord;
        this.email = email;
        this.phone = phone;
    }

    _description()
    {
        console.log(this.firstName);
        console.log(this.lastName);
        console.log(this.userName);
        console.log(this.passWord);
        console.log(this.email);
        console.log(this.phone);
    }
}

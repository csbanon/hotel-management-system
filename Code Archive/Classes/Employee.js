class Employee extends User
{
    constructor(firstName, lastName, userName, password, email, phone, empID)
    {
       super(firstName, lastName, userName, password, email, phone);
       this.empID = empID;
    }
}

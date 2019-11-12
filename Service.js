class Service 
{
    constructor (serviceID, type, room, date, employee, isComplete, comments)
    {
        this.serviceID = serviceID;
        this.type = type;
        this.room = room;
        this.date = date;
        this.employee = employee;
        this.isComplete = isComplete;
        this.comments = comments;
    }

    // tests: cancelling a service that doesn't exist
    //          cancelling a service that does exist
    //          cancelling services at different positions in the service queue
    // marks service complete and removes it from the employee's queue
    cancelService ()
    {
        this.comments = this.comments.concat("Cancelled. ");

        // insert some code about removing from the service queue in BackOfHouse

        this.isComplete = true;
        return this;
    }

    // tests: assign some tasks and check distribution of assignments
    // question: should the constructor call this?
    // assigns a random employee to this service
    assignRandomEmployee()
    {
        // we don't currently have an employee list, so yeah
        // get an employee, assign them to this.employee
        this.employee.assignService(this);
        return this.employee;
    }

    // tests: assigning an employee that doesn't exist
    //assigns a specific employee to this service
    assignEmployee (employee)
    {
        // there needs to be a check to see if the employee exists before assignment
        this.employee = employee;
        this.employee.assignService(this);
        return true;
    }

    static description ()
    {
        // This class tracks details concerning a service order, such as:
        // The service ID, service type, date generated, room requesting,
        // employee assigned for fulfillment, status, and comments.
        // This class supports cancellation and changes to assigned employee.
    }

    // returns in the format
    // ID: ***, Type: ***, Date: ***, Room: ***, Employee: ***, Status: ***
    // Comments: ***
    toString ()
    {
        var s = "ID: ";
        s = s.concat(this.serviceID.toString());
        s = s.concat(", Type: ");
        s = s.concat(this.type);
        s = s.concat(", Date: ");
        s = s.concat(this.date.toString());
        s = s.concat(", Room: ");
        s = s.concat(this.room.roomNum.toString());
        s = s.concat(", Employee: ");
        s = s.concat(this.employee.toString());
        s = s.concat(", Status: ");
        s = s.concat(this.isComplete.toString());
        s = s.concat("\nComments: ");
        return s.concat(this.comments);
    }
}
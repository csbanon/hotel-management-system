let activeOrders = [];
let completedOrders = [];

function newOrder(order)
{
    
}

class Service 
{
    constructor(serviceID, type, room, date, comments)
    {
        this.serviceID = serviceID;
        this.type = type;
        this.room = room;
        this.date = date;
        this.assignRandomEmployee();
        this.isComplete = false;
        this.comments = comments;
    }

    // tests: cancelling a service that doesn't exist
    //          cancelling a service that does exist
    //          cancelling services at different positions in the service queue
    // marks service complete and removes it from the employee's queue
    cancelService()
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
    assignEmployee(employee)
    {
        // there needs to be a check to see if the employee exists before assignment
        // since at creation of the service, an employee is automatically assigned, 
        //      the service needs to be removed from the original employee's queue
        this.employee = employee;
        this.employee.assignService(this);
        return true;
    }
}
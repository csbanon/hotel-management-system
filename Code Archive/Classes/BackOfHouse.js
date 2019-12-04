Queue < String > q = new < > LinkedList;

function giveWorkOrder() {
    if (q.size != 0)
        return q.pop();
}

// remember the extends user
// dropped it for testing purposes
class BackOfhouse {
    consotructor() {
        var occupied = false;
        var workorder;

    }

    attemptJob() {
        var nextInQ = giveWorkOrder();
        if (nextInQ) {
            work = nextInQ;
            occupied = true;
        } else
            occupied = false;
    }
}

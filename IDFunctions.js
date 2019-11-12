/*
    Questions I have about IDs:
        - What data structure are we using to store the IDs?
        - Are we associating the IDs with other data?
        - Is the ID list sorted?
*/

// testing:
//      retrieve ID you know is there
//      retrieve ID you know is not
//      manually generate ID you know is a duplicate

// assumes idList is sorted
// searches idList for new id
// adds id to list if not found
function generateID (idList)
{
    let newID = null;
    while (newID === null)
    {
        newID = Math.floor(Math.random() * 9999999999);
        if (retrieveIDsorted(idList, newID))
            newID = null;
    }
    return newID;
}

// assumes input is unsorted, doesn't sort
// assumes input is some list of numbers
// linear search
// returns true if found, false otherwise
function retrieveIDunsorted(input, toFind)
{
    for (let i = 0; i < input.length; i++)
    {
        if (input[i] === toFind) 
            return true;
    }

    return false;
}

// assumes input is sorted
// assumes input is some list of numbers
// binary search
// returns true if found, false otherwise
function retrieveIDsorted(input, toFind)
{
    let left = 0;
    let right = input.length - 1;
    while (left <= right)
    {
        const mid = left + Math.floor((right - left) / 2);
        if (input[mid] === toFind)
        {
            return true;
        }
        if (input[mid] < toFind)
        {
            left = mid + 1;
        }
        else
        {
            right = mid - 1;
        }
    }
    return false;
}

// assumes input is array like
// assumes input is unsorted, sorts the input
// binary search
// returns true if found, false otherwise
function retrieveIDsorts(input, toFind)
{
    input.sort();
    return input.retrieveIDsorted(input, toFind);
}
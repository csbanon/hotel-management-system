class AddOn
{
    constructor (name, description, price)
    {
        this.name = name;
        this.description = description;
        this.price = price;
    }

    static description ()
    {
        // This class keeps track of details for AddOns include name, description, and price.
    }

    // returns in the format:
    // [Name], $[price]: [description]
    toString()
    {
        var s = this.name;
        s = s.concat(", $");
        s = s.concat(this.price.toFixed(2));
        s = s.concat(": ");
        return s.concat(this.description);
    }
}
using System;

// This class stores customer information
public class Customer
{
    // Private variables
    private string _name;
    private Address _address;

    // Constructor - runs when we create a new Customer
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Check if the customer lives in the USA
    // We use the Address class's method to find out
    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    // Methods to get and set the name
    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    // Methods to get and set the address
    public Address GetAddress()
    {
        return _address;
    }

    public void SetAddress(Address address)
    {
        _address = address;
    }
}

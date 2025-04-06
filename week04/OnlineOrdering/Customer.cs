using System;

// This class stores customer information
public class Customer
{
    // Private variables
    private string _customerName;
    private Address _customerAddress;

    // Constructor - runs when we create a new Customer
    public Customer(string name, Address address)
    {
        _customerName = name;
        _customerAddress = address;
    }

    // Check if the customer lives in the USA
    // We use the Address class's method to find out
    public bool LivesInUSA()
    {
        return _customerAddress.IsInUSA();
    }

    // Methods to get and set the name
    public string GetName()
    {
        return _customerName;
    }

    public void SetName(string name)
    {
        _customerName = name;
    }

    // Methods to get and set the address
    public Address GetAddress()
    {
        return _customerAddress;
    }

    public void SetAddress(Address address)
    {
        _customerAddress = address;
    }
}

using System;

// This class stores address information
public class Address
{
    // Private variables - can only be accessed through methods
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    // Constructor - runs when we create a new Address
    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    // Check if the address is in the USA
    public bool IsInUSA()
    {
        // Convert country to uppercase and check if it matches any USA variations
        string upperCaseCountry = _country.ToUpper();
        if (upperCaseCountry == "USA" || 
            upperCaseCountry == "UNITED STATES" || 
            upperCaseCountry == "UNITED STATES OF AMERICA")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Get the full address formatted with line breaks
    public string GetFullAddress()
    {
        // Create a multi-line address string
        string fullAddress = _streetAddress + "\n";
        fullAddress = fullAddress + "         " + _city + ", " + _stateOrProvince + "\n";
        fullAddress = fullAddress + "         " + _country;
        
        return fullAddress;
    }

    // Methods to get and set the street address
    public string GetStreetAddress()
    {
        return _streetAddress;
    }

    public void SetStreetAddress(string streetAddress)
    {
        _streetAddress = streetAddress;
    }

    // Methods to get and set the city
    public string GetCity()
    {
        return _city;
    }

    public void SetCity(string city)
    {
        _city = city;
    }

    // Methods to get and set the state/province
    public string GetStateOrProvince()
    {
        return _stateOrProvince;
    }

    public void SetStateOrProvince(string stateOrProvince)
    {
        _stateOrProvince = stateOrProvince;
    }

    // Methods to get and set the country
    public string GetCountry()
    {
        return _country;
    }

    public void SetCountry(string country)
    {
        _country = country;
    }
}

using System;

// This class stores address information
public class Address
{
    // Private variables - can only be accessed through methods
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    // Constructor - runs when we create a new Address
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    // Check if the address is in the USA
    public bool IsInUSA()
    {
        // Convert country to uppercase and check if it matches any USA variations
        string uppercaseCountry = _country.ToUpper();
        if (uppercaseCountry == "USA" || 
            uppercaseCountry == "UNITED STATES" || 
            uppercaseCountry == "UNITED STATES OF AMERICA")
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
        fullAddress = fullAddress + _city + ", " + _stateProvince + "\n";
        fullAddress = fullAddress + _country;
        
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
    public string GetStateProvince()
    {
        return _stateProvince;
    }

    public void SetStateProvince(string stateProvince)
    {
        _stateProvince = stateProvince;
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

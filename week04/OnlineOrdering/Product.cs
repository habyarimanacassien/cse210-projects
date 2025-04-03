using System;

// This class stores product information
public class Product
{
    // Private variables
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    // Constructor - runs when we create a new Product
    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Calculate the total cost of this product (price × quantity)
    public double CalculateTotalCost()
    {
        double totalCost = _price * _quantity;
        return totalCost;
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

    // Methods to get and set the product ID
    public string GetProductId()
    {
        return _productId;
    }

    public void SetProductId(string productId)
    {
        _productId = productId;
    }

    // Methods to get and set the price
    public double GetPrice()
    {
        return _price;
    }

    public void SetPrice(double price)
    {
        _price = price;
    }

    // Methods to get and set the quantity
    public int GetQuantity()
    {
        return _quantity;
    }

    public void SetQuantity(int quantity)
    {
        _quantity = quantity;
    }
}

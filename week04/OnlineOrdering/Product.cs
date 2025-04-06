using System;

// This class stores product information
public class Product
{
    // Private variables
    private string _productName;
    private string _productId;
    private double _productPrice;
    private int _productQuantity;

    // Constructor - runs when we create a new Product
    public Product(string name, string productId, double price, int quantity)
    {
        _productName = name;
        _productId = productId;
        _productPrice = price;
        _productQuantity = quantity;
    }

    // Calculate the total cost of this product (price × quantity)
    public double ProductCost()
    {
        double totalCost = _productPrice * _productQuantity;
        return totalCost;
    }

    // Methods to get and set the name
    public string GetName()
    {
        return _productName;
    }

    public void SetName(string name)
    {
        _productName = name;
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
        return _productPrice;
    }

    public void SetPrice(double price)
    {
        _productPrice = price;
    }

    // Methods to get and set the quantity
    public int GetQuantity()
    {
        return _productQuantity;
    }

    public void SetQuantity(int quantity)
    {
        _productQuantity = quantity;
    }
}

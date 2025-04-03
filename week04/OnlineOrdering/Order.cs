using System;
using System.Collections.Generic;

// This class manages orders, including products and customer information
public class Order
{
    // Private variables
    private List<Product> _products;
    private Customer _customer;
    
    // Fixed shipping costs
    private double _usaShippingCost = 5.0;
    private double _internationalShippingCost = 35.0;

    // Constructor - runs when we create a new Order
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();  // Create an empty list of products
    }

    // Add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Calculate the total price of the order (including shipping)
    public double CalculateTotalPrice()
    {
        // Start with zero
        double totalProductCost = 0;
        
        // Add up the cost of each product
        foreach (Product product in _products)
        {
            // Add this product's cost to our running total
            totalProductCost = totalProductCost + product.CalculateTotalCost();
        }
        
        // Figure out shipping cost based on location
        double shippingCost;
        
        // If customer is in USA, use USA shipping cost, otherwise use international
        if (_customer.LivesInUSA())
        {
            shippingCost = _usaShippingCost;
        }
        else
        {
            shippingCost = _internationalShippingCost;
        }
        
        // Calculate final price by adding product costs and shipping
        double finalPrice = totalProductCost + shippingCost;
        return finalPrice;
    }

    // Create a packing label showing all products
    public string GetPackingLabel()
    {
        string packingLabel = "PACKING LABEL\n";
        
        // Add each product to the label
        foreach (Product product in _products)
        {
            packingLabel = packingLabel + "Product: " + product.GetName() + 
                           " (ID: " + product.GetProductId() + ")\n";
        }
        
        return packingLabel;
    }

    // Create a shipping label with customer's name and address
    public string GetShippingLabel()
    {
        string shippingLabel = "SHIPPING LABEL\n";
        shippingLabel = shippingLabel + "Customer: " + _customer.GetName() + "\n";
        shippingLabel = shippingLabel + "Address:\n" + _customer.GetAddress().GetFullAddress();
        
        return shippingLabel;
    }

    // Method to get the list of products
    public List<Product> GetProducts()
    {
        return _products;
    }

    // Methods to get and set the customer
    public Customer GetCustomer()
    {
        return _customer;
    }

    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }
}

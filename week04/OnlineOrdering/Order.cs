using System;
using System.Collections.Generic;

// This class manages orders, including products and customer information
public class Order
{
    // Private variables
    private List<Product> _productsList;
    private Customer _customer;
    
    // Fixed shipping costs
    private double _usaShippingCost = 5.0;
    private double _internationalShippingCost = 35.0;

    // Constructor - runs when we create a new Order
    public Order(Customer customer)
    {
        _customer = customer;
        _productsList = new List<Product>();  // Create an empty list of products
    }

    // Add a product to the order
    public void AddProduct(Product product)
    {
        _productsList.Add(product);
    }

    // Calculate the total price of the order (including shipping)
    public double DisplayOrderTotal()
    {
        // Start with zero
        double totalProductCost = 0;
        
        // Add up the cost of each product
        foreach (Product product in _productsList)
        {
            // Add this product's cost to our running total
            totalProductCost = totalProductCost + product.ProductCost();
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

    // Get shipping cost based on customer location
    public double GetShippingCost()
    {
        return _customer.LivesInUSA() ? _usaShippingCost : _internationalShippingCost;
    }


    // Create a packing label showing all products with quantity and unit price
    public string OrderSummary()
    {
        string summary = "PACKAGING LABEL & SUMMARY\n";
        summary += "-----------------\n";
        
        double subtotal = 0;
        
        // List each product with details
        foreach (Product product in _productsList)
        {
            double productTotal = product.ProductCost();
            subtotal += productTotal;
            
            summary += $"{product.GetName()} (ID: {product.GetProductId()})";
            summary += $"   Unit Price: ${product.GetPrice().ToString("F2")}";
            summary += $"   Quantity: {product.GetQuantity()}";
            summary += $"   Item Total: ${productTotal.ToString("F2")}\n";
        }
        
        // Add subtotal, shipping and final total
        double shippingCost = GetShippingCost();
        double finalTotal = subtotal + shippingCost;
        
        summary += $"Subtotal: ${subtotal.ToString("F2")}\n";
        summary += $"Shipping: ${shippingCost.ToString("F2")} ";
        summary += _customer.LivesInUSA() ? "(USA)" : "(International)";
        summary += "\n";
        summary += $"Total: ${finalTotal.ToString("F2")}";
        
        return summary;
    }

    // Create a shipping label with customer's name and address
    public string ShippingLabel()
    {
        string shippingLabel = "SHIPPING LABEL\n";
        shippingLabel = shippingLabel + "Customer: " + _customer.GetName() + "\n";
        shippingLabel = shippingLabel + "Address: " + _customer.GetAddress().GetFullAddress();
        
        return shippingLabel;
    }

    // Method to get the list of products
    public List<Product> GetProducts()
    {
        return _productsList;
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
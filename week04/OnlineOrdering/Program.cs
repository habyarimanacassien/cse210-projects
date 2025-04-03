using System;

// This is the main program that runs the online store
class Program
{
    static void Main(string[] args)
    {
        // Create two different addresses for our customers
        Address usaAddress = new Address("123 Main St", "Seattle", "WA", "USA");
        Address internationalAddress = new Address("456 Maple Ave", "Toronto", "Ontario", "Canada");
        
        // Create two customers with their addresses
        Customer customer1 = new Customer("John Smith", usaAddress);
        Customer customer2 = new Customer("Jane Doe", internationalAddress);
        
        // Create some products to sell
        Product product1 = new Product("Laptop", "TECH001", 899.99, 1);
        Product product2 = new Product("Wireless Mouse", "TECH002", 24.99, 2);
        Product product3 = new Product("Headphones", "TECH003", 149.99, 1);
        Product product4 = new Product("USB Drive", "TECH004", 14.99, 3);
        Product product5 = new Product("Keyboard", "TECH005", 59.99, 1);
        
        // Create Order 1 for customer 1 (USA)
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);  // Add laptop
        order1.AddProduct(product2);  // Add mouse
        order1.AddProduct(product3);  // Add headphones
        
        // Create Order 2 for customer 2 (International)
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);  // Add headphones
        order2.AddProduct(product4);  // Add USB drive
        order2.AddProduct(product5);  // Add keyboard
        
        // Display Order 1 details
        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.CalculateTotalPrice().ToString("F2"));
        Console.WriteLine();
        
        // Display Order 2 details
        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.CalculateTotalPrice().ToString("F2"));
    }
}

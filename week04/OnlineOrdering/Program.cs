using System;

class Program
{
    static void Main(string[] args)
    {
        Address usaAddress = new Address("123 Main St", "Anytown", "CA", "USA");
        Address canadaAddress = new Address("456 Elm St", "Othertown", "ON", "Canada");

        Customer customer1 = new Customer("John Doe", usaAddress);
        Customer customer2 = new Customer("Jane Smith", canadaAddress);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P001", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25.99, 2));
        order1.AddProduct(new Product("HDMI Cable", "P003", 19.99, 1));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Laptop", "P001", 850.00, 1));
        order2.AddProduct(new Product("Mouse", "P002", 20.00, 1));
        order2.AddProduct(new Product("Monitor", "P003", 249.99, 2));
        order2.AddProduct(new Product("Keyboard", "P004", 49.99, 1));

        List<Order> orders = new List<Order>();
        orders.Add(order1);
        orders.Add(order2);

        int orderNumber = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"Order {orderNumber}:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}\n");
            Console.WriteLine("--------------------------------------------------\n");
            orderNumber++;
        }
    }
}
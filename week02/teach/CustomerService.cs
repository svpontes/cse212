/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario:  The user shall specify the maximum size of the Customer Service Queue when it is created. 
        // If the size is invalid (less than or equal to 0) then the size shall default to 10.
        // Expected Result: _maxiSize would be 10 
        Console.WriteLine("=================");
        Console.WriteLine("Test 1");
        //1 create an objetct CustomerService with parameter 0
        var testMaxService = new CustomerService(0);
        //insert a consoleWrite to see the results
        Console.WriteLine(testMaxService);
        // Defect(s) Found: None! the expected result is 10 default

        Console.WriteLine("=================");
        Console.WriteLine("Test 2");
        // Test 2 
        // Scenario:The AddNewCustomer method shall enqueue a new customer into the queue.
        // Expected Result: queue size should increase by 1 after adding a new customer size=1
        var testAddNewCustomer = new CustomerService(4); //stack size 4
        testAddNewCustomer.AddNewCustomer();
        Console.WriteLine("Adding customer.....");
        //prompt will asking for data about the clients        
        Console.WriteLine("Current_queue: " + testAddNewCustomer);


        Console.WriteLine("Test 3");
        // Test3
        // Scenario: If the queue is full when trying to add a customer, then an error message will be displayed.
        // Expected Result:The second AddNewCustomer() should display the message:
        var testAddNewCustomerQueueFull = new CustomerService(1); //stack size 1
        testAddNewCustomerQueueFull.AddNewCustomer();//add first customer. This will be ok because the size of the stack is 1
        testAddNewCustomerQueueFull.AddNewCustomer();//add second customer - should failed and display the messsage: "Maximum Number of Customers in Queue."

        Console.WriteLine("=================");
        Console.WriteLine("Test 4");
        //test 4
        // Scenario:The ServeCustomer function shall dequeue the next customer from the queue and display the details.
        // Expected Result: The first customer added should be displayed and removed from the queue.
        // Defect(s) Found: Previously served the wrong customer and crashed when queue was empty.
        // Fixed by fetching the customer before RemoveAt(0) and adding queue-empty check.

        var testServeCustomerDequeue = new CustomerService(3);

        Console.WriteLine("Queue before serving the customers:");
        Console.WriteLine(testServeCustomerDequeue);

        Console.WriteLine("Add customer 1");
        testServeCustomerDequeue.AddNewCustomer();

        Console.WriteLine("Add customer 2");
        testServeCustomerDequeue.AddNewCustomer();

        Console.WriteLine("Add customer 3");
        testServeCustomerDequeue.AddNewCustomer();

        Console.WriteLine("Serving the first customer ");
        testServeCustomerDequeue.ServeCustomer();
        Console.WriteLine("Queue after Serving the first customer ");


        Console.WriteLine("=================");
        Console.WriteLine("Test 5");
        //test 5
        // Scenario: If the queue is empty when trying to serve a customer, then an error message will be displayed.
        // Expected Result:Program should print in the console "No customers in queue." instead of an error .
        // Defect(s) Found: No check if the queue was empty resulting in an error. If block introduced to check _queue == 0 (empty)
        var testQueueEmptyServeCustomer = new CustomerService(4);
        Console.WriteLine("Serving the customer from an empty queue: ");
        testQueueEmptyServeCustomer.ServeCustomer();
        Console.WriteLine("Queue after Serving the first customer ");

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {

            Console.WriteLine("No Customers in the queue");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
        return;
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
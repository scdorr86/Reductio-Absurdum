DisplayMenu();

void DisplayMenu()
{
    string choice = null;
    while (choice != "5")
    {
        Console.WriteLine(@"Please choose an option:
                                1. Display All Products
                                2. Delete a Product
                                3. Add a new Product
                                4. Update Product Properties
                                5. Exit");
        choice = Console.ReadLine();
        if (choice == "5")
        {
            Console.WriteLine("Thank you, come again!");
        }
        else if (choice == "1")
        {
            DisplayAllProducts(products, productTypes);
        }
        else if (choice == "2")
        {
            DeleteProduct(products, productTypes);
        }
        else if (choice == "3")
        {
            AddProduct(products, productTypes);
        }
        else if (choice == "4")
        {
            UpdateProduct(products, productTypes);
        }
    };

}
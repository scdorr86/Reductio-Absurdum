using System.Diagnostics;
using System.Xml.Linq;

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Name = "apparel",
        Id = 1,
    },
    new ProductType()
    {
        Name = "potions",
        Id = 2,
    },
    new ProductType()
    {
        Name = "enchanted objects",
        Id = 3,
    },
    new ProductType()
    {
        Name = "wands",
        Id = 4,
    }
};

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "apparel1",
        Price = 10.00M,
        Available = true,
        ProductTypeId = 1,
        DateStocked = new DateTime(2022, 5, 20)
    },
    new Product()
    {
        Name = "apparel2",
        Price = 20.00M,
        Available = true,
        ProductTypeId = 1,
        DateStocked = new DateTime(2023, 5, 01)
    },
    new Product()
    {
        Name = "potion1",
        Price = 10.00M,
        Available = true,
        ProductTypeId = 2,
        DateStocked = new DateTime(2023, 4, 01)
    },
    new Product()
    {
        Name = "potion2",
        Price = 20.00M,
        Available = true,
        ProductTypeId = 2,
        DateStocked = new DateTime(2022, 1, 31)
    },
    new Product()
    {
        Name = "echanted object 1",
        Price = 10.00M,
        Available = true,
        ProductTypeId = 3,
        DateStocked = new DateTime(2023, 7, 01)
    },
    new Product()
    {
        Name = "wand1",
        Price = 10.00M,
        Available = true,
        ProductTypeId = 4,
        DateStocked = new DateTime(2023, 6, 15)
    },
     new Product()
    {
        Name = "wand2",
        Price = 20.00M,
        Available = true,
        ProductTypeId = 4,
        DateStocked = new DateTime(2023, 7, 21)
    },
};



DisplayMenu();

void DisplayMenu()
{
    string? choice = null;
    while (choice != "7")
    {
        Console.WriteLine(@"Please choose an option:
                                1. Display All Products
                                2. Delete a Product
                                3. Add a new Product
                                4. Update Product Properties
                                5. Browse by Product Type
                                6. Products less than 30 days old
                                7. Exit");
        choice = Console.ReadLine();
        if (choice == "7")
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
        else if (choice == "5")
        {
            BrowseByType(products, productTypes);
        }
        else if (choice == "6")
        {
            ProductsUnder30(products, productTypes);
        }
    };

}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Current Products: ");
    for (int i = 0; i < products.Count; i++)
    {
        var findProdType = productTypes.First(x => x.Id == products[i].ProductTypeId);
        Console.WriteLine($"{i+1}. {products[i].Name}, which is a {findProdType.Name}, and is priced at ${products[i].Price}. Current Days on Shelf: {products[i].DaysOnShelf}");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Please choose a Product to Delete: ");
    foreach (Product product in products)
    {
        var index = products.IndexOf(product);
        Console.WriteLine($"{index}. {product.Name}");
    }

    int deleteSelection = Convert.ToInt32( Console.ReadLine() );
    products.RemoveAt(deleteSelection);
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Product product = new Product();

    Console.WriteLine("Please enter Product Name: ");
    string? prodNameInput = Console.ReadLine();
    product.Name = prodNameInput;

    Console.WriteLine("Please enter Product Price: ");
    decimal prodPriceInput = Convert.ToDecimal(Console.ReadLine());
    product.Price = prodPriceInput;

    product.Available = true;

    Console.WriteLine("Please choose a Product Type: ");
    foreach(ProductType productType in productTypes)
    {
        Console.WriteLine($"{productTypes.IndexOf(productType) + 1}. {productType.Name}");
    }
    int typeChoice = Convert.ToInt32(Console.ReadLine());
    var findProdType = productTypes.First(x => x.Id == typeChoice);
    product.ProductTypeId = findProdType.Id;

    products.Add(product);
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Please choose a Product to Update: ");
    for (int i = 0; i < products.Count; i++)
    {
        var findProdType = productTypes.First(x => x.Id == products[i].ProductTypeId);
        Console.WriteLine($"{i + 1}. Product: {products[i].Name} Type: {findProdType.Name} Price:{products[i].Price}");
    }

    int updateSelection = Convert.ToInt32(Console.ReadLine()) - 1;
    var productToUpdate = products.ElementAt(updateSelection);

    Console.WriteLine($"You chose to update: {productToUpdate.Name}");

    Console.WriteLine("Please enter updated product name: ");
    var updatedName = Console.ReadLine();
    if (updatedName == "")
    {
        productToUpdate.Name = productToUpdate.Name;
    }
    else
    {
        productToUpdate.Name = updatedName;
    }

    Console.WriteLine("Please enter updated product price: ");
    try
    {
        decimal updatedPrice = Convert.ToDecimal(Console.ReadLine());
        productToUpdate.Price = updatedPrice;
    }
    catch
    {
        productToUpdate.Price = productToUpdate.Price;
    }

    Console.WriteLine("Please enter updated product type: ");
    foreach (ProductType productType in productTypes)
    {
        Console.WriteLine($"{productTypes.IndexOf(productType) + 1}. {productType.Name}");
    }

    try
    {
        int NewTypeChoice = Convert.ToInt32(Console.ReadLine());
        var ProdType = productTypes.First(x => x.Id == NewTypeChoice);
        productToUpdate.ProductTypeId = ProdType.Id;
    }
    catch
    {
        productToUpdate.ProductTypeId = productToUpdate.ProductTypeId;
    }
}

void BrowseByType(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Please Choose a Product Type to view: ");
    foreach (ProductType productType in productTypes)
    {
        Console.WriteLine($"{productTypes.IndexOf(productType)+1}. {productType.Name}");
    }

    int NewTypeChoice = Convert.ToInt32(Console.ReadLine());
    var ProdType = productTypes.First(x => x.Id == NewTypeChoice);

    foreach (Product product in products)
    {
        if (product.ProductTypeId == ProdType.Id)
        {
            Console.WriteLine($"Product: {product.Name}");
        }
    }
}

void ProductsUnder30(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("These are the Products currently 30 days old or less: ");

    List<Product> productsUnder30 = products.Where(p => p.DaysOnShelf <= 30).ToList();

    foreach (Product product in productsUnder30)
    {
        Console.WriteLine($"Product: {product.Name}");
    }
}
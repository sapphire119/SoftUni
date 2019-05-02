namespace ProductShop.App
{
    using ProductShop.Data;
    using ProductShop.Models;

    using Newtonsoft.Json;
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using ProductShop.App.Dtos.Exported;
    using AutoMapper;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new ProductShopDbContext())
            {
                Mapper.Initialize(cfg => cfg.AddProfile(new ProductProfile()));

                //ResetDatabase(context);

                //ImportDataJson(context);

                //ExportDataJson(context);

                //ResetDatabase(context);

                //ImportDataXml(context);

                ExportDataXml(context);
            }
        }

        private static void ExportDataXml(ProductShopDbContext context)
        {
            Console.WriteLine(GetProductsInRangeXml(context));

            Console.WriteLine(GetUsersSoldProductXml(context));

            Console.WriteLine(GetCategoriesByProductCountXml(context));

            Console.WriteLine(GetUsersAndProductsXml(context));
        }

        private static string GetUsersAndProductsXml(ProductShopDbContext context)
        {
            var users = context.Users
                    .OrderByDescending(u => u.SoldProducts.Count)
                    .ThenBy(u => u.LastName)
                    .Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        Age = u.Age.ToString(),
                        SoldProducts = new
                        {
                            Product = u.SoldProducts
                            .Where(sp => sp.BuyerId != null)
                            .Select(sp => new
                            {
                                sp.Name,
                                sp.Price
                            })
                            .ToArray()
                        }
                    })
                    .Where(u => u.SoldProducts.Product.Length > 1)
                    .ToArray();


            var usersGlobal = new
            {
                usersCount = users.Count(),
                users = users
            };

            var doc = new XDocument();
            doc.Add(new XElement("users", new XAttribute("count", usersGlobal.usersCount)));

            foreach (var usersWithProducts in usersGlobal.users)
            {
                var userXml = new XElement("user");

                var userFirstName = new XAttribute("first-name",
                        usersWithProducts.FirstName != null ? usersWithProducts.FirstName : string.Empty);

                var userLastName = new XAttribute("last-name", usersWithProducts.LastName);

                var userAge = new XAttribute("age",
                        usersWithProducts.Age != null ? usersWithProducts.Age : string.Empty);

                if (userFirstName.Value != string.Empty)
                {
                    userXml.Add(userFirstName);
                }

                userXml.Add(userLastName);

                if (userAge.Value != string.Empty)
                {
                    userXml.Add(userAge);
                }

                var soldProductsXml = new XElement("sold-product", 
                    new XAttribute("count", usersWithProducts.SoldProducts.Product.Length));

                foreach (var product in usersWithProducts.SoldProducts.Product)
                {
                    var productXml = new XElement("product",
                            new XAttribute("name", product.Name),
                            new XAttribute("price", product.Price));

                    soldProductsXml.Add(productXml);
                }
                userXml.Add(soldProductsXml);

                doc.Root.Add(userXml);
            }


            File.WriteAllText("Output/GetUsersAndProducts.xml", doc.ToString());

            return $"Successfully Created new path file Output/GetUsersAndProducts.xml";
        }

        private static string GetCategoriesByProductCountXml(ProductShopDbContext context)
        {
            var categories = context.Categories
                    .Select(c => new
                    {
                        c.Name,
                        ProductsCount = c.CategoryProducts.Count(),
                        AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                        TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                    })
                    .OrderByDescending(c => c.ProductsCount)
                    .ToArray();

            var doc = new XDocument();
            doc.Add(new XElement("categories"));

            foreach (var categ in categories)
            {
                doc.Root
                    .Add(new XElement("category",
                            new XAttribute("name", categ.Name),
                            new XElement("products-count", categ.ProductsCount),
                            new XElement("average-price", categ.AveragePrice),
                            new XElement("total-revenue", Math.Round(categ.TotalRevenue),6)));
            }

            File.WriteAllText("Output/GetCategoriesByProductCount.xml", doc.ToString());
            return $"Successfully Created new path file Output/GetCategoriesByProductCount.xml";
        }

        private static string GetUsersSoldProductXml(ProductShopDbContext context)
        {
            var users = context.Users
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        SoldProducts = u.SoldProducts
                        .Where(sp => sp.BuyerId != null)
                        .Select(sp => new
                        {
                            sp.Name,
                            sp.Price
                        })
                        .ToArray()
                    })
                    .Where(u => u.SoldProducts.Length > 1)
                    .ToArray();

            var doc = new XDocument();
            doc.Add(new XElement("users"));

            foreach (var user in users)
            {
                var userXml = new XElement("user");

                var userFirstName = new XAttribute("first-name", user.FirstName != null? user.FirstName : string.Empty);

                var userLastName = new XAttribute("last-name", user.LastName);

                if (userFirstName.Value != string.Empty)
                {
                    userXml.Add(userFirstName);
                }

                userXml.Add(userLastName);

                userXml.Add(new XElement("sold-products"));
                foreach (var product in user.SoldProducts)
                {
                    var productName = new XElement("name", product.Name);
                    var productPrice = new XElement("price", product.Price);

                    var productXml = new XElement("product", productName, productPrice);

                    userXml.Element("sold-products").Add(productXml);
                    //userXml.Add(
                    //    new XElement("sold-products",
                    //        new XElement("product",
                    //            productName,
                    //            productPrice))
                    //        );
                }
                doc.Root.Add(userXml);
            }

            File.WriteAllText("Output/GetSoldProducts.xml", doc.ToString());

            return $"Successfully Created new path file Output/GetSoldProducts.xml";
        }

        private static string GetProductsInRangeXml(ProductShopDbContext context)
        {
            var productsInRange = context.Products
                    .Where(p => 1000 <= p.Price && p.Price <= 2000 &&
                           p.BuyerId != null)
                    .OrderBy(p => p.Price)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                    })
                    .ToArray();

            var xDocument = new XDocument();
            xDocument.Add(new XElement("products"));

            foreach (var product in productsInRange)
            {
                xDocument.Root.Add(
                        new XElement("product",
                            new XAttribute("Name", product.Name),
                            new XAttribute("Price", product.Price),
                            new XAttribute("Buyer", product.Buyer)));
                //    xDocument.Root.Add(
                //            new XElement("product",
                //                new XElement("Name", product.Name),
                //                new XElement("Price", product.Price),
                //                new XElement("Buyer", product.Buyer)));
            }

            File.WriteAllText("Output/ProductsInRange.xml", xDocument.ToString());

            return $"Successfully Created new path file Output/GetProductsInRange.xml";
        }

        private static void ImportDataXml(ProductShopDbContext context)
        {
            var xmlStringUsers = File.ReadAllText("Resources/users.xml");
            var users = GetUsersXml(xmlStringUsers);
            Console.WriteLine(ImportUsersToContext(context, users));


            var xmlStringCategories = File.ReadAllText("Resources/categories.xml");
            var categories = GetCategoriesXml(xmlStringCategories);
            Console.WriteLine(ImportCategoriesToContext(context, categories));


            var xmlStringProducts = File.ReadAllText("Resources/products.xml");
            var productsWithUsers = GetProductsWithBuyersAndSellersXml(xmlStringProducts, users);
            var productsWithCategories = GetProductsWithCategories(productsWithUsers, categories);

            Console.WriteLine(ImportProductsToContext(context, productsWithCategories));
        }

        private static Product[] GetProductsWithCategories(Product[] productsWithUsers, Category[] categories)
        {
            var random = new Random();

            foreach (var product in productsWithUsers)
            {
                var alreadyListedCategories = new List<int>();

                for (int i = 0; i < 5; i++)
                {
                    var categoryId = random.Next(0, categories.Length);

                    if (alreadyListedCategories.Contains(categoryId))
                    {
                        continue;
                    }

                    var categoryProduct = new CategoryProduct
                    {
                        Product = product,
                        Category = categories[categoryId]
                    };

                    product.CategoryProducts.Add(categoryProduct);
                    alreadyListedCategories.Add(categoryId);
                }
            }

            return productsWithUsers;
        }

        private static Product[] GetProductsWithBuyersAndSellersXml(string xmlStringProducts, User[] users)
        {
            var xml = XDocument.Parse(xmlStringProducts);

            var elements = xml.Root.Elements();

            var random = new Random();

            var products = new List<Product>();

            foreach (var element in elements)
            {
                var name = element.Element("name").Value;
                var price = decimal.Parse(element.Element("price").Value);

                var sellerId = random.Next(0, users.Length);

                var product = new Product
                {
                    Name = name,
                    Price = price,
                    Seller = users[sellerId]
                };

                products.Add(product);
            }

            foreach (var product in products)
            {
                var buyerId = random.Next(0, users.Length);
                var sellerId = product.Seller.Id;

                decimal number1 = random.Next(10, 17);
                decimal number2 = random.Next(2, 6);


                if (number1 / number2 % 2 == 0 || sellerId == buyerId)
                {
                    continue;
                }

                product.Buyer = users[buyerId];
            }

            return products.ToArray();
        }

        private static Category[] GetCategoriesXml(string xmlStringCategories)
        {
            var categoriesXml = XDocument.Parse(xmlStringCategories);

            var elements = categoriesXml.Root.Elements();

            var categories = new List<Category>();

            foreach (var element in elements)
            {
                var categoryName = element.Element("name").Value;

                var category = new Category
                {
                    Name = categoryName
                };

                categories.Add(category);
            }

            return categories.ToArray();
        }

        private static User[] GetUsersXml(string xmlString)
        {
            var xml = XDocument.Parse(xmlString);

            var root = xml.Root.Elements();

            var users = new List<User>();

            foreach (var element in root)
            {
                var firstName = element.Attribute("firstName")?.Value;
                var lastName = element.Attribute("lastName").Value;

                int? age = null;

                var isAgeNotNull = element.Attribute("age") != null;

                if (isAgeNotNull)
                {
                    age = int.Parse(element.Attribute("age").Value);
                }

                var user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };

                users.Add(user);
            }

            return users.ToArray();
        }

        private static void ExportDataJson(ProductShopDbContext context)
        {
            Console.WriteLine(ProductsInRange(context));

            Console.WriteLine(SuccessfullySoldProducts(context));

            Console.WriteLine(CategoriesByProductCount(context));

            Console.WriteLine(UsersAndProducts(context));
        }

        private static string UsersAndProducts(ProductShopDbContext context)
        {
            var users = context.Users
                        .Include(u => u.SoldProducts)
                        .Where(u => u.SoldProducts.Count > 1)
                        .OrderByDescending(u => u.SoldProducts.Count)
                        .ThenBy(u => u.LastName)
                        .Select(u => new
                        {
                            u.FirstName,
                            u.LastName,
                            u.Age,
                            SoldProducts = new
                            {
                                Count = u.SoldProducts.Count,
                                Products = u.SoldProducts.Select(sp => new
                                {
                                    Name = sp.Name,
                                    Price = sp.Price
                                })
                                .ToArray()
                            }

                        })
                        .ToArray();

            var usersGlobal = new
            {
                UsersCount = users.Count(),
                Users = users
            };

            var serializedUsers = JsonConvert.SerializeObject(usersGlobal, Formatting.Indented);
            File.WriteAllText("Output/UsersAndProducts.json", serializedUsers);

            return "Created new in file Output/UsersAndProducts.json";
        }

        private static string CategoriesByProductCount(ProductShopDbContext context)
        {
            var categories = context.CategoryProducts
                    .GroupBy(cp => cp.Category.Name)
                    .Select(cp => new
                    {
                        category = cp.Key,
                        productsCount = cp.Count(),
                        averagePrice = Math.Round(cp.Average(p => p.Product.Price), 6),
                        totalRevenue = cp.Sum(p => p.Product.Price)
                    })
                    .ToArray();

            var serializedCategories = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText("Output/CategoriesByProductCount.json", serializedCategories);

            return "Created new in file Output/CategoriesByProductCount.json";
        }

        private static string SuccessfullySoldProducts(ProductShopDbContext context)
        {
            var users = context.Users
                    .Include(u => u.SoldProducts)
                        .ThenInclude(sp => sp.Buyer)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        SoldProducts = e.SoldProducts
                        .Where(sp => sp.BuyerId != null)
                        .Select(sp => new
                        {
                            sp.Name,
                            sp.Price,
                            BuyerFirstName = sp.Buyer.FirstName,
                            BuyerLastName = sp.Buyer.LastName
                        })
                        .ToArray()
                    })
                    .Where(u => u.SoldProducts.Length > 0)
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .ToArray();

            var serializedUsers = JsonConvert.SerializeObject(users, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

            File.WriteAllText("Output/SuccessfullySoldProducts.json", serializedUsers);

            return "Created new in file Output/SuccessfullySoldProducts.json";
        }

        private static string ProductsInRange(ProductShopDbContext context)
        {
            var products = context.Products
                    .Where(p => 500M <= p.Price && p.Price <= 1000M)
                    .ProjectTo<ProductDtoExported>()
                    .OrderBy(p => p.Price)
                    .ToArray();

            var serializedProducts = JsonConvert.SerializeObject(products, Formatting.Indented);

            File.WriteAllText("Output/ProductsInRange.json", serializedProducts);
            return "Created new file in Output/ProductsInRange.json";
        }

        private static void ImportDataJson(ProductShopDbContext context)
        {

            var users = ImportJson<User>("Resources/users.json");

            Console.WriteLine(ImportUsersToContext(context, users));

            var categories = ImportJson<Category>("Resources/categories.json");

            Console.WriteLine(ImportCategoriesToContext(context, categories));

            var products = ImportJson<Product>("Resources/products.json");

            Product[] productsWithSellersAndBuyers =
                RandomizeUsersProducts(users, products);

            Product[] productsWithCategories =
                RandomizeCateogriesProducts(categories, productsWithSellersAndBuyers);

            Console.WriteLine(ImportProductsToContext(context, productsWithCategories));
        }

        private static Product[] RandomizeCateogriesProducts(Category[] categories, Product[] newProducts)
        {
            var random = new Random();

            foreach (var product in newProducts)
            {
                var alreadyListedCategories = new List<int>();

                for (int i = 0; i < 5; i++)
                {
                    var randomCategory = random.Next(0, categories.Length);

                    if (alreadyListedCategories.Contains(randomCategory))
                    {
                        continue;
                    }

                    var categoryProduct = new CategoryProduct()
                    {
                        Product = product,
                        Category = categories[randomCategory]
                    };

                    product.CategoryProducts.Add(categoryProduct);
                    alreadyListedCategories.Add(randomCategory);
                }
            }

            return newProducts;
        }

        private static Product[] RandomizeUsersProducts(User[] users, Product[] products)
        {
            var random = new Random();

            foreach (var product in products)
            {
                var randomSeller = random.Next(0, users.Length);
                product.Seller = users[randomSeller];
            }

            foreach (var product in products)
            {
                decimal number1 = random.Next(100, products.Length + 1);
                decimal number2 = random.Next(1, product.Name.Length + 1);

                if (!(number1 * number2 % 3 == 0))
                {
                    var randomBuyer = random.Next(0, users.Length);
                    product.Buyer = users[randomBuyer];
                }
            }

            return products;
        }

        private static string ImportProductsToContext(ProductShopDbContext context, Product[] products)
        {
            context.Products.AddRange(products);

            context.SaveChanges();

            var sb = new StringBuilder();

            sb.AppendLine($"Successfully added {products.Length} Products to context!");
            sb.AppendLine($"Successfully added {products.Sum(p => p.CategoryProducts.Count)} CategoriesProducts to context!");

            return sb.ToString().TrimEnd();
        }

        private static string ImportCategoriesToContext(ProductShopDbContext context, Category[] categories)
        {
            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully added {categories.Length} Categories to context!";
        }

        private static string ImportUsersToContext(ProductShopDbContext context, User[] users)
        {
            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully added {users.Length} Users to context!";
        }

        private static void ResetDatabase(ProductShopDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            Console.WriteLine("Successfully created the database!");
        }

        private static T[] ImportJson<T>(string path)
        {
            var jsonString = File.ReadAllText(path);

            var objects = JsonConvert.DeserializeObject<T[]>(jsonString);

            return objects;
        }
    }
}

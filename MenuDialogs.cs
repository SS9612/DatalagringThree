using Buisness.Services;
using Buisness.Models;
using Buisness.Factories; 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Presentation.ConsoleApp
{
    public class MenuDialogs
    {
        private readonly ICustomerService _customerService;
        private readonly IProjectService _projectService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IStatusTypeService _statusTypeService;

        public MenuDialogs(ICustomerService customerService, IProjectService projectService, IProductService productService, IUserService userService, IStatusTypeService statusTypeService)
        {
            _customerService = customerService;
            _projectService = projectService;
            _productService = productService;
            _userService = userService;
            _statusTypeService = statusTypeService;
        }

        public async Task MenuOptions()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Create Customer");
                Console.WriteLine("2. Get All Customers");
                Console.WriteLine("3. Get Customer By Id");
                Console.WriteLine("4. Get Customer By Name");
                Console.WriteLine("5. Update Customer");
                Console.WriteLine("6. Delete Customer");
                Console.WriteLine("7. Create Project");
                Console.WriteLine("8. Get All Projects");
                Console.WriteLine("9. Get Project By Id");
                Console.WriteLine("10. Get Project Details");
                Console.WriteLine("11. Update Project");
                Console.WriteLine("12. Update Project Status");
                Console.WriteLine("13. Delete Project");
                Console.WriteLine("14. Create Product");
                Console.WriteLine("15. Get All Products");
                Console.WriteLine("16. Get Product By Id");
                Console.WriteLine("17. Update Product");
                Console.WriteLine("18. Delete Product");
                Console.WriteLine("19. Create User");
                Console.WriteLine("20. Get All Users");
                Console.WriteLine("21. Get User By Id");
                Console.WriteLine("22. Update User");
                Console.WriteLine("23. Delete User");
                Console.WriteLine("24. Create StatusType");
                Console.WriteLine("25. Get All StatusTypes");
                Console.WriteLine("26. Get StatusType By Id");
                Console.WriteLine("27. Update StatusType");
                Console.WriteLine("28. Delete StatusType");
                Console.WriteLine("29. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": await CreateCustomer(); break;
                    case "2": await GetAllCustomers(); break;
                    case "3": await GetCustomerById(); break;
                    case "4": await GetCustomerByName(); break;
                    case "5": await UpdateCustomer(); break;
                    case "6": await DeleteCustomer(); break;
                    case "7": await CreateProject(); break;
                    case "8": await GetAllProjects(); break;
                    case "9": await GetProjectById(); break;
                    case "10": await GetProjectDetails(); break;
                    case "11": await UpdateProject(); break;
                    case "12": await UpdateProjectStatus(); break;
                    case "13": await DeleteProject(); break;
                    case "14": await CreateProduct(); break;
                    case "15": await GetAllProducts(); break;
                    case "16": await GetProductById(); break;
                    case "17": await UpdateProduct(); break;
                    case "18": await DeleteProduct(); break;
                    case "19": await CreateUser(); break;
                    case "20": await GetAllUsers(); break;
                    case "21": await GetUserById(); break;
                    case "22": await UpdateUser(); break;
                    case "23": await DeleteUser(); break;
                    case "24": await CreateStatusType(); break;
                    case "25": await GetAllStatusTypes(); break;
                    case "26": await GetStatusTypeById(); break;
                    case "27": await UpdateStatusType(); break;
                    case "28": await DeleteStatusType(); break;
                    case "29": return;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private async Task CreateCustomer()
        {
            Console.Write("Enter Customer Name: ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                await _customerService.CreateCustomerAsync(new CustomerRegistrationForm { CustomerName = name });
                Console.WriteLine("Customer created successfully!");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.ReadLine();
        }

        private async Task GetAllCustomers()
        {
            var customers = await _customerService.GetCustomersAsync();
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.CustomerName}");
            }
            Console.ReadLine();
        }

        private async Task GetCustomerById()
        {
            Console.Write("Enter Customer ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                if (customer != null)
                {
                    Console.WriteLine($"ID: {customer.Id}, Name: {customer.CustomerName}");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.ReadLine();
        }

        private async Task GetCustomerByName()
        {
            Console.Write("Enter Customer Name: ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                var customer = await _customerService.GetCustomerByCustomerNameAsync(name);
                if (customer != null)
                {
                    Console.WriteLine($"ID: {customer.Id}, Name: {customer.CustomerName}");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.ReadLine();
        }

        private async Task UpdateCustomer()
        {
            Console.Write("Enter Customer ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter new Customer Name: ");
                var newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    var updated = await _customerService.UpdateCustomerAsync(new Customer { Id = id, CustomerName = newName });
                    Console.WriteLine(updated ? "Customer updated successfully!" : "Customer not found.");
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.ReadLine();
        }

        private async Task DeleteCustomer()
        {
            Console.Write("Enter Customer ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var deleted = await _customerService.DeleteCustomerAsync(id);
                Console.WriteLine(deleted ? "Customer deleted successfully!" : "Customer not found.");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.ReadLine();
        }

        private async Task CreateProject()
        {

            Console.Write("Enter Project Title: ");
            var title = Console.ReadLine() ?? "";

            Console.Write("Enter Project Description: ");
            var description = Console.ReadLine() ?? "";

            Console.Write("Enter User ID: ");
if (int.TryParse(Console.ReadLine(), out int userId))

            Console.Write("Enter Customer ID: ");
            if (int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.Write("Enter Product ID: ");
                if (int.TryParse(Console.ReadLine(), out int productId))
                {
                    Console.Write("Enter Status Type ID (e.g., 1 = Not Started, 2 = Ongoing, 3 = Completed): ");
                    if (int.TryParse(Console.ReadLine(), out int statusId))
                    {
                        Console.Write("Enter Start Date (yyyy-MM-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
                        {
                            Console.Write("Enter End Date (yyyy-MM-dd): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
                            {
                                await _projectService.CreateProjectAsync(new ProjectRegistrationForm
                                {
                                    Title = title,
                                    Description = description,
                                    StartDate = startDate,
                                    EndDate = endDate,
                                    CustomerId = customerId,
                                    ProductId = productId,
                                    StatusId = statusId,
                                    UserId = userId
                                });

                                Console.WriteLine("Project created successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid end date format.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid start date format.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid status type ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid customer ID.");
            }

            
            Console.ReadLine();
        }

        private async Task GetAllProjects()
        {
            var projects = await _projectService.GetProjectsAsync();
            foreach (var project in projects)
            {
                Console.WriteLine($"Number: {project.ProjectNumber}, ID: {project.Id}, Title: {project.Title}, Status: {project.StatusId}");
            }
            Console.ReadLine();
        }

        private async Task GetProjectById()
        {
            Console.Write("Enter Project ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var project = await _projectService.GetProjectByIdAsync(id);
                if (project != null)
                {
                    Console.WriteLine($"ID: {project.Id}, Title: {project.Title}, Start Date: {project.StartDate:yyyy-MM-dd}, End Date: {project.EndDate:yyyy-MM-dd}");
                }
                else
                {
                    Console.WriteLine("Project not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.ReadLine();
        }

        private async Task UpdateProject()
        {
            Console.Write("Enter Project ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter new Project Title: ");
                var newTitle = Console.ReadLine() ?? "";

                Console.Write("Enter new Project Description: ");
                var newDescription = Console.ReadLine() ?? "";

                Console.Write("Enter new Start Date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime newStartDate))
                {
                    Console.Write("Enter new End Date (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime newEndDate))
                    {
                        var updated = await _projectService.UpdateProjectAsync(new Project
                        {
                            Id = id,
                            Title = newTitle,
                            Description = newDescription,
                            StartDate = newStartDate,
                            EndDate = newEndDate
                        });

                        Console.WriteLine(updated ? "Project updated successfully!" : "Project not found.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid end date format.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid start date format.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.ReadLine();
        }
        private async Task UpdateProjectStatus()
        {
            Console.Write("Enter Project ID: ");
            if (int.TryParse(Console.ReadLine(), out int projectId))
            {
                Console.Write("Enter new Status Type ID (1 = Not Started, 2 = Ongoing, 3 = Completed): ");
                if (int.TryParse(Console.ReadLine(), out int statusTypeId))
                {
                    var updated = await _projectService.UpdateProjectStatusAsync(projectId, statusTypeId);
                    Console.WriteLine(updated ? "Project status updated successfully!" : "Project not found.");
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            Console.ReadLine();
        }
        private async Task DeleteProject()
        {
            Console.Write("Enter Project ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var deleted = await _projectService.DeleteProjectAsync(id);
                Console.WriteLine(deleted ? "Project deleted successfully!" : "Project not found.");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.ReadLine();
        }
        private async Task GetProjectDetails()
        {
            Console.Write("Enter Project ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var project = await _projectService.GetProjectByIdAsync(id);
                if (project != null)
                {
                    Console.WriteLine($"Project Number: {project.ProjectNumber}");
                    Console.WriteLine($"Title: {project.Title}");
                    Console.WriteLine($"Description: {project.Description}");
                    Console.WriteLine($"Start Date: {project.StartDate:yyyy-MM-dd}");
                    Console.WriteLine($"End Date: {project.EndDate:yyyy-MM-dd}");
                    Console.WriteLine($"Customer ID: {project.CustomerId}");
                    Console.WriteLine($"Status Type: {project.StatusId}");
                }
                else
                {
                    Console.WriteLine("Project not found.");
                }
            }
            Console.ReadLine();
        }

        private async Task CreateProduct()
        {
            Console.Write("Enter Product Name: ");
            var name = Console.ReadLine() ?? "";

            Console.Write("Enter Price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                await _productService.CreateProductAsync(new ProductRegistrationForm
                {
                    ProductName = name,
                    Price = price
                });
                Console.WriteLine("Product created successfully!");
            }
            else
            {
                Console.WriteLine("Invalid price format.");
            }
            Console.ReadLine();
        }

        private async Task GetAllProducts()
        {
            var products = await _productService.GetProductsAsync();
            if (products.Any())
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.Id}, Name: {product.ProductName}, Price: {product.Price:C}");
                }
            }
            else
            {
                Console.WriteLine("No products found.");
            }
            Console.ReadLine();
        }

        private async Task GetProductById()
        {
            Console.Write("Enter Product ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var product = await _productService.GetProductByIdAsync(id);
                Console.WriteLine(product != null
                    ? $"ID: {product.Id}, Name: {product.ProductName}, Price: {product.Price:C}"
                    : "Product not found.");
            }
            Console.ReadLine();
        }

        private async Task UpdateProduct()
        {
            Console.Write("Enter Product ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter new Product Name: ");
                var newName = Console.ReadLine() ?? "";

                Console.Write("Enter new Price: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                {
                    var updated = await _productService.UpdateProductAsync(new Product
                    {
                        Id = id,
                        ProductName = newName,
                        Price = newPrice
                    });

                    Console.WriteLine(updated ? "Product updated successfully!" : "Product not found.");
                }
                else
                {
                    Console.WriteLine("Invalid price format.");
                }
            }
            Console.ReadLine();
        }

        private async Task DeleteProduct()
        {
            Console.Write("Enter Product ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var deleted = await _productService.DeleteProductAsync(id);
                Console.WriteLine(deleted ? "Product deleted successfully!" : "Product not found.");
            }
            Console.ReadLine();
        }
        private async Task CreateUser()
        {
            Console.Write("Enter Firstname: ");
            var firstname = Console.ReadLine() ?? "";

            Console.Write("Enter Lastname: ");
            var lastname = Console.ReadLine() ?? "";

            Console.Write("Enter Email: ");
            var email = Console.ReadLine() ?? "";

            await _userService.CreateUserAsync(new UserRegistrationForm
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email
            });

            Console.WriteLine("User created successfully!");
            Console.ReadLine();
        }

        private async Task GetAllUsers()
        {
            var users = await _userService.GetUsersAsync();
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Firstname} {user.Lastname}, Email: {user.Email}");
            }
            Console.ReadLine();
        }

        private async Task GetUserById()
        {
            Console.Write("Enter User ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user is not null)
                {
                    Console.WriteLine($"ID: {user.Id}, Name: {user.Firstname} {user.Lastname}, Email: {user.Email}");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.ReadLine();
        }
        private async Task UpdateUser()
        {
            Console.Write("Enter User ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter new Firstname: ");
                var newFirstname = Console.ReadLine() ?? "";

                Console.Write("Enter new Lastname: ");
                var newLastname = Console.ReadLine() ?? "";

                Console.Write("Enter new Email: ");
                var newEmail = Console.ReadLine() ?? "";

                var updated = await _userService.UpdateUserAsync(new User
                {
                    Id = id,
                    Firstname = newFirstname,
                    Lastname = newLastname,
                    Email = newEmail
                });

                Console.WriteLine(updated ? "User updated successfully!" : "User not found.");
            }
            Console.ReadLine();
        }

        private async Task DeleteUser()
        {
            Console.Write("Enter User ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var deleted = await _userService.DeleteUserAsync(id);
                Console.WriteLine(deleted ? "User deleted successfully!" : "User not found.");
            }
            Console.ReadLine();
        }
        private async Task CreateStatusType()
        {
            Console.Write("Enter Status Name: ");
            var name = Console.ReadLine() ?? "";

            await _statusTypeService.CreateStatusTypeAsync(new StatusTypeRegistrationForm { Statusname = name });
            Console.WriteLine("StatusType created successfully!");
            Console.ReadLine();
        }


        private async Task GetAllStatusTypes()
        {
            var statusTypes = await _statusTypeService.GetAllStatusTypesAsync();
            foreach (var statusType in statusTypes)
            {
                Console.WriteLine($"ID: {statusType.Id}, Name: {statusType.Statusname}");
            }
            Console.ReadLine();
        }

        private async Task GetStatusTypeById()
        {
            Console.Write("Enter StatusType ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var statusType = await _statusTypeService.GetStatusTypeByIdAsync(id);
                Console.WriteLine(statusType != null
                    ? $"ID: {statusType.Id}, Name: {statusType.Statusname}"
                    : "StatusType not found.");
            }
            Console.ReadLine();
        }

        private async Task UpdateStatusType()
        {
            Console.Write("Enter StatusType ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter new Status Name: ");
                var newName = Console.ReadLine() ?? "";

                var updated = await _statusTypeService.UpdateStatusTypeAsync(new StatusType { Id = id, Statusname = newName });
                Console.WriteLine(updated ? "StatusType updated successfully!" : "StatusType not found.");
            }
            Console.ReadLine();
        }

        private async Task DeleteStatusType()
        {
            Console.Write("Enter StatusType ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var deleted = await _statusTypeService.DeleteStatusTypeAsync(id);
                Console.WriteLine(deleted ? "StatusType deleted successfully!" : "StatusType not found.");
            }
            Console.ReadLine();
        }

    }
}